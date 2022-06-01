using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class OpenProcessForm : Form
    {
        List<string> args = new List<string>();
        public OpenProcessForm()
        {
            InitializeComponent();
        }
        
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                OpenProcess a = (OpenProcess)action;
                path.Text = a.FilePath;
                args = a.Arguments;
                UpdateList();
            }
        }
        private void argsAdd_Click(object sender, EventArgs e)
        {
            args.Add(argsNew.Text);
            argsNew.Text = "";
            UpdateList();
        }
        private void UpdateList()
        {
            argsList.Items.Clear();
            argsList.Items.AddRange(args.ToArray());
        }
        private void argsRemove_Click(object sender, EventArgs e)
        {
            if (args.Count > 0)
            {
                if (argsList.SelectedIndex != -1)
                {
                    args.RemoveAt(argsList.SelectedIndex);
                    UpdateList();
                }
                else
                {
                    args.RemoveAt(args.Count - 1);
                    UpdateList();
                }
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new OpenProcess(path.Text, args));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
