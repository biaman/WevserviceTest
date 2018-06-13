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
        Thread tWeb1;
        Thread tWeb2;
        Thread tWeb3;
        //Thread tProduct;
        Thread tWebService;
        Form3 form3;
        //bool threadFlag = false;
        static AutoResetEvent myResetEvent = new AutoResetEvent(false);
        static AutoResetEvent ChangeEvent = new AutoResetEvent(false);
        //bean声明
        MessageModel msg = null;
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
                        
                        msg.ProductCode = s;
                    }
                    
                    //msg.ProductCode = byToHexStr(buffer, len);
                    textBox2.Text = msg.ProductCode;
                    textBox4.Text += "Barcode:"+ msg.ProductCode + "\r\n";
                    if(time1Num!=0)
                    {
                        time1Num--;
                    }
                    timer1.Enabled = true;
                }
                MiscroSP.DiscardInBuffer();
                textBox1.Text = "Barcode:" + msg.ProductCode;
                msg.Productions = msg.ProductCode;
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
                if (msg.IsConnect == true)
                {
                    if (msg.IsSave == false)
                    {
                        //tWebService = new Thread(new ThreadStart(SendToWeb));
                        //tWebService.Start();
                        SendToWeb();
                        if (msg.IsSave == true)
                        {
                            textBox4.Text += "網絡中断，數據將保存在本地" + "\r\n";
                            SaveProducts();
                        }
                    }
                    else if (msg.IsSave == true)
                    {
                        msg.IsConnect = false;
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
                if (!msg.Isform3Alive)
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

        private void ConnectStatus()
        {
            if(msg.IsConnect)
            { 
            textBox4.AppendText("已连接至服务器\r\n");
            label1.ForeColor = Color.Green;
            label1.Text = "已连接";
            mainForm.SetToolstripValue();
            }
            else if(!msg.IsConnect)
            {
                textBox4.AppendText("沒有網絡，數據將保存在本地" + "\r\n");               
                label1.ForeColor = Color.Red;
                label1.Text = "已断开连接";              
            }
        }



        //數據保存
        public void SaveProducts()
        {         
            string pathtime = DateTime.Now.ToString("yyyy-MM-dd");
            if (msg.ProductId != msg.ProductId2) { 
            string path = string.Format("D:\\Products\\{0}\\{1}基本信息.txt", pathtime, msg.ProductId);
            msg.ProductId2 = msg.ProductId;
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textWrite = new StreamWriter(fs, Encoding.UTF8);
            textWrite.Write(msg.Factory + "," + msg.LineNumber + "," + msg.LineId + "," + msg.ProcessId);
            textWrite.Close();
            fs.Close();
            }
            string path1 = string.Format("D:\\Products\\{0}\\{1}Barcode.txt", pathtime, msg.ProductId);
            string time = DateTime.Now.ToString("HH_mm_ss_fff");
           
            FileStream fs1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
            StreamWriter textWrite1 = new StreamWriter(fs1, Encoding.UTF8);
            textWrite1.Write(time + "\t" + msg.Productions + "\r\n");
            textWrite1.Close();            
            fs1.Close();
        }
        public void SendToWeb()
        {
            try {
                string s = hWebService.SendBarcodes(mModel.ProductCode, mModel.ProductId);               
                msg.IsSave = false;
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
                msg.IsSave = true;
                msg.IsConnect = false;
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
                //LightSP.Write(openByte, 0, openByte.Length);
                time2Num = 0;
            }
        }
        private void Window2cs_Load(object sender, EventArgs e)
        {
            hWebService = new HuaTongWebReference1.WebService1();
            msg = MessageModel.instance();         
            mModel = MessageModel.instance();
            msg.TimerFlag1 = false;
            msg.TimerFlag2 = false;
            msg.TimerFlag3 = false;
            msg.Isform3Alive = false;
            msg.IsSave = false;
            string pathtime = DateTime.Now.ToString("yyyy-MM-dd");
            if (!MiscroSP.IsOpen)
            {
                MiscroSP.Open();
            }
            if(!LightSP.IsOpen)
            {
                LightSP.Open();
            }
            ConnectStatus();
            if (!Directory.Exists("D:\\Products\\" + pathtime))
            {
                Directory.CreateDirectory("D:\\Products\\" + pathtime);
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
    }
}
