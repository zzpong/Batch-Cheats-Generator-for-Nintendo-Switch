namespace Batch_Cheats_Generator
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load = new System.Windows.Forms.Button();
            this.DataFileBox = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.BaseAddress = new System.Windows.Forms.TextBox();
            this.comboBoxMemoryType = new System.Windows.Forms.ComboBox();
            this.comboBoxCodeFormat = new System.Windows.Forms.ComboBox();
            this.OffsetAdd1 = new System.Windows.Forms.TextBox();
            this.Value1 = new System.Windows.Forms.TextBox();
            this.Bytes1 = new System.Windows.Forms.ComboBox();
            this.Generate = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.OffsetAdd5 = new System.Windows.Forms.TextBox();
            this.Value5 = new System.Windows.Forms.TextBox();
            this.Bytes5 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.OffsetAdd4 = new System.Windows.Forms.TextBox();
            this.Value4 = new System.Windows.Forms.TextBox();
            this.Bytes4 = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.OffsetAdd3 = new System.Windows.Forms.TextBox();
            this.Value3 = new System.Windows.Forms.TextBox();
            this.Bytes3 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.OffsetAdd2 = new System.Windows.Forms.TextBox();
            this.Value2 = new System.Windows.Forms.TextBox();
            this.Bytes2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FreeForAll = new System.Windows.Forms.LinkLabel();
            this.BytesMain = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(282, 14);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 0;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataFileBox
            // 
            this.DataFileBox.Location = new System.Drawing.Point(12, 14);
            this.DataFileBox.Name = "DataFileBox";
            this.DataFileBox.Size = new System.Drawing.Size(264, 21);
            this.DataFileBox.TabIndex = 1;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(89, 20);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(175, 21);
            this.Description.TabIndex = 2;
            // 
            // BaseAddress
            // 
            this.BaseAddress.Location = new System.Drawing.Point(101, 88);
            this.BaseAddress.Name = "BaseAddress";
            this.BaseAddress.Size = new System.Drawing.Size(250, 21);
            this.BaseAddress.TabIndex = 3;
            // 
            // comboBoxMemoryType
            // 
            this.comboBoxMemoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMemoryType.FormattingEnabled = true;
            this.comboBoxMemoryType.Items.AddRange(new object[] {
            "MAIN",
            "HEAP"});
            this.comboBoxMemoryType.Location = new System.Drawing.Point(20, 117);
            this.comboBoxMemoryType.MaxDropDownItems = 2;
            this.comboBoxMemoryType.Name = "comboBoxMemoryType";
            this.comboBoxMemoryType.Size = new System.Drawing.Size(95, 20);
            this.comboBoxMemoryType.TabIndex = 5;
            // 
            // comboBoxCodeFormat
            // 
            this.comboBoxCodeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodeFormat.FormattingEnabled = true;
            this.comboBoxCodeFormat.Items.AddRange(new object[] {
            "Static",
            "Pointer"});
            this.comboBoxCodeFormat.Location = new System.Drawing.Point(113, 76);
            this.comboBoxCodeFormat.MaxDropDownItems = 2;
            this.comboBoxCodeFormat.Name = "comboBoxCodeFormat";
            this.comboBoxCodeFormat.Size = new System.Drawing.Size(100, 20);
            this.comboBoxCodeFormat.TabIndex = 7;
            // 
            // OffsetAdd1
            // 
            this.OffsetAdd1.Enabled = false;
            this.OffsetAdd1.Location = new System.Drawing.Point(7, 41);
            this.OffsetAdd1.Name = "OffsetAdd1";
            this.OffsetAdd1.Size = new System.Drawing.Size(107, 21);
            this.OffsetAdd1.TabIndex = 8;
            // 
            // Value1
            // 
            this.Value1.Enabled = false;
            this.Value1.Location = new System.Drawing.Point(122, 41);
            this.Value1.Name = "Value1";
            this.Value1.Size = new System.Drawing.Size(124, 21);
            this.Value1.TabIndex = 9;
            // 
            // Bytes1
            // 
            this.Bytes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bytes1.Enabled = false;
            this.Bytes1.FormattingEnabled = true;
            this.Bytes1.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.Bytes1.Location = new System.Drawing.Point(258, 41);
            this.Bytes1.MaxDropDownItems = 3;
            this.Bytes1.Name = "Bytes1";
            this.Bytes1.Size = new System.Drawing.Size(60, 20);
            this.Bytes1.TabIndex = 10;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(20, 395);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(101, 23);
            this.Generate.TabIndex = 15;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(134, 395);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(102, 23);
            this.Export.TabIndex = 16;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(363, 14);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(311, 404);
            this.OutputBox.TabIndex = 17;
            this.OutputBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "Base Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BytesMain);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Description);
            this.groupBox1.Controls.Add(this.comboBoxCodeFormat);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 105);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Propoerties";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(231, 78);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(108, 16);
            this.checkBox6.TabIndex = 23;
            this.checkBox6.Text = "Multi Descript";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.OffsetAdd5);
            this.groupBox2.Controls.Add(this.Value5);
            this.groupBox2.Controls.Add(this.Bytes5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.OffsetAdd4);
            this.groupBox2.Controls.Add(this.Value4);
            this.groupBox2.Controls.Add(this.Bytes4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.OffsetAdd3);
            this.groupBox2.Controls.Add(this.Value3);
            this.groupBox2.Controls.Add(this.Bytes3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.OffsetAdd2);
            this.groupBox2.Controls.Add(this.Value2);
            this.groupBox2.Controls.Add(this.Bytes2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.OffsetAdd1);
            this.groupBox2.Controls.Add(this.Value1);
            this.groupBox2.Controls.Add(this.Bytes1);
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 226);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More Properties";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(324, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(324, 189);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 40;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // OffsetAdd5
            // 
            this.OffsetAdd5.Enabled = false;
            this.OffsetAdd5.Location = new System.Drawing.Point(7, 186);
            this.OffsetAdd5.Name = "OffsetAdd5";
            this.OffsetAdd5.Size = new System.Drawing.Size(107, 21);
            this.OffsetAdd5.TabIndex = 37;
            // 
            // Value5
            // 
            this.Value5.Enabled = false;
            this.Value5.Location = new System.Drawing.Point(122, 186);
            this.Value5.Name = "Value5";
            this.Value5.Size = new System.Drawing.Size(124, 21);
            this.Value5.TabIndex = 38;
            // 
            // Bytes5
            // 
            this.Bytes5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bytes5.Enabled = false;
            this.Bytes5.FormattingEnabled = true;
            this.Bytes5.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.Bytes5.Location = new System.Drawing.Point(258, 186);
            this.Bytes5.MaxDropDownItems = 3;
            this.Bytes5.Name = "Bytes5";
            this.Bytes5.Size = new System.Drawing.Size(60, 20);
            this.Bytes5.TabIndex = 39;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(324, 153);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 36;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // OffsetAdd4
            // 
            this.OffsetAdd4.Enabled = false;
            this.OffsetAdd4.Location = new System.Drawing.Point(7, 150);
            this.OffsetAdd4.Name = "OffsetAdd4";
            this.OffsetAdd4.Size = new System.Drawing.Size(107, 21);
            this.OffsetAdd4.TabIndex = 33;
            // 
            // Value4
            // 
            this.Value4.Enabled = false;
            this.Value4.Location = new System.Drawing.Point(122, 150);
            this.Value4.Name = "Value4";
            this.Value4.Size = new System.Drawing.Size(124, 21);
            this.Value4.TabIndex = 34;
            // 
            // Bytes4
            // 
            this.Bytes4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bytes4.Enabled = false;
            this.Bytes4.FormattingEnabled = true;
            this.Bytes4.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.Bytes4.Location = new System.Drawing.Point(258, 150);
            this.Bytes4.MaxDropDownItems = 3;
            this.Bytes4.Name = "Bytes4";
            this.Bytes4.Size = new System.Drawing.Size(60, 20);
            this.Bytes4.TabIndex = 35;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(324, 116);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // OffsetAdd3
            // 
            this.OffsetAdd3.Enabled = false;
            this.OffsetAdd3.Location = new System.Drawing.Point(7, 113);
            this.OffsetAdd3.Name = "OffsetAdd3";
            this.OffsetAdd3.Size = new System.Drawing.Size(107, 21);
            this.OffsetAdd3.TabIndex = 29;
            // 
            // Value3
            // 
            this.Value3.Enabled = false;
            this.Value3.Location = new System.Drawing.Point(122, 113);
            this.Value3.Name = "Value3";
            this.Value3.Size = new System.Drawing.Size(124, 21);
            this.Value3.TabIndex = 30;
            // 
            // Bytes3
            // 
            this.Bytes3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bytes3.Enabled = false;
            this.Bytes3.FormattingEnabled = true;
            this.Bytes3.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.Bytes3.Location = new System.Drawing.Point(258, 113);
            this.Bytes3.MaxDropDownItems = 3;
            this.Bytes3.Name = "Bytes3";
            this.Bytes3.Size = new System.Drawing.Size(60, 20);
            this.Bytes3.TabIndex = 31;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(324, 80);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 28;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // OffsetAdd2
            // 
            this.OffsetAdd2.Enabled = false;
            this.OffsetAdd2.Location = new System.Drawing.Point(7, 77);
            this.OffsetAdd2.Name = "OffsetAdd2";
            this.OffsetAdd2.Size = new System.Drawing.Size(107, 21);
            this.OffsetAdd2.TabIndex = 25;
            // 
            // Value2
            // 
            this.Value2.Enabled = false;
            this.Value2.Location = new System.Drawing.Point(122, 77);
            this.Value2.Name = "Value2";
            this.Value2.Size = new System.Drawing.Size(124, 21);
            this.Value2.TabIndex = 26;
            // 
            // Bytes2
            // 
            this.Bytes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bytes2.Enabled = false;
            this.Bytes2.FormattingEnabled = true;
            this.Bytes2.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.Bytes2.Location = new System.Drawing.Point(258, 77);
            this.Bytes2.MaxDropDownItems = 3;
            this.Bytes2.Name = "Bytes2";
            this.Bytes2.Size = new System.Drawing.Size(60, 20);
            this.Bytes2.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "Bytes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Offset Address";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FreeForAll
            // 
            this.FreeForAll.AutoSize = true;
            this.FreeForAll.Location = new System.Drawing.Point(268, 400);
            this.FreeForAll.Name = "FreeForAll";
            this.FreeForAll.Size = new System.Drawing.Size(77, 12);
            this.FreeForAll.TabIndex = 26;
            this.FreeForAll.TabStop = true;
            this.FreeForAll.Text = "Free For All";
            this.FreeForAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FreeForAll_LinkClicked);
            // 
            // BytesMain
            // 
            this.BytesMain.FormattingEnabled = true;
            this.BytesMain.Items.AddRange(new object[] {
            "4",
            "2",
            "1"});
            this.BytesMain.Location = new System.Drawing.Point(270, 21);
            this.BytesMain.Name = "BytesMain";
            this.BytesMain.Size = new System.Drawing.Size(69, 20);
            this.BytesMain.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(686, 433);
            this.Controls.Add(this.FreeForAll);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.comboBoxMemoryType);
            this.Controls.Add(this.BaseAddress);
            this.Controls.Add(this.DataFileBox);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "Batch Cheats Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.MaximizeBox = false;  //取消最小化按键

        }

        #endregion

        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.TextBox DataFileBox;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.TextBox BaseAddress;
        private System.Windows.Forms.ComboBox comboBoxMemoryType;
        private System.Windows.Forms.ComboBox comboBoxCodeFormat;
        private System.Windows.Forms.TextBox OffsetAdd1;
        private System.Windows.Forms.TextBox Value1;
        private System.Windows.Forms.ComboBox Bytes1;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox OffsetAdd5;
        private System.Windows.Forms.TextBox Value5;
        private System.Windows.Forms.ComboBox Bytes5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox OffsetAdd4;
        private System.Windows.Forms.TextBox Value4;
        private System.Windows.Forms.ComboBox Bytes4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox OffsetAdd3;
        private System.Windows.Forms.TextBox Value3;
        private System.Windows.Forms.ComboBox Bytes3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox OffsetAdd2;
        private System.Windows.Forms.TextBox Value2;
        private System.Windows.Forms.ComboBox Bytes2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel FreeForAll;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox BytesMain;
    }
}

