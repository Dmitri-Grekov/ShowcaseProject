using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class GamePadActionForm : Form
    {
        private int index = -1;
        public GamePadActionForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.GamePadActions[index].Name;
            stateList.SelectedIndex = MainForm.Script.States.FindIndex(x => x.Name == MainForm.Script.GamePadActions[index].NextState);
            if (MainForm.Script.GamePadActions[index].GamepadType == GamePadType.GamePad)
            {
                gamepadType1.Checked = true;
                keyList.Items.Clear();
                keyList.Items.AddRange(Enum.GetNames(typeof(GamePadKeys)));
                keyList.SelectedIndex = keyList.Items.IndexOf(MainForm.Script.GamePadActions[index].GamepadKey.ToString());
            }
            else
            {
                gamepadType2.Checked = true;
                keyList.Items.Clear();
                keyList.Items.AddRange(Enum.GetNames(typeof(JoyStickKeys)));
                keyList.SelectedIndex = keyList.Items.IndexOf(MainForm.Script.GamePadActions[index].JoystickKey.ToString());
            }
            indexList.SelectedIndex = indexList.Items.IndexOf(MainForm.Script.GamePadActions[index].GamepadIndex.ToString());
            holdTime.Value = MainForm.Script.GamePadActions[index].HoldTime;
            this.index = index;
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
            indexList.Items.AddRange(Enum.GetNames(typeof(GamePadIndex)));
            indexList.SelectedIndex = 0;
            SetKeyUI();
        }
        private void SetKeyUI()
        {
            if (gamepadType1.Checked)
            {
                keyList.Items.Clear();
                keyList.Items.AddRange(Enum.GetNames(typeof(GamePadKeys)));
                keyList.SelectedIndex = 0;
            }
            else
            {
                keyList.Items.Clear();
                keyList.Items.AddRange(Enum.GetNames(typeof(JoyStickKeys)));
                keyList.SelectedIndex = 0;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                if (gamepadType1.Checked)
                    MainForm.Script.GamePadActions.Add(new ScriptGamePadAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()), (GamePadKeys)Enum.Parse(typeof(GamePadKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value));
                else
                    MainForm.Script.GamePadActions.Add(new ScriptGamePadAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()), (JoyStickKeys)Enum.Parse(typeof(JoyStickKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value));
            }
            else
            {
                if (gamepadType1.Checked)
                    MainForm.Script.GamePadActions[index] = new ScriptGamePadAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()), (GamePadKeys)Enum.Parse(typeof(GamePadKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value);
                else
                    MainForm.Script.GamePadActions[index] = new ScriptGamePadAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()), (JoyStickKeys)Enum.Parse(typeof(JoyStickKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gamepadType1_CheckedChanged(object sender, EventArgs e)
        {
            SetKeyUI();
        }
    }
}
