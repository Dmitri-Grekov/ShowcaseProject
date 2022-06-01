using System;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                Wait a = (Wait)action;
                milliseconds.Value = a.Milliseconds;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new Wait((int)milliseconds.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
