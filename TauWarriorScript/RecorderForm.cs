using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class RecorderForm : Form
    {
        Recorder recorder;
        public RecorderForm()
        {
            InitializeComponent();
            if (recorder == null)
            {
                recorder = new Recorder();
                recorder.AreaPoints = areaPoints.Checked;
                recorder.AreaImage = areaImage.Checked;
                recorder.RecordAdded += Recorder_RecordAdded;
                recorder.RecordAll();
                speedList.Items.AddRange(Enum.GetNames(typeof(MouseSpeed)));
                speedList.SelectedIndex = 0;
            }
        }
        private void Recorder_RecordAdded(object? sender, EventArgs e)
        {
            UpdateUI();
        }
        private void UpdateUI()
        {
            string[] files = recorder.GetScriptNames();
            recordsList.Invoke(new Action(() => { recordsList.Items.Clear(); recordsList.Items.AddRange(files); }));
        }
        private void recordsRemove_Click(object sender, EventArgs e)
        {
            if (recordsList.SelectedIndex != -1)
            {
                recorder.RemoveFile(recordsList.SelectedItem.ToString());
            }
            UpdateUI();
        }
        private void recordCopy_Click(object sender, EventArgs e)
        {
            List<IAction> data = new List<IAction>();
            string[] text = recorder.GetFileText(recordsList.SelectedItem.ToString()).Split('\n');
            string[] line;
            bool directInput = false;
            MouseSpeed mouseSpeed = MouseSpeed.Fast;
            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    line = text[i].Split(':');
                    if (line[0].ToLower().Contains("true"))
                        directInput = true;
                    switch (line[1].Split('=')[1].ToLower())
                    {
                        case "veryslow": mouseSpeed = MouseSpeed.VerySlow; break;
                        case "slow": mouseSpeed = MouseSpeed.Slow; break;
                        case "normal": mouseSpeed = MouseSpeed.Normal; break;
                        case "fast": mouseSpeed = MouseSpeed.Fast; break;
                        case "veryfast": mouseSpeed = MouseSpeed.VeryFast; break;
                    }
                }
                else
                {
                    line = text[i].Split(':');
                    switch (line[0])
                    {
                        case "Keyboard":
                            data.Add(new KeyboardPress((KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), line[1]), KeyboardKeys.NONE, KeyboardKeys.NONE, int.Parse(line[2]), 1, directInput));
                            break;
                        case "Mouse":
                            int p = 1;
                            while (true)
                            {
                                if (!MainForm.Script.ScreenPoints.Exists(x => x.Name == $"_mouse{p}"))
                                {
                                    MainForm.Script.ScreenPoints.Add(new ScreenPoint($"_mouse{p}", new Point(int.Parse(line[3]), int.Parse(line[4]))));
                                    break;
                                }
                                else
                                    p++;
                            }
                            data.Add(new MouseClick(true, $"_mouse{p}", mouseSpeed, (MouseKeys)Enum.Parse(typeof(MouseKeys), line[1]), int.Parse(line[2]), 1));
                            break;
                        case "Wait":
                            data.Add(new Wait(int.Parse(line[1])));
                            break;
                    }
                }
            }
            Clipboard.SetData("TauWarrior", data);
        }
        private void RecorderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            recorder.Unload();
        }
        private void RecorderForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
        private void speedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speedList.SelectedIndex != -1)
                recorder.MouseSpeed = (MouseSpeed)Enum.Parse(typeof(MouseSpeed), speedList.SelectedItem.ToString());
        }
        private void recordsList_DoubleClick(object sender, EventArgs e)
        {
            if (recordsList.SelectedIndex != -1)
                Process.Start("explorer.exe", Path.Combine(Environment.CurrentDirectory, recorder.GetPath(recordsList.SelectedItem.ToString())));
        }
        private void openFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Environment.CurrentDirectory, recorder.RecorderFolder));
        }

        private void directInput_CheckedChanged(object sender, EventArgs e)
        {
            recorder.DirectInput = directInput.Checked;
        }

        private void areaImage_CheckedChanged(object sender, EventArgs e)
        {
            recorder.AreaImage = areaImage.Checked;
        }

        private void areaPoints_CheckedChanged(object sender, EventArgs e)
        {
            recorder.AreaPoints = areaPoints.Checked;
        }
    }
}
