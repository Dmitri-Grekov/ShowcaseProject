using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class IfElseForm : Form
    {
        List<IAction> Conditions = new List<IAction>();
        List<IAction> IfActions = new List<IAction>();
        List<IAction> ElseActions = new List<IAction>();
        public IfElseForm()
        {
            InitializeComponent();
            SetUI();
        }

        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                IfElse a = (IfElse)action;
                allConditions.Checked = a.AllTrue;
                notTrue.Checked = a.NotTrue;
                Conditions = a.Conditions;
                IfActions = a.IfActions;
                ElseActions = a.ElseActions;
                UpdateUI(-1, -1, -1);
            }
        }
        private void SetUI()
        {
            conditionActionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            conditionActionPick.SelectedIndex = 0;
            ifActionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            ifActionPick.SelectedIndex = 0;
            elseActionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            elseActionPick.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new IfElse(Conditions, IfActions, ElseActions, allConditions.Checked, notTrue.Checked));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
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
                UpdateUI(conditionActionList.SelectedIndex + 1, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
            }
        }
        private void UpdateUI(int conditionIndex, int ifIndex, int elseIndex)
        {
            conditionActionList.Items.Clear();
            conditionActionList.Items.AddRange(Conditions.Select(x => x.Info).ToArray());
            conditionActionList.SelectedIndex = conditionIndex;
            ifActionList.Items.Clear();
            ifActionList.Items.AddRange(IfActions.Select(x => x.Info).ToArray());
            ifActionList.SelectedIndex = ifIndex;
            elseActionList.Items.Clear();
            elseActionList.Items.AddRange(ElseActions.Select(x => x.Info).ToArray());
            elseActionList.SelectedIndex = elseIndex;
        }

        private void ifAddAction_Click(object sender, EventArgs e)
        {
            ActionType actionType = MainForm.ActionNames[ifActionPick.SelectedIndex].Type;
            MainForm.OpenForm(actionType, null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                if (ifActionList.SelectedIndex != -1)
                    IfActions.Insert(ifActionList.SelectedIndex + 1, temp);
                else
                    IfActions.Add(temp);
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex + 1, elseActionList.SelectedIndex);
            }
        }

        private void elseAddAction_Click(object sender, EventArgs e)
        {
            ActionType actionType = MainForm.ActionNames[elseActionPick.SelectedIndex].Type;
            MainForm.OpenForm(actionType, null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                if (elseActionList.SelectedIndex != -1)
                    ElseActions.Insert(elseActionList.SelectedIndex + 1, temp);
                else
                    ElseActions.Add(temp);
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex + 1);
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
                UpdateUI(conditionActionList.SelectedIndex - 1, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
            }
        }

        private void ifRemoveAction_Click(object sender, EventArgs e)
        {
            if (ifActionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in ifActionList.SelectedIndices)
                {
                    IfActions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex - 1, elseActionList.SelectedIndex);
            }
        }

        private void elseRemoveAction_Click(object sender, EventArgs e)
        {
            if (elseActionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in elseActionList.SelectedIndices)
                {
                    ElseActions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex - 1);
            }
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
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
            }
        }

        private void ifActionList_DoubleClick(object sender, EventArgs e)
        {
            if (ifActionList.SelectedIndex != -1)
            {
                ActionType actionType = IfActions[ifActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, IfActions[ifActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    IfActions[ifActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
            }
        }

        private void elseActionList_DoubleClick(object sender, EventArgs e)
        {
            if (elseActionList.SelectedIndex != -1)
            {
                ActionType actionType = ElseActions[elseActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, ElseActions[elseActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    ElseActions[elseActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
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
                    UpdateUI(conditionActionList.SelectedIndex - 1, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
                }
            }
        }

        private void ifUp_Click(object sender, EventArgs e)
        {
            if (ifActionList.SelectedIndex != -1)
            {
                if (ifActionList.SelectedIndex > 0)
                {
                    IAction temp = IfActions[ifActionList.SelectedIndex];
                    IfActions.RemoveAt(ifActionList.SelectedIndex);
                    IfActions.Insert(ifActionList.SelectedIndex - 1, temp);
                    UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex - 1, elseActionList.SelectedIndex);
                }
            }
        }

        private void elseUp_Click(object sender, EventArgs e)
        {
            if (elseActionList.SelectedIndex != -1)
            {
                if (elseActionList.SelectedIndex > 0)
                {
                    IAction temp = ElseActions[elseActionList.SelectedIndex];
                    ElseActions.RemoveAt(elseActionList.SelectedIndex);
                    ElseActions.Insert(elseActionList.SelectedIndex - 1, temp);
                    UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex - 1);
                }
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

        private void ifCopy_Click(object sender, EventArgs e)
        {
            if (ifActionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in ifActionList.SelectedIndices)
                {
                    data.Add(IfActions[i]);
                }
                Clipboard.SetData("TauWarrior", data);
            }
        }

        private void elseCopy_Click(object sender, EventArgs e)
        {
            if (elseActionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in elseActionList.SelectedIndices)
                {
                    data.Add(ElseActions[i]);
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
            UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
        }

        private void ifPaste_Click(object sender, EventArgs e)
        {
            List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
            int mod = 0;
            foreach (var action in data)
            {
                IfActions.Insert(ifActionList.SelectedIndex + 1 + mod, action);
                mod++;
            }
            UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
        }

        private void elsePaste_Click(object sender, EventArgs e)
        {
            List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
            int mod = 0;
            foreach (var action in data)
            {
                ElseActions.Insert(elseActionList.SelectedIndex + 1 + mod, action);
                mod++;
            }
            UpdateUI(conditionActionList.SelectedIndex, ifActionList.SelectedIndex, elseActionList.SelectedIndex);
        }
    }
}
