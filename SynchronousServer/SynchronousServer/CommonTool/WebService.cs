using System;
using System.Web.Services;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CommonTool
{
   
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "WebServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class WebService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback HIS_InterfaceOperationCompleted;

        private System.Threading.SendOrPostCallback HIPMessageServerOperationCompleted;

        private bool useDefaultCredentialsSetExplicitly;

        /// <remarks/>
        public WebService(string url)
        {
            this.Url =url;
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true)
                            && (this.useDefaultCredentialsSetExplicitly == false))
                            && (this.IsLocalFileSystemWebService(value) == false)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        /// <remarks/>
        public event HIS_InterfaceCompletedEventHandler HIS_InterfaceCompleted;

        /// <remarks/>
        public event HIPMessageServerCompletedEventHandler HIPMessageServerCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HIS_Interface", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HIS_Interface(string TradeCode, string InputParameter)
        {
            object[] results = this.Invoke("HIS_Interface", new object[] {
                        TradeCode,
                        InputParameter});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void HIS_InterfaceAsync(string TradeCode, string InputParameter)
        {
            this.HIS_InterfaceAsync(TradeCode, InputParameter, null);
        }

        /// <remarks/>
        public void HIS_InterfaceAsync(string TradeCode, string InputParameter, object userState)
        {
            if ((this.HIS_InterfaceOperationCompleted == null))
            {
                this.HIS_InterfaceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHIS_InterfaceOperationCompleted);
            }
            this.InvokeAsync("HIS_Interface", new object[] {
                        TradeCode,
                        InputParameter}, this.HIS_InterfaceOperationCompleted, userState);
        }

        private void OnHIS_InterfaceOperationCompleted(object arg)
        {
            if ((this.HIS_InterfaceCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HIS_InterfaceCompleted(this, new HIS_InterfaceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HIPMessageServer", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HIPMessageServer(string action, string message)
        {
            object[] results = this.Invoke("HIPMessageServer", new object[] {
                        action,
                        message});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void HIPMessageServerAsync(string action, string message)
        {
            this.HIPMessageServerAsync(action, message, null);
        }

        /// <remarks/>
        public void HIPMessageServerAsync(string action, string message, object userState)
        {
            if ((this.HIPMessageServerOperationCompleted == null))
            {
                this.HIPMessageServerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHIPMessageServerOperationCompleted);
            }
            this.InvokeAsync("HIPMessageServer", new object[] {
                        action,
                        message}, this.HIPMessageServerOperationCompleted, userState);
        }

        private void OnHIPMessageServerOperationCompleted(object arg)
        {
            if ((this.HIPMessageServerCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HIPMessageServerCompleted(this, new HIPMessageServerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void HIS_InterfaceCompletedEventHandler(object sender, HIS_InterfaceCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HIS_InterfaceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal HIS_InterfaceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void HIPMessageServerCompletedEventHandler(object sender, HIPMessageServerCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HIPMessageServerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal HIPMessageServerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591