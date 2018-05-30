using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemLib
{
    public partial class RibbonWin : Form
    {
        private int ribbon = 0;
        public RibbonWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox1.Text.Equals(""))
                {
                    ribbon = Convert.ToInt32(textBox1.Text);
                }
                else
                {
                    ribbon = 20;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入整数");
            }
           
        }
        public int getRibbon()
        {
            return ribbon;
        }
    }
}
