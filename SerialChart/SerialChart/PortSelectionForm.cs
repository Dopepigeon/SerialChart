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

namespace SerialChart
{
    public partial class PortSelectionForm : Form
    {
        public PortSelectionForm()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();

            foreach (var item in ports)
            {
                comboBoxPorts.Items.Add(item);
            }
        }

        private void ButtonPlot_Click(object sender, EventArgs e)
        {
            FormSerialPlotter fp = new FormSerialPlotter(comboBoxPorts.SelectedItem.ToString(), this);
            fp.Show();
            this.Hide();
        }
    }
}
