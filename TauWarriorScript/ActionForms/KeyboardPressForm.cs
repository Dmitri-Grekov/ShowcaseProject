using System;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;

namespace TauWarriorScript.ActionForms
{
    public partial class KeyboardPressForm : Form
    {
        public KeyboardPressForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                KeyboardPress a = (KeyboardPress)action;
                keyList.SelectedIndex = Enum.GetNames(typeof(KeyboardKeys)).ToList().FindIndex(x => x == a.Key.ToString());
                key2List.SelectedIndex = Enum.GetNames(typeof(KeyboardKeys)).ToList().FindIndex(x => x == a.SecondKey.ToString());
                key3List.SelectedIndex = Enum.GetNames(typeof(KeyboardKeys)).ToList().FindIndex(x => x == a.ThirdKey.ToString());
                holdTime.Value = a.HoldTime;
                count.Value = a.Count;
                directInput.Checked = a.DirectInput;
            }
        }
        private void SetUI()
        {
            keyList.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            keyList.SelectedIndex = 0;
            key2List.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            key2List.SelectedIndex = 0;
            key3List.Items.AddRange(Enum.GetNames(typeof(KeyboardKeys)));
            key3List.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new KeyboardPress((KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), keyList.Items[keyList.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), key2List.Items[key2List.SelectedIndex].ToString()), (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), key3List.Items[key3List.SelectedIndex].ToString()), (int)holdTime.Value, (int)count.Value, directInput.Checked));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
