﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        #region 實例
        Windows1cs form1;
        Window2cs form2;
        MessageModel mModel;
        Form1 firForm;
        HuaTongWebReference1.WebService1 webService;
        #endregion
        private void Form2_Load(object sender, EventArgs e)
        {
            
            fun1();
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                this.Width, this.Height, BoundsSpecified.Location);
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);
            
            mModel = MessageModel.instance();
            webService = new HuaTongWebReference1.WebService1();

            //Thread t = new Thread(new ThreadStart(initForm2));
            //t.Start();
            
            
        }

        public void closeForm()
        {
            this.close = true;
            this.Close();
            
        }
        public void fun1()
        {
            form1 = new Windows1cs(this);
            this.Width = 425;
            this.Height = 327;
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width, this.Height, BoundsSpecified.Location);
            
            form1.Show();
            groupBox3.Controls.Clear();
            groupBox3.Controls.Add(form1);
        }
       public void fun()
        {
            try
            {
                form2 = new Window2cs(this);
                this.Width = 885;
                this.Height = 496;
                this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                this.Width, this.Height, BoundsSpecified.Location);
                form2.Show();
                groupBox3.Controls.Clear();
                groupBox3.Controls.Add(form2);
                setToolstrip();
                toolStripStatusLabel1.Text = mModel.Factory;
                    toolStripStatusLabel2.Text = mModel.LineId;
                toolStripStatusLabel3.Text = mModel.LineNumber;
                    toolStripStatusLabel4.Text = mModel.ProcessId;
                    toolStripLabel1.Text = "工號：" + mModel.UserId;
                    toolStripLabel2.Text = "批號：" + mModel.ProductId;
                

            }
            catch (Exception exception)
            {
                
                MessageBox.Show(exception.Message);
            }
        }

    
       public bool close = false;
       

        private void productIdtxt_Validated(object sender, EventArgs e)
        {
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(close == true)
            {            
            firForm = new Form1();
            firForm.Show();
            }
            else { 
            System.Environment.Exit(0);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void setToolstrip()
        {
            toolStrip1.Visible = true;
            statusStrip1.Visible = true;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

            fun1();
            toolStrip1.Visible = false;
            statusStrip1.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //public GroupBox GetgroupBox()
        //{
        //    return this.groupBox3;
        //}
    }
}
