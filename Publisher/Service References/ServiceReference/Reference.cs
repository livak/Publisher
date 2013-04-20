﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Publisher.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VariableDto", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class VariableDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VariableNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentValue {
            get {
                return this.CurrentValueField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentValueField, value) != true)) {
                    this.CurrentValueField = value;
                    this.RaisePropertyChanged("CurrentValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VariableName {
            get {
                return this.VariableNameField;
            }
            set {
                if ((object.ReferenceEquals(this.VariableNameField, value) != true)) {
                    this.VariableNameField = value;
                    this.RaisePropertyChanged("VariableName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateVariableSingle", ReplyAction="http://tempuri.org/IService/UpdateVariableSingleResponse")]
        void UpdateVariableSingle(string name, float currentValue, System.DateTime timeStamp);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/UpdateVariableSingle", ReplyAction="http://tempuri.org/IService/UpdateVariableSingleResponse")]
        System.IAsyncResult BeginUpdateVariableSingle(string name, float currentValue, System.DateTime timeStamp, System.AsyncCallback callback, object asyncState);
        
        void EndUpdateVariableSingle(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetVariables", ReplyAction="http://tempuri.org/IService/GetVariablesResponse")]
        Publisher.ServiceReference.VariableDto[] GetVariables();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetVariables", ReplyAction="http://tempuri.org/IService/GetVariablesResponse")]
        System.IAsyncResult BeginGetVariables(System.AsyncCallback callback, object asyncState);
        
        Publisher.ServiceReference.VariableDto[] EndGetVariables(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetVariable", ReplyAction="http://tempuri.org/IService/GetVariableResponse")]
        Publisher.ServiceReference.VariableDto GetVariable(string Name);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetVariable", ReplyAction="http://tempuri.org/IService/GetVariableResponse")]
        System.IAsyncResult BeginGetVariable(string Name, System.AsyncCallback callback, object asyncState);
        
        Publisher.ServiceReference.VariableDto EndGetVariable(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAverageLastDay", ReplyAction="http://tempuri.org/IService/GetAverageLastDayResponse")]
        float GetAverageLastDay(string Name);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetAverageLastDay", ReplyAction="http://tempuri.org/IService/GetAverageLastDayResponse")]
        System.IAsyncResult BeginGetAverageLastDay(string Name, System.AsyncCallback callback, object asyncState);
        
        float EndGetAverageLastDay(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Publisher.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetVariablesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetVariablesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Publisher.ServiceReference.VariableDto[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Publisher.ServiceReference.VariableDto[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetVariableCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetVariableCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Publisher.ServiceReference.VariableDto Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Publisher.ServiceReference.VariableDto)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAverageLastDayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetAverageLastDayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public float Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((float)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Publisher.ServiceReference.IService>, Publisher.ServiceReference.IService {
        
        private BeginOperationDelegate onBeginUpdateVariableSingleDelegate;
        
        private EndOperationDelegate onEndUpdateVariableSingleDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateVariableSingleCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetVariablesDelegate;
        
        private EndOperationDelegate onEndGetVariablesDelegate;
        
        private System.Threading.SendOrPostCallback onGetVariablesCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetVariableDelegate;
        
        private EndOperationDelegate onEndGetVariableDelegate;
        
        private System.Threading.SendOrPostCallback onGetVariableCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetAverageLastDayDelegate;
        
        private EndOperationDelegate onEndGetAverageLastDayDelegate;
        
        private System.Threading.SendOrPostCallback onGetAverageLastDayCompletedDelegate;
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> UpdateVariableSingleCompleted;
        
        public event System.EventHandler<GetVariablesCompletedEventArgs> GetVariablesCompleted;
        
        public event System.EventHandler<GetVariableCompletedEventArgs> GetVariableCompleted;
        
        public event System.EventHandler<GetAverageLastDayCompletedEventArgs> GetAverageLastDayCompleted;
        
        public void UpdateVariableSingle(string name, float currentValue, System.DateTime timeStamp) {
            base.Channel.UpdateVariableSingle(name, currentValue, timeStamp);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUpdateVariableSingle(string name, float currentValue, System.DateTime timeStamp, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateVariableSingle(name, currentValue, timeStamp, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndUpdateVariableSingle(System.IAsyncResult result) {
            base.Channel.EndUpdateVariableSingle(result);
        }
        
        private System.IAsyncResult OnBeginUpdateVariableSingle(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string name = ((string)(inValues[0]));
            float currentValue = ((float)(inValues[1]));
            System.DateTime timeStamp = ((System.DateTime)(inValues[2]));
            return this.BeginUpdateVariableSingle(name, currentValue, timeStamp, callback, asyncState);
        }
        
        private object[] OnEndUpdateVariableSingle(System.IAsyncResult result) {
            this.EndUpdateVariableSingle(result);
            return null;
        }
        
        private void OnUpdateVariableSingleCompleted(object state) {
            if ((this.UpdateVariableSingleCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateVariableSingleCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateVariableSingleAsync(string name, float currentValue, System.DateTime timeStamp) {
            this.UpdateVariableSingleAsync(name, currentValue, timeStamp, null);
        }
        
        public void UpdateVariableSingleAsync(string name, float currentValue, System.DateTime timeStamp, object userState) {
            if ((this.onBeginUpdateVariableSingleDelegate == null)) {
                this.onBeginUpdateVariableSingleDelegate = new BeginOperationDelegate(this.OnBeginUpdateVariableSingle);
            }
            if ((this.onEndUpdateVariableSingleDelegate == null)) {
                this.onEndUpdateVariableSingleDelegate = new EndOperationDelegate(this.OnEndUpdateVariableSingle);
            }
            if ((this.onUpdateVariableSingleCompletedDelegate == null)) {
                this.onUpdateVariableSingleCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateVariableSingleCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateVariableSingleDelegate, new object[] {
                        name,
                        currentValue,
                        timeStamp}, this.onEndUpdateVariableSingleDelegate, this.onUpdateVariableSingleCompletedDelegate, userState);
        }
        
        public Publisher.ServiceReference.VariableDto[] GetVariables() {
            return base.Channel.GetVariables();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetVariables(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetVariables(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Publisher.ServiceReference.VariableDto[] EndGetVariables(System.IAsyncResult result) {
            return base.Channel.EndGetVariables(result);
        }
        
        private System.IAsyncResult OnBeginGetVariables(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetVariables(callback, asyncState);
        }
        
        private object[] OnEndGetVariables(System.IAsyncResult result) {
            Publisher.ServiceReference.VariableDto[] retVal = this.EndGetVariables(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetVariablesCompleted(object state) {
            if ((this.GetVariablesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetVariablesCompleted(this, new GetVariablesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetVariablesAsync() {
            this.GetVariablesAsync(null);
        }
        
        public void GetVariablesAsync(object userState) {
            if ((this.onBeginGetVariablesDelegate == null)) {
                this.onBeginGetVariablesDelegate = new BeginOperationDelegate(this.OnBeginGetVariables);
            }
            if ((this.onEndGetVariablesDelegate == null)) {
                this.onEndGetVariablesDelegate = new EndOperationDelegate(this.OnEndGetVariables);
            }
            if ((this.onGetVariablesCompletedDelegate == null)) {
                this.onGetVariablesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetVariablesCompleted);
            }
            base.InvokeAsync(this.onBeginGetVariablesDelegate, null, this.onEndGetVariablesDelegate, this.onGetVariablesCompletedDelegate, userState);
        }
        
        public Publisher.ServiceReference.VariableDto GetVariable(string Name) {
            return base.Channel.GetVariable(Name);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetVariable(string Name, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetVariable(Name, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Publisher.ServiceReference.VariableDto EndGetVariable(System.IAsyncResult result) {
            return base.Channel.EndGetVariable(result);
        }
        
        private System.IAsyncResult OnBeginGetVariable(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string Name = ((string)(inValues[0]));
            return this.BeginGetVariable(Name, callback, asyncState);
        }
        
        private object[] OnEndGetVariable(System.IAsyncResult result) {
            Publisher.ServiceReference.VariableDto retVal = this.EndGetVariable(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetVariableCompleted(object state) {
            if ((this.GetVariableCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetVariableCompleted(this, new GetVariableCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetVariableAsync(string Name) {
            this.GetVariableAsync(Name, null);
        }
        
        public void GetVariableAsync(string Name, object userState) {
            if ((this.onBeginGetVariableDelegate == null)) {
                this.onBeginGetVariableDelegate = new BeginOperationDelegate(this.OnBeginGetVariable);
            }
            if ((this.onEndGetVariableDelegate == null)) {
                this.onEndGetVariableDelegate = new EndOperationDelegate(this.OnEndGetVariable);
            }
            if ((this.onGetVariableCompletedDelegate == null)) {
                this.onGetVariableCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetVariableCompleted);
            }
            base.InvokeAsync(this.onBeginGetVariableDelegate, new object[] {
                        Name}, this.onEndGetVariableDelegate, this.onGetVariableCompletedDelegate, userState);
        }
        
        public float GetAverageLastDay(string Name) {
            return base.Channel.GetAverageLastDay(Name);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetAverageLastDay(string Name, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAverageLastDay(Name, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public float EndGetAverageLastDay(System.IAsyncResult result) {
            return base.Channel.EndGetAverageLastDay(result);
        }
        
        private System.IAsyncResult OnBeginGetAverageLastDay(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string Name = ((string)(inValues[0]));
            return this.BeginGetAverageLastDay(Name, callback, asyncState);
        }
        
        private object[] OnEndGetAverageLastDay(System.IAsyncResult result) {
            float retVal = this.EndGetAverageLastDay(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetAverageLastDayCompleted(object state) {
            if ((this.GetAverageLastDayCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetAverageLastDayCompleted(this, new GetAverageLastDayCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAverageLastDayAsync(string Name) {
            this.GetAverageLastDayAsync(Name, null);
        }
        
        public void GetAverageLastDayAsync(string Name, object userState) {
            if ((this.onBeginGetAverageLastDayDelegate == null)) {
                this.onBeginGetAverageLastDayDelegate = new BeginOperationDelegate(this.OnBeginGetAverageLastDay);
            }
            if ((this.onEndGetAverageLastDayDelegate == null)) {
                this.onEndGetAverageLastDayDelegate = new EndOperationDelegate(this.OnEndGetAverageLastDay);
            }
            if ((this.onGetAverageLastDayCompletedDelegate == null)) {
                this.onGetAverageLastDayCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAverageLastDayCompleted);
            }
            base.InvokeAsync(this.onBeginGetAverageLastDayDelegate, new object[] {
                        Name}, this.onEndGetAverageLastDayDelegate, this.onGetAverageLastDayCompletedDelegate, userState);
        }
    }
}
