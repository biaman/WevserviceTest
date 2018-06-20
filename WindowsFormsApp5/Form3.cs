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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Window2cs form):this()
        {
            Window = new Window2cs();
        }
        #region 實例
        MessageModel mModel;
        HuaTongWebReference1.WebService1 hWebservice;
        bool flag1 = false;
        bool flag2 = false;
        bool flag = false;
        Window2cs Window;
        #endregion
        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (hWebservice.xxcc_work_num_f(mModel.Factory,textBox1.Text,mModel.ProcessIds[0], mModel.LineIds[0]) =="OK")
            {
                mModel.UserId = textBox1.Text;
                flag1 = true;
                label4.Text = "";
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = hWebservice.xxcc_work_num_f(mModel.Factory, textBox1.Text, mModel.ProcessIds[0], mModel.LineIds[0]);
                flag1 = false;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if(hWebservice.XXCC_LOT_PC_F(mModel.Factory,textBox2.Text,mModel.ProcessIds[0])=="OK")
            {
                
                string ssss = hWebservice.GetPartnum(textBox2.Text);
                mModel.ProductNum = ssss.Substring(0, ssss.IndexOf("，"));
                textBox3.Text = mModel.ProductNum;
                mModel.ProductId = textBox2.Text;
                flag2 = true;
                //mModel.ProductNum = textBox3.Text;
                label5.Text = "";
            }
            else
            {
                
                label5.ForeColor = Color.Red;
                label5.Text = hWebservice.XXCC_LOT_PC_F(mModel.Factory, textBox2.Text, mModel.ProcessIds[0]);
                flag2 = false;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()== ""||textBox2.Text.Trim()=="")
            {
                MessageBox.Show("輸入不能為空");
            }
            else if(flag1==false||flag2==false)
            {
                MessageBox.Show("驗證未通過");
            }
            else
            {
                flag = true;
                this.Close();
            }
            
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            hWebservice = new HuaTongWebReference1.WebService1();
            mModel = MessageModel.instance();
            mModel.Isform3Alive = true;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(flag==true)
            {
                mModel.IsSave = false;
                mModel.IsConnect = true;

                hWebservice.SendBasicMessage(mModel.Factory, mModel.LineIds[0], mModel.LineNumbers[0], mModel.ProcessIds[0], mModel.UserId, mModel.ProductId, mModel.ProductNum);
                Window.TextBox4Add();
            }
            else
            {
                flag = false;
            }
            mModel.Isform3Alive = false;
        }
    }
}
