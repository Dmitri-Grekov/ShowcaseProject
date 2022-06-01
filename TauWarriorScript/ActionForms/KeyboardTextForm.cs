using System;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class KeyboardTextForm : Form
    {
        public KeyboardTextForm()
        {
            InitializeComponent();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                KeyboardText a = (KeyboardText)action;
                text.Text = a.Text;
                directInput.Checked = a.DirectInput;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new KeyboardText(text.Text, directInput.Checked));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
