using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace WindowsServiceInstaller
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {

        public WindowsServiceInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "EmailSynchronizer";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            


            serviceInstaller.ServiceName = "EmailSynchronizer";

            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
            //serviceInstaller.AfterInstall += ServiceInstaller_AfterInstall; // to start service after install
        }

        /* private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
         {
             ServiceController sc = new ServiceController("Windows Automatic Start Service");
             sc.Start();
         }
     */
    }
}
