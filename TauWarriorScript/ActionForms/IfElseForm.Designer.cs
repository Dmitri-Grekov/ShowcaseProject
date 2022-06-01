
namespace TauWarriorScript.ActionForms
{
    partial class IfElseForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.elsePaste = new System.Windows.Forms.Button();
            this.elseCopy = new System.Windows.Forms.Button();
            this.elseUp = new System.Windows.Forms.Button();
            this.elseActionPick = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.elseRemoveAction = new System.Windows.Forms.Button();
            this.elseAddAction = new System.Windows.Forms.Button();
            this.elseActionList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ifPaste = new System.Windows.Forms.Button();
            this.ifCopy = new System.Windows.Forms.Button();
            this.ifUp = new System.Windows.Forms.Button();
            this.ifActionPick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ifRemoveAction = new System.Windows.Forms.Button();
            this.ifAddAction = new System.Windows.Forms.Button();
            this.ifActionList = new System.Windows.Forms.ListBox();
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
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1176, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "If Else";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.elsePaste);
            this.groupBox4.Controls.Add(this.elseCopy);
            this.groupBox4.Controls.Add(this.elseUp);
            this.groupBox4.Controls.Add(this.elseActionPick);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.elseRemoveAction);
            this.groupBox4.Controls.Add(this.elseAddAction);
            this.groupBox4.Controls.Add(this.elseActionList);
            this.groupBox4.Location = new System.Drawing.Point(786, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 242);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Else Actions";
            // 
            // elsePaste
            // 
            this.elsePaste.Location = new System.Drawing.Point(196, 51);
            this.elsePaste.Name = "elsePaste";
            this.elsePaste.Size = new System.Drawing.Size(51, 23);
            this.elsePaste.TabIndex = 0;
            this.elsePaste.Text = "Paste";
            this.elsePaste.UseVisualStyleBackColor = true;
            this.elsePaste.Click += new System.EventHandler(this.elsePaste_Click);
            // 
            // elseCopy
            // 
            this.elseCopy.Location = new System.Drawing.Point(139, 51);
            this.elseCopy.Name = "elseCopy";
            this.elseCopy.Size = new System.Drawing.Size(51, 23);
            this.elseCopy.TabIndex = 0;
            this.elseCopy.Text = "Copy";
            this.elseCopy.UseVisualStyleBackColor = true;
            this.elseCopy.Click += new System.EventHandler(this.elseCopy_Click);
            // 
            // elseUp
            // 
            this.elseUp.Location = new System.Drawing.Point(253, 51);
            this.elseUp.Name = "elseUp";
            this.elseUp.Size = new System.Drawing.Size(42, 23);
            this.elseUp.TabIndex = 0;
            this.elseUp.Text = "Up";
            this.elseUp.UseVisualStyleBackColor = true;
            this.elseUp.Click += new System.EventHandler(this.elseUp_Click);
            // 
            // elseActionPick
            // 
            this.elseActionPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elseActionPick.FormattingEnabled = true;
            this.elseActionPick.Location = new System.Drawing.Point(57, 22);
            this.elseActionPick.Name = "elseActionPick";
            this.elseActionPick.Size = new System.Drawing.Size(238, 23);
            this.elseActionPick.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Action:";
            // 
            // elseRemoveAction
            // 
            this.elseRemoveAction.Location = new System.Drawing.Point(301, 51);
            this.elseRemoveAction.Name = "elseRemoveAction";
            this.elseRemoveAction.Size = new System.Drawing.Size(75, 23);
            this.elseRemoveAction.TabIndex = 0;
            this.elseRemoveAction.Text = "Remove";
            this.elseRemoveAction.UseVisualStyleBackColor = true;
            this.elseRemoveAction.Click += new System.EventHandler(this.elseRemoveAction_Click);
            // 
            // elseAddAction
            // 
            this.elseAddAction.Location = new System.Drawing.Point(301, 22);
            this.elseAddAction.Name = "elseAddAction";
            this.elseAddAction.Size = new System.Drawing.Size(75, 23);
            this.elseAddAction.TabIndex = 0;
            this.elseAddAction.Text = "Add";
            this.elseAddAction.UseVisualStyleBackColor = true;
            this.elseAddAction.Click += new System.EventHandler(this.elseAddAction_Click);
            // 
            // elseActionList
            // 
            this.elseActionList.FormattingEnabled = true;
            this.elseActionList.ItemHeight = 15;
            this.elseActionList.Location = new System.Drawing.Point(6, 80);
            this.elseActionList.Name = "elseActionList";
            this.elseActionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.elseActionList.Size = new System.Drawing.Size(370, 154);
            this.elseActionList.TabIndex = 0;
            this.elseActionList.DoubleClick += new System.EventHandler(this.elseActionList_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ifPaste);
            this.groupBox3.Controls.Add(this.ifCopy);
            this.groupBox3.Controls.Add(this.ifUp);
            this.groupBox3.Controls.Add(this.ifActionPick);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ifRemoveAction);
            this.groupBox3.Controls.Add(this.ifAddAction);
            this.groupBox3.Controls.Add(this.ifActionList);
            this.groupBox3.Location = new System.Drawing.Point(396, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 242);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "If Actions";
            // 
            // ifPaste
            // 
            this.ifPaste.Location = new System.Drawing.Point(196, 51);
            this.ifPaste.Name = "ifPaste";
            this.ifPaste.Size = new System.Drawing.Size(51, 23);
            this.ifPaste.TabIndex = 0;
            this.ifPaste.Text = "Paste";
            this.ifPaste.UseVisualStyleBackColor = true;
            this.ifPaste.Click += new System.EventHandler(this.ifPaste_Click);
            // 
            // ifCopy
            // 
            this.ifCopy.Location = new System.Drawing.Point(139, 51);
            this.ifCopy.Name = "ifCopy";
            this.ifCopy.Size = new System.Drawing.Size(51, 23);
            this.ifCopy.TabIndex = 0;
            this.ifCopy.Text = "Copy";
            this.ifCopy.UseVisualStyleBackColor = true;
            this.ifCopy.Click += new System.EventHandler(this.ifCopy_Click);
            // 
            // ifUp
            // 
            this.ifUp.Location = new System.Drawing.Point(253, 51);
            this.ifUp.Name = "ifUp";
            this.ifUp.Size = new System.Drawing.Size(42, 23);
            this.ifUp.TabIndex = 0;
            this.ifUp.Text = "Up";
            this.ifUp.UseVisualStyleBackColor = true;
            this.ifUp.Click += new System.EventHandler(this.ifUp_Click);
            // 
            // ifActionPick
            // 
            this.ifActionPick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ifActionPick.FormattingEnabled = true;
            this.ifActionPick.Location = new System.Drawing.Point(57, 22);
            this.ifActionPick.Name = "ifActionPick";
            this.ifActionPick.Size = new System.Drawing.Size(238, 23);
            this.ifActionPick.TabIndex = 0;
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
            // ifRemoveAction
            // 
            this.ifRemoveAction.Location = new System.Drawing.Point(301, 51);
            this.ifRemoveAction.Name = "ifRemoveAction";
            this.ifRemoveAction.Size = new System.Drawing.Size(75, 23);
            this.ifRemoveAction.TabIndex = 0;
            this.ifRemoveAction.Text = "Remove";
            this.ifRemoveAction.UseVisualStyleBackColor = true;
            this.ifRemoveAction.Click += new System.EventHandler(this.ifRemoveAction_Click);
            // 
            // ifAddAction
            // 
            this.ifAddAction.Location = new System.Drawing.Point(301, 22);
            this.ifAddAction.Name = "ifAddAction";
            this.ifAddAction.Size = new System.Drawing.Size(75, 23);
            this.ifAddAction.TabIndex = 0;
            this.ifAddAction.Text = "Add";
            this.ifAddAction.UseVisualStyleBackColor = true;
            this.ifAddAction.Click += new System.EventHandler(this.ifAddAction_Click);
            // 
            // ifActionList
            // 
            this.ifActionList.FormattingEnabled = true;
            this.ifActionList.ItemHeight = 15;
            this.ifActionList.Location = new System.Drawing.Point(6, 80);
            this.ifActionList.Name = "ifActionList";
            this.ifActionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ifActionList.Size = new System.Drawing.Size(370, 154);
            this.ifActionList.TabIndex = 0;
            this.ifActionList.DoubleClick += new System.EventHandler(this.ifActionList_DoubleClick);
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
            this.cancel.Location = new System.Drawing.Point(1113, 282);
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
            this.ok.Location = new System.Drawing.Point(1032, 282);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // IfElseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 312);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IfElseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "If Else";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox conditionActionPick;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button conditionRemoveAction;
        private System.Windows.Forms.Button conditionAddAction;
        private System.Windows.Forms.ListBox conditionActionList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox elseActionPick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button elseRemoveAction;
        private System.Windows.Forms.Button elseAddAction;
        private System.Windows.Forms.ListBox elseActionList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ifActionPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ifRemoveAction;
        private System.Windows.Forms.Button ifAddAction;
        private System.Windows.Forms.ListBox ifActionList;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.CheckBox allConditions;
        private System.Windows.Forms.CheckBox notTrue;
        private System.Windows.Forms.Button elseUp;
        private System.Windows.Forms.Button ifUp;
        private System.Windows.Forms.Button conditionUp;
        private System.Windows.Forms.Button elseCopy;
        private System.Windows.Forms.Button ifCopy;
        private System.Windows.Forms.Button conditionCopy;
        private System.Windows.Forms.Button elsePaste;
        private System.Windows.Forms.Button ifPaste;
        private System.Windows.Forms.Button conditionPaste;
    }
}