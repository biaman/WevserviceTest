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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        Form6 form6;
        public UserControl2(Form6 form6):this()
        {
            this.form6 = form6;
        }
        bool flag1;
        bool flag2;
        MessageModel mModel; 

        private void button1_Click(object sender, EventArgs e)
        {

            if (flag1 == false || flag2 == false)
            {
                MessageBox.Show("上方驗證未通過,請重新輸入");
            }
            else
            {
                MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("確定修改密碼嗎？", "否", messbutton);
                if (dr == DialogResult.OK)
                {
                    mModel.Password = textBox1.Text;
                    form6.Close();
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length < 6)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "密碼位數最少為6位";
                flag1 = false;
            }
            else
            {
                label3.Text = "";
                flag1 = true;

            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != textBox1.Text)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "兩次輸入的密碼不一致";
                flag2 = false;
            }
            else
            {
                label4.Text = "";
                flag2 = true;
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            form6.fun();
            mModel = MessageModel.instance();
        }
    }
}
