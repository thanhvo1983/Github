using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;

namespace DummyProcon
{
    public partial class T900ReaderForm : Form
    {
        private T900 _T900 = null;

        public T900ReaderForm()
        {
            InitializeComponent();
        }

        private void btnT900_FileName_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtT900_FileName.Text = openFileDialog1.FileName;
                LoadDataT900();
            }
        }

        private void btnT900_Save_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataT900()
        {
            //string valuesSeparator = ",";
            string fileName = txtT900_FileName.Text;

            try
            {
                string[] fileContents = System.IO.File.ReadAllLines(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
                if (fileContents != null)
                {
                    for (int i = 0; i < fileContents.Length; i++)
                    {
                        if (fileContents[i] != null)
                        {
                            fileContents[i] = fileContents[i].Trim();
                        }
                        _T900 = LoadFromStrings(fileContents);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnT800_FileName_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtT800_FileName.Text = openFileDialog1.FileName;
                LoadDataT800();
            }
        }

        private void btnT800_Save_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataT800()
        {
        }

        private void btnT1800_FileName_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtT1800_FileName.Text = openFileDialog1.FileName;
                LoadDataT1800();
            }
        }

        private void btnT1800_Save_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataT1800()
        {
        }

        private T900 LoadFromStrings(string[] data)
        {
            T900 t900 = new T900();

            return t900;
        }

        /*
        private T_I2_04 FromStrings(ref T_I2_04 t_I2_4, string[] data, int index)
        {
            if (t_I2_4 == null)
            {
                throw new NullReferenceException("Reference t_I2_4 variable can not be null.");
            }

            try
            {
                for (int i = 0; i < t_I2_4.Rows.Length; i++)
                {
                    t_I2_4.Rows[i] = Int16.Parse(data[index + i]);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return t_I2_4;
        }
        */

        private T_I2_R FromStrings(ref T_I2_R t_I2_R, string[] data, int index)
        {
            if (t_I2_R == null)
            {
                throw new NullReferenceException("Reference t_I2_R variable can not be null.");
            }

            try
            {
                for (int i = 0; i < t_I2_R.Rows.Length; i++)
                {
                    t_I2_R.Rows[i] = Int16.Parse(data[index + i]);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return t_I2_R;
        }

    }
}