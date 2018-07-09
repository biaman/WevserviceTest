using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

namespace WindowsFormsApp5
{
    public partial class Windows1cs : UserControl
    {
        public Windows1cs()
        {
            InitializeComponent();
            BindKeyBoardHook();
        }
        public Windows1cs(Form2 f) : this()
        {
            form2 = f;
        }
        Form2 form2;
        MessageModel mModel = MessageModel.instance();
        WebReference.Service webService = new WebReference.Service();
        private KeyBoardHookLib _keyBoardHook = null;
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
                    string message = webService.xxcc_work_num_f(mModel.Factories[Convert.ToInt32(mModel.Factory)],userIdtxt.Text,mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)], mModel.LineIds[Convert.ToInt32(mModel.LineId)]);
                    //MessageBox.Show("工廠：" + mModel.Factories[Convert.ToInt32(mModel.Factory)] + "工號：" + userIdtxt.Text + "製程：" + mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)] + "線別：" + mModel.LineIds[Convert.ToInt32(mModel.LineId)]);
                    if (message != "OK")
                    {
                        label8.ForeColor = Color.Red;
                        label8.Text = message;
                        mModel.IsFlag = false;
                    }
                    else
                    {
                        label8.ForeColor = Color.Green;
                        label8.Text = message;
                        mModel.IsFlag = true;
                        productIdtxt.Focus();
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
                    string message = webService.XXCC_LOT_PC_F(mModel.Factories[Convert.ToInt32(mModel.Factory)],productIdtxt.Text,mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)],mModel.LineIds[Convert.ToInt32(mModel.LineId)],mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)],"1");
                    //MessageBox.Show(mModel.Factories[Convert.ToInt32(mModel.Factory)]+"," +productIdtxt.Text + "," + mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)] + "," + mModel.LineIds[Convert.ToInt32(mModel.LineId)] + "," + mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)] + "," + "1");
                    if (message == "OK")
                    {
                        mModel.IsFlag1 = true;
                        label9.ForeColor = Color.Green;
                        label9.Text = message;
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
            string ssss = webService.getPartnum(productIdtxt.Text);
            //int i = ssss.IndexOf("，");
            mModel.ProductNum = ssss.Substring(0, ssss.IndexOf(","));
            productNumtxt.Text = mModel.ProductNum;
        }
        //连接状态改变更新界面
        public void initForm2()
        {
           
            label4.Text ="廠區：" +mModel.Factories[Convert.ToInt32(mModel.Factory)]+"厰";
            label3.Text = "製程名："+mModel.LineIds[Convert.ToInt32(mModel.LineId)];
            label5.Text = "線別："+mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)];
            label6.Text = "製程代號："+mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)];
            userIdtxt.Text = mModel.UserId ?? "";
            productIdtxt.Text = mModel.ProductId ?? "";
            
            bool flag =userIdtxt.Focus();
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
                //mModel.UserId = userIdtxt.Text;
                //mModel.ProductId = productIdtxt.Text;


            }
        }
        
        private void newForm()
        {
            try
            {
                if (!mModel.IsConnect)
                {
                    mModel.UserId = userIdtxt.Text;
                    mModel.ProductId = productIdtxt.Text;
                    MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("網絡斷開是否進入無網絡讀碼？", "否", messbutton);
                    if (dr == DialogResult.OK)
                    {
                        this.BeginInvoke(new Action(() => { form2.fun(); }));
                    }
                }
                else
                {
                    string ss = webService.INSERT_CM_WIP_PROCESS_LINE_HISTORY(mModel.Factories[Convert.ToInt32(mModel.Factory)], userIdtxt.Text, productIdtxt.Text, mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)], mModel.LineIds[Convert.ToInt32(mModel.LineId)], mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)], mModel.P_LOT_TYPE, "");
                    //MessageBox.Show(mModel.Factories[Convert.ToInt32(mModel.Factory)]+","+userIdtxt.Text+","+productIdtxt.Text + "," + mModel.ProcessIds[Convert.ToInt32(mModel.ProcessId)] + "," + mModel.LineIds[Convert.ToInt32(mModel.LineId)] + "," + mModel.LineNumbers[Convert.ToInt32(mModel.LineNumber)] + "," + mModel.P_LOT_TYPE);
                    if (ss != "OK")
                    {
                        MessageBox.Show(ss);
                    }
                    else
                    {
                        mModel.IsLockKeyboard = true;
                        BindKeyBoardHook();
                        this.BeginInvoke(new Action(() => { form2.fun(); }));

                    }
                }
            }
            catch
            {
                mModel.IsConnect = false;
                mModel.UserId = userIdtxt.Text;
                mModel.ProductId = productIdtxt.Text;
                MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("網絡斷開是否進入無網絡讀碼？", "否", messbutton);
                if (dr == DialogResult.OK)
                {
                    this.BeginInvoke(new Action(() => { form2.fun(); }));
                }
            }
            finally
            {
                
            }

        }

        private void Windows1cs_Load(object sender, EventArgs e)
        {
           
            mModel.P_LOT_TYPE = "正常板";
            label10.Text = "";
            initForm2();
           
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                mModel.P_LOT_TYPE = "正常板";
            }
            else
            {
                mModel.P_LOT_TYPE = "重工板";   
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(this);
            
            form6.ShowDialog() ;
        }

        private void Windows1cs_Click(object sender, EventArgs e)
        {
            if(userIdtxt.Focused ==true)
            { 
            userIdtxt_Validated(sender,e);
            }
            if(productIdtxt.Focused ==true )
            { 
            productIdtxt_Validated(sender, e);
            }
        }
        //客户端键盘捕捉事件
        public void OnKeyPre(KeyBoardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false;//预设不拦截
            if (hookStruct.vkCode == 91)//拦截左win键
            {
                handle = true;
            }
            if (hookStruct.vkCode == 92)//右win
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) ;
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.F1)
            {
                handle = true;
            }
            if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)
            {
                handle = true;
            }
            if (hookStruct.vkCode >= (int)Keys.A && hookStruct.vkCode <= (int)Keys.Z)
            {
                if (hookStruct.vkCode == (int)Keys.B)
                    hookStruct.vkCode = (int)Keys.None;
                handle = true;
            }
            Keys key = (Keys)hookStruct.vkCode;
            //label10.Text = "你按下了：" + (key == Keys.None ? "" : key.ToString());
            label10.ForeColor = Color.Red;
            label10.Text = "不可手動輸入，請掃碼輸入";
        }
        public void BindKeyBoardHook()
        {
            try
            {
                _keyBoardHook = new KeyBoardHookLib();
                _keyBoardHook.InstallHook(this.OnKeyPre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UninKeyBoardHook()
        {

            if (_keyBoardHook != null)
                this.BeginInvoke(new Action(() => { label10.Text = ""; }));
                _keyBoardHook.UninstallHook();
        }
    }
}
