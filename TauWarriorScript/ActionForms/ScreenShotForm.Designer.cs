
namespace TauWarriorScript.ActionForms
{
    partial class ScreenShotForm
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
            this.addTime = new System.Windows.Forms.CheckBox();
            this.addDate = new System.Windows.Forms.CheckBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.folder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.formatList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.areaList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isFullScreen = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addTime);
            this.groupBox1.Controls.Add(this.addDate);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Controls.Add(this.folder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.formatList);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.areaList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.isFullScreen);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ScreenShot";
            // 
            // addTime
            // 
            this.addTime.AutoSize = true;
            this.addTime.Location = new System.Drawing.Point(164, 134);
            this.addTime.Name = "addTime";
            this.addTime.Size = new System.Drawing.Size(77, 19);
            this.addTime.TabIndex = 0;
            this.addTime.Text = "Add Time";
            this.addTime.UseVisualStyleBackColor = true;
            // 
            // addDate
            // 
            this.addDate.AutoSize = true;
            this.addDate.Location = new System.Drawing.Point(66, 134);
            this.addDate.Name = "addDate";
            this.addDate.Size = new System.Drawing.Size(75, 19);
            this.addDate.TabIndex = 0;
            this.addDate.Text = "Add Date";
            this.addDate.UseVisualStyleBackColor = true;
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(84, 105);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(157, 23);
            this.fileName.TabIndex = 0;
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(84, 76);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(157, 23);
            this.folder.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder:";
            // 
            // formatList
            // 
            this.formatList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatList.FormattingEnabled = true;
            this.formatList.Location = new System.Drawing.Point(84, 159);
            this.formatList.Name = "formatList";
            this.formatList.Size = new System.Drawing.Size(157, 23);
            this.formatList.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Format:";
            // 
            // areaList
            // 
            this.areaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaList.Enabled = false;
            this.areaList.FormattingEnabled = true;
            this.areaList.Location = new System.Drawing.Point(46, 47);
            this.areaList.Name = "areaList";
            this.areaList.Size = new System.Drawing.Size(233, 23);
            this.areaList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Area:";
            // 
            // isFullScreen
            // 
            this.isFullScreen.AutoSize = true;
            this.isFullScreen.Checked = true;
            this.isFullScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isFullScreen.Location = new System.Drawing.Point(16, 22);
            this.isFullScreen.Name = "isFullScreen";
            this.isFullScreen.Size = new System.Drawing.Size(91, 19);
            this.isFullScreen.TabIndex = 0;
            this.isFullScreen.Text = "Is FullScreen";
            this.isFullScreen.UseVisualStyleBackColor = true;
            this.isFullScreen.CheckedChanged += new System.EventHandler(this.isFullScreen_CheckedChanged);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(225, 203);
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
            this.ok.Location = new System.Drawing.Point(144, 203);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // ScreenShotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 232);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScreenShotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScreenShot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox areaList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isFullScreen;
        private System.Windows.Forms.CheckBox addTime;
        private System.Windows.Forms.CheckBox addDate;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.TextBox folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox formatList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}