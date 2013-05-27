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
    using System.Linq;
    using System.ServiceProcess;

    /// <summary>
    /// A helper class to determine whether MSMQ is currently active on the executing machine.  If it
    /// is not, it can be used to turn it on.
    /// </summary>
    public static class MsmqInstaller
    {
        private static bool _msmqInstalled;

        /// <summary>
        /// Gets a value indicating whether MSMQ is installed.
        /// </summary>
        public static bool MsmqIsInstalled
        {
            get
            {
                if (_msmqInstalled)
                {
                    return true;
                }

                _msmqInstalled = DetermineMsmqStatus();

                return _msmqInstalled;
            }
        }

        /// <summary>
        /// Turn on the MSMQ Windows Feature.
        /// </summary>
        public static void ActivateMsmq()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                InstallUsingDsim();
            }
            else
            {
                throw new InvalidOperationException(@"
MSMQ can currently only be installed on operating systems with a kernel version greater than or equal to 6.
I.e. Windows Vista / Windows Server 2008 or higher.  If you require this feature I will implement it.  
Please contact james@jdibble.co.uk.");
            }
        }

        private static bool DetermineMsmqStatus()
        {
            var msmqService = ServiceController.GetServices().ToList().Find(o => o.ServiceName == "MSMQ");
            if (msmqService != null)
            {
                return msmqService.Status == ServiceControllerStatus.Running;
            }

            return false;
        }

        private static void InstallUsingDsim()
        {
            var dsim = new Process();

            try
            {
                dsim.StartInfo = new ProcessStartInfo
                                     {
                                         FileName =
                                             Path.Combine(
                                                 Environment.GetFolderPath(
                                                     Environment.SpecialFolder.System),
                                                 "dsim.exe"),
                                         Arguments = "/online /enable-feature /featurename:MSMQ-Server",
                                         CreateNoWindow = true,
                                         ErrorDialog = false,
                                         UseShellExecute = false
                                     };

                dsim.Start();
                dsim.WaitForExit();
            }
            catch (Win32Exception win32Ex)
            {
                ThrowDsimException(win32Ex);
            }
            catch (InvalidOperationException iox)
            {
                ThrowDsimException(iox);
            }
            finally
            {
                dsim.Dispose();
            }
        }

        private static void ThrowDsimException(Exception innerException)
        {
            throw new InvalidOperationException("MSMQ could not be activated on the current machine.", innerException);
        }
    }
}