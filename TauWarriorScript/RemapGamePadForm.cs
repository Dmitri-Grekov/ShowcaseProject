using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TauWarriorCore;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;
using TauWarriorCore.Script;
using static TauWarriorCore.Script.ScriptRemapConfig;

namespace TauWarriorScript
{
    public partial class RemapGamePadForm : Form
    {

        private List<GamepadRemap> gamepadButtons = new List<GamepadRemap>();
        private List<JoystickRemap> joystickButtons = new List<JoystickRemap>();
        public RemapGamePadForm()
        {
            InitializeComponent();
            UpdateUI();
            SetUI();
            SetPanelUI();
        }
        private void LoadData(GamePadType gamepadType, GamePadIndex gamepadIndex)
        {
            int index = MainForm.Script.RemapConfigs.FindIndex(x => x.GamepadType == gamepadType && x.GamepadIndex == gamepadIndex);
            if (index != -1)
            {
                if (gamepadType == GamePadType.GamePad)
                {
                    GamepadRemap[] temp = new GamepadRemap[MainForm.Script.RemapConfigs[index].GamepadKeys.Count];
                    MainForm.Script.RemapConfigs[index].GamepadKeys.CopyTo(temp);
                    gamepadButtons = temp.ToList();
                    joystickButtons.Clear();
                }
                else
                {
                    JoystickRemap[] temp = new JoystickRemap[MainForm.Script.RemapConfigs[index].JoystickKeys.Count];
                    MainForm.Script.RemapConfigs[index].JoystickKeys.CopyTo(temp);
                    joystickButtons = temp.ToList();
                    gamepadButtons.Clear();
                }
                directInput.Checked = MainForm.Script.RemapConfigs[index].DirectInput;
            }
            else
            {
                gamepadButtons.Clear();
                joystickButtons.Clear();
            }
            UpdateUI();
        }
        private void SaveData(GamePadType gamepadType, GamePadIndex gamepadIndex)
        {
            int index = MainForm.Script.RemapConfigs.FindIndex(x => x.GamepadType == gamepadType && x.GamepadIndex == gamepadIndex);
            if (index != -1)
            {
                if (gamepadType == GamePadType.GamePad)
                {
                    GamepadRemap[] temp = new GamepadRemap[gamepadButtons.Count];
                    gamepadButtons.CopyTo(temp);
                    MainForm.Script.RemapConfigs[index] = new ScriptRemapConfig(gamepadType, gamepadIndex, temp.ToList(), directInput.Checked);
                }
                else
                {
                    JoystickRemap[] temp = new JoystickRemap[joystickButtons.Count];
                    joystickButtons.CopyTo(temp);
                    MainForm.Script.RemapConfigs[index] = new ScriptRemapConfig(gamepadType, gamepadIndex, temp.ToList(), directInput.Checked);
                }
            }
            else
            {
                if (gamepadType == GamePadType.GamePad)
                {
                    GamepadRemap[] temp = new GamepadRemap[gamepadButtons.Count];
                    gamepadButtons.CopyTo(temp);
                    MainForm.Script.RemapConfigs.Add(new ScriptRemapConfig(gamepadType, gamepadIndex, temp.ToList(), directInput.Checked));
                }
                else
                {
                    JoystickRemap[] temp = new JoystickRemap[joystickButtons.Count];
                    joystickButtons.CopyTo(temp);
                    MainForm.Script.RemapConfigs.Add(new ScriptRemapConfig(gamepadType, gamepadIndex, temp.ToList(), directInput.Checked));
                }
            }
        }
        private void UpdateUI()
        {

            foreach (var c in gamepadPanel.Controls)
            {
                foreach (var t in ((GroupBox)c).Controls)
                {
                    if (t is TextBox)
                        ((TextBox)t).Text = "-";
                }
            }
            foreach (var c in joystickPanel.Controls)
            {
                foreach (var t in ((GroupBox)c).Controls)
                {
                    if (t is TextBox)
                        ((TextBox)t).Text = "-";
                }
            }
            foreach (var b in gamepadButtons)
            {
                switch (b.GamepadKey)
                {
                    case GamePadKeys.LStickUp: lStickUp.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LStickDown: lStickDown.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LStickLeft: lStickLeft.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LStickRight: lStickRight.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LStick: lStickPress.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RStickUp: rStickUp.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RStickDown: rStickDown.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RStickLeft: rStickLeft.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RStickRight: rStickRight.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RStick: rStickPress.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LB: lb.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.LT: lt.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RB: rb.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.RT: rt.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Back: back.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Start: start.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.X: x.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.A: a.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.B: bb.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Y: y.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Up: up.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Down: down.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Left: left.Text = b.KeyboardKey.ToString(); break;
                    case GamePadKeys.Right: right.Text = b.KeyboardKey.ToString(); break;
                }
            }
            foreach (var b in joystickButtons)
            {
                switch (b.JoystickKey)
                {
                    case JoyStickKeys.LStickUp: jLStickUp.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.LStickDown: jLStickDown.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.LStickLeft: jLStickLeft.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.LStickRight: jLStickRight.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.RStickUp: jRStickUp.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.RStickDown: jRStickDown.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.RStickLeft: jRStickLeft.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.RStickRight: jRStickRight.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B1: b1.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B2: b2.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B3: b3.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B4: b4.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B5: b5.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B6: b6.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B7: b7.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B8: b8.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B9: b9.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B10: b10.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B11: b11.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.B12: b12.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.Up: jUp.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.Down: jDown.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.Left: jLeft.Text = b.KeyboardKey.ToString(); break;
                    case JoyStickKeys.Right: jRight.Text = b.KeyboardKey.ToString(); break;
                }
            }
        }
        private KeyboardKeys LookForKey()
        {
            keyPanel.Location = new Point(125, 150);
            remapPanel.Enabled = false;
            gamepadPanel.Enabled = false;
            joystickPanel.Enabled = false;
            var t = Task.Run(() =>
            {
                while (true)
                {
                    foreach (var key in Enum.GetNames(typeof(KeyboardKeys)))
                    {
                        if (Keyboard.IsPressed((KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), key)))
                        {
                            return (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), key);
                        }
                    }
                    Thread.Sleep(5);
                }
            });
            t.Wait();
            remapPanel.Enabled = true;
            keyPanel.Location = new Point(600, 100);
            SetPanelUI();
            return t.Result;
        }
        private void SetUI()
        {
            indexList.Items.AddRange(Enum.GetNames(typeof(GamePadIndex)));
            indexList.SelectedIndex = 0;
        }
        private void SetPanelUI()
        {
            if (gamepadType1.Checked)
            {
                joystickPanel.Enabled = false;
                joystickPanel.Visible = false;
                gamepadPanel.Enabled = true;
                gamepadPanel.Visible = true;
            }
            else
            {
                gamepadPanel.Enabled = false;
                gamepadPanel.Visible = false;
                joystickPanel.Enabled = true;
                joystickPanel.Visible = true;
            }
        }
        private void SetLoadUI()
        {
            if (gamepadType1.Checked)
            {
                LoadData(GamePadType.GamePad, (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()));
            }
            else
            {
                LoadData(GamePadType.JoyStick, (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()));
            }
            UpdateUI();
        }
        private void RemoveDouble(GamePadType gamepadType, KeyboardKeys key)
        {
            /*
            if (gamepadType == GamePadType.GamePad)
                gamepadButtons.RemoveAll(x => x.KeyboardKey == key);
            else
                joystickButtons.RemoveAll(x => x.KeyboardKey == key);
            */
        }
        private void lStickUpKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LStickUp))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LStickUp)] = new GamepadRemap(GamePadKeys.LStickUp, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LStickUp, key));
            }
            UpdateUI();
        }

        private void lStickDownKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LStickDown))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LStickDown)] = new GamepadRemap(GamePadKeys.LStickDown, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LStickDown, key));
            }
            UpdateUI();
        }

        private void lStickLeftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LStickLeft))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LStickLeft)] = new GamepadRemap(GamePadKeys.LStickLeft, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LStickLeft, key));
            }
            UpdateUI();
        }

        private void lStickRightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LStickRight))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LStickRight)] = new GamepadRemap(GamePadKeys.LStickRight, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LStickRight, key));
            }
            UpdateUI();
        }

        private void lStickPressKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LStick))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LStick)] = new GamepadRemap(GamePadKeys.LStick, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LStick, key));
            }
            UpdateUI();
        }

        private void rStickUpKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RStickUp))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RStickUp)] = new GamepadRemap(GamePadKeys.RStickUp, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RStickUp, key));
            }
            UpdateUI();
        }

        private void rStickDownKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RStickDown))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RStickDown)] = new GamepadRemap(GamePadKeys.RStickDown, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RStickDown, key));
            }
            UpdateUI();
        }

        private void rStickLeftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RStickLeft))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RStickLeft)] = new GamepadRemap(GamePadKeys.RStickLeft, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RStickLeft, key));
            }
            UpdateUI();
        }

        private void rStickRightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RStickRight))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RStickRight)] = new GamepadRemap(GamePadKeys.RStickRight, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RStickRight, key));
            }
            UpdateUI();
        }

        private void rStickPressKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RStick))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RStick)] = new GamepadRemap(GamePadKeys.RStick, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RStick, key));
            }
            UpdateUI();
        }

        private void lbKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LB))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LB)] = new GamepadRemap(GamePadKeys.LB, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LB, key));
            }
            UpdateUI();
        }

        private void ltKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.LT))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.LT)] = new GamepadRemap(GamePadKeys.LT, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.LT, key));
            }
            UpdateUI();
        }

        private void rbKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RB))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RB)] = new GamepadRemap(GamePadKeys.RB, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RB, key));
            }
            UpdateUI();
        }

        private void rtKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.RT))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.RT)] = new GamepadRemap(GamePadKeys.RT, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.RT, key));
            }
            UpdateUI();
        }

        private void backKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Back))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Back)] = new GamepadRemap(GamePadKeys.Back, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Back, key));
            }
            UpdateUI();
        }

        private void startKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Start))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Start)] = new GamepadRemap(GamePadKeys.Start, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Start, key));
            }
            UpdateUI();
        }

        private void xKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.X))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.X)] = new GamepadRemap(GamePadKeys.X, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.X, key));
            }
            UpdateUI();
        }

        private void aKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.A))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.A)] = new GamepadRemap(GamePadKeys.A, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.A, key));
            }
            UpdateUI();
        }

        private void yKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Y))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Y)] = new GamepadRemap(GamePadKeys.Y, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Y, key));
            }
            UpdateUI();
        }

        private void bKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.B))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.B)] = new GamepadRemap(GamePadKeys.B, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.B, key));
            }
            UpdateUI();
        }

        private void upKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Up))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Up)] = new GamepadRemap(GamePadKeys.Up, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Up, key));
            }
            UpdateUI();
        }

        private void downKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Down))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Down)] = new GamepadRemap(GamePadKeys.Down, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Down, key));
            }
            UpdateUI();
        }

        private void leftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Left))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Left)] = new GamepadRemap(GamePadKeys.Left, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Left, key));
            }
            UpdateUI();
        }

        private void rightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.GamePad, key);
            if (gamepadButtons.Exists(x => x.GamepadKey == GamePadKeys.Right))
            {
                gamepadButtons[gamepadButtons.FindIndex(x => x.GamepadKey == GamePadKeys.Right)] = new GamepadRemap(GamePadKeys.Right, key);
            }
            else
            {
                gamepadButtons.Add(new GamepadRemap(GamePadKeys.Right, key));
            }
            UpdateUI();
        }

        private void jLStickUpKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.LStickUp))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.LStickUp)] = new JoystickRemap(JoyStickKeys.LStickUp, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.LStickUp, key));
            }
            UpdateUI();
        }

        private void jLStickDownKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.LStickDown))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.LStickDown)] = new JoystickRemap(JoyStickKeys.LStickDown, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.LStickDown, key));
            }
            UpdateUI();
        }

        private void jLStickLeftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.LStickLeft))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.LStickLeft)] = new JoystickRemap(JoyStickKeys.LStickLeft, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.LStickLeft, key));
            }
            UpdateUI();
        }

        private void jLStickRightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.LStickRight))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.LStickRight)] = new JoystickRemap(JoyStickKeys.LStickRight, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.LStickRight, key));
            }
            UpdateUI();
        }

        private void jRStickUpKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.RStickUp))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.RStickUp)] = new JoystickRemap(JoyStickKeys.RStickUp, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.RStickUp, key));
            }
            UpdateUI();
        }

        private void jRStickDownKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.RStickDown))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.RStickDown)] = new JoystickRemap(JoyStickKeys.RStickDown, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.RStickDown, key));
            }
            UpdateUI();
        }

        private void jRStickLeftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.RStickLeft))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.RStickLeft)] = new JoystickRemap(JoyStickKeys.RStickLeft, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.RStickLeft, key));
            }
            UpdateUI();
        }

        private void jRStickRightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.RStickRight))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.RStickRight)] = new JoystickRemap(JoyStickKeys.RStickRight, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.RStickRight, key));
            }
            UpdateUI();
        }

        private void b1Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B1))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B1)] = new JoystickRemap(JoyStickKeys.B1, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B1, key));
            }
            UpdateUI();
        }

        private void b2Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B2))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B2)] = new JoystickRemap(JoyStickKeys.B2, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B2, key));
            }
            UpdateUI();
        }

        private void b3Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B3))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B3)] = new JoystickRemap(JoyStickKeys.B3, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B3, key));
            }
            UpdateUI();
        }

        private void b4Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B4))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B4)] = new JoystickRemap(JoyStickKeys.B4, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B4, key));
            }
            UpdateUI();
        }

        private void b5Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B5))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B5)] = new JoystickRemap(JoyStickKeys.B5, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B5, key));
            }
            UpdateUI();
        }

        private void b6Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B6))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B6)] = new JoystickRemap(JoyStickKeys.B6, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B6, key));
            }
            UpdateUI();
        }

        private void b7Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B7))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B7)] = new JoystickRemap(JoyStickKeys.B7, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B7, key));
            }
            UpdateUI();
        }

        private void b8Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B8))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B8)] = new JoystickRemap(JoyStickKeys.B8, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B8, key));
            }
            UpdateUI();
        }

        private void b9Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B9))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B9)] = new JoystickRemap(JoyStickKeys.B9, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B9, key));
            }
            UpdateUI();
        }

        private void b10Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B10))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B10)] = new JoystickRemap(JoyStickKeys.B10, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B10, key));
            }
            UpdateUI();
        }

        private void b11Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B11))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B11)] = new JoystickRemap(JoyStickKeys.B11, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B11, key));
            }
            UpdateUI();
        }

        private void b12Key_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.B12))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.B12)] = new JoystickRemap(JoyStickKeys.B12, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.B12, key));
            }
            UpdateUI();
        }

        private void jUpKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.Up))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.Up)] = new JoystickRemap(JoyStickKeys.Up, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.Up, key));
            }
            UpdateUI();
        }

        private void jDownKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.Down))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.Down)] = new JoystickRemap(JoyStickKeys.Down, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.Down, key));
            }
            UpdateUI();
        }

        private void jLeftKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.Left))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.Left)] = new JoystickRemap(JoyStickKeys.Left, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.Left, key));
            }
            UpdateUI();
        }

        private void jRightKey_MouseClick(object sender, MouseEventArgs e)
        {
            KeyboardKeys key = LookForKey();
            RemoveDouble(GamePadType.JoyStick, key);
            if (joystickButtons.Exists(x => x.JoystickKey == JoyStickKeys.Right))
            {
                joystickButtons[joystickButtons.FindIndex(x => x.JoystickKey == JoyStickKeys.Right)] = new JoystickRemap(JoyStickKeys.Right, key);
            }
            else
            {
                joystickButtons.Add(new JoystickRemap(JoyStickKeys.Right, key));
            }
            UpdateUI();
        }

        private void gamepadType1_CheckedChanged(object sender, EventArgs e)
        {
            SetLoadUI();
            SetPanelUI();
        }

        private void save_MouseClick(object sender, MouseEventArgs e)
        {
            SaveData(gamepadType1.Checked ? GamePadType.GamePad : GamePadType.JoyStick, (GamePadIndex)Enum.Parse(typeof(GamePadIndex), indexList.Items[indexList.SelectedIndex].ToString()));
        }

        private void indexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLoadUI();
        }

        private void gamepadType1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void gamepadType2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void generate_MouseClick(object sender, MouseEventArgs e)
        {
            ClearBinding();
            AddBinding();
            Console.Beep();
        }
        private void ClearBinding()
        {
            MainForm.Script.States.RemoveAll(x => x.Name.StartsWith("_Remap"));
            MainForm.Script.GamePadActions.RemoveAll(x => x.Name.StartsWith("_Remap"));
        }
        private void AddBinding()
        {
            foreach(var b in MainForm.Script.RemapConfigs)
            {
                if(b.GamepadType == GamePadType.GamePad)
                {
                    foreach (var r in b.GamepadKeys)
                    {
                        if (!MainForm.Script.States.Exists(x => x.Name == $"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}"))
                            MainForm.Script.States.Add(new ScriptState($"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}", ScriptFile.ScriptHoldState, new List<IAction>() { new KeyboardPress(r.KeyboardKey, KeyboardKeys.NONE, KeyboardKeys.NONE, 0, 1, b.DirectInput) }));
                        MainForm.Script.GamePadActions.Add(new ScriptGamePadAction($"_Remap{r.GamepadKey}", $"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}", b.GamepadIndex, r.GamepadKey));
                    }
                }
                else
                {
                    foreach (var r in b.JoystickKeys)
                    {
                        if (!MainForm.Script.States.Exists(x => x.Name == $"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}"))
                            MainForm.Script.States.Add(new ScriptState($"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}", ScriptFile.ScriptHoldState, new List<IAction>() { new KeyboardPress(r.KeyboardKey, KeyboardKeys.NONE, KeyboardKeys.NONE, 0, 1, b.DirectInput) }));
                        MainForm.Script.GamePadActions.Add(new ScriptGamePadAction($"_Remap{r.JoystickKey}", $"_Remap{r.KeyboardKey}{(b.DirectInput ? "_DirectInput" : "")}", b.GamepadIndex, r.JoystickKey));
                    }
                }
            }
        }

        private void lStickUpKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LStickUp);
            UpdateUI();
        }

        private void lStickDownKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LStickDown);
            UpdateUI();
        }

        private void lStickLeftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LStickLeft);
            UpdateUI();
        }

        private void lStickRightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LStickRight);
            UpdateUI();
        }

        private void lStickPressKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LStick);
            UpdateUI();
        }

        private void rStickUpKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RStickUp);
            UpdateUI();
        }

        private void rStickDownKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RStickDown);
            UpdateUI();
        }

        private void rStickLeftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RStickLeft);
            UpdateUI();
        }

        private void rStickRightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RStickRight);
            UpdateUI();
        }

        private void rStickPressKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RStick);
            UpdateUI();
        }

        private void lbKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LB);
            UpdateUI();
        }

        private void ltKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.LT);
            UpdateUI();
        }

        private void backKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Back);
            UpdateUI();
        }

        private void xKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.X);
            UpdateUI();
        }

        private void aKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.A);
            UpdateUI();
        }

        private void rbKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RB);
            UpdateUI();
        }

        private void rtKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.RT);
            UpdateUI();
        }

        private void startKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Start);
            UpdateUI();
        }

        private void yKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Y);
            UpdateUI();
        }

        private void bKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.B);
            UpdateUI();
        }

        private void upKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Up);
            UpdateUI();
        }

        private void leftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Left);
            UpdateUI();
        }

        private void downKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Down);
            UpdateUI();
        }

        private void rightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            gamepadButtons.RemoveAll(x => x.GamepadKey == GamePadKeys.Right);
            UpdateUI();
        }

        private void jLStickUpKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.LStickUp);
            UpdateUI();
        }

        private void jLStickDownKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.LStickDown);
            UpdateUI();
        }

        private void jLStickLeftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.LStickLeft);
            UpdateUI();
        }

        private void jLStickRightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.LStickRight);
            UpdateUI();
        }

        private void jRStickUpKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.RStickUp);
            UpdateUI();
        }

        private void jRStickDownKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.RStickDown);
            UpdateUI();
        }

        private void jRStickLeftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.RStickLeft);
            UpdateUI();
        }

        private void jRStickRightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.RStickRight);
            UpdateUI();
        }

        private void b1KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B1);
            UpdateUI();
        }

        private void b2KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B2);
            UpdateUI();
        }

        private void b3KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B3);
            UpdateUI();
        }

        private void b4KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B4);
            UpdateUI();
        }

        private void b5KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B5);
            UpdateUI();
        }

        private void b6KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B6);
            UpdateUI();
        }

        private void b7KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B7);
            UpdateUI();
        }

        private void b8KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B8);
            UpdateUI();
        }

        private void b9KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B9);
            UpdateUI();
        }

        private void b10KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B10);
            UpdateUI();
        }

        private void b11KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B11);
            UpdateUI();
        }

        private void b12KeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.B12);
            UpdateUI();
        }

        private void jUpKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.Up);
            UpdateUI();
        }

        private void jLeftKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.Left);
            UpdateUI();
        }

        private void jDownKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.Down);
            UpdateUI();
        }

        private void jRightKeyC_MouseClick(object sender, MouseEventArgs e)
        {
            joystickButtons.RemoveAll(x => x.JoystickKey == JoyStickKeys.Right);
            UpdateUI();
        }

    }
}
