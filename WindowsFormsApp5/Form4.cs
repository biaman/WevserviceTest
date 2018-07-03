using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Windows1cs form1;
        public Form4(Windows1cs form):this()
        {
            form1 = form;
        }
        MessageModel mModel;
        private void Form4_Load(object sender, EventArgs e)
        {
            this.SetBounds((Screen.GetBounds(this).Width / 1) - (this.Width ),
                (Screen.GetBounds(this).Height / 2) - (this.Height ),
                this.Width, this.Height, BoundsSpecified.Location);
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);
            mModel = MessageModel.instance();
            InitForm();
            
        }

        private void InitForm()
        {
            comboBox1.Items.AddRange((object[])mModel.Factories);
            comboBox2.Items.AddRange((object[])mModel.LineIds);
            comboBox3.Items.AddRange((object[])mModel.LineNumbers);
            comboBox4.Items.AddRange((object[])mModel.ProcessIds);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = Convert.ToInt32(mModel.LineId);
            comboBox3.SelectedIndex = Convert.ToInt32(mModel.LineNumber);
            comboBox4.SelectedIndex = Convert.ToInt32(mModel.ProcessId);           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("確定修改廠區信息嗎？", "否", messbutton);
            if (dr == DialogResult.OK)
            {
                mModel.Factory = comboBox1.SelectedIndex.ToString();
                mModel.LineId = comboBox2.SelectedIndex.ToString() ;
                mModel.LineNumber = comboBox3.SelectedIndex.ToString();
                mModel.ProcessId = comboBox4.SelectedIndex.ToString();
                this.Close();
               
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.initForm2();
        }
    }
}
