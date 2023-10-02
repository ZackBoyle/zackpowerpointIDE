namespace PowerPointIDE
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.PowerPointIDE = this.Factory.CreateRibbonGroup();
            this.Compile = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.PowerPointIDE.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.PowerPointIDE);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // PowerPointIDE
            // 
            this.PowerPointIDE.Items.Add(this.Compile);
            this.PowerPointIDE.Label = "PowerPoint IDE Functions";
            this.PowerPointIDE.Name = "PowerPointIDE";
            // 
            // Compile
            // 
            this.Compile.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Compile.Image = global::PowerPointIDE.Properties.Resources.FRED;
            this.Compile.Label = "Compile";
            this.Compile.Name = "Compile";
            this.Compile.ShowImage = true;
            this.Compile.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Compile_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.PowerPointIDE.ResumeLayout(false);
            this.PowerPointIDE.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup PowerPointIDE;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Compile;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
