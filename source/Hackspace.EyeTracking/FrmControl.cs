using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework;
using System.IO;


namespace Prueba2
{
    public partial class FrmControl : Form
    {
		SerialPort puerto;
        public FrmControl()
        {
            InitializeComponent();

            puerto = new SerialPort("COM3",9600);
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

            behaviorMap1.Add(munecaUp, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(munecaStop, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(munecaDown, new GazeAwareBehavior(OnGaze));

            behaviorMap1.Add(ManoAbierta, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(ManoStop, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(ManoCerrada, new GazeAwareBehavior(OnGaze));

            panel1.MouseHover += OnHover;
            panel2.MouseHover += OnHover;
            panel3.MouseHover += OnHover;
            panel4.MouseHover += OnHover;
            panel5.MouseHover += OnHover;
            panel6.MouseHover += OnHover;
            panel7.MouseHover += OnHover;
            panel8.MouseHover += OnHover;
            panel9.MouseHover += OnHover;

            munecaUp.MouseHover += OnHover;
            munecaStop.MouseHover += OnHover;
            munecaDown.MouseHover += OnHover;

            ManoAbierta.MouseHover += OnHover;
            ManoStop.MouseHover += OnHover;
            ManoCerrada.MouseHover += OnHover;
        }

        private void OnHover(object sender, EventArgs e)
        {
            var panel = sender as Direccion;
            if (panel != null)
            {
                txtHorizontal.Text = panel.Horizontal.ToString();
                txtVertical.Text = panel.Vertical.ToString();
                puerto.Open();
                switch (panel.Vertical)
                {
                    case 1: puerto.Write("A");
                        break;
                    case 2: puerto.Write("B");
                        break;
                    case 3: puerto.Write("C");
                        break;
                }
                switch (panel.Horizontal)
                {
                    case 1: puerto.Write("D");
                        break;
                    case 2: puerto.Write("E");
                        break;
                    case 3: puerto.Write("F");
                        break;
                }
                switch (panel.Vertical)
                {
                    case 5: switch (panel.Horizontal)
                        {
                            case 6: puerto.Write("P");
                                break;
                            case 5: puerto.Write("Q");
                                break;
                            case 4: puerto.Write("R");
                                break;
                        }
                        break;
                    case 4: switch (panel.Horizontal)
                        {
                            case 4: puerto.Write("T");
                                break;
                            case 5: puerto.Write("U");
                                break;
                            case 6: puerto.Write("V");
                                break;
                        }
                        break;
                }
                puerto.Close();
            }
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
		            puerto.Open();
                    switch (panel.Vertical) {
		            		case 1:puerto.Write("A");
		            		break;
		            		case 2:puerto.Write("B");
		            		break;
		            		case 3:puerto.Write("C");
		            		break;
                    }
		            switch (panel.Horizontal) {
		            		case 1:puerto.Write("D");
		            		break;
		            		case 2:puerto.Write("E");
		            		break;
		            		case 3:puerto.Write("F");
		            		break;
                    }
		            switch (panel.Vertical) {
		            	case 5: switch (panel.Horizontal) {
		            				case 6:puerto.Write("P");
		            				break;
		            				case 5:puerto.Write("Q");
		            				break;
		            				case 4:puerto.Write("R");
		            				break;
		            	}
		            		break;
		            	case 4: switch (panel.Horizontal) {
		            				case 4:puerto.Write("T");
		            				break;
		            				case 5:puerto.Write("U");
		            				break;
		            				case 6:puerto.Write("V");
		            				break;
		            	}
		            		break;
		            }
                    puerto.Close();
                }
            }
        }
    }
}
