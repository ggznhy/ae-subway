namespace WAEngine
{
    partial class frmQueryByAttribute
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
            this.cbo_LayerName = new System.Windows.Forms.ComboBox();
            this.cbo_SelectMethod = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lst_Value = new System.Windows.Forms.ListBox();
            this.lst_Fields = new System.Windows.Forms.ListBox();
            this.lbl_SelectResult = new System.Windows.Forms.Label();
            this.rtx_SelectResult = new System.Windows.Forms.RichTextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_unique = new System.Windows.Forms.Button();
            this.btn_Equal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_LayerName
            // 
            this.cbo_LayerName.FormattingEnabled = true;
            this.cbo_LayerName.Location = new System.Drawing.Point(110, 23);
            this.cbo_LayerName.Name = "cbo_LayerName";
            this.cbo_LayerName.Size = new System.Drawing.Size(450, 23);
            this.cbo_LayerName.TabIndex = 0;
            this.cbo_LayerName.SelectedIndexChanged += new System.EventHandler(this.cbo_LayerName_SelectedIndexChanged);
            // 
            // cbo_SelectMethod
            // 
            this.cbo_SelectMethod.FormattingEnabled = true;
            this.cbo_SelectMethod.Items.AddRange(new object[] {
            "Create a new section",
            "Add to current section",
            "Remove from current section",
            "Select from current section"});
            this.cbo_SelectMethod.Location = new System.Drawing.Point(110, 73);
            this.cbo_SelectMethod.Name = "cbo_SelectMethod";
            this.cbo_SelectMethod.Size = new System.Drawing.Size(450, 23);
            this.cbo_SelectMethod.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbo_SelectMethod);
            this.splitContainer1.Panel1.Controls.Add(this.cbo_LayerName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(587, 563);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "METHOD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "NAME:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_Equal);
            this.splitContainer2.Panel1.Controls.Add(this.btn_unique);
            this.splitContainer2.Panel1.Controls.Add(this.lst_Value);
            this.splitContainer2.Panel1.Controls.Add(this.lst_Fields);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbl_SelectResult);
            this.splitContainer2.Panel2.Controls.Add(this.rtx_SelectResult);
            this.splitContainer2.Panel2.Controls.Add(this.btn_clear);
            this.splitContainer2.Panel2.Controls.Add(this.btn_ok);
            this.splitContainer2.Panel2.Controls.Add(this.btn_apply);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Size = new System.Drawing.Size(587, 445);
            this.splitContainer2.SplitterDistance = 162;
            this.splitContainer2.TabIndex = 0;
            // 
            // lst_Value
            // 
            this.lst_Value.FormattingEnabled = true;
            this.lst_Value.ItemHeight = 15;
            this.lst_Value.Location = new System.Drawing.Point(270, 20);
            this.lst_Value.Name = "lst_Value";
            this.lst_Value.Size = new System.Drawing.Size(187, 139);
            this.lst_Value.TabIndex = 1;
            this.lst_Value.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_Value_MouseDoubleClick);
            // 
            // lst_Fields
            // 
            this.lst_Fields.FormattingEnabled = true;
            this.lst_Fields.ItemHeight = 15;
            this.lst_Fields.Location = new System.Drawing.Point(31, 20);
            this.lst_Fields.Name = "lst_Fields";
            this.lst_Fields.Size = new System.Drawing.Size(195, 139);
            this.lst_Fields.TabIndex = 0;
            this.lst_Fields.SelectedIndexChanged += new System.EventHandler(this.lst_Fields_SelectedIndexChanged);
            this.lst_Fields.DoubleClick += new System.EventHandler(this.lst_Fields_DoubleClick);
            // 
            // lbl_SelectResult
            // 
            this.lbl_SelectResult.AutoSize = true;
            this.lbl_SelectResult.Location = new System.Drawing.Point(28, 18);
            this.lbl_SelectResult.Name = "lbl_SelectResult";
            this.lbl_SelectResult.Size = new System.Drawing.Size(159, 15);
            this.lbl_SelectResult.TabIndex = 5;
            this.lbl_SelectResult.Text = "SELECT * FROM WHERE";
            // 
            // rtx_SelectResult
            // 
            this.rtx_SelectResult.Location = new System.Drawing.Point(31, 45);
            this.rtx_SelectResult.Name = "rtx_SelectResult";
            this.rtx_SelectResult.Size = new System.Drawing.Size(529, 144);
            this.rtx_SelectResult.TabIndex = 4;
            this.rtx_SelectResult.Text = "";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(31, 195);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(79, 35);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(287, 195);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(93, 35);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(386, 195);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(80, 35);
            this.btn_apply.TabIndex = 1;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_unique
            // 
            this.btn_unique.Location = new System.Drawing.Point(476, 20);
            this.btn_unique.Name = "btn_unique";
            this.btn_unique.Size = new System.Drawing.Size(99, 75);
            this.btn_unique.TabIndex = 2;
            this.btn_unique.Text = "Get Unique Values";
            this.btn_unique.UseVisualStyleBackColor = true;
            this.btn_unique.Click += new System.EventHandler(this.btn_unique_Click);
            // 
            // btn_Equal
            // 
            this.btn_Equal.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Equal.Location = new System.Drawing.Point(476, 119);
            this.btn_Equal.Name = "btn_Equal";
            this.btn_Equal.Size = new System.Drawing.Size(99, 40);
            this.btn_Equal.TabIndex = 3;
            this.btn_Equal.Text = "=";
            this.btn_Equal.UseVisualStyleBackColor = true;
            this.btn_Equal.Click += new System.EventHandler(this.btn_Equal_Click);
            // 
            // frmQueryByAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 563);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmQueryByAttribute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQueryByAttribute";
            this.Load += new System.EventHandler(this.frmQueryByAttribute_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_LayerName;
        private System.Windows.Forms.ComboBox cbo_SelectMethod;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lst_Fields;
        private System.Windows.Forms.ListBox lst_Value;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.RichTextBox rtx_SelectResult;
        private System.Windows.Forms.Label lbl_SelectResult;
        private System.Windows.Forms.Button btn_unique;
        private System.Windows.Forms.Button btn_Equal;
    }
}