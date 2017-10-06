using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kvics.HotMill.Forms
{
    public partial class RangeForm : Form
    {
        public RangeForm()
        {
            InitializeComponent();
        }

        double _MaxValue = 1000;
        public double MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                if (value > 0)
                {
                    _MaxValue = value;
                }
            }
        }

        private void RangeForm_Load(object sender, EventArgs e)
        {
            txtMaxValue.Text = _MaxValue.ToString();
            txtMaxValue.Focus();
            txtMaxValue.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double inputtedValue = Convert.ToDouble(txtMaxValue.Text.Trim());
                if (inputtedValue <= 0)
                {
                    throw new Exception();
                }
                this.MaxValue = inputtedValue;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                txtMaxValue.Focus();
                txtMaxValue.SelectAll();
            }
        }
    }
}