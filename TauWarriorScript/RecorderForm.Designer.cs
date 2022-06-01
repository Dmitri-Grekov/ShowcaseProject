namespace TauWarriorScript
{
    partial class RecorderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.recordsList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.speedList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.directInput = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.areaPoints = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.areaImage = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.recordCopy = new System.Windows.Forms.Button();
            this.openFolder = new System.Windows.Forms.Button();
            this.recordsRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Records:";
            // 
            // recordsList
            // 
            this.recordsList.FormattingEnabled = true;
            this.recordsList.ItemHeight = 15;
            this.recordsList.Location = new System.Drawing.Point(20, 314);
            this.recordsList.Name = "recordsList";
            this.recordsList.Size = new System.Drawing.Size(231, 124);
            this.recordsList.TabIndex = 0;
            this.recordsList.DoubleClick += new System.EventHandler(this.recordsList_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.recordsList);
            this.groupBox1.Controls.Add(this.recordCopy);
            this.groupBox1.Controls.Add(this.openFolder);
            this.groupBox1.Controls.Add(this.recordsRemove);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 503);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorder";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.speedList);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.directInput);
            this.groupBox3.Location = new System.Drawing.Point(8, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 104);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "F12 - Stop record";
            // 
            // speedList
            // 
            this.speedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedList.FormattingEnabled = true;
            this.speedList.Location = new System.Drawing.Point(98, 72);
            this.speedList.Name = "speedList";
            this.speedList.Size = new System.Drawing.Size(148, 23);
            this.speedList.TabIndex = 0;
            this.speedList.SelectedIndexChanged += new System.EventHandler(this.speedList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mouse Speed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "F11 - Start record";
            // 
            // directInput
            // 
            this.directInput.AutoSize = true;
            this.directInput.Location = new System.Drawing.Point(27, 53);
            this.directInput.Name = "directInput";
            this.directInput.Size = new System.Drawing.Size(85, 19);
            this.directInput.TabIndex = 0;
            this.directInput.Text = "DirectInput";
            this.directInput.UseVisualStyleBackColor = true;
            this.directInput.CheckedChanged += new System.EventHandler(this.directInput_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.areaPoints);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.areaImage);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 151);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screen";
            // 
            // areaPoints
            // 
            this.areaPoints.AutoSize = true;
            this.areaPoints.Checked = true;
            this.areaPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.areaPoints.Location = new System.Drawing.Point(27, 78);
            this.areaPoints.Name = "areaPoints";
            this.areaPoints.Size = new System.Drawing.Size(87, 19);
            this.areaPoints.TabIndex = 0;
            this.areaPoints.Text = "Create Area";
            this.areaPoints.UseVisualStyleBackColor = true;
            this.areaPoints.CheckedChanged += new System.EventHandler(this.areaPoints_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "F5 - Add Color";
            // 
            // areaImage
            // 
            this.areaImage.AutoSize = true;
            this.areaImage.Location = new System.Drawing.Point(140, 78);
            this.areaImage.Name = "areaImage";
            this.areaImage.Size = new System.Drawing.Size(96, 19);
            this.areaImage.TabIndex = 0;
            this.areaImage.Text = "Create Image";
            this.areaImage.UseVisualStyleBackColor = true;
            this.areaImage.CheckedChanged += new System.EventHandler(this.areaImage_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "F8 - Set RightBottom point and Save";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "F7 - Set LeftTop point";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "F10 - ScreenShot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "F9 - Create Point";
            // 
            // recordCopy
            // 
            this.recordCopy.Location = new System.Drawing.Point(98, 442);
            this.recordCopy.Name = "recordCopy";
            this.recordCopy.Size = new System.Drawing.Size(75, 23);
            this.recordCopy.TabIndex = 0;
            this.recordCopy.Text = "Copy";
            this.recordCopy.UseVisualStyleBackColor = true;
            this.recordCopy.Click += new System.EventHandler(this.recordCopy_Click);
            // 
            // openFolder
            // 
            this.openFolder.Location = new System.Drawing.Point(83, 471);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(105, 23);
            this.openFolder.TabIndex = 0;
            this.openFolder.Text = "Recorder Folder";
            this.openFolder.UseVisualStyleBackColor = true;
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // recordsRemove
            // 
            this.recordsRemove.Location = new System.Drawing.Point(193, 251);
            this.recordsRemove.Name = "recordsRemove";
            this.recordsRemove.Size = new System.Drawing.Size(59, 23);
            this.recordsRemove.TabIndex = 0;
            this.recordsRemove.Text = "Remove";
            this.recordsRemove.UseVisualStyleBackColor = true;
            this.recordsRemove.Click += new System.EventHandler(this.recordsRemove_Click);
            // 
            // RecorderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 522);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecorderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecorderForm_FormClosed);
            this.Load += new System.EventHandler(this.RecorderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox recordsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button recordsRemove;
        private System.Windows.Forms.Button recordCopy;
        private System.Windows.Forms.CheckBox directInput;
        private System.Windows.Forms.ComboBox speedList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox areaImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox areaPoints;
    }
}