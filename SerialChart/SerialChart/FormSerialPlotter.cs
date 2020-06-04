using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerialChart
{
    public partial class FormSerialPlotter : Form
    {
        private SerialPort sp;
        private PortSelectionForm selectionForm;
        private int lastX = 0;

        public FormSerialPlotter(string port, PortSelectionForm selectionForm)
        {
            InitializeComponent();
            this.selectionForm = selectionForm;

            labelPort.Text = "PORT: " + port;

            ChartInit();
            SetupSerial(port);
        }

        private void SetupSerial(string port)
        {
            sp = new SerialPort(port, 2400, Parity.None, 8, StopBits.One);
            sp.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            sp.Open();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string readString = ReadStringWithDelimeter();

            try
            {
                PlotInChart(double.Parse(readString, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo));
            }
            catch (Exception)
            {
            }
        }

        private string ReadStringWithDelimeter()
        {
            int lastChar;
            string builtString = "";
            bool gotDelimeter = false;

            while (!gotDelimeter)
            {
                lastChar = sp.ReadChar();
                char converted = (char)lastChar;

                if (converted == '^')
                {
                    gotDelimeter = true;
                }
                else
                {
                    builtString += converted.ToString();
                }
            }

            return builtString;
        }

        private void ChartInit()
        {
            chartMain.ChartAreas[0].AxisY.ScaleView.Zoom(100, 255);
            chartMain.ChartAreas[0].AxisX.ScaleView.Zoom(0, 500);
            chartMain.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartMain.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartMain.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            chartMain.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            chartMain.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartMain.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartMain.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartMain.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartMain.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartMain.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chartMain.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartMain.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            chartMain.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chartMain.ChartAreas[0].AxisY.LineColor = Color.Transparent;
            chartMain.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            chartMain.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chartMain.Series[0].IsVisibleInLegend = false;
        }


        private void PlotInChart(double number)
        {
            this.Invoke(new MethodInvoker(delegate () { chartMain.Series[0].Points.AddXY(lastX, number); }));
            this.Invoke(new MethodInvoker(delegate () { chartMain.ChartAreas[0].AxisX.ScaleView.Zoom(lastX - 500, lastX); }));
            lastX++;
        }

        private void FormSerialPlotter_FormClosing(object sender, FormClosingEventArgs e)
        {
            selectionForm.Close();

        }
    }
}
