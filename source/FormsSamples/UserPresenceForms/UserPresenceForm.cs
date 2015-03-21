//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace UserPresenceForms
{
    using System;
    using System.Windows.Forms;
    using EyeXFramework;
    using Tobii.EyeX.Framework;

    public partial class UserPresenceForm : Form
    {
        public UserPresenceForm()
        {
            InitializeComponent();

            // Register an status-changed event listener for user presence.
            // NOTE that the event listener must be unregistered too. This is taken care of in the Dispose(bool) method.
            Program.EyeXHost.UserPresenceChanged += EyeXHost_UserPresenceChanged;

            // Start with initial value.
            UpdateImageBasedOnUserPresence(Program.EyeXHost.UserPresence);
        }

        void EyeXHost_UserPresenceChanged(object sender, EngineStateValue<UserPresence> e)
        {
            // State-changed events are received on a background thread.
            // But operations that affect the GUI must be executed on the main thread.
            // We use BeginInvoke to marshal the call to the main thread.
            if (Created)
            {
                BeginInvoke(new Action(() => UpdateImageBasedOnUserPresence(e)));
            }
        }

        private void UpdateImageBasedOnUserPresence(EngineStateValue<UserPresence> value)
        {
            if (value.IsValid &&
                value.Value == UserPresence.Present)
            {
                pictureBox1.ImageLocation = "Images/present.png";
            }
            else
            {
                pictureBox1.ImageLocation = "Images/not-present.png";
            }
        }
    }
}
