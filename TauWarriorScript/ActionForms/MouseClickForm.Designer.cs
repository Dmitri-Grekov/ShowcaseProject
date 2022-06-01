
namespace TauWarriorScript.ActionForms
{
    partial class MouseClickForm
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
            this.count = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.holdTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.keyList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.speedList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataPointList = new System.Windows.Forms.ComboBox();
            this.usePoint = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(229, 207);
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
            this.ok.Location = new System.Drawing.Point(148, 207);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usePoint);
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.holdTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.keyList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.speedList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dataPointList);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mouse Click";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(93, 163);
            this.count.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(90, 23);
            this.count.TabIndex = 0;
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Count:";
            // 
            // holdTime
            // 
            this.holdTime.Location = new System.Drawing.Point(93, 134);
            this.holdTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.holdTime.Name = "holdTime";
            this.holdTime.Size = new System.Drawing.Size(90, 23);
            this.holdTime.TabIndex = 0;
            this.holdTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hold Time:";
            // 
            // keyList
            // 
            this.keyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyList.FormattingEnabled = true;
            this.keyList.Location = new System.Drawing.Point(93, 105);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(157, 23);
            this.keyList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Key:";
            // 
            // speedList
            // 
            this.speedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedList.FormattingEnabled = true;
            this.speedList.Location = new System.Drawing.Point(93, 76);
            this.speedList.Name = "speedList";
            this.speedList.Size = new System.Drawing.Size(157, 23);
            this.speedList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Point:";
            // 
            // dataPointList
            // 
            this.dataPointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataPointList.FormattingEnabled = true;
            this.dataPointList.Location = new System.Drawing.Point(49, 47);
            this.dataPointList.Name = "dataPointList";
            this.dataPointList.Size = new System.Drawing.Size(233, 23);
            this.dataPointList.TabIndex = 0;
            // 
            // usePoint
            // 
            this.usePoint.AutoSize = true;
            this.usePoint.Checked = true;
            this.usePoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usePoint.Location = new System.Drawing.Point(49, 22);
            this.usePoint.Name = "usePoint";
            this.usePoint.Size = new System.Drawing.Size(76, 19);
            this.usePoint.TabIndex = 0;
            this.usePoint.Text = "Use Point";
            this.usePoint.UseVisualStyleBackColor = true;
            this.usePoint.CheckedChanged += new System.EventHandler(this.usePoint_CheckedChanged);
            // 
            // MouseClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 237);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MouseClickForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mouse Click";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown holdTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox speedList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox dataPointList;
        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox usePoint;
    }
}