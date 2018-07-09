using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }
        #region 實例
        Window2cs form2;//第二主窗口实例
        MessageModel mModel;//model类
        
        WebReference.Service huaTongWebService;//服务引用
        //public delegate void ShowEventHandle(object sender, EventArgs e);
        Thread CheckCon;//检查网络的线程
        //ShowEventHandle showEvent = null;
        #endregion
            /// <summary>
            /// 窗体加载方法
            /// </summary>
            /// <param name="sender">本窗体</param>
            /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                this.Width, this.Height, BoundsSpecified.Location);// 窗体剧中
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND); //窗体渐变          
            form2 = new Window2cs();
            mModel = MessageModel.instance();
            huaTongWebService = new WebReference.Service();
            timer1.Enabled = true;           
        }
        /// <summary>
        /// 检测网络连接
        /// </summary>
        private void CheckConnect()
        {
            try {
                mModel.Timer1Wait++;
                huaTongWebService.Discover();
                mModel.IsConnect = true;                                                
                mModel.Timer1Wait--;                    
            }
            catch
            {
               
            }
        }
        //点击进入输入界面
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {     
                StartRunForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //窗体
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckCon = new Thread(new ThreadStart(CheckConnect));
            CheckCon.Start();
            label1.Text += ".  ";
            if (label1.Text.Length >= 45)
            { 
                label1.Text = "";
            }  
            if(mModel.IsConnect ==true)
            {
                timer1.Enabled = false;
                label2.Text = "連接成功";
                StartRunForm();
            }
            if (mModel.Timer1Wait >= 5)
            {
                timer1.Enabled = false;
                label2.Text = "連接超時";
                button1.Visible = true;
                button2.Visible = true;
                mModel.Timer1Wait = 0;
                MessageBox.Show("未能成功連接至服務器，請檢查網絡是否暢通，網線是否插好，網絡檢測後點擊重新連接進入重連，若網絡段時間內無法連接，請進入無連接運行");
            }
        }
        //进入输入界面的方法
        private void StartRunForm()
        {
            
            Form2 MainForm = new Form2();
            MainForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Text = "";
            label2.Text = "";
            mModel.Timer1Wait = 0;
            button1.Visible = false;
            button2.Visible = false;
        }
    }
}
