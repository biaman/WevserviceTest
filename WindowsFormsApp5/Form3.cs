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
        #region 實例
        MessageModel mModel;
        HuaTongWebReference1.WebService1 hWebservice;
        bool flag1 = false;
        bool flag2 = false;
        bool flag = true;
        #endregion
        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (hWebservice.xxcc_work_num_f(mModel.Factory,textBox1.Text,mModel.ProcessId,mModel.LineId)=="OK")
            {
                mModel.UserId = textBox1.Text;
                flag1 = true;
                label1.Text = "";
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "請輸入正確的工號";
                flag1 = false;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if(hWebservice.XXCC_LOT_PC_F(mModel.Factory,textBox2.Text,mModel.ProcessId)=="")
            {
                label2.ForeColor = Color.Red;
                label2.Text = "請輸入正確的批號";
                flag2 = false;
            }
            else
            {
                string ssss = hWebservice.GetPartnum(mModel.ProductId);
                mModel.ProductNum = ssss.Substring(0, ssss.IndexOf(","));             
                textBox3.Text = mModel.ProductNum;
                mModel.ProductId = textBox2.Text;
                //mModel.ProductNum = textBox3.Text;
                label2.Text = "";
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
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(flag==true)
            {
                mModel.IsConnect = true;
                hWebservice.SendBasicMessage(mModel.Factory, mModel.LineId, mModel.LineNumber, mModel.ProcessId, mModel.UserId, mModel.ProductId, mModel.ProductNum);
            }
            else
            {
                flag = false;
                    }
        }
    }
}
