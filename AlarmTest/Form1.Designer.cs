namespace AlarmTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            NationalInstruments.NetworkVariable.WindowsForms.NetworkVariableBinding networkVariableBinding2 = new NationalInstruments.NetworkVariable.WindowsForms.NetworkVariableBinding();
            this.slide1 = new NationalInstruments.UI.WindowsForms.Slide();
            this.networkVariableDataSource1 = new NationalInstruments.NetworkVariable.WindowsForms.NetworkVariableDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.slide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkVariableDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // slide1
            // 
            this.slide1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.networkVariableDataSource1, "Binding1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.slide1.Location = new System.Drawing.Point(34, 12);
            this.slide1.Name = "slide1";
            this.slide1.Range = new NationalInstruments.UI.Range(0D, 100D);
            this.slide1.Size = new System.Drawing.Size(81, 366);
            this.slide1.TabIndex = 0;
            // 
            // networkVariableDataSource1
            // 
            networkVariableBinding2.BindingMode = NationalInstruments.NetworkVariable.NetworkVariableBindingMode.ReadWrite;
            networkVariableBinding2.Location = "\\\\localhost\\jure\\Single";
            networkVariableBinding2.Name = "Binding1";
            this.networkVariableDataSource1.Bindings.AddRange(new NationalInstruments.NetworkVariable.WindowsForms.NetworkVariableBinding[] {
            networkVariableBinding2});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 381);
            this.Controls.Add(this.slide1);
            this.Name = "Form1";
            this.Text = "Alarm test";
            ((System.ComponentModel.ISupportInitialize)(this.slide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkVariableDataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Slide slide1;
        private NationalInstruments.NetworkVariable.WindowsForms.NetworkVariableDataSource networkVariableDataSource1;
    }
}

