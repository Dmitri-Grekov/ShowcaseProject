using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class ChangeStateForm : Form
    {
        public ChangeStateForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                ChangeState a = (ChangeState)action;
                int index = MainForm.Script.States.FindIndex(x => x.Name == a.NextState);
                if (index != -1)
                    stateList.SelectedIndex = index;
            }
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new ChangeState(stateList.Items[stateList.SelectedIndex].ToString()));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
