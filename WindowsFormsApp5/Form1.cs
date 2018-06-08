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
        Window2cs form2;
        MessageModel mModel;
        HuaTongWebReference1.WebService1 huaTongWebService;
        //public delegate void ShowEventHandle(object sender, EventArgs e);
        Thread CheckCon;
        //ShowEventHandle showEvent = null;
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                this.Width, this.Height, BoundsSpecified.Location);
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);           
            form2 = new Window2cs();
            mModel = MessageModel.instance();
            huaTongWebService = new HuaTongWebReference1.WebService1();
            timer1.Enabled = true;           
        }
        private void CheckConnect()
        {
            try {
                mModel.Timer1Wait++;
                huaTongWebService.Connection();
                mModel.IsConnect = true;                                                
                mModel.Timer1Wait--;                    
            }
            catch
            {
               
            }
        }
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
            if (mModel.Timer1Wait >= 14)
            {
                timer1.Enabled = false;
                label2.Text = "連接超時";
                button1.Visible = true;
                button2.Visible = true;
                mModel.Timer1Wait = 0;
            }
        }

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
