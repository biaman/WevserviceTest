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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        Windows1cs form;
        public Form6(Windows1cs form):this()
        {
            this.form = form;
        }
        MessageModel mModel = MessageModel.instance();
        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox1.Text;
            if(pass.Trim()!="")
            { 
            if(MD5Cls.md5(pass)==mModel.Password||MD5Cls.md5(pass)==mModel.Managepass)
            {
                    label1.Text = "";
                    this.Hide();
                    Form5 form4 = new Form5(form);
                    form4.Show();
                    
            }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "密碼錯誤";
                }
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "密碼不能為空";
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
