﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace WindowsFormsApp5.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExecuteNonQueryOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteDataSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteLotQueryOperationCompleted;
        
        private System.Threading.SendOrPostCallback getPartnumOperationCompleted;
        
        private System.Threading.SendOrPostCallback insert_cm_wip_print_labelOperationCompleted;
        
        private System.Threading.SendOrPostCallback xxcc_barcodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback INSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted;
        
        private System.Threading.SendOrPostCallback insert_cc_wip_lot_bc_historyOperationCompleted;
        
        private System.Threading.SendOrPostCallback XXCC_LOT_PC_FOperationCompleted;
        
        private System.Threading.SendOrPostCallback xxcc_work_num_fOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::WindowsFormsApp5.Properties.Settings.Default.WindowsFormsApp5_WebReference_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ExecuteNonQueryCompletedEventHandler ExecuteNonQueryCompleted;
        
        /// <remarks/>
        public event ExecuteDataSetCompletedEventHandler ExecuteDataSetCompleted;
        
        /// <remarks/>
        public event ExecuteLotQueryCompletedEventHandler ExecuteLotQueryCompleted;
        
        /// <remarks/>
        public event getPartnumCompletedEventHandler getPartnumCompleted;
        
        /// <remarks/>
        public event insert_cm_wip_print_labelCompletedEventHandler insert_cm_wip_print_labelCompleted;
        
        /// <remarks/>
        public event xxcc_barcodeCompletedEventHandler xxcc_barcodeCompleted;
        
        /// <remarks/>
        public event INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventHandler INSERT_CM_WIP_PROCESS_LINE_HISTORYCompleted;
        
        /// <remarks/>
        public event insert_cc_wip_lot_bc_historyCompletedEventHandler insert_cc_wip_lot_bc_historyCompleted;
        
        /// <remarks/>
        public event XXCC_LOT_PC_FCompletedEventHandler XXCC_LOT_PC_FCompleted;
        
        /// <remarks/>
        public event xxcc_work_num_fCompletedEventHandler xxcc_work_num_fCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteNonQuery", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ExecuteNonQuery(string sql) {
            object[] results = this.Invoke("ExecuteNonQuery", new object[] {
                        sql});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteNonQueryAsync(string sql) {
            this.ExecuteNonQueryAsync(sql, null);
        }
        
        /// <remarks/>
        public void ExecuteNonQueryAsync(string sql, object userState) {
            if ((this.ExecuteNonQueryOperationCompleted == null)) {
                this.ExecuteNonQueryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteNonQueryOperationCompleted);
            }
            this.InvokeAsync("ExecuteNonQuery", new object[] {
                        sql}, this.ExecuteNonQueryOperationCompleted, userState);
        }
        
        private void OnExecuteNonQueryOperationCompleted(object arg) {
            if ((this.ExecuteNonQueryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteNonQueryCompleted(this, new ExecuteNonQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteDataSet", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet ExecuteDataSet(string sql) {
            object[] results = this.Invoke("ExecuteDataSet", new object[] {
                        sql});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteDataSetAsync(string sql) {
            this.ExecuteDataSetAsync(sql, null);
        }
        
        /// <remarks/>
        public void ExecuteDataSetAsync(string sql, object userState) {
            if ((this.ExecuteDataSetOperationCompleted == null)) {
                this.ExecuteDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteDataSetOperationCompleted);
            }
            this.InvokeAsync("ExecuteDataSet", new object[] {
                        sql}, this.ExecuteDataSetOperationCompleted, userState);
        }
        
        private void OnExecuteDataSetOperationCompleted(object arg) {
            if ((this.ExecuteDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteDataSetCompleted(this, new ExecuteDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteLotQuery", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExecuteLotQuery(string sql) {
            object[] results = this.Invoke("ExecuteLotQuery", new object[] {
                        sql});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteLotQueryAsync(string sql) {
            this.ExecuteLotQueryAsync(sql, null);
        }
        
        /// <remarks/>
        public void ExecuteLotQueryAsync(string sql, object userState) {
            if ((this.ExecuteLotQueryOperationCompleted == null)) {
                this.ExecuteLotQueryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteLotQueryOperationCompleted);
            }
            this.InvokeAsync("ExecuteLotQuery", new object[] {
                        sql}, this.ExecuteLotQueryOperationCompleted, userState);
        }
        
        private void OnExecuteLotQueryOperationCompleted(object arg) {
            if ((this.ExecuteLotQueryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteLotQueryCompleted(this, new ExecuteLotQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getPartnum", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getPartnum(string vlot) {
            object[] results = this.Invoke("getPartnum", new object[] {
                        vlot});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getPartnumAsync(string vlot) {
            this.getPartnumAsync(vlot, null);
        }
        
        /// <remarks/>
        public void getPartnumAsync(string vlot, object userState) {
            if ((this.getPartnumOperationCompleted == null)) {
                this.getPartnumOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetPartnumOperationCompleted);
            }
            this.InvokeAsync("getPartnum", new object[] {
                        vlot}, this.getPartnumOperationCompleted, userState);
        }
        
        private void OngetPartnumOperationCompleted(object arg) {
            if ((this.getPartnumCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getPartnumCompleted(this, new getPartnumCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insert_cm_wip_print_label", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string insert_cm_wip_print_label(string P_ORG_CODE, string P_LOT_NUM, string P_PART_NUM, string P_EQUIP_ID, string P_DATE_CODE, int P_XOUT, int P_QTY, int P_UNIT_QTY, string P_IP, string P_ACCOUNT) {
            object[] results = this.Invoke("insert_cm_wip_print_label", new object[] {
                        P_ORG_CODE,
                        P_LOT_NUM,
                        P_PART_NUM,
                        P_EQUIP_ID,
                        P_DATE_CODE,
                        P_XOUT,
                        P_QTY,
                        P_UNIT_QTY,
                        P_IP,
                        P_ACCOUNT});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void insert_cm_wip_print_labelAsync(string P_ORG_CODE, string P_LOT_NUM, string P_PART_NUM, string P_EQUIP_ID, string P_DATE_CODE, int P_XOUT, int P_QTY, int P_UNIT_QTY, string P_IP, string P_ACCOUNT) {
            this.insert_cm_wip_print_labelAsync(P_ORG_CODE, P_LOT_NUM, P_PART_NUM, P_EQUIP_ID, P_DATE_CODE, P_XOUT, P_QTY, P_UNIT_QTY, P_IP, P_ACCOUNT, null);
        }
        
        /// <remarks/>
        public void insert_cm_wip_print_labelAsync(string P_ORG_CODE, string P_LOT_NUM, string P_PART_NUM, string P_EQUIP_ID, string P_DATE_CODE, int P_XOUT, int P_QTY, int P_UNIT_QTY, string P_IP, string P_ACCOUNT, object userState) {
            if ((this.insert_cm_wip_print_labelOperationCompleted == null)) {
                this.insert_cm_wip_print_labelOperationCompleted = new System.Threading.SendOrPostCallback(this.Oninsert_cm_wip_print_labelOperationCompleted);
            }
            this.InvokeAsync("insert_cm_wip_print_label", new object[] {
                        P_ORG_CODE,
                        P_LOT_NUM,
                        P_PART_NUM,
                        P_EQUIP_ID,
                        P_DATE_CODE,
                        P_XOUT,
                        P_QTY,
                        P_UNIT_QTY,
                        P_IP,
                        P_ACCOUNT}, this.insert_cm_wip_print_labelOperationCompleted, userState);
        }
        
        private void Oninsert_cm_wip_print_labelOperationCompleted(object arg) {
            if ((this.insert_cm_wip_print_labelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insert_cm_wip_print_labelCompleted(this, new insert_cm_wip_print_labelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/xxcc_barcode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string xxcc_barcode(string P_ORG_CODE, string P_BARCODE, string P_EQUIP_ID, string P_ACCOUNT) {
            object[] results = this.Invoke("xxcc_barcode", new object[] {
                        P_ORG_CODE,
                        P_BARCODE,
                        P_EQUIP_ID,
                        P_ACCOUNT});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void xxcc_barcodeAsync(string P_ORG_CODE, string P_BARCODE, string P_EQUIP_ID, string P_ACCOUNT) {
            this.xxcc_barcodeAsync(P_ORG_CODE, P_BARCODE, P_EQUIP_ID, P_ACCOUNT, null);
        }
        
        /// <remarks/>
        public void xxcc_barcodeAsync(string P_ORG_CODE, string P_BARCODE, string P_EQUIP_ID, string P_ACCOUNT, object userState) {
            if ((this.xxcc_barcodeOperationCompleted == null)) {
                this.xxcc_barcodeOperationCompleted = new System.Threading.SendOrPostCallback(this.Onxxcc_barcodeOperationCompleted);
            }
            this.InvokeAsync("xxcc_barcode", new object[] {
                        P_ORG_CODE,
                        P_BARCODE,
                        P_EQUIP_ID,
                        P_ACCOUNT}, this.xxcc_barcodeOperationCompleted, userState);
        }
        
        private void Onxxcc_barcodeOperationCompleted(object arg) {
            if ((this.xxcc_barcodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.xxcc_barcodeCompleted(this, new xxcc_barcodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/INSERT_CM_WIP_PROCESS_LINE_HISTORY", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string INSERT_CM_WIP_PROCESS_LINE_HISTORY(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE, string P_BKfile) {
            object[] results = this.Invoke("INSERT_CM_WIP_PROCESS_LINE_HISTORY", new object[] {
                        P_ORG_CODE,
                        P_NUM,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE,
                        P_BKfile});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void INSERT_CM_WIP_PROCESS_LINE_HISTORYAsync(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE, string P_BKfile) {
            this.INSERT_CM_WIP_PROCESS_LINE_HISTORYAsync(P_ORG_CODE, P_NUM, P_LOT, P_PC, P_LINE, P_LINE_NUM, P_LOT_TYPE, P_BKfile, null);
        }
        
        /// <remarks/>
        public void INSERT_CM_WIP_PROCESS_LINE_HISTORYAsync(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE, string P_BKfile, object userState) {
            if ((this.INSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted == null)) {
                this.INSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted = new System.Threading.SendOrPostCallback(this.OnINSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted);
            }
            this.InvokeAsync("INSERT_CM_WIP_PROCESS_LINE_HISTORY", new object[] {
                        P_ORG_CODE,
                        P_NUM,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE,
                        P_BKfile}, this.INSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted, userState);
        }
        
        private void OnINSERT_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted(object arg) {
            if ((this.INSERT_CM_WIP_PROCESS_LINE_HISTORYCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.INSERT_CM_WIP_PROCESS_LINE_HISTORYCompleted(this, new INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insert_cc_wip_lot_bc_history", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string insert_cc_wip_lot_bc_history(string P_ORG_CODE, string P_LOT, string P_BC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE) {
            object[] results = this.Invoke("insert_cc_wip_lot_bc_history", new object[] {
                        P_ORG_CODE,
                        P_LOT,
                        P_BC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void insert_cc_wip_lot_bc_historyAsync(string P_ORG_CODE, string P_LOT, string P_BC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE) {
            this.insert_cc_wip_lot_bc_historyAsync(P_ORG_CODE, P_LOT, P_BC, P_LINE, P_LINE_NUM, P_LOT_TYPE, null);
        }
        
        /// <remarks/>
        public void insert_cc_wip_lot_bc_historyAsync(string P_ORG_CODE, string P_LOT, string P_BC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE, object userState) {
            if ((this.insert_cc_wip_lot_bc_historyOperationCompleted == null)) {
                this.insert_cc_wip_lot_bc_historyOperationCompleted = new System.Threading.SendOrPostCallback(this.Oninsert_cc_wip_lot_bc_historyOperationCompleted);
            }
            this.InvokeAsync("insert_cc_wip_lot_bc_history", new object[] {
                        P_ORG_CODE,
                        P_LOT,
                        P_BC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE}, this.insert_cc_wip_lot_bc_historyOperationCompleted, userState);
        }
        
        private void Oninsert_cc_wip_lot_bc_historyOperationCompleted(object arg) {
            if ((this.insert_cc_wip_lot_bc_historyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insert_cc_wip_lot_bc_historyCompleted(this, new insert_cc_wip_lot_bc_historyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XXCC_LOT_PC_F", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string XXCC_LOT_PC_F(string P_ORG_CODE, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_CHK_FLAG) {
            object[] results = this.Invoke("XXCC_LOT_PC_F", new object[] {
                        P_ORG_CODE,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_CHK_FLAG});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void XXCC_LOT_PC_FAsync(string P_ORG_CODE, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_CHK_FLAG) {
            this.XXCC_LOT_PC_FAsync(P_ORG_CODE, P_LOT, P_PC, P_LINE, P_LINE_NUM, P_CHK_FLAG, null);
        }
        
        /// <remarks/>
        public void XXCC_LOT_PC_FAsync(string P_ORG_CODE, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_CHK_FLAG, object userState) {
            if ((this.XXCC_LOT_PC_FOperationCompleted == null)) {
                this.XXCC_LOT_PC_FOperationCompleted = new System.Threading.SendOrPostCallback(this.OnXXCC_LOT_PC_FOperationCompleted);
            }
            this.InvokeAsync("XXCC_LOT_PC_F", new object[] {
                        P_ORG_CODE,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_CHK_FLAG}, this.XXCC_LOT_PC_FOperationCompleted, userState);
        }
        
        private void OnXXCC_LOT_PC_FOperationCompleted(object arg) {
            if ((this.XXCC_LOT_PC_FCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.XXCC_LOT_PC_FCompleted(this, new XXCC_LOT_PC_FCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/xxcc_work_num_f", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string xxcc_work_num_f(string P_ORG_CODE, string P_WORK_NUM, string P_PC, string P_LINE) {
            object[] results = this.Invoke("xxcc_work_num_f", new object[] {
                        P_ORG_CODE,
                        P_WORK_NUM,
                        P_PC,
                        P_LINE});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void xxcc_work_num_fAsync(string P_ORG_CODE, string P_WORK_NUM, string P_PC, string P_LINE) {
            this.xxcc_work_num_fAsync(P_ORG_CODE, P_WORK_NUM, P_PC, P_LINE, null);
        }
        
        /// <remarks/>
        public void xxcc_work_num_fAsync(string P_ORG_CODE, string P_WORK_NUM, string P_PC, string P_LINE, object userState) {
            if ((this.xxcc_work_num_fOperationCompleted == null)) {
                this.xxcc_work_num_fOperationCompleted = new System.Threading.SendOrPostCallback(this.Onxxcc_work_num_fOperationCompleted);
            }
            this.InvokeAsync("xxcc_work_num_f", new object[] {
                        P_ORG_CODE,
                        P_WORK_NUM,
                        P_PC,
                        P_LINE}, this.xxcc_work_num_fOperationCompleted, userState);
        }
        
        private void Onxxcc_work_num_fOperationCompleted(object arg) {
            if ((this.xxcc_work_num_fCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.xxcc_work_num_fCompleted(this, new xxcc_work_num_fCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void ExecuteNonQueryCompletedEventHandler(object sender, ExecuteNonQueryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteNonQueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteNonQueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void ExecuteDataSetCompletedEventHandler(object sender, ExecuteDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void ExecuteLotQueryCompletedEventHandler(object sender, ExecuteLotQueryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteLotQueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteLotQueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void getPartnumCompletedEventHandler(object sender, getPartnumCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getPartnumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getPartnumCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void insert_cm_wip_print_labelCompletedEventHandler(object sender, insert_cm_wip_print_labelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class insert_cm_wip_print_labelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal insert_cm_wip_print_labelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void xxcc_barcodeCompletedEventHandler(object sender, xxcc_barcodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class xxcc_barcodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal xxcc_barcodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventHandler(object sender, INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal INSERT_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void insert_cc_wip_lot_bc_historyCompletedEventHandler(object sender, insert_cc_wip_lot_bc_historyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class insert_cc_wip_lot_bc_historyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal insert_cc_wip_lot_bc_historyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void XXCC_LOT_PC_FCompletedEventHandler(object sender, XXCC_LOT_PC_FCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XXCC_LOT_PC_FCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal XXCC_LOT_PC_FCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void xxcc_work_num_fCompletedEventHandler(object sender, xxcc_work_num_fCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class xxcc_work_num_fCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal xxcc_work_num_fCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591