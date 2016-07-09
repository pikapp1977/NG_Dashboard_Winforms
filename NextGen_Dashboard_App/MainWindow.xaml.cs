using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;



namespace NextGen_Dashboard_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CHECK FIRST FOR v4 OR STANDALONE APP SERVER SERIVE
            using (RegistryKey legacyAppServer = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServer"))
                if (legacyAppServer != null)
                {
                    serviceStatusLegacy(agentHost, adapterHost, appServer, pwngsql, apacheServer, pearlHost, mtmBridge, "127.0.0.1", "PWAgentHost", "PWAdapterHost", "PWApplicationServer", "MSSQL$PWNGSQL", "Apache2.2", "PWPEARLAdapterHost", "Bridge2Mobile");
                }
                else
                    using (RegistryKey esuiteAppServer = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerEservices"))
                        if (esuiteAppServer != null)
                        {
                            serviceStatusESuite(agentHost, adapterHost, appServer, pwngsql, apacheServer, pearlHost, mtmBridge, "127.0.0.1", "PWAgentHost", "PWAdapterHost", "PWApplicationServerEservices", "MSSQL$PWNGSQL", "Apache2.2", "PWPEARLAdapterHost", "Bridge2Mobile");
                        }
                        else

                    //IF NO v4 OR STANDALONE APP SERVER CHECK FOR v7 SOFTDENT APP SERVER
                    using (RegistryKey v7AppServer = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerSoftDent"))
                        if (v7AppServer != null)
                        {
                            serviceStatusv7SD(agentHost, adapterHost, appServer, pwngsql, apacheServer, pearlHost, mtmBridge, "127.0.0.1", "PWAgentHostSoftDent", "PWAdapterHostSoftDent", "PWApplicationServerSoftDent", "MSSQL$PWNGSQL", "Apache2.2","PWPEARLAdapterHostSoftDent", "Bridge2Mobile");
                        }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //METHODS FOR SHOWING SERVICE STATUS AT PROGRAM LOAD
        public void serviceStatusLegacy(Ellipse agentLabel, Ellipse adapterLabel, Ellipse appserverLabel, Ellipse sqlLabel, Ellipse apacheLabel, Ellipse pearlLabel, Ellipse mtmLabel, string machineName,
            string agentService, string adapterService, string appserverService, string sqlService, string apacheService, string pearlService, string mtmService) //SHOW INITIAL SERVICE STATUS AT DASHBOARD INITIAL LOAD
        {
            try
            {
                ServiceController agent = new ServiceController();
                agent.ServiceName = agentService;
                ServiceController adapter = new ServiceController();
                adapter.ServiceName = adapterService;
                ServiceController appserver = new ServiceController();
                appserver.ServiceName = appserverService;
                ServiceController sql = new ServiceController();
                sql.ServiceName = sqlService;
                ServiceController apache = new ServiceController();
                apache.ServiceName = apacheService;
                ServiceController pearl = new ServiceController();
                pearl.ServiceName = pearlService;
                ServiceController mtm = new ServiceController();
                mtm.ServiceName = mtmService;

                if (agent.Status == ServiceControllerStatus.Running)
                {
                    agentLabel.Fill = Brushes.Green; 
                }
                else
                {
                    agentLabel.Fill = Brushes.Red;
                }
                if (adapter.Status == ServiceControllerStatus.Running)
                {
                    adapterLabel.Fill = Brushes.Green; 
                }
                else
                {
                    adapterLabel.Fill = Brushes.Red; 
                }
                if (appserver.Status == ServiceControllerStatus.Running)
                {
                    appserverLabel.Fill = Brushes.Green; 
                }
                else
                {
                    appserverLabel.Fill= Brushes.Red; 
                }
                if (sql.Status == ServiceControllerStatus.Running)
                {
                    sqlLabel.Fill = Brushes.Green; 
                }
                else
                {
                    sqlLabel.Fill = Brushes.Red; 
                }
                if (apache.Status == ServiceControllerStatus.Running)
                {
                    apacheLabel.Fill = Brushes.Green; 
                }
                else
                {
                    apacheLabel.Fill = Brushes.Red; 
                }
                if (pearl.Status == ServiceControllerStatus.Running)
                {
                    pearlLabel.Fill = Brushes.Green;
                }
                else
                {
                    pearlLabel.Fill = Brushes.Red;
                }
                if (mtm.Status == ServiceControllerStatus.Running)
                {
                    mtmLabel.Fill = Brushes.Green;
                }
                else
                {
                    mtmLabel.Fill = Brushes.Red;
                }
            }
            catch
            {
                //
            }
        }
        public void serviceStatusv7SD(Ellipse agentLabelv7SD, Ellipse adapterLabelv7SD, Ellipse appserverLabelv7SD, Ellipse sqlLabelv7SD, Ellipse apacheLabelv7SD, Ellipse pearlLabelv7SD, Ellipse mtmLabelv7SD,
            string machineNamev7SD, string agentServicev7SD, string adapterServicev7SD, string appserverServicev7SD, string sqlServicev7SD, string apacheServicev7SD, string pearlServicev7SD, string mtmServicev7SD) //SHOW INITIAL SERVICE STATUS AT DASHBOARD INITIAL LOAD
        {

            try
            {
                ServiceController agent = new ServiceController();
                agent.ServiceName = agentServicev7SD;
                ServiceController adapter = new ServiceController();
                adapter.ServiceName = adapterServicev7SD;
                ServiceController appserver = new ServiceController();
                appserver.ServiceName = appserverServicev7SD;
                ServiceController sql = new ServiceController();
                sql.ServiceName = sqlServicev7SD;
                ServiceController apache = new ServiceController();
                apache.ServiceName = apacheServicev7SD;
                ServiceController pearl = new ServiceController();
                pearl.ServiceName = pearlServicev7SD;
                ServiceController mtm = new ServiceController();
                mtm.ServiceName = mtmServicev7SD;

                if (agent.Status == ServiceControllerStatus.Running)
                {
                    agentLabelv7SD.Fill = Brushes.Green;
                }                               
                else
                {
                    agentLabelv7SD.Fill = Brushes.Red; 
                }
                if (adapter.Status == ServiceControllerStatus.Running)
                {
                    adapterLabelv7SD.Fill = Brushes.Green; 
                }
                else
                {
                    adapterLabelv7SD.Fill = Brushes.Red; 
                }
                if (appserver.Status == ServiceControllerStatus.Running)
                {
                    appserverLabelv7SD.Fill = Brushes.Green; 
                }
                else
                {
                    appserverLabelv7SD.Fill = Brushes.Red; 
                }
                if (sql.Status == ServiceControllerStatus.Running)
                {
                    sqlLabelv7SD.Fill = Brushes.Green; 
                }
                else
                {
                    sqlLabelv7SD.Fill = Brushes.Red; 
                }
                if (apache.Status == ServiceControllerStatus.Running)
                {
                    apacheLabelv7SD.Fill = Brushes.Green; 
                }
                else
                {
                    apacheLabelv7SD.Fill = Brushes.Red; 
                }
                if (pearl.Status == ServiceControllerStatus.Running)
                {
                    pearlLabelv7SD.Fill = Brushes.Green;
                }
                else
                {
                    pearlLabelv7SD.Fill = Brushes.Red;
                }
                if (mtm.Status == ServiceControllerStatus.Running)
                {
                    mtmLabelv7SD.Fill = Brushes.Green;
                }
                else
                {
                    mtmLabelv7SD.Fill = Brushes.Red;
                }
            }
            catch
            {
                //
            }
        }
        public void serviceStatusESuite(Ellipse agentLabelESuite, Ellipse adapterLabelESuite, Ellipse appserverLabelESuite, Ellipse sqlLabelESuite, Ellipse apacheLabelESuite, Ellipse pearlLabelESuite, Ellipse mtmLabelESuite, string machineNameESuite,
            string agentServiceESuite, string adapterServiceESuite, string appserverServiceESuite, string sqlServiceESuite, string apacheServiceESuite, string pearlServiceESuite, string mtmServiceESuite) //SHOW INITIAL SERVICE STATUS AT DASHBOARD INITIAL LOAD
        {
            try
            {
                ServiceController agent = new ServiceController();
                agent.ServiceName = agentServiceESuite;
                ServiceController adapter = new ServiceController();
                adapter.ServiceName = adapterServiceESuite;
                ServiceController appserver = new ServiceController();
                appserver.ServiceName = appserverServiceESuite;
                ServiceController sql = new ServiceController();
                sql.ServiceName = sqlServiceESuite;
                ServiceController apache = new ServiceController();
                apache.ServiceName = apacheServiceESuite;
                ServiceController pearl = new ServiceController();
                pearl.ServiceName = pearlServiceESuite;
                ServiceController mtm = new ServiceController();
                mtm.ServiceName = mtmServiceESuite;

                if (agent.Status == ServiceControllerStatus.Running)
                {
                    agentLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    agentLabelESuite.Fill = Brushes.Red;
                }
                if (adapter.Status == ServiceControllerStatus.Running)
                {
                    adapterLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    adapterLabelESuite.Fill = Brushes.Red;
                }
                if (appserver.Status == ServiceControllerStatus.Running)
                {
                    appserverLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    appserverLabelESuite.Fill = Brushes.Red;
                }
                if (sql.Status == ServiceControllerStatus.Running)
                {
                    sqlLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    sqlLabelESuite.Fill = Brushes.Red;
                }
                if (apache.Status == ServiceControllerStatus.Running)
                {
                    apacheLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    apacheLabelESuite.Fill = Brushes.Red;
                }
                if (pearl.Status == ServiceControllerStatus.Running)
                {
                    pearlLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    pearlLabelESuite.Fill = Brushes.Red;
                }
                if (mtm.Status == ServiceControllerStatus.Running)
                {
                    mtmLabelESuite.Fill = Brushes.Green;
                }
                else
                {
                    mtmLabelESuite.Fill = Brushes.Red;
                }
            }
            catch
            {
                //
            }
        }


        //BELOW METHODS FOR STOPPING AND STARTING SERVICES
        public void stopService(Ellipse labelName, string machineName, string serviceName) //STOP STANDALONE AND v4 SERVICE
        {

            ServiceController controller = new ServiceController();
            //controller.MachineName = machineName;
            controller.ServiceName = serviceName;

            if (controller.Status == ServiceControllerStatus.Running)
                controller.Stop();

            controller.WaitForStatus(ServiceControllerStatus.Stopped); //Wait for it...
            labelName.Fill = Brushes.Red; //RED WHEN STOPPED
        }
        public void startService(Ellipse labelName, string machineName, string serviceName) //START STANDALONE AND v4 SERVICE
        {
            ServiceController controller = new ServiceController();
            //controller.MachineName = machineName;
            controller.ServiceName = serviceName;

            if (controller.Status == ServiceControllerStatus.Stopped)
                controller.Start();

            controller.WaitForStatus(ServiceControllerStatus.Running); //Wait for it...
            labelName.Fill = Brushes.Green; //RED WHEN STOPPED
        }
        public void stopServiceSoftDent(Ellipse labelName, string machineNameSoftDent, string serviceNameSoftDent) //STOP SERVICES FOR v7 SOFTDENT APP SUITE
        {
            string v7ServiceName = serviceNameSoftDent + "SoftDent";
            ServiceController controller = new ServiceController();
            //controller.MachineName = machineNameSoftDent;
            controller.ServiceName = v7ServiceName; //APPEND SOFTDENT TAG FOR v7 SERVICES

            if (controller.Status == ServiceControllerStatus.Running)
                controller.Stop();

            controller.WaitForStatus(ServiceControllerStatus.Stopped); //Wait for it...
            labelName.Fill = Brushes.Red; //RED WHEN STOPPED
        }
        public void startServiceSoftDent(Ellipse labelName, string machineNameSoftDent, string serviceNameSoftDent) //START SERVICES FOR v7 SOFTDENT APP SUITE
        {
            string v7ServiceName = serviceNameSoftDent + "SoftDent"; //APPEND SOFTDENT SUFFIX FOR v7 SERVICES
            ServiceController controller = new ServiceController();
            //controller.MachineName = machineNameSoftDent;
            controller.ServiceName = v7ServiceName; //USE SOFTDENT SUFFIX FOR v7 APP SUITE

            if (controller.Status == ServiceControllerStatus.Stopped)
                controller.Start();

            controller.WaitForStatus(ServiceControllerStatus.Running); //Wait for it...
            labelName.Fill = Brushes.Green; //RED WHEN STOPPED
        }

        //SERVICE CONTROL BUTTONS
        private void button1_Click(object sender, RoutedEventArgs e) //STOP AGENT HOST SERVICE
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHostSoftDent"))

                if (appSuitelegacy != null)
                {
                    stopService(agentHost, "127.0.0.1", "PWAgentHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        stopServiceSoftDent(agentHost, "127.0.0.1", "PWAgentHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow, "The Agent Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
        }
        private void button32_Click(object sender, RoutedEventArgs e) //STOP PEARL ADAPTER HOST
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWPEARLAdapterHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWPEARLAdapterHostSoftDent"))
                if (appSuitelegacy != null)
                {
                    stopService(pearlHost, "127.0.0.1", "PWPEARLAdapterHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        stopServiceSoftDent(pearlHost, "127.0.0.1", "PWPEARLAdapterHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow, "The PEARL Adapter Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

        }
        private void button2_Click(object sender, RoutedEventArgs e) //STOP ADAPTER HOST SERVICE
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAdapterHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAdapterHostSoftDent"))

                if (appSuitelegacy != null)
                {
                    stopService(adapterHost, "127.0.0.1", "PWAdapterHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        stopServiceSoftDent(adapterHost, "127.0.0.1", "PWAdapterHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow, "The Adapter Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
        }
        private void button3_Click(object sender, RoutedEventArgs e) //STOP APPLICATION SERVER
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServer"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerSoftDent"))
            using (RegistryKey appSuiteESuite = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerEservices"))

                if (appSuitelegacy != null)
                {
                    stopService(appServer, "127.0.0.1", "PWApplicationServer");
                }
                else
                    if (appSuitev7 != null)
                    {
                        stopServiceSoftDent(appServer, "127.0.0.1", "PWApplicationServer");
                    }
                    else
                        if (appSuiteESuite != null)
                        {
                            stopService(appServer, "127.0.0.1", "PWApplicationServerEservices");
                        }

                        else
                        {
                            MessageBox.Show(Application.Current.MainWindow, "The Application Server is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
        }
        private void button4_Click(object sender, RoutedEventArgs e) //START APPLICATION SERVER
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServer"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerSoftDent"))
            using (RegistryKey appSuiteESuite = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerEservices"))


                if (appSuitelegacy != null)
                {
                    startService(appServer, "127.0.0.1", "PWApplicationServer");
                }
                else
                    if (appSuitev7 != null)
                    {
                        startServiceSoftDent(appServer, "127.0.0.1", "PWApplicationServer");
                    }
                    else
                        if (appSuiteESuite != null)
                        {
                            startService(appServer, "127.0.0.1", "PWApplicationServerEservices");
                        }
                        else
                        {
                            MessageBox.Show(Application.Current.MainWindow, "The Application Server is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
        }
        private void button5_Click(object sender, RoutedEventArgs e) //START ADAPTER HOST SERVICE
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAdapterHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAdapterHostSoftDent"))

                if (appSuitelegacy != null)
                {
                    startService(adapterHost, "127.0.0.1", "PWAdapterHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        startServiceSoftDent(adapterHost, "127.0.0.1", "PWAdapterHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow, "The Adapter Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
        }
        private void button33_Click(object sender, RoutedEventArgs e) //START PEARL ADAPTER HOST
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWPEARLAdapterHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWPEARLAdapterHost"))

                if (appSuitelegacy != null)
                {
                    startService(pearlHost, "127.0.0.1", "PWPEARLAdapterHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        startServiceSoftDent(pearlHost, "127.0.0.1", "PWPEARLAdapterHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow, "The PEARL Adapter Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

        }
        private void button6_Click(object sender, RoutedEventArgs e) //START AGENT HOST SERVICE
        {
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHost"))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHostSoftDent"))

                if (appSuitelegacy != null)
                {
                    startService(agentHost, "127.0.0.1", "PWAgentHost");
                }
                else
                    if (appSuitev7 != null)
                    {
                        startServiceSoftDent(agentHost, "127.0.0.1", "PWAgentHost");
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.MainWindow,"The Agent Host service is not present on this machine.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
        }
        private void button7_Click(object sender, RoutedEventArgs e) //STOP PWNGSQL NAMED INSTANCE
        {
            try
            {
                stopService(pwngsql, "127.0.0.1", "MSSQL$PWNGSQL");
            }
            catch
            {
                MessageBox.Show("The PWNGSQL Named instance could not be found on this computer.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button8_Click(object sender, RoutedEventArgs e) //START PWNGSQL NAMED INSTANCE
        {
            try
            {
                startService(pwngsql, "127.0.0.1", "MSSQL$PWNGSQL");
            }
            catch
            {
                MessageBox.Show("The PWNGSQL Named instance could not be found on this computer.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button9_Click(object sender, RoutedEventArgs e) //STOP APACHE SERVER
        {
            try
            {
                stopService(apacheServer, "127.0.0.1", "Apache2.2");
            }
            catch
            {
                MessageBox.Show("The Apache Web Server software does not appear to be on this computer. This may indicate that the eForms Service is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button10_Click(object sender, RoutedEventArgs e) //START APACHE SERVER
        {
            try
            {
                startService(apacheServer, "127.0.0.1", "Apache2.2");
            }
            catch
            {
                MessageBox.Show("The Apache Web Server software does not appear to be on this computer. This may indicate that the eForms Service is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // METHOD TO LAUNCH SERVICE CONFIG FILE ACCESS
        public void openConfig(string legacySvcName, string v7Svcname) //METHOD TO LAUNCH SERVICE CONFIG FILE BASED ON PRESENCE IN REGISTRY
        {
            string legacyConfig = (String)Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\services\\{0}", legacySvcName), "ImagePath", "");
            string v7Config = (String)Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\services\\{0}", v7Svcname), "ImagePath", "");
            using (RegistryKey appSuitelegacy = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\" + (string)legacySvcName))
            using (RegistryKey appSuitev7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\" + (string)v7Svcname))

                if (appSuitelegacy != null)
                {
                    legacyConfig = legacyConfig.Substring(0, legacyConfig.IndexOf(".exe", 0, StringComparison.CurrentCultureIgnoreCase) + 4);
                    legacyConfig = legacyConfig.Trim() + ".config";
                    //legacyConfig = legacyConfig + ".config";
                    System.Diagnostics.Process.Start("notepad.exe", legacyConfig);
                    //System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    //prc.StartInfo.FileName = legacyConfig;
                    //prc.Start();

                }
                else
                    if (appSuitev7 != null)
                    {
                        v7Config = v7Config.Substring(0, v7Config.IndexOf(".exe", 0, StringComparison.CurrentCultureIgnoreCase) + 4);
                        v7Config = v7Config.Trim() + ".config";
                        //v7Config = v7Config + ".config";
                        System.Diagnostics.Process.Start("notepad.exe", v7Config);
                        //System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        //prc.StartInfo.FileName = v7Config;
                        //prc.Start();

                    }
                    else
                        if (appSuitelegacy == null && appSuitev7 == null)
                        {
                            MessageBox.Show("The service configuration file is not present on this machine. This may indicate the Agent host is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }

        }        
        //LAUNCH CONFIG FILES WITH NOTEPAD
        private void button11_Click(object sender, RoutedEventArgs e) //OPEN AGENT HOST CONFIG
        {
            openConfig("PWAgentHost", "PWAgentHostSoftDent");
        }
        private void button12_Click(object sender, RoutedEventArgs e) //OPEN ADAPTER HOST CONFIG
        {
            openConfig("PWAdapterHost", "PWAdapterHostSoftDent");
        }
        private void button13_Click(object sender, RoutedEventArgs e) //OPEN APPLICATION SERVER CONFIG
        {
            openConfig("PWApplicationServer", "PWApplicationServerSoftDent");
        }

        //METHOD TO LAUNCH NON-SERVICE CONFIG FILES
        public void openAppConfig(string legacyAppDir, string ecsSuiteDir, string v7AppDir, 
            string LegacyAppConfig, string v7AppConfig) //METHOD TO LAUNCH NON-SERVICE CONFIG FILE BASED ON PRESENCE IN REGISTRY
        {
            using (RegistryKey x86LegacyConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\"))
            using (RegistryKey x64LegacyConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node"))
            using (RegistryKey x86ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Carestream\\InstalledApplications\\Carestream eService Suite"))
            using (RegistryKey x64ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Carestream\\InstalledApplications\\Carestream eService Suite"))
            using (RegistryKey x86v7Config = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\PracticeWorks\Carestream SoftDent Application Suite"))
            using (RegistryKey x64v7Config = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\PracticeWorks\\Carestream SoftDent Application Suite"))

                if ((File.Exists(@"C:\\Program Files\\CareStream\\Carestream eService Suite\\" + ecsSuiteDir + "\\" + LegacyAppConfig)) && (x86ECSSuiteConfig != null))
                {
                    System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files\\Carestream\\Carestream eService Suite\\" + ecsSuiteDir + "\\" + LegacyAppConfig);
                }
                else
                    if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\Carestream eService Suite\\" + ecsSuiteDir + "\\" + LegacyAppConfig)) && (x64ECSSuiteConfig != null)) 
                    {
                        System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files (x86)\\Carestream\\Carestream eService Suite\\" + ecsSuiteDir + "\\" + LegacyAppConfig);
                    }
                    else    
                        if ((File.Exists(@"C:\\Program Files\\CareStream\\" + legacyAppDir + "\\" + LegacyAppConfig)) && (x86v7Config == null))
                            {
                                System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files\\Carestream\\" + legacyAppDir + "\\" + LegacyAppConfig);
                            }
                            else
                                if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\" + legacyAppDir + "\\" + LegacyAppConfig)) && (x64v7Config == null))
                                {
                                    System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files (x86)\\Carestream\\" + legacyAppDir + "\\" + LegacyAppConfig);
                                }
                                else
                                    if ((File.Exists(@"C:\\Program Files\\CareStream\\Carestream SoftDent Application Suite\\" + v7AppDir + "\\" + v7AppConfig)) && (x86v7Config != null))
                                    {
                                        System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files\\Carestream\\Carestream SoftDent Application Suite\\" + v7AppDir + "\\" + v7AppConfig);
                                    }
                                    else
                                        if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\" + v7AppDir + "\\" + v7AppConfig)) && (x64v7Config != null))
                                        {
                                            System.Diagnostics.Process.Start("notepad.exe", "C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\" + v7AppDir + "\\" + v7AppConfig);
                                        }
                                        else 
                                          if (x86LegacyConfig==null && x64LegacyConfig==null)
                                        {
                                            MessageBox.Show("The service configuration file is not present on this machine. This may indicate the Agent host is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        }
                                          else
                                              if (x86v7Config == null && x64v7Config == null)
                                              {
                                                  MessageBox.Show("The service configuration file is not present on this machine. This may indicate the Agent host is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                              }
        } 
        //LAUNCH NON SERVICE CONFIG FILES
        private void button14_Click(object sender, RoutedEventArgs e) //OPEN EFORMS DISPATCHER CONFIG
        {
            openAppConfig("eForms", "eForms", "eForms", "PW.EFormApplication.Dispatcher.exe.config", "PW.EFormApplication.Dispatcher.exe.config");
        }
        private void button15_Click(object sender, RoutedEventArgs e) //OPEN WEB HOST CONFIG
        {
            try
            {
                //If it's there, then let's open the config file
                string myPath = @"C:\\Program Files\\Common Files\\PracticeWorks\\eFormsWebHost\\web.config";
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = myPath;
                prc.Start();
            }
            catch
            {
                MessageBox.Show("The eForms Web Host configuration file is not present on this machine. This could indicate that eForms is not installed or not installed properly. Please install eForms along with a compatible DPMS and try again.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
        private void button16_Click(object sender, RoutedEventArgs e) //OPEN EREMINDERS APP CONFIG
        {
            openAppConfig("eReminders Service", "eReminders", "eReminders", "PW.EReminderApplication.exe.config", "PW.EReminderApplication.exe.config");
        }
        
        //METHODE TO LAUNCH LOG FILES
        public void openApplog(string legacyLog, string v7Log, string legacyService, string v7Service) //METHOD TO LAUNCH LOG FILES
        {
            using (RegistryKey legacyKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\"+legacyService))
            using (RegistryKey v7Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\"+v7Service))

                if ((File.Exists(@"C:\\Documents and Settings\\All Users\\Application Data\\PracticeWorks\\" + legacyLog)) && (v7Key == null)) //OPEN LEGACY LOG FROM WINXP LEGACY IF v7 SERVICE NOT PRESENT
                {
                    System.Diagnostics.Process.Start("notepad.exe", "C:\\Documents and Settings\\All USers\\Application Data\\PracticeWorks\\"+legacyLog);
                }
                else
                    if ((File.Exists(@"C:\\Documents and Settings\\All USers\\Application Data\\PracticeWorks\\")) && (legacyKey == null)) //OPEN v7 LOG FROM WINXP IF LEGACY SERVICE NOT PRESENT
                    {
                        System.Diagnostics.Process.Start("notepad.exe", "C:\\Documents and Settings\\All USers\\Application Data\\PracticeWorks\\"+v7Log);
                    }
                    else
                        if ((File.Exists(@"C:\\ProgramData\\PracticeWorks\\"+legacyLog)) && (v7Key == null)) //OPEN LEGACY LOG FILE FROM Win7+ IF v7 SERVICE NOT PRESENT
                        {
                            System.Diagnostics.Process.Start("notepad.exe", "C:\\ProgramData\\PracticeWorks\\"+legacyLog);
                        }
                        else
                            if ((File.Exists(@"C:\\ProgramData\\PracticeWorks\\"+v7Log)) && (legacyKey == null)) //OPEN v7 LOG FILE FROM Win7+ IF LEGACY SERVICE NOT PRESENT
                            {
                                System.Diagnostics.Process.Start("notepad.exe", "C:\\ProgramData\\PracticeWorks\\"+v7Log);
                            }
                            
                            else
                                if (legacyKey == null && v7Key == null)
                                {
                                    MessageBox.Show("The service configuration file is not present on this machine. This may indicate the Agent host is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                                
        } 

        //OPEN LOG FILES
        private void button17_Click(object sender, RoutedEventArgs e) //OPEN LOG FILES FOLDER
        {
            try
            {
                //Let's check to see if the containing folder exists in ProgramData
                if (File.Exists("C:\\ProgramData\\PracticeWorks"))
                {
                    //If it's there, then let's open the folder
                    string myPath = @"C:\\ProgramData\\PracticeWorks";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
                //If the file wasnt there....
                else
                {
                    //Launch it form the standard Docs and Settings location
                    string myPath = @"C:\\Documents and Settings\\All Users\\Application Data\\PracticeWorks";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
            }
            catch
            {
                MessageBox.Show("Could not retrieve the Carestream Modules log file location. This may indicate that the NextGen modules are not installed.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button18_Click(object sender, RoutedEventArgs e) //EFORMS DISPATCHER LOG
        {
            openApplog("PW.EFormApplication.Dispatcher.log", "PW.EFormApplication.Dispatcher.log", "PWAgentHost", "PWAgentHostSoftDent");
        }
        private void button19_Click(object sender, RoutedEventArgs e) //EREMINDER APPLICATION LOG
        {
            openApplog("PW.EReminderApplication.log", "PW.EReminderApplication.log", "PWAgentHost", "PWAgentHostSoftDent");
        }
        private void button20_Click(object sender, RoutedEventArgs e) //AGENT HOST LOG
        {
            openApplog("PW.AgentHost.log", "PW.AgentHost_SoftDent.log", "PWAgentHost", "PWAgentHostSoftDent");
        }
        private void button21_Click(object sender, RoutedEventArgs e) //ADAPTER HOST LOG
        {
            openApplog("PW.AdapterHost.log", "PW.AdapterHost_SoftDent.log", "PWAdapterHost", "PWAdapterHostSoftDent");
        }
        private void button22_Click(object sender, RoutedEventArgs e) //APPLICATION SERVER LOG
        {
            openApplog("PW.ApplicationServer.log", "PW.ApplicationServer_SoftDent.log", "PWApplicationServer", "PWApplicationServerSoftDent");
        }

        //METHOD TO LAUNCH EREMINDERS VIA COMMAND LINE
        public void reminderShortcut (string legacyCommand, string v7SDCommand) //METHOD TO LAUNCH EREMINDERS VIA COMMAND LINE
        {
            using (RegistryKey legacyKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServer"))
            using (RegistryKey v7SDKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerSoftDent"))
            using (RegistryKey x86ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Carestream\\InstalledApplications\\Carestream eService Suite"))
            using (RegistryKey x64ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Carestream\\InstalledApplications\\Carestream eService Suite"))

                if ((File.Exists(@"C:\\Program Files\\CareStream\\Carestream eService Suite\\eReminders\\PW.EReminderApplication.exe")) && ((x86ECSSuiteConfig !=null)&&(v7SDKey == null)))
                {
                    System.Diagnostics.Process.Start(@"C:\\Program Files\\CareStream\\Carestream eService Suite\\eReminders\\PW.EReminderApplication.exe" + " ", legacyCommand);
                }
                else
                    if ((File.Exists(@"C:\\Program Files (x86)\\CareStream\\Carestream eService Suite\\eReminders\\PW.EReminderApplication.exe")) && ((x64ECSSuiteConfig != null) && (v7SDKey == null)))
                    {
                        System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\CareStream\\Carestream eService Suite\\eReminders\\PW.EReminderApplication.exe" + " ", legacyCommand);
                    }
                    else
                        if ((File.Exists(@"C:\\Program Files\\CareStream\\eReminders Service\\PW.EReminderApplication.exe")) && (v7SDKey == null))
                        {
                            System.Diagnostics.Process.Start(@"C:\\Program Files\\CareStream\\eReminders Service\\PW.EReminderApplication.exe"+" ", legacyCommand);
                        }
                        else
                            if ((File.Exists(@"C:\\Program Files (x86)\\CareStream\\eReminders Service\\PW.EReminderApplication.exe")) && (v7SDKey == null))
                            {
                                System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\CareStream\\eReminders Service\\PW.EReminderApplication.exe"+" ", legacyCommand);
                            }
                            else
                                if ((File.Exists(@"C:\\Program Files\\CareStream\\Carestream SoftDent Application Suite\\eReminders\\PW.EReminderApplication.exe")) && (v7SDKey != null))
                                {
                                    System.Diagnostics.Process.Start(@"C:\\Program Files\\CareStream\\Carestream SoftDent Application Suite\\eReminders\\PW.EReminderApplication.exe"+" ", v7SDCommand);
                                }
                                else
                                    if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\eReminders\\PW.EReminderApplication.exe")) && (v7SDKey != null))
                                    {
                                        System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\eReminders\\PW.EReminderApplication.exe"+" ", v7SDCommand);
                                    }
                                    else
                                        if (legacyKey == null && v7SDKey == null)
                                        {
                                            MessageBox.Show("eReminders could not be found on this machine. This may indicate that eRemidners is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        }
        }
        //METHOD TO DETERMINE REMINDER REQUEST LOCATION
        public void reminderRequests (string legacyAgentHost, string mdbAgentHost) //METHOD TO DETERMINE REMINDER REQUEST LOCATION
        {
            using (RegistryKey legacyKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHost")) //For Legacy NG or ESuite Agent Host
            using (RegistryKey v7Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWAgentHostSoftDent")) //For SoftDent MDB Agent Host
                if (legacyKey != null)
                {
                   try
                    {
                        string legacyAgent = (String)Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\{0}", legacyAgentHost), "ImagePath", "");
                        legacyAgent = legacyAgent.Substring(0, legacyAgent.IndexOf("PW.AgentHost.exe", 0) + 0);
                        legacyAgent = legacyAgent.Trim() + "\\Agents\\eReminderAgent\\ReminderRequests";
                        System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        prc.StartInfo.FileName = legacyAgent;
                        prc.Start();
                    }
                   catch
                    {
                        MessageBox.Show("Unable to determine the Legacy Reminder Request repository.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                 }
                 else
                    if (v7Key != null)
                    {
                       try
                        {
                            string v7AgentHost = (String)Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\{0}", mdbAgentHost), "ImagePath", "");
                            v7AgentHost = v7AgentHost.Substring(0, v7AgentHost.IndexOf("PW.AgentHost.exe DPMSType=1", 0) + 0);
                            v7AgentHost = v7AgentHost.Trim() + "\\Agents\\eReminderAgent\\ReminderRequests";
                            System.Diagnostics.Process prc = new System.Diagnostics.Process();
                            prc.StartInfo.FileName = v7AgentHost;
                            prc.Start();
                        }
                       catch
                        {
                            MessageBox.Show("Unable to determine the MDB Reminder Request repository.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                        if (v7Key==null & legacyKey==null)
                        {
                            MessageBox.Show("The Agent Host Service does not appear to be installed. Unable to verify the Reminder Request repository.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
        }

        //EREMINDERS SHORTCUTS
        private void button23_Click(object sender, RoutedEventArgs e) //EREMINDER PRACTICE SETTINGS
        {
            reminderShortcut("PracticeSettings", "1 SoftDent_DatabaseSet PracticeSettings");
        }
        private void button24_Click(object sender, RoutedEventArgs e) //SEND EREMINDERS
        {
            reminderShortcut("SendReminders", "1 SoftDent_DatabaseSet SendReminders");
        }
        private void button26_Click(object sender, RoutedEventArgs e) //RECEIVE EREMINDER RESPONSES
        {
            reminderShortcut("ReceiveResponses", "1 SoftDent_DatabaseSet ReceiveResponses");
        }
        private void button25_Click(object sender, RoutedEventArgs e) //EREMINDER REPORTING
        {
            reminderShortcut("Reporting", "1 SoftDent_DatabaseSet Reporting");
        }
        private void button27_Click(object sender, RoutedEventArgs e) //OPEN REMINDER REQUESTS
        {
            reminderRequests("PWAgentHost", "PWAgentHostSoftDent");
        }

        //EFORMS SHORTCUTS
        private void button28_Click(object sender, RoutedEventArgs e) //OPEN APACHE CONFIGURATION FILE
        {
            try
            {
                //Let's check to see if the config file exists in the 64 Bit windows path Program Files (x86)
                if (File.Exists(@"C:\\Program Files (x86)\\Apache Software Foundation\\Apache2.2\conf\\httpd.conf"))
                {
                    //If it's there, then let's open the config file
                    string myPath = @"C:\\Program Files (x86)\\Apache Software Foundation\\Apache2.2\conf\\httpd.conf";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
                //If the file wasnt in the 64 Bit windows path....
                else
                {
                    //Launch it form the standard Program Files location
                    string myPath = @"C:\\Program Files\\Apache Software Foundation\\Apache2.2\conf\\httpd.conf";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
            }
            catch
            {
                MessageBox.Show("The Apache Web Server configuration file is not present on this machine. This could indicate that eForms is not installed or not installed properly. Please install eForms along with a compatible DPMS and try again.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button29_Click(object sender, RoutedEventArgs e) //OPEN APACHE LOG FILE
        {
            try
            {
                //Let's check to see if the containing folder exists in ProgramData
                if (File.Exists("C:\\ProgramData\\PracticeWorks\\httpd.log"))
                {
                    //If it's there, then let's open the folder
                    string myPath = @"C:\\ProgramData\\PracticeWorks\\httpd.log";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
                //If the file wasnt there....
                else
                {
                    //Launch it form the standard Docs and Settings location
                    string myPath = @"C:\\Documents and Settings\\All Users\\Application Data\\PracticeWorks\\httpd.log";
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = myPath;
                    prc.Start();
                }
            }
            catch
            {
                MessageBox.Show("The Apache Web Server software does not appear to be on this computer. This may indicate that the eForms Service is either not installed or not installed properly.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void button30_Click(object sender, RoutedEventArgs e) //OPEN EFORMS IN DEBUG MODE
        {
            using (RegistryKey legacyKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServer"))
            using (RegistryKey v7SDKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\\CurrentControlSet\\Services\\PWApplicationServerSoftDent"))
            using (RegistryKey x86ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Carestream\\InstalledApplications\\Carestream eService Suite"))
            using (RegistryKey x64ECSSuiteConfig = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Carestream\\InstalledApplications\\Carestream eService Suite"))
                
                if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\Carestream eService Suite\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (x64ECSSuiteConfig !=null))//Are we running ECS App Suite flavor on x64 OS?
                {
                    System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Carestream\\Carestream eService Suite\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG");
                }
                else
                    if ((File.Exists(@"C:\\Program Files\\Carestream\\Carestream eService Suite\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (x86ECSSuiteConfig !=null))
                    {
                        System.Diagnostics.Process.Start(@"C:\\Program Files\\Carestream\\Carestream eService Suite\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG"); //Run it form x86 location
                    }
                    else
                        if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (v7SDKey==null))//Are we running on x64 OS?
                        {
                            System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Carestream\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG");
                        }
                        else
                            if ((File.Exists(@"C:\\Program Files\\Carestream\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (v7SDKey == null))
                            {
                                System.Diagnostics.Process.Start(@"C:\\Program Files\\Carestream\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG"); //Run it form x86 location
                            }
                            else
                                if ((File.Exists(@"C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (v7SDKey!=null))//Are we running on x64 OS?
                                {
                                    System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Carestream\\Carestream SoftDent Application Suite\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG");
                                }
                                else
                                    if ((File.Exists(@"C:\\Program Files\\Carestream\\Carestream SoftDent Application Suite\\eForms\\PW.EFormApplication.Dispatcher.exe")) && (v7SDKey != null))//Are we running on x64 OS?
                                    {
                                        System.Diagnostics.Process.Start(@"C:\\Program Files\\Carestream\\Carestream SoftDent Application Suite\\eForms\\PW.EFormApplication.Dispatcher.exe", "/DEBUG");
                                    }
                                    else
                                        {
                                            MessageBox.Show("The eForms Application Dispatcher is not present on this machine. This could indicate that eForms is not installed or not installed properly. Please install eForms along with a compatible DPMS and try again.", "NextGen Dashboard", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        }
        }
        private void button31_Click(object sender, RoutedEventArgs e) //EFORMS RECEPTION SIGNIN
        {
            System.Diagnostics.Process.Start("http://localhost:19560/eForms/ReceptionSignin.aspx");

        }
    }
}
