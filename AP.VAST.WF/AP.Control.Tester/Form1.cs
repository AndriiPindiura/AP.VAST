using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP.Control.Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vastNet1.Connect("192.168.47.100", 3454, "admin", "admin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vastNet1.Live(1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vastNet1.Playback(1, 1, DateTime.Parse("18.11.2015 08:00:00"));
        }
    }
}
