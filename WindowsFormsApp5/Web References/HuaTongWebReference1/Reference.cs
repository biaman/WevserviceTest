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

namespace WindowsFormsApp5.HuaTongWebReference1 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://Aumex.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConnectionOperationCompleted;
        
        private System.Threading.SendOrPostCallback xxcc_work_num_fOperationCompleted;
        
        private System.Threading.SendOrPostCallback getPartnumOperationCompleted;
        
        private System.Threading.SendOrPostCallback funOperationCompleted;
        
        private System.Threading.SendOrPostCallback XXCC_LOT_PC_FOperationCompleted;
        
        private System.Threading.SendOrPostCallback insert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted;
        
        private System.Threading.SendOrPostCallback insert_cc_wip_lot_bc_historyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService1() {
            this.Url = global::WindowsFormsApp5.Properties.Settings.Default.WindowsFormsApp5_HuaTongWebReference2_WebService1;
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
        public event SendProductCompletedEventHandler SendProductCompleted;
        
        /// <remarks/>
        public event ConnectionCompletedEventHandler ConnectionCompleted;
        
        /// <remarks/>
        public event xxcc_work_num_fCompletedEventHandler xxcc_work_num_fCompleted;
        
        /// <remarks/>
        public event getPartnumCompletedEventHandler getPartnumCompleted;
        
        /// <remarks/>
        public event funCompletedEventHandler funCompleted;
        
        /// <remarks/>
        public event XXCC_LOT_PC_FCompletedEventHandler XXCC_LOT_PC_FCompleted;
        
        /// <remarks/>
        public event insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventHandler insert_CM_WIP_PROCESS_LINE_HISTORYCompleted;
        
        /// <remarks/>
        public event insert_cc_wip_lot_bc_historyCompletedEventHandler insert_cc_wip_lot_bc_historyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/SendProduct", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendProduct(string products) {
            object[] results = this.Invoke("SendProduct", new object[] {
                        products});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendProductAsync(string products) {
            this.SendProductAsync(products, null);
        }
        
        /// <remarks/>
        public void SendProductAsync(string products, object userState) {
            if ((this.SendProductOperationCompleted == null)) {
                this.SendProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendProductOperationCompleted);
            }
            this.InvokeAsync("SendProduct", new object[] {
                        products}, this.SendProductOperationCompleted, userState);
        }
        
        private void OnSendProductOperationCompleted(object arg) {
            if ((this.SendProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendProductCompleted(this, new SendProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/Connection", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Connection() {
            object[] results = this.Invoke("Connection", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConnectionAsync() {
            this.ConnectionAsync(null);
        }
        
        /// <remarks/>
        public void ConnectionAsync(object userState) {
            if ((this.ConnectionOperationCompleted == null)) {
                this.ConnectionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConnectionOperationCompleted);
            }
            this.InvokeAsync("Connection", new object[0], this.ConnectionOperationCompleted, userState);
        }
        
        private void OnConnectionOperationCompleted(object arg) {
            if ((this.ConnectionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConnectionCompleted(this, new ConnectionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/xxcc_work_num_f", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/getPartnum", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/fun", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool fun() {
            object[] results = this.Invoke("fun", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void funAsync() {
            this.funAsync(null);
        }
        
        /// <remarks/>
        public void funAsync(object userState) {
            if ((this.funOperationCompleted == null)) {
                this.funOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfunOperationCompleted);
            }
            this.InvokeAsync("fun", new object[0], this.funOperationCompleted, userState);
        }
        
        private void OnfunOperationCompleted(object arg) {
            if ((this.funCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.funCompleted(this, new funCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/XXCC_LOT_PC_F", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/insert_CM_WIP_PROCESS_LINE_HISTORY", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string insert_CM_WIP_PROCESS_LINE_HISTORY(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE) {
            object[] results = this.Invoke("insert_CM_WIP_PROCESS_LINE_HISTORY", new object[] {
                        P_ORG_CODE,
                        P_NUM,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void insert_CM_WIP_PROCESS_LINE_HISTORYAsync(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE) {
            this.insert_CM_WIP_PROCESS_LINE_HISTORYAsync(P_ORG_CODE, P_NUM, P_LOT, P_PC, P_LINE, P_LINE_NUM, P_LOT_TYPE, null);
        }
        
        /// <remarks/>
        public void insert_CM_WIP_PROCESS_LINE_HISTORYAsync(string P_ORG_CODE, string P_NUM, string P_LOT, string P_PC, string P_LINE, string P_LINE_NUM, string P_LOT_TYPE, object userState) {
            if ((this.insert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted == null)) {
                this.insert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted = new System.Threading.SendOrPostCallback(this.Oninsert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted);
            }
            this.InvokeAsync("insert_CM_WIP_PROCESS_LINE_HISTORY", new object[] {
                        P_ORG_CODE,
                        P_NUM,
                        P_LOT,
                        P_PC,
                        P_LINE,
                        P_LINE_NUM,
                        P_LOT_TYPE}, this.insert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted, userState);
        }
        
        private void Oninsert_CM_WIP_PROCESS_LINE_HISTORYOperationCompleted(object arg) {
            if ((this.insert_CM_WIP_PROCESS_LINE_HISTORYCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insert_CM_WIP_PROCESS_LINE_HISTORYCompleted(this, new insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Aumex.org/insert_cc_wip_lot_bc_history", RequestNamespace="http://Aumex.org/", ResponseNamespace="http://Aumex.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
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
    public delegate void SendProductCompletedEventHandler(object sender, SendProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ConnectionCompletedEventHandler(object sender, ConnectionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConnectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConnectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void funCompletedEventHandler(object sender, funCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class funCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal funCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventHandler(object sender, insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal insert_CM_WIP_PROCESS_LINE_HISTORYCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591