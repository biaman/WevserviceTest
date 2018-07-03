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
        WebReference.Service hWebservice;
        bool flag1 = false;
        bool flag2 = false;
        bool flag = false;
        Window2cs Window;
        #endregion
        private void textBox1_Validated(object sender, EventArgs e)
        {
            string s1 = hWebservice.xxcc_work_num_f(mModel.Factories[Convert.ToInt32(mModel.Factory)], textBox1.Text, mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)], mModel.LineIds[Convert.ToInt32(mModel.LineId)]);
            if ( s1=="OK")
            {
                mModel.UserId = textBox1.Text;
                flag1 = true;
                label4.ForeColor = Color.Green;
                label4.Text = "OK";
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = s1;
                flag1 = false;
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            string s2 = hWebservice.XXCC_LOT_PC_F(mModel.Factories[Convert.ToInt32(mModel.Factory)], textBox2.Text, mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)], mModel.LineIds[Convert.ToInt32(mModel.LineId)], mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)], mModel.P_LOT_TYPE);
            if (s2=="OK")
            {
                
                string ssss = hWebservice.getPartnum(textBox2.Text);
                mModel.ProductNum = ssss.Substring(0, ssss.IndexOf(","));
                textBox3.Text = mModel.ProductNum;
                mModel.ProductId = textBox2.Text;
                flag2 = true;
                //mModel.ProductNum = textBox3.Text;
                label5.ForeColor = Color.Green;
                label5.Text = "OK";
            }
            else
            {
                
                label5.ForeColor = Color.Red;
                label5.Text = s2;
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
            hWebservice = new WebReference.Service();
            mModel = MessageModel.instance();
            mModel.Isform3Alive = true;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(flag==true)
            {
                mModel.IsSave = false;
                mModel.IsConnect = true;

                hWebservice.INSERT_CM_WIP_PROCESS_LINE_HISTORY(mModel.Factories[Convert.ToInt32(mModel.Factory)], mModel.LineIds[Convert.ToInt32(mModel.LineId)], mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)], mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)], mModel.UserId, mModel.ProductId, mModel.P_LOT_TYPE,"");
                Window.TextBox4Add();
            }
            else
            {
                flag = false;
            }
            mModel.Isform3Alive = false;
        }

        private void Form3_Click(object sender, EventArgs e)
        {
            if(textBox1.Focused ==true)
            {
                textBox1_Validated(sender, e);
            }
            if(textBox2.Focused == true)
            {
                textBox2_Validated(sender, e);
            }
        }
    }
}
