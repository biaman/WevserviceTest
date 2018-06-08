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
        Thread tProduct;
        Thread tWebService;
        bool threadFlag = false;
        static AutoResetEvent myResetEvent = new AutoResetEvent(false);
        static AutoResetEvent ChangeEvent = new AutoResetEvent(false);
        //bean声明
        MessageModel msg = null;
        public delegate void circleIngnore();
        string checkString;
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
                    if(buffer!=null)
                    {
                        for(int i =0;i<len;i++)
                        {
                            barcode += buffer[i].ToString();
                        }
                        msg.ProductCode = barcode;
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

        private void SendProducts()
        {
            try
            {                
                if (msg.IsConnect == true)
                {
                    if (msg.IsSave == false)
                    {
                        tWebService = new Thread(new ThreadStart(SendToWeb));
                        tWebService.Start();

                    }
                    else if (msg.IsSave == true)
                    {
                        textBox4.Text = "網絡終端，數據將保存在本地" + "\r\n";
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

        private void CkeckConnect()
        {
            try
            {
                hWebService.Connection();
                Openform3();
            }
            catch
            {

            }
        }

        private void Openform3()
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        //數據保存
        public void SaveProducts()
        {
            msg.Productions = msg.ProductId + ":" + msg.ProductCode;
            string pathtime = DateTime.Now.ToString("yyyy-MM-dd");
            if (msg.ProductId != msg.ProductId2) { 
            string path = string.Format("D:\\Products\\{0}\\{1}+基本信息.txt", pathtime, msg.ProductId);
            msg.ProductId2 = msg.ProductId;
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textWrite = new StreamWriter(fs, Encoding.UTF8);
            textWrite.Write(msg.Factory + "," + msg.LineNumber + "," + msg.LineId + "," + msg.ProcessId);
            textWrite.Close();
            fs.Close();
            }
            string path1 = string.Format("D:\\Products\\{0}\\{1}+Barcode.txt", pathtime, msg.ProductId);
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
                if(s=="OK")
                {
                    textBox4.Text += "匹配通過" + "r\n";
                }
                else
                {
                    LightSP.Write(openByte, 0, openByte.Length);
                }
            }catch(Exception ex)
            {
                msg.IsSave = true;
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

        private void SendBtn_Click(object sender, EventArgs e)
        {
            msg.Productions = "123:34234";
            tWebService = new Thread(new ThreadStart(SendToWeb));
            tWebService.Start();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            
              
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread tConnec = new Thread(new ThreadStart(TestConnection));
            tConnec.Start();
        }
        public void TestConnection()
        {
           
           
        }

        //時鐘事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                time1Num++;
                if (time1Num == 20)
                {
                    timer1.Enabled = false;
                    textBox4.Text = "讀碼器斷開連接了" + "\r\n";
                    LightSP.Write(openByte, 0, openByte.Length);
                    time1Num = 0;
                }
                //    if (msg.TimerFlag1 == true)
                //    {
                //        msg.TimerWait1++;
                //        if (msg.TimerWait1 == 10)
                //        {
                //            timer1.Enabled = false;
                //            textBox4.Text += "\r\n"+"連接超時"+ "\r\n";
                //        }
                //        else
                //        {
                //            tWeb1 = new Thread(new ParameterizedThreadStart(TestGetOP));
                //            tWeb1.Start(1);
                //            tWeb1.IsBackground = true;
                //            if (msg.IsConnect == false)
                //            {
                //                textBox4.Text += ".";
                //            }
                //            else
                //            {
                //                timer1.Enabled = false;
                //                msg.TimerFlag1 = false;
                //            }
            //}
            //    }
            //    if (msg.TimerFlag2 == true)
            //    {
            //        tProduct = new Thread(new ThreadStart(circles));
            //        tProduct.Start();
            //        if (threadFlag == true)
            //        { textBox4.Text += "."; }
            //    }
            //    if (msg.TimerWait2 == 10)
            //    {
            //        textBox4.Text += "\r\n" + "連接丟失" + "\r\n";
            //        timer1.Enabled = false;
            //    }
            }
            catch (Exception exception)
            {
                textBox4.Text += exception.Message + "\r\n";
            }
        }
        
        private void TestGetOP(object i)
        {
            try
            {
                int s = (int)i;
                switch (s)
                {
                    case 1:
                        msg.IsConnect = hWebService.fun();
                        break;
                    case 2:
                        msg.TimerWait2++;
                        //msg.NewProductId = hWebService.getProduct();
                        msg.TimerWait2--;
                        break;
                }
            }
            catch (Exception) { }
            //{
            //    textBox4.Text += "\r\n" + "連接丟失" + "\r\n";
            //}

            //this.BeginInvoke(new Action(() => {
            //    circleIngnore stcb = new circleIngnore(circles);
            //    Invoke(stcb);
            //}));
        }
        private void circles()
        {
            tWeb2 = new Thread(new ParameterizedThreadStart(TestGetOP));
            tWeb2.Start(2);
            Thread.Sleep(1000);                       
            //if ((threadFlag == false)&&(msg.NewProductId == " " || msg.NewProductId == null))
            //{
                
            //    textBox4.Text += ("未收到产品编号信息" + "\r\n");                
            //    do
            //    {
            //        threadFlag = true;

            //    } while (msg.NewProductId == "" || msg.NewProductId == null);
            //    threadFlag = false;
            //    msg.ProductId = msg.NewProductId;
            //    textBox4.Text += ("\r\n"+"产品序号为：" + msg.ProductId + "\r\n");
            //}
            //if ((msg.NewProductId != " ") && (msg.NewProductId != null) && (msg.NewProductId != "结批信号") && (msg.NewProductId != "結批信號"))
            //{
            //    if (msg.ProductId == null)
            //    {
            //        textBox4.Text += ("开始读取数据" + "\r\n");
            //        msg.ProductId = msg.NewProductId;
            //        textBox4.Text += "产品序号为：" + msg.NewProductId + "\r\n";
                   
            //    }
            //}
            //if ((threadFlag==false)&&(msg.NewProductId == "结批信号"||msg.NewProductId =="結批信號"))
            //{
            //    textBox4.Text += ("准备进入下一批产品数据处理" + "\r\n");                                                              
            //    do
            //    {
            //        //textBox4.Text += (".");
            //        //tWeb2.Start(2);
            //        threadFlag = true;
            //        Thread.Sleep(1000);
            //    }
            //    while (msg.NewProductId == "结批信号" || msg.NewProductId == "結批信號");
            //    msg.ProductId = msg.NewProductId;
            //    threadFlag = false;
            //    textBox4.Text += ("\r\n");
            //    textBox4.Text += ("开始读取数据" + "\r\n");
               
            //    textBox4.Text += "产品批号为：" + msg.ProductId + "\r\n";

            //}

        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            msg.IsSave = true;
            textBox4.Text += "數據將保存在本地" + "\r\n";
            SaveProducts();        
        }

        private void Window2cs_Load(object sender, EventArgs e)
        {
            hWebService = new HuaTongWebReference1.WebService1();
            msg = MessageModel.instance();
            tWeb1 = new Thread(new ParameterizedThreadStart(TestGetOP));
            tWeb2 = new Thread(new ParameterizedThreadStart(TestGetOP));
            tWeb3 = new Thread(new ParameterizedThreadStart(TestGetOP));
            mModel = MessageModel.instance();
            msg.TimerFlag1 = false;
            msg.TimerFlag2 = false;
            msg.TimerFlag3 = false;
            msg.IsSave = false;
            if(!MiscroSP.IsOpen)
            {
                MiscroSP.Open();
            }
            if(!LightSP.IsOpen)
            {
                LightSP.Open();
            }
           if(msg.IsConnect ==false)
            {
                textBox4.Text = ("沒有網絡，數據將保存在本地" + "\r\n");
            }
            if (!Directory.Exists("D:\\Products"))
            {
                Directory.CreateDirectory("D:\\Products");
            }
            initForm();
        }

        private void initForm()
        {
            if (mModel.IsConnect == false)
            {
                button4.Visible = false;
                button5.Visible = false;
                textBox5.Visible = false;
            }
            else
            {
                button4.Visible = true;
                button5.Visible = true;
                textBox5.Visible = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "產品數據文件(*.txt)|*.txt;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog.FileName;
            }
        }

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    Form2 mainForm = new Form2();
        //    mainForm.Show();
            
        //}
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

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox5.Text!="")
            { 
            string path1 = textBox5.Text;
            string path = path1.Substring(path1.LastIndexOf("\\"), mModel.ProductId.Length);
            string path2 ="D:\\Product"+ path + "基本信息.txt";
            FileStream file1 = File.Open(path1, FileMode.Open, FileAccess.Read);
            FileStream file2 = File.Open(path2, FileMode.Open, FileAccess.Read);
                //hWebService.sendFile(file2, file1);
            }
            }

       
    }
}
