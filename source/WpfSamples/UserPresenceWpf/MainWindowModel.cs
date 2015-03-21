//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace UserPresenceWpf
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using EyeXFramework;
    using EyeXFramework.Wpf;
    using Tobii.EyeX.Framework;

    /// <summary>
    /// The MainWindowModel retrieves the UserPresence state from the WpfEyeXHost,
    /// and sets up a listener for changes to the state. It exposes a property
    /// ImageSource, which changes depending on the UserPresence state.
    /// </summary>
    public class MainWindowModel : INotifyPropertyChanged, IDisposable
    {
        private const string PathToImageForUserPresent = "/Images/present.png";
        private const string PathToImageForUserNotPresent = "/Images/not-present.png";

        private readonly WpfEyeXHost _eyeXHost;
        private string _imageSource = PathToImageForUserNotPresent;

        public MainWindowModel(WpfEyeXHost eyeXHost)
        {
            _eyeXHost = eyeXHost;

            // Start with the initial UserPresence value.
            UpdateImageSourceBasedOnUserPresence(_eyeXHost.UserPresence);

            // Register an status-changed event listener for UserPresence.
            // NOTE that the event listener must be unregistered too. This is taken care of in the Dispose(bool) method.
            _eyeXHost.UserPresenceChanged += EyeXHost_UserPresenceChanged; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A path to an image corresponding to the current UserPresence state.
        /// </summary>
        public string ImageSource
        {
            get { return _imageSource; }

            private set
            {
                if (!_imageSource.Equals(value))
                {
                    _imageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        public void Dispose()
        {
            _eyeXHost.UserPresenceChanged -= EyeXHost_UserPresenceChanged;
            GC.SuppressFinalize(this);
        }

        private void EyeXHost_UserPresenceChanged(object sender, EngineStateValue<UserPresence> engineStateValue)
        {
            // State-changed events are received on a background thread.
            // But operations that affect the GUI must be executed on the main thread.
            RunOnMainThread(new Action(() => UpdateImageSourceBasedOnUserPresence(engineStateValue)));
        }

        private void UpdateImageSourceBasedOnUserPresence(EngineStateValue<UserPresence> value)
        {
            if (value.IsValid &&
                value.Value == UserPresence.Present)
            {
                ImageSource = PathToImageForUserPresent;
            }
            else
            {
                ImageSource = PathToImageForUserNotPresent;
            }
        }

        private void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Marshals the given operation to the UI thread.
        /// </summary>
        /// <param name="action">The operation to be performed.</param>
        private static void RunOnMainThread(Action action)
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke(action);
            }
        }
    }
}
