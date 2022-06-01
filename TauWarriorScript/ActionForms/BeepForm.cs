using System;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class BeepForm : Form
    {
        public BeepForm()
        {
            InitializeComponent();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                Beep a = (Beep)action;
                count.Value = a.Count;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new Beep((int)count.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
