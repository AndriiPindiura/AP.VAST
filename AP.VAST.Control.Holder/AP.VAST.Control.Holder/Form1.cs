using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP.VAST.Control.Holder
{
    public partial class Form1 : Form
    {
        private AP.VAST.Control.wf.VASTNet vastNet1;


        public Form1()
        {
            InitializeComponent();
            vastNet1 = new AP.VAST.Control.wf.VASTNet();
            this.Controls.Add(vastNet1);
            vastNet1.BringToFront();
            vastNet1.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vastNet1.Connect(serverIp.Text, (int)serverPort.Value, login.Text, password.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vastNet1.Live((int)cameraId.Value, (int)streamId.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vastNet1.Playback((int)cameraId.Value, (int)streamId.Value, date.Value);
        }
    }
}
