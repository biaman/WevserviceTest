using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        Form6 form6;
        MessageModel mModel;
        public UserControl3(Form6 form6) : this()
        {
            this.form6 = form6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("確定修改廠區信息嗎？", "否", messbutton);
            if (dr == DialogResult.OK)
            {
                mModel.Factory = comboBox1.SelectedIndex.ToString();
                mModel.LineId = comboBox2.SelectedIndex.ToString();
                mModel.LineNumber = comboBox3.SelectedIndex.ToString();
                mModel.ProcessId = comboBox4.SelectedIndex.ToString();
                form6.Close();

            }
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            mModel = MessageModel.instance();
            InitForm();
        }
        private void InitForm()
        {
            comboBox1.Items.AddRange((object[])mModel.Factories);
            comboBox2.Items.AddRange((object[])mModel.LineIds);
            comboBox3.Items.AddRange((object[])mModel.LineNumbers);
            comboBox4.Items.AddRange((object[])mModel.ProcessIds);
            comboBox1.SelectedIndex = Convert.ToInt32(mModel.Factory);
            comboBox2.SelectedIndex = Convert.ToInt32(mModel.LineId);
            comboBox3.SelectedIndex = Convert.ToInt32(mModel.LineNumber);
            comboBox4.SelectedIndex = Convert.ToInt32(mModel.ProcessId);

        }
    }
}
