namespace TauWarriorScript.ActionForms
{
    partial class ScreenFindMoveForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.option2 = new System.Windows.Forms.RadioButton();
            this.option1 = new System.Windows.Forms.RadioButton();
            this.option3 = new System.Windows.Forms.RadioButton();
            this.speedList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.accuracy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.areaList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isFullScreen = new System.Windows.Forms.CheckBox();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.colorList = new System.Windows.Forms.ComboBox();
            this.imageList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(264, 211);
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
            this.ok.Location = new System.Drawing.Point(183, 211);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.speedList);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.accuracy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.areaList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.isFullScreen);
            this.groupBox1.Controls.Add(this.radio2);
            this.groupBox1.Controls.Add(this.radio1);
            this.groupBox1.Controls.Add(this.colorList);
            this.groupBox1.Controls.Add(this.imageList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen Find Click";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.option2);
            this.panel1.Controls.Add(this.option1);
            this.panel1.Controls.Add(this.option3);
            this.panel1.Location = new System.Drawing.Point(154, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 25);
            this.panel1.TabIndex = 0;
            // 
            // option2
            // 
            this.option2.AutoSize = true;
            this.option2.Location = new System.Drawing.Point(48, 3);
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(47, 19);
            this.option2.TabIndex = 0;
            this.option2.Text = "First";
            this.option2.UseVisualStyleBackColor = true;
            this.option2.CheckedChanged += new System.EventHandler(this.option2_CheckedChanged);
            // 
            // option1
            // 
            this.option1.AutoSize = true;
            this.option1.Checked = true;
            this.option1.Location = new System.Drawing.Point(3, 3);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(39, 19);
            this.option1.TabIndex = 0;
            this.option1.TabStop = true;
            this.option1.Text = "All";
            this.option1.UseVisualStyleBackColor = true;
            this.option1.CheckedChanged += new System.EventHandler(this.option1_CheckedChanged);
            // 
            // option3
            // 
            this.option3.AutoSize = true;
            this.option3.Location = new System.Drawing.Point(101, 3);
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(63, 19);
            this.option3.TabIndex = 0;
            this.option3.Text = "Closest";
            this.option3.UseVisualStyleBackColor = true;
            this.option3.CheckedChanged += new System.EventHandler(this.option3_CheckedChanged);
            // 
            // speedList
            // 
            this.speedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedList.FormattingEnabled = true;
            this.speedList.Location = new System.Drawing.Point(105, 166);
            this.speedList.Name = "speedList";
            this.speedList.Size = new System.Drawing.Size(157, 23);
            this.speedList.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Speed:";
            // 
            // accuracy
            // 
            this.accuracy.Location = new System.Drawing.Point(170, 137);
            this.accuracy.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.accuracy.Name = "accuracy";
            this.accuracy.Size = new System.Drawing.Size(44, 23);
            this.accuracy.TabIndex = 0;
            this.accuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.accuracy.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Accuracy:";
            // 
            // areaList
            // 
            this.areaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaList.Enabled = false;
            this.areaList.FormattingEnabled = true;
            this.areaList.Location = new System.Drawing.Point(82, 50);
            this.areaList.Name = "areaList";
            this.areaList.Size = new System.Drawing.Size(233, 23);
            this.areaList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Area:";
            // 
            // isFullScreen
            // 
            this.isFullScreen.AutoSize = true;
            this.isFullScreen.Checked = true;
            this.isFullScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isFullScreen.Location = new System.Drawing.Point(33, 22);
            this.isFullScreen.Name = "isFullScreen";
            this.isFullScreen.Size = new System.Drawing.Size(91, 19);
            this.isFullScreen.TabIndex = 0;
            this.isFullScreen.Text = "Is FullScreen";
            this.isFullScreen.UseVisualStyleBackColor = true;
            this.isFullScreen.CheckedChanged += new System.EventHandler(this.isFullScreen_CheckedChanged);
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Enabled = false;
            this.radio2.Location = new System.Drawing.Point(13, 112);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(14, 13);
            this.radio2.TabIndex = 0;
            this.radio2.UseVisualStyleBackColor = true;
            this.radio2.CheckedChanged += new System.EventHandler(this.radio2_CheckedChanged);
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(13, 83);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(14, 13);
            this.radio1.TabIndex = 0;
            this.radio1.TabStop = true;
            this.radio1.UseVisualStyleBackColor = true;
            this.radio1.CheckedChanged += new System.EventHandler(this.radio1_CheckedChanged);
            // 
            // colorList
            // 
            this.colorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorList.Enabled = false;
            this.colorList.FormattingEnabled = true;
            this.colorList.Location = new System.Drawing.Point(82, 108);
            this.colorList.Name = "colorList";
            this.colorList.Size = new System.Drawing.Size(233, 23);
            this.colorList.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageList.FormattingEnabled = true;
            this.imageList.Location = new System.Drawing.Point(82, 79);
            this.imageList.Name = "imageList";
            this.imageList.Size = new System.Drawing.Size(233, 23);
            this.imageList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Color:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image:";
            // 
            // ScreenFindMoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 240);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScreenFindMoveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screen Find Move";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton option2;
        private System.Windows.Forms.RadioButton option1;
        private System.Windows.Forms.RadioButton option3;
        private System.Windows.Forms.ComboBox speedList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown accuracy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox areaList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isFullScreen;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.ComboBox colorList;
        private System.Windows.Forms.ComboBox imageList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}