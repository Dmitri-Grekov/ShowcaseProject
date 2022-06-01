
namespace TauWarriorScript
{
    partial class KeyboardActionForm
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
            this.secondModKeyList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modKeyList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.holdTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.keyList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stateList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secondModKeyList);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.modKeyList);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.holdTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.keyList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.stateList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keyboard Action";
            // 
            // secondModKeyList
            // 
            this.secondModKeyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondModKeyList.FormattingEnabled = true;
            this.secondModKeyList.Location = new System.Drawing.Point(201, 74);
            this.secondModKeyList.Name = "secondModKeyList";
            this.secondModKeyList.Size = new System.Drawing.Size(127, 23);
            this.secondModKeyList.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Second Modifier Key:";
            // 
            // modKeyList
            // 
            this.modKeyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modKeyList.FormattingEnabled = true;
            this.modKeyList.Location = new System.Drawing.Point(287, 45);
            this.modKeyList.Name = "modKeyList";
            this.modKeyList.Size = new System.Drawing.Size(127, 23);
            this.modKeyList.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Modifier Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "ms";
            // 
            // holdTime
            // 
            this.holdTime.Location = new System.Drawing.Point(201, 103);
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
            this.label4.Location = new System.Drawing.Point(130, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hold Time:";
            // 
            // keyList
            // 
            this.keyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyList.FormattingEnabled = true;
            this.keyList.Location = new System.Drawing.Point(54, 45);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(127, 23);
            this.keyList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Key:";
            // 
            // stateList
            // 
            this.stateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateList.FormattingEnabled = true;
            this.stateList.Location = new System.Drawing.Point(287, 16);
            this.stateList.Name = "stateList";
            this.stateList.Size = new System.Drawing.Size(127, 23);
            this.stateList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Next State:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(54, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(149, 23);
            this.name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(361, 148);
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
            this.ok.Location = new System.Drawing.Point(280, 148);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // KeyboardActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 177);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KeyboardActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KeyboardActionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holdTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown holdTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stateList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox secondModKeyList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox modKeyList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}