
namespace TauWarriorScript.ActionForms
{
    partial class WhileForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.conditionPaste = new System.Windows.Forms.Button();
            this.conditionCopy = new System.Windows.Forms.Button();
            this.conditionUp = new System.Windows.Forms.Button();
            this.notTrue = new System.Windows.Forms.CheckBox();
            this.allConditions = new System.Windows.Forms.CheckBox();
            this.conditionActionPick = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.conditionRemoveAction = new System.Windows.Forms.Button();
            this.conditionAddAction = new System.Windows.Forms.Button();
            this.conditionActionList = new System.Windows.Forms.ListBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "While";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(383, 270);
            this.count.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(90, 23);
            this.count.TabIndex = 0;
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Max Count:";
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
            this.groupBox3.Location = new System.Drawing.Point(396, 22);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.conditionPaste);
            this.groupBox2.Controls.Add(this.conditionCopy);
            this.groupBox2.Controls.Add(this.conditionUp);
            this.groupBox2.Controls.Add(this.notTrue);
            this.groupBox2.Controls.Add(this.allConditions);
            this.groupBox2.Controls.Add(this.conditionActionPick);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.conditionRemoveAction);
            this.groupBox2.Controls.Add(this.conditionAddAction);
            this.groupBox2.Controls.Add(this.conditionActionList);
            this.groupBox2.Location = new System.Drawing.Point(6, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 242);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conditions";
            // 
            // conditionPaste
            // 
            this.conditionPaste.Location = new System.Drawing.Point(196, 51);
            this.conditionPaste.Name = "conditionPaste";
            this.conditionPaste.Size = new System.Drawing.Size(51, 23);
            this.conditionPaste.TabIndex = 0;
            this.conditionPaste.Text = "Paste";
            this.conditionPaste.UseVisualStyleBackColor = true;
            this.conditionPaste.Click += new System.EventHandler(this.conditionPaste_Click);
            // 
            // conditionCopy
            // 
            this.conditionCopy.Location = new System.Drawing.Point(139, 51);
            this.conditionCopy.Name = "conditionCopy";
            this.conditionCopy.Size = new System.Drawing.Size(51, 23);
            this.conditionCopy.TabIndex = 0;
            this.conditionCopy.Text = "Copy";
            this.conditionCopy.UseVisualStyleBackColor = true;
            this.conditionCopy.Click += new System.EventHandler(this.conditionCopy_Click);
            // 
            // conditionUp
            // 
            this.conditionUp.Location = new System.Drawing.Point(253, 51);
            this.conditionUp.Name = "conditionUp";
            this.conditionUp.Size = new System.Drawing.Size(42, 23);
            this.conditionUp.TabIndex = 0;
            this.conditionUp.Text = "Up";
            this.conditionUp.UseVisualStyleBackColor = true;
            this.conditionUp.Click += new System.EventHandler(this.conditionUp_Click);
            // 
            // notTrue
            // 
            this.notTrue.AutoSize = true;
            this.notTrue.Location = new System.Drawing.Point(105, 54);
            this.notTrue.Name = "notTrue";
            this.notTrue.Size = new System.Drawing.Size(37, 19);
            this.notTrue.TabIndex = 0;
            this.notTrue.Text = "!=";
            this.notTrue.UseVisualStyleBackColor = true;
            // 
            // allConditions
            // 
            this.allConditions.AutoSize = true;
            this.allConditions.Location = new System.Drawing.Point(6, 54);
            this.allConditions.Name = "allConditions";
            this.allConditions.Size = new System.Drawing.Size(101, 19);
            this.allConditions.TabIndex = 0;
            this.allConditions.Text = "All Conditions";
            this.allConditions.UseVisualStyleBackColor = true;
            // 
            // conditionActionPick
            // 
            this.conditionActionPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionActionPick.FormattingEnabled = true;
            this.conditionActionPick.Location = new System.Drawing.Point(57, 22);
            this.conditionActionPick.Name = "conditionActionPick";
            this.conditionActionPick.Size = new System.Drawing.Size(238, 23);
            this.conditionActionPick.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Action:";
            // 
            // conditionRemoveAction
            // 
            this.conditionRemoveAction.Location = new System.Drawing.Point(301, 51);
            this.conditionRemoveAction.Name = "conditionRemoveAction";
            this.conditionRemoveAction.Size = new System.Drawing.Size(75, 23);
            this.conditionRemoveAction.TabIndex = 0;
            this.conditionRemoveAction.Text = "Remove";
            this.conditionRemoveAction.UseVisualStyleBackColor = true;
            this.conditionRemoveAction.Click += new System.EventHandler(this.conditionRemoveAction_Click);
            // 
            // conditionAddAction
            // 
            this.conditionAddAction.Location = new System.Drawing.Point(301, 22);
            this.conditionAddAction.Name = "conditionAddAction";
            this.conditionAddAction.Size = new System.Drawing.Size(75, 23);
            this.conditionAddAction.TabIndex = 0;
            this.conditionAddAction.Text = "Add";
            this.conditionAddAction.UseVisualStyleBackColor = true;
            this.conditionAddAction.Click += new System.EventHandler(this.conditionAddAction_Click);
            // 
            // conditionActionList
            // 
            this.conditionActionList.FormattingEnabled = true;
            this.conditionActionList.ItemHeight = 15;
            this.conditionActionList.Location = new System.Drawing.Point(6, 80);
            this.conditionActionList.Name = "conditionActionList";
            this.conditionActionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.conditionActionList.Size = new System.Drawing.Size(370, 154);
            this.conditionActionList.TabIndex = 0;
            this.conditionActionList.DoubleClick += new System.EventHandler(this.conditionActionList_DoubleClick);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(723, 314);
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
            this.ok.Location = new System.Drawing.Point(642, 314);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // WhileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 343);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WhileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "While";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox notTrue;
        private System.Windows.Forms.CheckBox allConditions;
        private System.Windows.Forms.ComboBox conditionActionPick;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button conditionRemoveAction;
        private System.Windows.Forms.Button conditionAddAction;
        private System.Windows.Forms.ListBox conditionActionList;
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
        private System.Windows.Forms.Button conditionUp;
        private System.Windows.Forms.Button conditionCopy;
        private System.Windows.Forms.Button actionCopy;
        private System.Windows.Forms.Button actionPaste;
        private System.Windows.Forms.Button conditionPaste;
    }
}