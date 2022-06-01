
namespace TauWarriorScript.ActionForms
{
    partial class OpenProcessForm
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
            this.path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.argsNew = new System.Windows.Forms.TextBox();
            this.argsAdd = new System.Windows.Forms.Button();
            this.argsRemove = new System.Windows.Forms.Button();
            this.argsList = new System.Windows.Forms.ListBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.argsList);
            this.groupBox1.Controls.Add(this.argsRemove);
            this.groupBox1.Controls.Add(this.argsAdd);
            this.groupBox1.Controls.Add(this.argsNew);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open Process";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(45, 22);
            this.path.MaxLength = 40;
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(266, 23);
            this.path.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Args:";
            // 
            // argsNew
            // 
            this.argsNew.Location = new System.Drawing.Point(45, 51);
            this.argsNew.Name = "argsNew";
            this.argsNew.Size = new System.Drawing.Size(154, 23);
            this.argsNew.TabIndex = 0;
            // 
            // argsAdd
            // 
            this.argsAdd.Location = new System.Drawing.Point(205, 51);
            this.argsAdd.Name = "argsAdd";
            this.argsAdd.Size = new System.Drawing.Size(39, 23);
            this.argsAdd.TabIndex = 0;
            this.argsAdd.Text = "Add";
            this.argsAdd.UseVisualStyleBackColor = true;
            this.argsAdd.Click += new System.EventHandler(this.argsAdd_Click);
            // 
            // argsRemove
            // 
            this.argsRemove.Location = new System.Drawing.Point(250, 51);
            this.argsRemove.Name = "argsRemove";
            this.argsRemove.Size = new System.Drawing.Size(62, 23);
            this.argsRemove.TabIndex = 0;
            this.argsRemove.Text = "Remove";
            this.argsRemove.UseVisualStyleBackColor = true;
            this.argsRemove.Click += new System.EventHandler(this.argsRemove_Click);
            // 
            // argsList
            // 
            this.argsList.FormattingEnabled = true;
            this.argsList.ItemHeight = 15;
            this.argsList.Location = new System.Drawing.Point(8, 80);
            this.argsList.Name = "argsList";
            this.argsList.Size = new System.Drawing.Size(303, 64);
            this.argsList.TabIndex = 0;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(256, 163);
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
            this.ok.Location = new System.Drawing.Point(175, 163);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // OpenProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 192);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OpenProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Process";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox argsList;
        private System.Windows.Forms.Button argsRemove;
        private System.Windows.Forms.Button argsAdd;
        private System.Windows.Forms.TextBox argsNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}