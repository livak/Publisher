﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfClient.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VariableDto", Namespace="http://schemas.datacontract.org/2004/07/WebService.Entities")]
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TerminalDto", Namespace="http://schemas.datacontract.org/2004/07/WebService.Entities")]
    [System.SerializableAttribute()]
    public partial class TerminalDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AcknowledgedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AlarmIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AlarmLevelNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MaxValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SetTimeField;
        
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
        public bool Acknowledged {
            get {
                return this.AcknowledgedField;
            }
            set {
                if ((this.AcknowledgedField.Equals(value) != true)) {
                    this.AcknowledgedField = value;
                    this.RaisePropertyChanged("Acknowledged");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Active {
            get {
                return this.ActiveField;
            }
            set {
                if ((this.ActiveField.Equals(value) != true)) {
                    this.ActiveField = value;
                    this.RaisePropertyChanged("Active");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AlarmId {
            get {
                return this.AlarmIdField;
            }
            set {
                if ((this.AlarmIdField.Equals(value) != true)) {
                    this.AlarmIdField = value;
                    this.RaisePropertyChanged("AlarmId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AlarmLevelName {
            get {
                return this.AlarmLevelNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AlarmLevelNameField, value) != true)) {
                    this.AlarmLevelNameField = value;
                    this.RaisePropertyChanged("AlarmLevelName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double MaxValue {
            get {
                return this.MaxValueField;
            }
            set {
                if ((this.MaxValueField.Equals(value) != true)) {
                    this.MaxValueField = value;
                    this.RaisePropertyChanged("MaxValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SetTime {
            get {
                return this.SetTimeField;
            }
            set {
                if ((this.SetTimeField.Equals(value) != true)) {
                    this.SetTimeField = value;
                    this.RaisePropertyChanged("SetTime");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistogramDto", Namespace="http://schemas.datacontract.org/2004/07/WebService.Entities")]
    [System.SerializableAttribute()]
    public partial class HistogramDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float SingleValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeStampField;
        
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
        public float SingleValue {
            get {
                return this.SingleValueField;
            }
            set {
                if ((this.SingleValueField.Equals(value) != true)) {
                    this.SingleValueField = value;
                    this.RaisePropertyChanged("SingleValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AcknowledgeAlarm", ReplyAction="http://tempuri.org/IService/AcknowledgeAlarmResponse")]
        void AcknowledgeAlarm(int alarmId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/AcknowledgeAlarm", ReplyAction="http://tempuri.org/IService/AcknowledgeAlarmResponse")]
        System.IAsyncResult BeginAcknowledgeAlarm(int alarmId, System.AsyncCallback callback, object asyncState);
        
        void EndAcknowledgeAlarm(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetVariables", ReplyAction="http://tempuri.org/IService/GetVariablesResponse")]
        WpfClient.ServiceReference.VariableDto[] GetVariables();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetVariables", ReplyAction="http://tempuri.org/IService/GetVariablesResponse")]
        System.IAsyncResult BeginGetVariables(System.AsyncCallback callback, object asyncState);
        
        WpfClient.ServiceReference.VariableDto[] EndGetVariables(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTerminal", ReplyAction="http://tempuri.org/IService/GetTerminalResponse")]
        WpfClient.ServiceReference.TerminalDto[] GetTerminal();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetTerminal", ReplyAction="http://tempuri.org/IService/GetTerminalResponse")]
        System.IAsyncResult BeginGetTerminal(System.AsyncCallback callback, object asyncState);
        
        WpfClient.ServiceReference.TerminalDto[] EndGetTerminal(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetHistogram", ReplyAction="http://tempuri.org/IService/GetHistogramResponse")]
        WpfClient.ServiceReference.HistogramDto[] GetHistogram();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetHistogram", ReplyAction="http://tempuri.org/IService/GetHistogramResponse")]
        System.IAsyncResult BeginGetHistogram(System.AsyncCallback callback, object asyncState);
        
        WpfClient.ServiceReference.HistogramDto[] EndGetHistogram(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAverageLastDay", ReplyAction="http://tempuri.org/IService/GetAverageLastDayResponse")]
        float GetAverageLastDay(string name);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService/GetAverageLastDay", ReplyAction="http://tempuri.org/IService/GetAverageLastDayResponse")]
        System.IAsyncResult BeginGetAverageLastDay(string name, System.AsyncCallback callback, object asyncState);
        
        float EndGetAverageLastDay(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WpfClient.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetVariablesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetVariablesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public WpfClient.ServiceReference.VariableDto[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((WpfClient.ServiceReference.VariableDto[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTerminalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTerminalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public WpfClient.ServiceReference.TerminalDto[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((WpfClient.ServiceReference.TerminalDto[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetHistogramCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetHistogramCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public WpfClient.ServiceReference.HistogramDto[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((WpfClient.ServiceReference.HistogramDto[])(this.results[0]));
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
    public partial class ServiceClient : System.ServiceModel.ClientBase<WpfClient.ServiceReference.IService>, WpfClient.ServiceReference.IService {
        
        private BeginOperationDelegate onBeginUpdateVariableSingleDelegate;
        
        private EndOperationDelegate onEndUpdateVariableSingleDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateVariableSingleCompletedDelegate;
        
        private BeginOperationDelegate onBeginAcknowledgeAlarmDelegate;
        
        private EndOperationDelegate onEndAcknowledgeAlarmDelegate;
        
        private System.Threading.SendOrPostCallback onAcknowledgeAlarmCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetVariablesDelegate;
        
        private EndOperationDelegate onEndGetVariablesDelegate;
        
        private System.Threading.SendOrPostCallback onGetVariablesCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTerminalDelegate;
        
        private EndOperationDelegate onEndGetTerminalDelegate;
        
        private System.Threading.SendOrPostCallback onGetTerminalCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetHistogramDelegate;
        
        private EndOperationDelegate onEndGetHistogramDelegate;
        
        private System.Threading.SendOrPostCallback onGetHistogramCompletedDelegate;
        
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
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> AcknowledgeAlarmCompleted;
        
        public event System.EventHandler<GetVariablesCompletedEventArgs> GetVariablesCompleted;
        
        public event System.EventHandler<GetTerminalCompletedEventArgs> GetTerminalCompleted;
        
        public event System.EventHandler<GetHistogramCompletedEventArgs> GetHistogramCompleted;
        
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
        
        public void AcknowledgeAlarm(int alarmId) {
            base.Channel.AcknowledgeAlarm(alarmId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAcknowledgeAlarm(int alarmId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAcknowledgeAlarm(alarmId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndAcknowledgeAlarm(System.IAsyncResult result) {
            base.Channel.EndAcknowledgeAlarm(result);
        }
        
        private System.IAsyncResult OnBeginAcknowledgeAlarm(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int alarmId = ((int)(inValues[0]));
            return this.BeginAcknowledgeAlarm(alarmId, callback, asyncState);
        }
        
        private object[] OnEndAcknowledgeAlarm(System.IAsyncResult result) {
            this.EndAcknowledgeAlarm(result);
            return null;
        }
        
        private void OnAcknowledgeAlarmCompleted(object state) {
            if ((this.AcknowledgeAlarmCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AcknowledgeAlarmCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AcknowledgeAlarmAsync(int alarmId) {
            this.AcknowledgeAlarmAsync(alarmId, null);
        }
        
        public void AcknowledgeAlarmAsync(int alarmId, object userState) {
            if ((this.onBeginAcknowledgeAlarmDelegate == null)) {
                this.onBeginAcknowledgeAlarmDelegate = new BeginOperationDelegate(this.OnBeginAcknowledgeAlarm);
            }
            if ((this.onEndAcknowledgeAlarmDelegate == null)) {
                this.onEndAcknowledgeAlarmDelegate = new EndOperationDelegate(this.OnEndAcknowledgeAlarm);
            }
            if ((this.onAcknowledgeAlarmCompletedDelegate == null)) {
                this.onAcknowledgeAlarmCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAcknowledgeAlarmCompleted);
            }
            base.InvokeAsync(this.onBeginAcknowledgeAlarmDelegate, new object[] {
                        alarmId}, this.onEndAcknowledgeAlarmDelegate, this.onAcknowledgeAlarmCompletedDelegate, userState);
        }
        
        public WpfClient.ServiceReference.VariableDto[] GetVariables() {
            return base.Channel.GetVariables();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetVariables(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetVariables(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public WpfClient.ServiceReference.VariableDto[] EndGetVariables(System.IAsyncResult result) {
            return base.Channel.EndGetVariables(result);
        }
        
        private System.IAsyncResult OnBeginGetVariables(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetVariables(callback, asyncState);
        }
        
        private object[] OnEndGetVariables(System.IAsyncResult result) {
            WpfClient.ServiceReference.VariableDto[] retVal = this.EndGetVariables(result);
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
        
        public WpfClient.ServiceReference.TerminalDto[] GetTerminal() {
            return base.Channel.GetTerminal();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetTerminal(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetTerminal(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public WpfClient.ServiceReference.TerminalDto[] EndGetTerminal(System.IAsyncResult result) {
            return base.Channel.EndGetTerminal(result);
        }
        
        private System.IAsyncResult OnBeginGetTerminal(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetTerminal(callback, asyncState);
        }
        
        private object[] OnEndGetTerminal(System.IAsyncResult result) {
            WpfClient.ServiceReference.TerminalDto[] retVal = this.EndGetTerminal(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTerminalCompleted(object state) {
            if ((this.GetTerminalCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTerminalCompleted(this, new GetTerminalCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTerminalAsync() {
            this.GetTerminalAsync(null);
        }
        
        public void GetTerminalAsync(object userState) {
            if ((this.onBeginGetTerminalDelegate == null)) {
                this.onBeginGetTerminalDelegate = new BeginOperationDelegate(this.OnBeginGetTerminal);
            }
            if ((this.onEndGetTerminalDelegate == null)) {
                this.onEndGetTerminalDelegate = new EndOperationDelegate(this.OnEndGetTerminal);
            }
            if ((this.onGetTerminalCompletedDelegate == null)) {
                this.onGetTerminalCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTerminalCompleted);
            }
            base.InvokeAsync(this.onBeginGetTerminalDelegate, null, this.onEndGetTerminalDelegate, this.onGetTerminalCompletedDelegate, userState);
        }
        
        public WpfClient.ServiceReference.HistogramDto[] GetHistogram() {
            return base.Channel.GetHistogram();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetHistogram(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetHistogram(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public WpfClient.ServiceReference.HistogramDto[] EndGetHistogram(System.IAsyncResult result) {
            return base.Channel.EndGetHistogram(result);
        }
        
        private System.IAsyncResult OnBeginGetHistogram(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetHistogram(callback, asyncState);
        }
        
        private object[] OnEndGetHistogram(System.IAsyncResult result) {
            WpfClient.ServiceReference.HistogramDto[] retVal = this.EndGetHistogram(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetHistogramCompleted(object state) {
            if ((this.GetHistogramCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetHistogramCompleted(this, new GetHistogramCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetHistogramAsync() {
            this.GetHistogramAsync(null);
        }
        
        public void GetHistogramAsync(object userState) {
            if ((this.onBeginGetHistogramDelegate == null)) {
                this.onBeginGetHistogramDelegate = new BeginOperationDelegate(this.OnBeginGetHistogram);
            }
            if ((this.onEndGetHistogramDelegate == null)) {
                this.onEndGetHistogramDelegate = new EndOperationDelegate(this.OnEndGetHistogram);
            }
            if ((this.onGetHistogramCompletedDelegate == null)) {
                this.onGetHistogramCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetHistogramCompleted);
            }
            base.InvokeAsync(this.onBeginGetHistogramDelegate, null, this.onEndGetHistogramDelegate, this.onGetHistogramCompletedDelegate, userState);
        }
        
        public float GetAverageLastDay(string name) {
            return base.Channel.GetAverageLastDay(name);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetAverageLastDay(string name, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAverageLastDay(name, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public float EndGetAverageLastDay(System.IAsyncResult result) {
            return base.Channel.EndGetAverageLastDay(result);
        }
        
        private System.IAsyncResult OnBeginGetAverageLastDay(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string name = ((string)(inValues[0]));
            return this.BeginGetAverageLastDay(name, callback, asyncState);
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
        
        public void GetAverageLastDayAsync(string name) {
            this.GetAverageLastDayAsync(name, null);
        }
        
        public void GetAverageLastDayAsync(string name, object userState) {
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
                        name}, this.onEndGetAverageLastDayDelegate, this.onGetAverageLastDayCompletedDelegate, userState);
        }
    }
}
