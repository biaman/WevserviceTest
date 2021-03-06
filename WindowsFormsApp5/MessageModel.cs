﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp5
{
    class MessageModel
    {
        IniFile iniFile = new IniFile("D:\\FaBasicMessage.ini");
        IniFile inifile = new IniFile("D:\\BasicMessage.ini");
        private static MessageModel mModel = new MessageModel();
        private MessageModel()
        { }
        public static MessageModel instance()
        {
            return mModel;
        }
        private bool _isFlag;
        private bool _isFlag1;
        private string _productId;//批號
        private string _productId2;
        private string _productCode;//barcode
        private string _productions;
        private string _productNum;//料號
        private bool _isConnect;//連接狀態
        private string _userId;//工號
        private string[] _lineIds;//線
        private string lineId;
        private string lineNumber;
        private string processId;
        private string[] _lineNumbers;//線別
        private bool isform3Alive;
        private bool timerFlag1;
        private bool timerFlag2;
        private bool timerFlag3;
        private bool isLockKeyboard;
        private int timer1Wait;
        private int timerWait1;
        private int timerWait2;
        private int timerWait3;
        private bool isSave;
        private string factory;
        private string[] factories;//廠號      
        private string[] processIds;//製程   
        private string password;
        private string managepass;
        private string p_LOT_TYPE;
        public bool IsFlag
        {
            get { return _isFlag; }
            set { _isFlag = value; }
        }
        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }
        public string Productions
        {
            get { return _productions; }
            set { _productions = value; }
        }
        public string ProductNum
        {
            get { return _productNum; }
            set { _productNum = value; }
        }
        public bool IsConnect
        {
            get { return _isConnect; }
            set { _isConnect = value; }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string[] LineIds
        {
            get
            {
                _lineIds = inifile.IniReadByte("製程名");
                return _lineIds;
            }          
        }
        public string[] LineNumbers
        {
            get
            {
                _lineNumbers = inifile.IniReadByte("線別編號");
                return _lineNumbers;
            }           
        }

        public bool TimerFlag1
        {
            get
            {
                return timerFlag1;
            }

            set
            {
                timerFlag1 = value;
            }
        }

        public bool TimerFlag2
        {
            get
            {
                return timerFlag2;
            }

            set
            {
                timerFlag2 = value;
            }
        }

        public bool TimerFlag3
        {
            get
            {
                return timerFlag3;
            }

            set
            {
                timerFlag3 = value;
            }
        }

        public int TimerWait1
        {
            get
            {
                return timerWait1;
            }

            set
            {
                timerWait1 = value;
            }
        }

        public int TimerWait2
        {
            get
            {
                return timerWait2;
            }

            set
            {
                timerWait2 = value;
            }
        }

        public int TimerWait3
        {
            get
            {
                return timerWait3;
            }

            set
            {
                timerWait3 = value;
            }
        }

        public bool IsSave
        {
            get
            {
                return isSave;
            }

            set
            {
                isSave = value;
            }
        }

        public int Timer1Wait
        {
            get
            {
                return Timer1Wait1;
            }

            set
            {
                Timer1Wait1 = value;
            }
        }

        public int Timer1Wait1
        {
            get
            {
                return timer1Wait;
            }

            set
            {
                timer1Wait = value;
            }
        }

        public string[] Factories
        {
            get
            {
                factories = inifile.IniReadByte("廠區");
                return factories;
            }

        }    
        public string[] ProcessIds
        {
            get
            {
                processIds = inifile.IniReadByte("製程代號");
                return processIds;
            }
        }

        public bool IsFlag1
        {
            get
            {
                return _isFlag1;
            }

            set
            {
                _isFlag1 = value;
            }
        }

        public string ProductId2
        {
            get
            {
                return _productId2;
            }

            set
            {
                _productId2 = value;
            }
        }

        public bool Isform3Alive
        {
            get
            {
                return isform3Alive;
            }

            set
            {
                isform3Alive = value;
            }
        }

        public string Password
        {
            get 
            {
                password = iniFile.IniReadValue("廠區信息", "密碼");
                return password;
            }

            set
            {
                password = MD5Cls.md5(value);
                iniFile.WriteString("廠區信息", "密碼", password);
            }
        }

        public string Managepass
        {
            get
            {
                managepass = iniFile.IniReadValue("廠區信息", "密碼1");
                return managepass;
            }

            set
            {
                managepass = MD5Cls.md5(value);
                iniFile.WriteString("廠區信息", "密碼1", managepass);
            }
        }

        public string LineId
        {
            get
            {
                lineId = iniFile.IniReadValue("廠區信息", "製程名");
                return lineId;
            }
            set
            {
                lineId = value;
                iniFile.WriteString("廠區信息", "製程名", lineId);
            }
        }

        public string LineNumber
        {
            get
            {
                lineNumber = iniFile.IniReadValue("廠區信息", "線別編號");
                return lineNumber;
            }
            set
            {
                lineNumber = value;
                iniFile.WriteString("廠區信息", "線別編號", lineNumber);
            }
        }

        public string ProcessId
        {
            get
            {
                processId = iniFile.IniReadValue("廠區信息", "製程代號");
                return processId;
            }
            set
            {
                processId = value;
                iniFile.WriteString("廠區信息", "製程代號", processId);
            }
        }

        public string P_LOT_TYPE
        {
            get
            {
                return p_LOT_TYPE;
            }

            set
            {
                p_LOT_TYPE = value;
            }
        }

        public string Factory
        {
            get
            {
                factory = iniFile.IniReadValue("廠區信息", "廠區");
                return factory;
            }

            set
            {
                factory = value;
                iniFile.WriteString("廠區信息", "廠區", factory);
            }
        }

        public bool IsLockKeyboard
        {
            get
            {
                return isLockKeyboard;
            }

            set
            {
                isLockKeyboard = value;
            }
        }
    }
}
