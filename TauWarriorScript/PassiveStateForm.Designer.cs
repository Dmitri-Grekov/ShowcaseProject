
namespace TauWarriorScript
{
    partial class PassiveStateForm
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
            this.statesEditAction = new System.Windows.Forms.Button();
            this.statesSetAction = new System.Windows.Forms.Button();
            this.statesActionPick = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.statesActionList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.stateList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statesEditAction);
            this.groupBox1.Controls.Add(this.statesSetAction);
            this.groupBox1.Controls.Add(this.statesActionPick);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.statesActionList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.time);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.stateList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Passive State";
            // 
            // statesEditAction
            // 
            this.statesEditAction.Location = new System.Drawing.Point(317, 74);
            this.statesEditAction.Name = "statesEditAction";
            this.statesEditAction.Size = new System.Drawing.Size(75, 23);
            this.statesEditAction.TabIndex = 0;
            this.statesEditAction.Text = "Edit";
            this.statesEditAction.UseVisualStyleBackColor = true;
            this.statesEditAction.Click += new System.EventHandler(this.statesEditAction_Click);
            // 
            // statesSetAction
            // 
            this.statesSetAction.Location = new System.Drawing.Point(317, 45);
            this.statesSetAction.Name = "statesSetAction";
            this.statesSetAction.Size = new System.Drawing.Size(75, 23);
            this.statesSetAction.TabIndex = 0;
            this.statesSetAction.Text = "Set";
            this.statesSetAction.UseVisualStyleBackColor = true;
            this.statesSetAction.Click += new System.EventHandler(this.statesSetAction_Click);
            // 
            // statesActionPick
            // 
            this.statesActionPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statesActionPick.FormattingEnabled = true;
            this.statesActionPick.Location = new System.Drawing.Point(73, 45);
            this.statesActionPick.Name = "statesActionPick";
            this.statesActionPick.Size = new System.Drawing.Size(238, 23);
            this.statesActionPick.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Action:";
            // 
            // statesActionList
            // 
            this.statesActionList.FormattingEnabled = true;
            this.statesActionList.ItemHeight = 15;
            this.statesActionList.Location = new System.Drawing.Point(22, 76);
            this.statesActionList.Name = "statesActionList";
            this.statesActionList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.statesActionList.Size = new System.Drawing.Size(289, 19);
            this.statesActionList.TabIndex = 0;
            this.statesActionList.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "sec";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(161, 101);
            this.time.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(90, 23);
            this.time.TabIndex = 0;
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Time:";
            // 
            // stateList
            // 
            this.stateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateList.FormattingEnabled = true;
            this.stateList.Location = new System.Drawing.Point(279, 16);
            this.stateList.Name = "stateList";
            this.stateList.Size = new System.Drawing.Size(127, 23);
            this.stateList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 19);
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
            this.cancel.Location = new System.Drawing.Point(352, 147);
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
            this.ok.Location = new System.Drawing.Point(271, 147);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // PassiveStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 175);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PassiveStateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PassiveStateForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stateList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ListBox statesActionList;
        private System.Windows.Forms.ComboBox statesActionPick;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button statesSetAction;
        private System.Windows.Forms.Button statesEditAction;
    }
}