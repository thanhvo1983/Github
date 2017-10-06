using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;
using Kvics.Utility;

namespace DummyProcon
{
    public partial class ParseTestingForm : Form
    {
        public ParseTestingForm()
        {
            InitializeComponent();
        }

        private void btnT900_Parse_Click(object sender, EventArgs e)
        {
            try
            {
                lblT900_Status.ForeColor = Color.DarkOrange;
                lblT900_Status.Text = "";

                byte[] bytes = GetBytes(txtT900_Data.Text.Trim());

                T900 t900 = T900.Parse(bytes);
                if (t900 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }
                lblT900_Status.Text = "Parse successful. CoilNo: " + t900.R025;
            }
            catch (Exception ex)
            {
                lblT900_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT900_Status.ForeColor = Color.Red;
            }
        }

        private void btnT800_Parse_Click(object sender, EventArgs e)
        {
            try
            {
                lblT800_Status.ForeColor = Color.DarkOrange;

                byte[] bytes = GetBytes(txtT800_Data.Text.Trim());

                T800 t800 = T800.Parse(bytes);
                if (t800 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }
                lblT800_Status.Text = "Parse successful. CoilNo: " + t800.R025;
            }
            catch (Exception ex)
            {
                lblT800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT800_Status.ForeColor = Color.Red;
            }
        }

        private void btnT1800_Parse_Click(object sender, EventArgs e)
        {
            try
            {
                lblT1800_Status.ForeColor = Color.DarkOrange;

                byte[] bytes = GetBytes(txtT1800_Data.Text.Trim());

                T1800 t1800 = T1800.Parse(bytes);
                if (t1800 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }
                lblT1800_Status.Text = "Parse successful. CoilNo: " + t1800.R0025;
            }
            catch (Exception ex)
            {
                lblT1800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT1800_Status.ForeColor = Color.Red;
            }
        }

        private byte[] GetBytes(string value)
        {
            int discarded = 0;
            byte[] bytes = HexEncoding.GetBytes(value, out discarded);

            return bytes;
        }
    }
}