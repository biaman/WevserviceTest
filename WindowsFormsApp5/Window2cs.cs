using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Window2cs : UserControl
    {
        public Window2cs()
        {
            InitializeComponent();
        }
        public Window2cs(Form2 form):this()
        {
            mainForm = form;
        }
        #region 實例
        HuaTongWebReference1.WebService1 hWebService = null;
        Form2 mainForm;
       
        //Thread tProduct;
        
        Form3 form3;
        //bool threadFlag = false;
        static AutoResetEvent myResetEvent = new AutoResetEvent(false);
        static AutoResetEvent ChangeEvent = new AutoResetEvent(false);
        //bean声明
        
        public delegate void circleIngnore();
        //string checkString;
        MessageModel mModel;
        #endregion

        //串口事件
        private void MiscroSP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string barcode = string.Empty;
                int num = MiscroSP.BytesToRead;
                if (num > 0)
                {
                    byte[] buffer = new byte[1024];
                    int len = MiscroSP.Read(buffer, 0, buffer.Length);
                    string s = string.Empty;
                    if(buffer!=null)
                    {
                        for(int i=0;i<len;i++)
                        {
                           s += Convert.ToChar(buffer[i]);
                        }

                        mModel.ProductCode = s;
                    }
                    
                    //msg.ProductCode = byToHexStr(buffer, len);
                    textBox2.Text = mModel.ProductCode;
                    textBox4.Text += "Barcode:"+ mModel.ProductCode + "\r\n";
                    if(time1Num!=0)
                    {
                        time1Num--;
                    }
                    timer1.Enabled = true;
                }
                MiscroSP.DiscardInBuffer();
                textBox1.Text = "Barcode:" + mModel.ProductCode;
                mModel.Productions = mModel.ProductCode;
                SendProducts();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        //发送数据至服务器
        private void SendProducts()
        {
            try
            {                
                if (mModel.IsConnect == true)
                {
                    if (mModel.IsSave == false)
                    {
                        //tWebService = new Thread(new ThreadStart(SendToWeb));
                        //tWebService.Start();
                        SendToWeb();
                        if (mModel.IsSave == true)
                        {
                            textBox4.Text += "網絡中断，數據將保存在本地" + "\r\n";
                            SaveProducts();
                        }
                    }
                    else if (mModel.IsSave == true)
                    {
                        mModel.IsConnect = false;
                        textBox4.Text += "網絡中断，數據將保存在本地" + "\r\n";
                        SaveProducts();
                    }
                }
                else {
                    Thread tCheck = new Thread(new ThreadStart(CkeckConnect));
                    tCheck.Start();
                    SaveProducts();
                }
            }
            catch (Exception exception)
            {
                textBox4.Text += exception.Message + "\r\n";

            }
        }
        //检测连接状态
        private void CkeckConnect()
        {

            try
            {
                hWebService.Connection();
                if (!mModel.Isform3Alive)
                {
                    form3 = new Form3(this);
                    form3.Show();
                    Application.Run();

                    //form3.Focus();
                }

            }
            catch (ArgumentException)
            {
                this.Invoke(new Action(() =>
                {
                    ConnectStatus();
                }));
            }
            catch
            { }
            
            //Openform3();        
        }

        public void ConnectStatus()
        {
            if(mModel.IsConnect)
            { 
            textBox4.AppendText("已連接至服務器\r\n");
            label1.ForeColor = Color.Green;
            label1.Text = "已連接";
            mainForm.SetToolstripValue();
            }
            else if(!mModel.IsConnect)
            {
                textBox4.AppendText("沒有網絡，數據將保存在本地" + "\r\n");               
                label1.ForeColor = Color.Red;
                label1.Text = "已斷開連接";              
            }
        }



        //數據保存
        public void SaveProducts()
        {         
            string pathtime = DateTime.Now.ToString("yyyy-MM-dd");
            if (mModel.ProductId != mModel.ProductId2) { 
            string path = string.Format("D:\\Products\\{0}\\{1}基本信息.txt", pathtime, mModel.ProductId);
                mModel.ProductId2 = mModel.ProductId;
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textWrite = new StreamWriter(fs, Encoding.UTF8);
            textWrite.Write(mModel.Factory + "," + mModel.LineNumber + "," + mModel.LineId + "," + mModel.ProcessId);
            textWrite.Close();
            fs.Close();
            }
            string path1 = string.Format("D:\\Products\\{0}\\{1}Barcode.txt", pathtime, mModel.ProductId);
            string time = DateTime.Now.ToString("HH_mm_ss_fff");
           
            FileStream fs1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
            StreamWriter textWrite1 = new StreamWriter(fs1, Encoding.UTF8);
            textWrite1.Write(time + "\t" + mModel.Productions + "\r\n");
            textWrite1.Close();            
            fs1.Close();
        }
        public void SendToWeb()
        {
            try {
                string s = hWebService.SendBarcodes(mModel.ProductCode, mModel.ProductId);
                mModel.IsSave = false;
                if(s=="OK")
                {
                    //textBox4.Text += "匹配通過" + "\r\n";
                }
                else
                {
                    LightSP.Write(openByte, 0, openByte.Length);
                }
            }catch(Exception ex)
            {
                mModel.IsSave = true;
                mModel.IsConnect = false;
            }
           //checkString = PostWebRequest( msg.Productions);
        }
        //16进制转为字符串
        public static string byToHexStr(byte[] bytes, int Length)
        {

            string Str = "";

            if (bytes != null)
            {
                for (int i = 0; i < Length; i++)
                {
                    Str += bytes[i].ToString("X2");
                }
            }

            return Str;
        }
        //将数据Post至服务器
        private string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;
            try
            {
                if (!postUrl.StartsWith("http://"))
                    return "url地址出错！";
                byte[] byteArray = Encoding.Default.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                textBox4.Text += ex.Message + "\r\n";
                return ex.Message;
            }
            return ret;
        }
        //時鐘事件 读码器防呆
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                time1Num++;
                if (time1Num == 20)
                {
                    timer1.Enabled = false;
                    if(MiscroSP.IsOpen)
                    { 
                    textBox4.Text = "讀碼器斷開連接了" + "\r\n";
                        button1.Visible = true;
                    LightSP.Write(openByte, 0, openByte.Length);
                    time1Num = 0;
                    }
                }
                
            }
            catch (Exception exception)
            {
                textBox4.Text += exception.Message + "\r\n";
            }
        }
        
        //时钟事件报警灯防呆
        private void timer2_Tick(object sender, EventArgs e)
        {
            time2Num++;
            if(time2Num == 20)
            {
                timer2.Enabled = false;
                textBox4.Text = "報警燈斷開連接了" + "\r\n";
                button2.Visible = true;
                //LightSP.Write(openByte, 0, openByte.Length);
                time2Num = 0;
            }
        }
        private void Window2cs_Load(object sender, EventArgs e)
        {
            hWebService = new HuaTongWebReference1.WebService1();
            mModel = MessageModel.instance();
            mModel.TimerFlag1 = false;
            mModel.TimerFlag2 = false;
            mModel.TimerFlag3 = false;
            mModel.Isform3Alive = false;
            mModel.IsSave = false;
            string pathtime = DateTime.Now.ToString("yyyy-MM-dd");
            ConnectToSerip();
            if (!Directory.Exists("D:\\Products\\" + pathtime))
            {
                Directory.CreateDirectory("D:\\Products\\" + pathtime);
            }
        }

        private void ConnectToSerip()
        {
            try {
                if (!MiscroSP.IsOpen)
                {
                    MiscroSP.Open();
                    button1.Visible = false;
                }
            }
            catch
            {
                button1.Visible = true;
                textBox4.AppendText("串口COM2異常，未能正常打開讀碼器的連接,請檢查串口COM2是否被佔用,或者串口线是否連接，是否接觸不良;\r\n");
            }
            try { 
            if (!LightSP.IsOpen)
            {
                LightSP.Open();
                    button2.Visible = false;
            }
            
            }catch
            {
                button2.Visible = true;
                textBox4.AppendText("串口COM1異常，未能正常打開報警燈的連接,請檢查串口COM1是否被佔用,或者串口線是否連接，是否接觸不良;\r\n");
            }
        }

        public void TextBox4Add()
        {
            throw new ArgumentException();
            
        }        
        #region IO串口
        string dataReceived = null;
        byte[] openByte = { 0xAA, 0x01, 0x06, 0x0A, 0x00 };
        byte[] closeByte = { 0xAA, 0x01, 0x06, 0x0B, 0x00 };
        int time1Num = 0;
        int time2Num = 0;
        #endregion
        private void LightSP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int i = LightSP.BytesToRead;
                if(i>0)
                {
                    byte[] bit = new byte[1024];
                    int len = LightSP.Read(bit, 0, 1024);
                    dataReceived = byToHexStr(bit, len);
                }
                if (dataReceived.Contains("AA") && i > 4)
                {
                    if(dataReceived.Contains("AA01060A00"))
                    {
                        if(time2Num!=0)
                        {
                            time2Num--;
                        }
                        timer2.Enabled = true;
                    }
                }
                }
            catch (Exception)
            { }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox4.SelectionStart = this.textBox4.Text.Length;
            this.textBox4.SelectionLength = 0;
            this.textBox4.ScrollToCaret();
            //textBox4.AppendText(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                textBox4.AppendText("檢測讀碼其連接情況\r\n");
            if(!MiscroSP.IsOpen)
            {
                textBox4.AppendText("嘗試連接讀碼器\r\n");
                MiscroSP.Open();
                textBox4.AppendText("讀碼器連接成功\r\n");
                button1.Visible = false;
            }
            }
            catch { }
        }
    }
}
