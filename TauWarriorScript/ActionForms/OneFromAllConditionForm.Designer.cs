namespace TauWarriorScript.ActionForms
{
    partial class OneFromAllConditionForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.conditionPaste = new System.Windows.Forms.Button();
            this.conditionCopy = new System.Windows.Forms.Button();
            this.conditionUp = new System.Windows.Forms.Button();
            this.notTrue = new System.Windows.Forms.CheckBox();
            this.conditionActionPick = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.conditionRemoveAction = new System.Windows.Forms.Button();
            this.conditionAddAction = new System.Windows.Forms.Button();
            this.conditionActionList = new System.Windows.Forms.ListBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.conditionPaste);
            this.groupBox2.Controls.Add(this.conditionCopy);
            this.groupBox2.Controls.Add(this.conditionUp);
            this.groupBox2.Controls.Add(this.notTrue);
            this.groupBox2.Controls.Add(this.conditionActionPick);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.conditionRemoveAction);
            this.groupBox2.Controls.Add(this.conditionAddAction);
            this.groupBox2.Controls.Add(this.conditionActionList);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 242);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "One From All Condition";
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
            this.notTrue.Location = new System.Drawing.Point(87, 54);
            this.notTrue.Name = "notTrue";
            this.notTrue.Size = new System.Drawing.Size(37, 19);
            this.notTrue.TabIndex = 0;
            this.notTrue.Text = "!=";
            this.notTrue.UseVisualStyleBackColor = true;
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
            this.cancel.Location = new System.Drawing.Point(321, 254);
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
            this.ok.Location = new System.Drawing.Point(240, 254);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // OneFromAllConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 283);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OneFromAllConditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "One From All Condition";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button conditionUp;
        private System.Windows.Forms.CheckBox notTrue;
        private System.Windows.Forms.ComboBox conditionActionPick;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button conditionRemoveAction;
        private System.Windows.Forms.Button conditionAddAction;
        private System.Windows.Forms.ListBox conditionActionList;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button conditionCopy;
        private System.Windows.Forms.Button conditionPaste;
    }
}