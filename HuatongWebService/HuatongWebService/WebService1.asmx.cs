using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HuatongWebService
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Aumex.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Class1 c1 = Class1.Instance();
        [WebMethod(Description ="发送产品编号")]
        public string SendProduct(string products)
        {
            return "发送成功";
        }       
        [WebMethod(Description ="检验连接")]
        public string Connection()
        {            
            c1.Flag = true;            
            return "连接成功";                                       
        }
        [WebMethod(Description ="檢測用戶輸入的員工工號是否是该厂区")]
        public string xxcc_work_num_f(string factory,string employeeId,string processId,string lineNum)
        {            
            for(int i=0;i<c1.EmployeesId.Length;i++)
            {
                if(employeeId==c1.EmployeesId[i])
                {                   
                    return "OK";
                }
            }           
            return "该人员不属于该厂区或者已经离职！！";
        }
        [WebMethod(Description ="檢測產品批號是否正確，並返回料號")]
        public string GetPartnum(string productId)
        {
            for(int i = 0;i<c1.ProductsId.Length;i++)
            {
                if(productId==c1.ProductsId[i])
                {
                    return  c1.ProductNum+"，sb渣渣，我实在是无语啊，我无Fu*k可说";
                }
            }
            return "";
        }
        [WebMethod]
        public bool fun()
        {
            return true;
        }
        [WebMethod(Description = "检查批号当前批号是否属于该制程")]
        public string XXCC_LOT_PC_F(string factory, string productId, string processId)
        {
            bool flag = false;
            for (int i = 0; i < c1.ProductsId.Length; i++)
            {
                if (productId == c1.ProductsId[i])
                {
                    flag = true;
                    //return c1.ProductNum + "，sb渣渣，我实在是无语啊，我无Fu*k可说";
                }
            }
            if(flag==false)
            {
                return "该批号" + productId + "当前制程不存在";
            }
            return "OK";
        }
        [WebMethod(Description ="傳送廠號，線，線別，製程，工號，批號，料號") ]
        public string SendBasicMessage(string proId,string lineId,string lineNum,string processId,string memberId,string productId,string productNum)
        {
            if (proId == c1.ProId && lineId == c1.LineId && lineNum == c1.LineNum && processId == c1.ProcessId && productNum == c1.ProductNum)
            {
                
                return "";
            }
            return "信息有誤";
        }
        [WebMethod(Description ="發送Barcode數據")]
        public string SendBarcodes(string barcode,string productId)
        {
            if(barcode!=null&&productId!=null)
            {
                return "OK";
            }
            return "不匹配";
        }
    }
}
