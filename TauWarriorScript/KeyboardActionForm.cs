using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class KeyboardActionForm : Form
    {
        private int index = -1;
        public KeyboardActionForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.KeyboardActions[index].Name;
            stateList.SelectedIndex = MainForm.Script.States.FindIndex(x => x.Name == MainForm.Script.KeyboardActions[index].NextState);
            keyList.SelectedIndex = keyList.Items.IndexOf(MainForm.Script.KeyboardActions[index].Key.ToString());
            modKeyList.SelectedIndex = modKeyList.Items.IndexOf(MainForm.Script.KeyboardActions[index].ModifierKey.ToString());
            secondModKeyList.SelectedIndex = secondModKeyList.Items.IndexOf(MainForm.Script.KeyboardActions[index].SecondModifierKey.ToString());
            holdTime.Value = MainForm.Script.KeyboardActions[index].HoldTime;
            this.index = index;
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
            keyList.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            keyList.SelectedIndex = 0;
            modKeyList.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            modKeyList.SelectedIndex = 0;
            secondModKeyList.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            secondModKeyList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.KeyboardActions.Add(new ScriptKeyboardAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), keyList.Items[keyList.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), modKeyList.Items[modKeyList.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), secondModKeyList.Items[secondModKeyList.SelectedIndex].ToString()), (long)holdTime.Value));
            }
            else
            {
                MainForm.Script.KeyboardActions[index] = new ScriptKeyboardAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), keyList.Items[keyList.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), modKeyList.Items[modKeyList.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), secondModKeyList.Items[secondModKeyList.SelectedIndex].ToString()), (long)holdTime.Value);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
