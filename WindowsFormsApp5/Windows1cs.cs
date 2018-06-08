using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp5
{
    public partial class Windows1cs : UserControl
    {
        public Windows1cs()
        {
            InitializeComponent();
        }
        public Windows1cs(Form2 f) : this()
        {
            form2 = f;
        }
        Form2 form2;
        MessageModel mModel = MessageModel.instance();
        HuaTongWebReference1.WebService1 webService = new HuaTongWebReference1.WebService1();
        //重连数据保存
        private void button2_Click(object sender, EventArgs e)
        {
            mModel.UserId = userIdtxt.Text;
            mModel.ProductId = productIdtxt.Text;
            mModel.ProductNum = productNumtxt.Text;

            form2.closeForm();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //工号验证
        private void userIdtxt_Validated(object sender, EventArgs e)
        {
            if (mModel.IsConnect == true)
            {
                try
                {
                    string message = webService.xxcc_work_num_f(mModel.Factory,userIdtxt.Text,mModel.ProcessId,mModel.LineNumber);
                    if (message != "OK")
                    {
                        label8.ForeColor = Color.Red;
                        label8.Text = message;
                        mModel.IsFlag = false;
                    }
                    else
                    {
                        label8.Text = "";
                        mModel.IsFlag = true;
                    }
                }
                catch
                {
                    mModel.IsConnect = false;
                    initForm2();
                    MessageBox.Show("連接有誤");

                }
            }
            else
            {

            }
        }
        //批号验证
        private void productIdtxt_Validated(object sender, EventArgs e)
        {

            if (mModel.IsConnect == true)
            {
                try
                {
                    string message = webService.XXCC_LOT_PC_F(mModel.Factory,productIdtxt.Text,mModel.ProcessId);
                    if (message == "OK")
                    {
                        mModel.IsFlag1 = true;
                        label9.Text = "";
                        getProductNum();
                        //productNumtxt.Text = message;
                        
                    }
                    else
                    {
                        label9.ForeColor = Color.Red;
                        label9.Text = message;
                        mModel.IsFlag1 = false;
                    }
                }
                catch
                {
                    mModel.IsConnect = false;
                    initForm2();
                    MessageBox.Show("連接有誤");
                }
            }
        }
        //获取料号
        private void getProductNum()
        {
            string ssss = webService.GetPartnum(productIdtxt.Text);
            //int i = ssss.IndexOf("，");
            mModel.ProductNum = ssss.Substring(0, ssss.IndexOf("，"));
            productNumtxt.Text = mModel.ProductNum;
        }
        //连接状态改变更新界面
        private void initForm2()
        {
            userIdtxt.Text = mModel.UserId ?? "";
            productIdtxt.Text = mModel.ProductId ?? "";
            if (mModel.IsConnect == true)
            {
                //mModel.ProductNum = webService.CheckProductsId(mModel.ProductId);
                productNumtxt.Text = mModel.ProductNum;
            }
            else
            {
                productNumtxt.Enabled = true;
                productNumtxt.Text = mModel.ProductNum ?? "";
                button2.Visible = true;
            }
        }
        //跳转到读码界面
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (userIdtxt.Text.Trim() == null || userIdtxt.Text.Trim() == "" || productIdtxt.Text.Trim() == null || productIdtxt.Text.Trim() == "")
                {
                    throw new Exception("輸入不能為空");
                }
                if (mModel.IsConnect == true)
                {
                    if (mModel.IsFlag == false||mModel.IsFlag1 == false)
                    {
                        throw new Exception("請檢查輸入");
                    }
                }
                Thread s = new Thread(new ThreadStart(newForm));
                s.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mModel.Factory = label4.Text;
                mModel.LineId = label3.Text;
                mModel.LineNumber = label5.Text;
                mModel.ProcessId = label6.Text;
                mModel.UserId = userIdtxt.Text;
                mModel.ProductId = productIdtxt.Text;


            }
        }

        private void newForm()
        {
            try
            {
                webService.SendProduct("basicMessage");
            }
            catch
            {
                mModel.IsConnect = false;
            }
            finally
            {
                this.BeginInvoke(new Action(() => { form2.fun(); }));
            }

        }

        private void Windows1cs_Load(object sender, EventArgs e)
        {
            initForm2();
        }
    }
}
