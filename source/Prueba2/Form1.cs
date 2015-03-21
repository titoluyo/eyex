using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework;


namespace Prueba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Program.EyeXHost.Connect(behaviorMap1);
            behaviorMap1.Add(panel1, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel2, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel3, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel4, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel5, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel6, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel7, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel8, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panel9, new GazeAwareBehavior(OnGaze));
        }

        private void OnGaze(object sender, GazeAwareEventArgs e)
        {
            var panel = sender as Direccion;
            if (panel != null)
            {
                panel.BackColor = e.HasGaze ? Color.Yellow : Color.Black;
                if (e.HasGaze)
                {
                    txtHorizontal.Text = panel.Horizontal.ToString();
                    txtVertical.Text = panel.Vertical.ToString();

                }
            }
        }
    }
}
