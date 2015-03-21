//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace UserPresenceWpf
{
    using System.Windows;
    using EyeXFramework.Wpf;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WpfEyeXHost _eyeXHost;
        private MainWindowModel _mainWindowModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create and start the WpfEyeXHost. Starting the host means
            // that it will connect to the EyeX Engine and be ready to 
            // start receiving events and get the current values of
            // different engine states. In this sample we will be using
            // the UserPresence engine state.
            _eyeXHost = new WpfEyeXHost();
            _eyeXHost.Start();

            _mainWindowModel = new MainWindowModel(_eyeXHost);
            MainWindow = new MainWindow() { Visibility = Visibility.Visible, DataContext = _mainWindowModel };
        }

        /// <summary>
        /// We have to dispose the WpfEyeXHost on exit. This makes sure
        /// that all resources are cleaned up and that the connection to
        /// the EyeX Engine is closed. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _mainWindowModel.Dispose();
            _eyeXHost.Dispose();
        }
    }
}
