using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;

namespace Hotmill.Test
{
    public partial class BinaryTextConverterForm : Form
    {
        public BinaryTextConverterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            StringBuilder str = new StringBuilder();
            int lineLength = 32;
            //try
            //{
            //    lineLength = Int32.Parse(textBox3.Text);
            //}
            //catch (Exception) { }
            while (i < txtData.Text.Length)
            {
                str.Append(txtData.Text.Substring(i, ((i + 2) > txtData.Text.Length ? 1 : 2)));
                i += 2;
                if (i % lineLength == 0)
                {
                    str.Append(System.Environment.NewLine);
                }
                else
                {
                    str.Append(" ");
                }
            }

            txtLog.Text = str.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtData.Text = txtData.Text.Trim();
            txtLog.Text = "";

            int i = 0;
            int dataLength = txtData.Text.Length;
            
            if (dataLength % 2 != 0)
            {
                MessageBox.Show("Data not valid.");
                return;
            }

            byte[] dataBytes = new byte[dataLength / 2];

            while (i < txtData.Text.Length)
            {
                dataBytes[i/2] = Convert.ToByte(txtData.Text.Substring(i, 2), 16);
                txtLog.Text += dataBytes[i / 2].ToString() + " ";
                //string byteX 
                i += 2;
            }

            txtLog.Text += System.Environment.NewLine + "Length: " + dataBytes.Length.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtData.Text = txtData.Text.Trim();
            txtLog.Text = "";

            int i = 0;
            int dataLength = txtData.Text.Length;

            if (dataLength % 2 != 0)
            {
                MessageBox.Show("Data not valid.");
                return;
            }

            byte[] dataBytes = new byte[dataLength / 2];

            while (i < txtData.Text.Length)
            {
                dataBytes[i / 2] = Convert.ToByte(txtData.Text.Substring(i, 2), 16);
                //txtLog.Text += dataBytes[i / 2].ToString() + " ";
                //string byteX 
                i += 2;
            }

            txtLog.Text += System.Environment.NewLine + "Length: " + dataBytes.Length.ToString();

            txtLog.Text += System.Environment.NewLine + "Begin Parse";

            T1800 t1800 = T1800.Parse(dataBytes);

            txtLog.Text += System.Environment.NewLine + "End Parse";
            txtLog.Text += System.Environment.NewLine + "CoilNo: " + t1800.R0025;

            txtLog.SelectAll();
            txtLog.Focus();
        }
    }
}