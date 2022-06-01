
namespace TauWarriorScript.ActionForms
{
    partial class RepeatForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.actionPaste = new System.Windows.Forms.Button();
            this.actionCopy = new System.Windows.Forms.Button();
            this.actionUp = new System.Windows.Forms.Button();
            this.actionPick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.removeAction = new System.Windows.Forms.Button();
            this.addAction = new System.Windows.Forms.Button();
            this.actionList = new System.Windows.Forms.ListBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repeat";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(167, 270);
            this.count.Maximum = new decimal(new int[] {
            1000000,
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
            this.label5.Location = new System.Drawing.Point(120, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.actionPaste);
            this.groupBox3.Controls.Add(this.actionCopy);
            this.groupBox3.Controls.Add(this.actionUp);
            this.groupBox3.Controls.Add(this.actionPick);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.removeAction);
            this.groupBox3.Controls.Add(this.addAction);
            this.groupBox3.Controls.Add(this.actionList);
            this.groupBox3.Location = new System.Drawing.Point(6, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 242);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            // 
            // actionPaste
            // 
            this.actionPaste.Location = new System.Drawing.Point(196, 51);
            this.actionPaste.Name = "actionPaste";
            this.actionPaste.Size = new System.Drawing.Size(51, 23);
            this.actionPaste.TabIndex = 0;
            this.actionPaste.Text = "Paste";
            this.actionPaste.UseVisualStyleBackColor = true;
            this.actionPaste.Click += new System.EventHandler(this.actionPaste_Click);
            // 
            // actionCopy
            // 
            this.actionCopy.Location = new System.Drawing.Point(139, 51);
            this.actionCopy.Name = "actionCopy";
            this.actionCopy.Size = new System.Drawing.Size(51, 23);
            this.actionCopy.TabIndex = 0;
            this.actionCopy.Text = "Copy";
            this.actionCopy.UseVisualStyleBackColor = true;
            this.actionCopy.Click += new System.EventHandler(this.actionCopy_Click);
            // 
            // actionUp
            // 
            this.actionUp.Location = new System.Drawing.Point(253, 51);
            this.actionUp.Name = "actionUp";
            this.actionUp.Size = new System.Drawing.Size(42, 23);
            this.actionUp.TabIndex = 0;
            this.actionUp.Text = "Up";
            this.actionUp.UseVisualStyleBackColor = true;
            this.actionUp.Click += new System.EventHandler(this.actionUp_Click);
            // 
            // actionPick
            // 
            this.actionPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionPick.FormattingEnabled = true;
            this.actionPick.Location = new System.Drawing.Point(57, 22);
            this.actionPick.Name = "actionPick";
            this.actionPick.Size = new System.Drawing.Size(238, 23);
            this.actionPick.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action:";
            // 
            // removeAction
            // 
            this.removeAction.Location = new System.Drawing.Point(301, 51);
            this.removeAction.Name = "removeAction";
            this.removeAction.Size = new System.Drawing.Size(75, 23);
            this.removeAction.TabIndex = 0;
            this.removeAction.Text = "Remove";
            this.removeAction.UseVisualStyleBackColor = true;
            this.removeAction.Click += new System.EventHandler(this.removeAction_Click);
            // 
            // addAction
            // 
            this.addAction.Location = new System.Drawing.Point(301, 22);
            this.addAction.Name = "addAction";
            this.addAction.Size = new System.Drawing.Size(75, 23);
            this.addAction.TabIndex = 0;
            this.addAction.Text = "Add";
            this.addAction.UseVisualStyleBackColor = true;
            this.addAction.Click += new System.EventHandler(this.addAction_Click);
            // 
            // actionList
            // 
            this.actionList.FormattingEnabled = true;
            this.actionList.ItemHeight = 15;
            this.actionList.Location = new System.Drawing.Point(6, 80);
            this.actionList.Name = "actionList";
            this.actionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.actionList.Size = new System.Drawing.Size(370, 154);
            this.actionList.TabIndex = 0;
            this.actionList.DoubleClick += new System.EventHandler(this.actionList_DoubleClick);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(333, 313);
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
            this.ok.Location = new System.Drawing.Point(252, 313);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // RepeatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 341);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RepeatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Repeat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox actionPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeAction;
        private System.Windows.Forms.Button addAction;
        private System.Windows.Forms.ListBox actionList;
        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button actionUp;
        private System.Windows.Forms.Button actionCopy;
        private System.Windows.Forms.Button actionPaste;
    }
}