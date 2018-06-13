using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp5
{
    class MessageModel
    {
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
        private string _lineId;//線
        private string _lineNumber;//線別
        private bool isform3Alive;
        private bool timerFlag1;
        private bool timerFlag2;
        private bool timerFlag3;
        private int timer1Wait;
        private int timerWait1;
        private int timerWait2;
        private int timerWait3;
        private bool isSave;
        private string factory;//廠號      
        private string processId;//製程
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
        public string LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }
        public string LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
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

        public string Factory
        {
            get
            {
                return factory;
            }

            set
            {
                factory = value;
            }
        }    
        public string ProcessId
        {
            get
            {
                return processId;
            }

            set
            {
                processId = value;
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
    }
}
