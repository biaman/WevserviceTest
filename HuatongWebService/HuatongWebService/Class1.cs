using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuatongWebService
{
    public class Class1
    {
        private static Class1 class1 = new Class1();
        private Class1()
        {
            employeesId = new string[10];
            productsId = new string[100];
            proId = "CF廠";
            lineId = "01號";
            lineNum = "cse-235";
            processId = "010";
            for(int i = 0;i<employeesId.Length;i++)
            {
                productNum = "cplsan94";
                employeesId[i] = "a" + i;
                for (int j = 0;j<employeesId.Length;j++)
                {
                    productsId[i*10 + j] = employeesId[i] + "b"+j;
                }
            }
        }
        public static Class1 Instance()
        {
            return class1;
        }
        private bool _flag = false;
        private string productNum;//料號
        private string[] employeesId;//工號
        private string[] productsId;//批號
        private string proId;//廠名
        private string lineId;//線
        private string lineNum;//線別
        private string processId;//製程
        private string barcode;//二維碼
        
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        public string ProductNum
        {
            get { return productNum; }          
        }

        public string[] EmployeesId
        {
            get
            {
                return employeesId;
            }
        }

        public string[] ProductsId
        {
            get
            {
                return productsId;
            }
        }

        public string ProId
        {
            get
            {
                return proId;
            }

            set
            {
                proId = value;
            }
        }

        public string LineId
        {
            get
            {
                return lineId;
            }

            set
            {
                lineId = value;
            }
        }

        public string LineNum
        {
            get
            {
                return lineNum;
            }

            set
            {
                lineNum = value;
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

        public string Barcode
        {
            get
            {
                return barcode;
            }

            set
            {
                barcode = value;
            }
        }
    }
}