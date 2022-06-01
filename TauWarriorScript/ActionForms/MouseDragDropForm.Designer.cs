
namespace TauWarriorScript.ActionForms
{
    partial class MouseDragDropForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.secondAccuracy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.secondImageList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.secondRadio2 = new System.Windows.Forms.RadioButton();
            this.secondRadio1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.secondPointList = new System.Windows.Forms.ComboBox();
            this.secondAreaList = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.secondIsFullScreen = new System.Windows.Forms.CheckBox();
            this.speedList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.firstAccuracy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.firstImageList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.firstRadio2 = new System.Windows.Forms.RadioButton();
            this.firstRadio1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.firstPointList = new System.Windows.Forms.ComboBox();
            this.firstAreaList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.firstIsFullScreen = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondAccuracy)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstAccuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.speedList);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mouse Drag Drop";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.secondAccuracy);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.secondImageList);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.secondRadio2);
            this.groupBox3.Controls.Add(this.secondRadio1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.secondPointList);
            this.groupBox3.Controls.Add(this.secondAreaList);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.secondIsFullScreen);
            this.groupBox3.Location = new System.Drawing.Point(335, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 164);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drop To";
            // 
            // secondAccuracy
            // 
            this.secondAccuracy.Enabled = false;
            this.secondAccuracy.Location = new System.Drawing.Point(170, 132);
            this.secondAccuracy.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.secondAccuracy.Name = "secondAccuracy";
            this.secondAccuracy.Size = new System.Drawing.Size(44, 23);
            this.secondAccuracy.TabIndex = 0;
            this.secondAccuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.secondAccuracy.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Accuracy:";
            // 
            // secondImageList
            // 
            this.secondImageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondImageList.Enabled = false;
            this.secondImageList.FormattingEnabled = true;
            this.secondImageList.Location = new System.Drawing.Point(79, 103);
            this.secondImageList.Name = "secondImageList";
            this.secondImageList.Size = new System.Drawing.Size(233, 23);
            this.secondImageList.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Image:";
            // 
            // secondRadio2
            // 
            this.secondRadio2.AutoSize = true;
            this.secondRadio2.Location = new System.Drawing.Point(10, 107);
            this.secondRadio2.Name = "secondRadio2";
            this.secondRadio2.Size = new System.Drawing.Size(14, 13);
            this.secondRadio2.TabIndex = 0;
            this.secondRadio2.UseVisualStyleBackColor = true;
            this.secondRadio2.CheckedChanged += new System.EventHandler(this.secondRadio2_CheckedChanged);
            // 
            // secondRadio1
            // 
            this.secondRadio1.AutoSize = true;
            this.secondRadio1.Checked = true;
            this.secondRadio1.Location = new System.Drawing.Point(10, 78);
            this.secondRadio1.Name = "secondRadio1";
            this.secondRadio1.Size = new System.Drawing.Size(14, 13);
            this.secondRadio1.TabIndex = 0;
            this.secondRadio1.TabStop = true;
            this.secondRadio1.UseVisualStyleBackColor = true;
            this.secondRadio1.CheckedChanged += new System.EventHandler(this.secondRadio1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Point:";
            // 
            // secondPointList
            // 
            this.secondPointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondPointList.FormattingEnabled = true;
            this.secondPointList.Location = new System.Drawing.Point(79, 74);
            this.secondPointList.Name = "secondPointList";
            this.secondPointList.Size = new System.Drawing.Size(233, 23);
            this.secondPointList.TabIndex = 0;
            // 
            // secondAreaList
            // 
            this.secondAreaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondAreaList.FormattingEnabled = true;
            this.secondAreaList.Location = new System.Drawing.Point(79, 45);
            this.secondAreaList.Name = "secondAreaList";
            this.secondAreaList.Size = new System.Drawing.Size(233, 23);
            this.secondAreaList.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Area:";
            // 
            // secondIsFullScreen
            // 
            this.secondIsFullScreen.AutoSize = true;
            this.secondIsFullScreen.Location = new System.Drawing.Point(23, 22);
            this.secondIsFullScreen.Name = "secondIsFullScreen";
            this.secondIsFullScreen.Size = new System.Drawing.Size(91, 19);
            this.secondIsFullScreen.TabIndex = 0;
            this.secondIsFullScreen.Text = "Is FullScreen";
            this.secondIsFullScreen.UseVisualStyleBackColor = true;
            this.secondIsFullScreen.CheckedChanged += new System.EventHandler(this.secondIsFullScreen_CheckedChanged);
            // 
            // speedList
            // 
            this.speedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedList.FormattingEnabled = true;
            this.speedList.Location = new System.Drawing.Point(274, 192);
            this.speedList.Name = "speedList";
            this.speedList.Size = new System.Drawing.Size(157, 23);
            this.speedList.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Speed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.firstAccuracy);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.firstImageList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.firstRadio2);
            this.groupBox2.Controls.Add(this.firstRadio1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.firstPointList);
            this.groupBox2.Controls.Add(this.firstAreaList);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.firstIsFullScreen);
            this.groupBox2.Location = new System.Drawing.Point(6, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 164);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drag From";
            // 
            // firstAccuracy
            // 
            this.firstAccuracy.Enabled = false;
            this.firstAccuracy.Location = new System.Drawing.Point(170, 132);
            this.firstAccuracy.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.firstAccuracy.Name = "firstAccuracy";
            this.firstAccuracy.Size = new System.Drawing.Size(44, 23);
            this.firstAccuracy.TabIndex = 0;
            this.firstAccuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.firstAccuracy.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Accuracy:";
            // 
            // firstImageList
            // 
            this.firstImageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstImageList.Enabled = false;
            this.firstImageList.FormattingEnabled = true;
            this.firstImageList.Location = new System.Drawing.Point(79, 103);
            this.firstImageList.Name = "firstImageList";
            this.firstImageList.Size = new System.Drawing.Size(233, 23);
            this.firstImageList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image:";
            // 
            // firstRadio2
            // 
            this.firstRadio2.AutoSize = true;
            this.firstRadio2.Location = new System.Drawing.Point(10, 107);
            this.firstRadio2.Name = "firstRadio2";
            this.firstRadio2.Size = new System.Drawing.Size(14, 13);
            this.firstRadio2.TabIndex = 0;
            this.firstRadio2.UseVisualStyleBackColor = true;
            this.firstRadio2.CheckedChanged += new System.EventHandler(this.firstRadio2_CheckedChanged);
            // 
            // firstRadio1
            // 
            this.firstRadio1.AutoSize = true;
            this.firstRadio1.Checked = true;
            this.firstRadio1.Location = new System.Drawing.Point(10, 78);
            this.firstRadio1.Name = "firstRadio1";
            this.firstRadio1.Size = new System.Drawing.Size(14, 13);
            this.firstRadio1.TabIndex = 0;
            this.firstRadio1.TabStop = true;
            this.firstRadio1.UseVisualStyleBackColor = true;
            this.firstRadio1.CheckedChanged += new System.EventHandler(this.firstRadio1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Point:";
            // 
            // firstPointList
            // 
            this.firstPointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstPointList.FormattingEnabled = true;
            this.firstPointList.Location = new System.Drawing.Point(79, 74);
            this.firstPointList.Name = "firstPointList";
            this.firstPointList.Size = new System.Drawing.Size(233, 23);
            this.firstPointList.TabIndex = 0;
            // 
            // firstAreaList
            // 
            this.firstAreaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstAreaList.FormattingEnabled = true;
            this.firstAreaList.Location = new System.Drawing.Point(79, 45);
            this.firstAreaList.Name = "firstAreaList";
            this.firstAreaList.Size = new System.Drawing.Size(233, 23);
            this.firstAreaList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Area:";
            // 
            // firstIsFullScreen
            // 
            this.firstIsFullScreen.AutoSize = true;
            this.firstIsFullScreen.Location = new System.Drawing.Point(23, 22);
            this.firstIsFullScreen.Name = "firstIsFullScreen";
            this.firstIsFullScreen.Size = new System.Drawing.Size(91, 19);
            this.firstIsFullScreen.TabIndex = 0;
            this.firstIsFullScreen.Text = "Is FullScreen";
            this.firstIsFullScreen.UseVisualStyleBackColor = true;
            this.firstIsFullScreen.CheckedChanged += new System.EventHandler(this.firstIsFullScreen_CheckedChanged);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(601, 235);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(520, 235);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // MouseDragDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 265);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MouseDragDropForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mouse Drag Drop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondAccuracy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstAccuracy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox firstAreaList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox firstIsFullScreen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox firstPointList;
        private System.Windows.Forms.ComboBox firstImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton firstRadio2;
        private System.Windows.Forms.RadioButton firstRadio1;
        private System.Windows.Forms.ComboBox speedList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown firstAccuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown secondAccuracy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox secondImageList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton secondRadio2;
        private System.Windows.Forms.RadioButton secondRadio1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox secondPointList;
        private System.Windows.Forms.ComboBox secondAreaList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox secondIsFullScreen;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}