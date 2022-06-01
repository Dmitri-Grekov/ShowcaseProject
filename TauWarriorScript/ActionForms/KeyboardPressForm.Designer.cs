
namespace TauWarriorScript.ActionForms
{
    partial class KeyboardPressForm
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
            this.count = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.key3List = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.key2List = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.holdTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.keyList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.directInput = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directInput);
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.key3List);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.key2List);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.holdTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.keyList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keyboard Press";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(109, 138);
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
            this.label5.Location = new System.Drawing.Point(60, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Count:";
            // 
            // key3List
            // 
            this.key3List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.key3List.FormattingEnabled = true;
            this.key3List.Location = new System.Drawing.Point(109, 80);
            this.key3List.Name = "key3List";
            this.key3List.Size = new System.Drawing.Size(157, 23);
            this.key3List.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Second Modifier:";
            // 
            // key2List
            // 
            this.key2List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.key2List.FormattingEnabled = true;
            this.key2List.Location = new System.Drawing.Point(109, 51);
            this.key2List.Name = "key2List";
            this.key2List.Size = new System.Drawing.Size(157, 23);
            this.key2List.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifier:";
            // 
            // holdTime
            // 
            this.holdTime.Location = new System.Drawing.Point(109, 109);
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
            this.label4.Location = new System.Drawing.Point(38, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hold Time:";
            // 
            // keyList
            // 
            this.keyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyList.FormattingEnabled = true;
            this.keyList.Location = new System.Drawing.Point(109, 22);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(157, 23);
            this.keyList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Key:";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(215, 203);
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
            this.ok.Location = new System.Drawing.Point(134, 203);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // directInput
            // 
            this.directInput.AutoSize = true;
            this.directInput.Location = new System.Drawing.Point(109, 167);
            this.directInput.Name = "directInput";
            this.directInput.Size = new System.Drawing.Size(85, 19);
            this.directInput.TabIndex = 0;
            this.directInput.Text = "DirectInput";
            this.directInput.UseVisualStyleBackColor = true;
            // 
            // KeyboardPressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 232);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KeyboardPressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keyboard Press";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox key3List;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox key2List;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown holdTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox directInput;
    }
}