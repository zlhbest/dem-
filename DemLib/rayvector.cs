using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemLib;

namespace DemLib
{
    public partial class rayvector : Form
    {
       private vector Rayvector = new vector();
        public rayvector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double fAltitude = Convert.ToDouble(textBox1.Text);
                double fAzimuth = Convert.ToDouble(textBox2.Text);
                 Rayvector.X = Math.Cos(fAltitude) * Math.Cos(fAzimuth);
                 Rayvector.Y = Math.Cos(fAltitude) * Math.Sin(fAzimuth);
                 Rayvector.Z = Math.Sin(fAltitude) * Math.Cos(fAzimuth);
                 this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的格式");
            }
           

        }

        public vector GetRayvector()
        {
            return Rayvector;
        }
    }
}
