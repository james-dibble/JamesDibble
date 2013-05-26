// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MsmqInstaller.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Queueing.Msmq
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// A helper class to determine whether MSMQ is currently active on the executing machine.  If it
    /// is not, it can be used to turn it on.
    /// </summary>
    public static class MsmqInstaller
    {
        /// <summary>
        /// Gets a value indicating whether MSMQ is installed.
        /// </summary>
        public static bool MsmqIsInstalled
        {
            get
            {
                // TODO: Add this functionality.
                return true;
            }
        }

        /// <summary>
        /// Turn on the MSMQ Windows Feature.
        /// </summary>
        public static void ActivateMsmq()
        {
            if (Environment.OSVersion.Version.MajorRevision >= 6)
            {
                InstallUsingDsim();
            }
            else
            {
                throw new ApplicationException(@"
MSMQ can currently only be installed on operating systems with a kernal version greater than or equal to 6.
I.e. Windows Vista / Windows Server 2008 or higher.  If you require this feature I will implement it.  
Please contact james@jdibble.co.uk.");
            }
        }

        private static void InstallUsingDsim()
        {
            try
            {
                var dsim = new Process
                               {
                                   StartInfo =
                                       {
                                           FileName =
                                               Path.Combine(
                                                   Environment.GetFolderPath(
                                                       Environment.SpecialFolder.System),
                                                   "dsim.exe"),
                                           Arguments =
                                               "/online /enable-feature /featurename:MSMQ-Server",
                                           CreateNoWindow = true,
                                           ErrorDialog = false,
                                           UseShellExecute = false
                                       }
                               };
                dsim.Start();
                dsim.WaitForExit();
            }
            catch (Win32Exception win32ex)
            {
                ThrowDsimException(win32ex);
            }
            catch (InvalidOperationException iox)
            {
                ThrowDsimException(iox);
            }
        }

        private static void ThrowDsimException(Exception innerException)
        {
            throw new ApplicationException("MSMQ could not be activated on the current machine.", innerException);
        }
    }
}