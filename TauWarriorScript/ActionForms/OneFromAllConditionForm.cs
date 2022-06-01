using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class OneFromAllConditionForm : Form
    {
        List<IAction> Conditions = new List<IAction>();
        public OneFromAllConditionForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                OneFromAllCondition a = (OneFromAllCondition)action;
                notTrue.Checked = a.NotTrue;
                Conditions = a.Conditions;
                UpdateUI(-1);
            }
        }
        private void SetUI()
        {
            conditionActionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            conditionActionPick.SelectedIndex = 0;
        }
        private void conditionAddAction_Click(object sender, EventArgs e)
        {
            ActionType actionType = MainForm.ActionNames[conditionActionPick.SelectedIndex].Type;
            MainForm.OpenForm(actionType, null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                if (conditionActionList.SelectedIndex != -1)
                    Conditions.Insert(conditionActionList.SelectedIndex + 1, temp);
                else
                    Conditions.Add(temp);
                UpdateUI(conditionActionList.SelectedIndex + 1);
            }
        }
        private void conditionUp_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                if (conditionActionList.SelectedIndex > 0)
                {
                    IAction temp = Conditions[conditionActionList.SelectedIndex];
                    Conditions.RemoveAt(conditionActionList.SelectedIndex);
                    Conditions.Insert(conditionActionList.SelectedIndex - 1, temp);
                    UpdateUI(conditionActionList.SelectedIndex - 1);
                }
            }
        }
        private void conditionEditAction_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                ActionType actionType = Conditions[conditionActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Conditions[conditionActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Conditions[conditionActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex);
            }
        }
        private void conditionRemoveAction_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in conditionActionList.SelectedIndices)
                {
                    Conditions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(conditionActionList.SelectedIndex - 1);
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new OneFromAllCondition(Conditions, notTrue.Checked));
            Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateUI(int conditionIndex)
        {
            conditionActionList.Items.Clear();
            conditionActionList.Items.AddRange(Conditions.Select(x => x.Info).ToArray());
            conditionActionList.SelectedIndex = conditionIndex;
        }
        private void conditionActionList_DoubleClick(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                ActionType actionType = Conditions[conditionActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Conditions[conditionActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Conditions[conditionActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex);
            }
        }

        private void conditionCopy_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in conditionActionList.SelectedIndices)
                {
                    data.Add(Conditions[i]);
                }
                Clipboard.SetData("TauWarrior", data);
            }
        }

        private void conditionPaste_Click(object sender, EventArgs e)
        {
            List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
            int mod = 0;
            foreach (var action in data)
            {
                Conditions.Insert(conditionActionList.SelectedIndex + 1 + mod, action);
                mod++;
            }
            UpdateUI(conditionActionList.SelectedIndex);
        }
    }
}