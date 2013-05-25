// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyChangedBehavior.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Practices.Unity.InterceptionExtension;
    using Microsoft.Practices.Unity.Utility;

    /// <summary>
    /// This interception behaviour should be added to an object realising <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class PropertyChangedBehavior : IInterceptionBehavior
    {
        private static readonly MethodInfo AddEventMethodInfo =
            typeof(INotifyPropertyChanged).GetEvent("PropertyChanged").GetAddMethod();

        private static readonly MethodInfo RemoveEventMethodInfo =
            typeof(INotifyPropertyChanged).GetEvent("PropertyChanged").GetRemoveMethod();

        /// <summary>
        /// Gets a value indicating whether this behaviour will actually do anything when invoked.
        /// </summary>
        /// <remarks>
        /// This is used to optimize interception. If the behaviours won't actually
        ///             do anything (for example, PIAB where no policies match) then the interception
        ///             mechanism can be skipped completely.
        /// </remarks>
        public bool WillExecute
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Implement this method to execute your behaviour processing.
        /// </summary>
        /// <param name="input">Inputs to the current call to the target.</param><param name="getNext">Delegate to execute to get the next delegate in the behaviour chain.</param>
        /// <returns>
        /// Return value from the target.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is."), 
        SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "I is.")]
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Guard.ArgumentNotNull(input, "input");
            Guard.ArgumentNotNull(getNext, "getNext");

            if (input.MethodBase == AddEventMethodInfo)
            {
                return AddEventSubscription(input);
            }

            if (input.MethodBase == RemoveEventMethodInfo)
            {
                return RemoveEventSubscription(input);
            }

            if (IsPropertySetter(input))
            {
                return InterceptPropertySet(input, getNext);
            }

            return getNext()(input, getNext);
        }

        /// <summary>
        /// Returns the interfaces required by the behaviour for the objects it intercepts.
        /// </summary>
        /// <returns>
        /// The required interfaces.
        /// </returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return new[] { typeof(INotifyPropertyChanged) };
        }

        private static bool IsPropertySetter(IMethodInvocation input)
        {
            return input.MethodBase.IsSpecialName && input.MethodBase.Name.StartsWith("set_", StringComparison.CurrentCulture);
        }

        private static IMethodReturn AddEventSubscription(IMethodInvocation input)
        {
            var subscriber = (PropertyChangedEventHandler)input.Arguments[0];
            (input.Target as INotifyPropertyChanged).PropertyChanged += subscriber;
            return input.CreateMethodReturn(null);
        }

        private static IMethodReturn RemoveEventSubscription(IMethodInvocation input)
        {
            var subscriber = (PropertyChangedEventHandler)input.Arguments[0];
            (input.Target as INotifyPropertyChanged).PropertyChanged -= subscriber;
            return input.CreateMethodReturn(null);
        }

        private static IMethodReturn InterceptPropertySet(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var propertyName = input.MethodBase.Name.Substring(4);

            var returnValue = getNext()(input, getNext);

            Type currentType = input.Target.GetType();
            FieldInfo info = null;

            while (currentType != null && info == null)
            {
                info = currentType.GetFields(
                         BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
                     .FirstOrDefault(
                         f => f.FieldType == typeof(PropertyChangedEventHandler));

                if (info == null)
                {
                    currentType = currentType.BaseType;
                }
            }

            if (info != null)
            {
                var handler = info.GetValue(input.Target) as PropertyChangedEventHandler;

                if (handler != null)
                {
                    handler.Invoke(input.Target.GetType(), new PropertyChangedEventArgs(propertyName));
                }
            }

            return returnValue;
        }
    }
}