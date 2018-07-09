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
        UserControl1 userWindow1;
        UserControl2 userWindow2;
        UserControl3 userWindow3;
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
                  
                    mModel.IsLockKeyboard = true;
                    form.BindKeyBoardHook();
                    fun1();
                    
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
            this.SetBounds((Screen.GetBounds(this).Width/4) - (this.Width),
                (Screen.GetBounds(this).Height/2) - (this.Height),
                this.Width, this.Height, BoundsSpecified.Location);
            form.UninKeyBoardHook();
            mModel.IsLockKeyboard = true;
            label1.Text = "";
        }
        public void fun()
        {
            form.UninKeyBoardHook();
        }
        public void fun1()
        {
            try {
                this.Width = 280;
                this.Height = 255;
                this.Text = "功能選擇";
                userWindow1 = new UserControl1(this);
                userWindow1.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(userWindow1);
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public void fun2()
        {
            this.Width = 363;
            this.Height = 232;
            this.Text = "密碼修改";
            userWindow2 = new UserControl2(this);          
            userWindow2.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(userWindow2);
        }
        public void fun3()
        {
            this.Width = 380;
            this.Height = 332;
            this.Text = "信息修改";
            userWindow3 = new UserControl3(this);
            userWindow3.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(userWindow3);
        }
        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(mModel.IsLockKeyboard==true)
            {
                form.BindKeyBoardHook();
            }
            else
            {
                form.UninKeyBoardHook();
            }
            form.initForm2();
        }
    }
}
