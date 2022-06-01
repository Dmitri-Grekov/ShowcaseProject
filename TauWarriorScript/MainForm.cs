using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;
using TauWarriorCore.Script;
using TauWarriorScript.ActionForms;

namespace TauWarriorScript
{
    public partial class MainForm : Form
    {
        public static ScriptFile Script = new ScriptFile();
        public static List<(ActionType Type, string Name)> ActionNames = new List<(ActionType Type, string Name)>()
        {
            new (ActionType.Beep, "Beep"),
            new (ActionType.ChangeState, "Change State"),
            new (ActionType.IfElse, "If Else"),
            new (ActionType.KeyboardPress, "Keyboard Press"),
            new (ActionType.KeyboardText, "Keyboard Text"),
            new (ActionType.MouseClick, "Mouse Click"),
            new (ActionType.MouseDragDrop, "Mouse Drag Drop"),
            new (ActionType.MouseMove, "Mouse Move"),
            new (ActionType.OneFromAllCondition, "One From All Condition"),
            new (ActionType.OpenProcess, "Open Process"),
            new (ActionType.Pack, "Pack"),
            new (ActionType.Repeat, "Repeat"),
            new (ActionType.ScreenExists, "Screen Exists"),
            new (ActionType.ScreenFindClick, "Screen Find Click"),
            new (ActionType.ScreenFindMove, "Screen Find Move"),
            new (ActionType.ScreenShot, "ScreenShot"),
            new (ActionType.Wait, "Wait"),
            new (ActionType.While, "While")
        };
        private static IAction? action;
        public MainForm()
        {
            InitializeComponent();
            SetUI();
            createEmptyScript();
        }
        public static IAction? GetAction()
        {
            if (action == null)
                return null;
            else
            {
                IAction a = action.GetCopy();
                action = null;
                return a;
            }
        }
        public static void SetAction(IAction action)
        {
            MainForm.action = action;
        }
        public static void OpenForm(ActionType actionType, IAction? action)
        {
            switch (actionType)
            {
                case ActionType.Beep: BeepForm beepForm = new BeepForm(); beepForm.LoadData(action); beepForm.ShowDialog(); break;
                case ActionType.ChangeState: ChangeStateForm changeStateForm = new ChangeStateForm(); changeStateForm.LoadData(action); changeStateForm.ShowDialog(); break;
                case ActionType.IfElse: IfElseForm ifElseForm = new IfElseForm(); ifElseForm.LoadData(action); ifElseForm.ShowDialog(); break;
                case ActionType.KeyboardPress: KeyboardPressForm keyboardPressForm = new KeyboardPressForm(); keyboardPressForm.LoadData(action); keyboardPressForm.ShowDialog(); break;
                case ActionType.KeyboardText: KeyboardTextForm keyboardTextForm = new KeyboardTextForm(); keyboardTextForm.LoadData(action); keyboardTextForm.ShowDialog(); break;
                case ActionType.MouseClick: MouseClickForm mouseClickForm = new MouseClickForm(); mouseClickForm.LoadData(action); mouseClickForm.ShowDialog(); break;
                case ActionType.MouseDragDrop: MouseDragDropForm mouseDragDropForm = new MouseDragDropForm(); mouseDragDropForm.LoadData(action); mouseDragDropForm.ShowDialog(); break;
                case ActionType.MouseMove: MouseMoveForm mouseMoveForm = new MouseMoveForm(); mouseMoveForm.LoadData(action); mouseMoveForm.ShowDialog(); break;
                case ActionType.OneFromAllCondition: OneFromAllConditionForm oneFromAllConditionForm = new OneFromAllConditionForm(); oneFromAllConditionForm.LoadData(action); oneFromAllConditionForm.ShowDialog(); break;
                case ActionType.OpenProcess: OpenProcessForm openProcessForm = new OpenProcessForm(); openProcessForm.LoadData(action); openProcessForm.ShowDialog(); break;
                case ActionType.Pack: PackForm packForm = new PackForm(); packForm.LoadData(action); packForm.ShowDialog(); break;
                case ActionType.Repeat: RepeatForm repeatForm = new RepeatForm(); repeatForm.LoadData(action); repeatForm.ShowDialog(); break;
                case ActionType.ScreenExists: ScreenExistsForm screenExistsForm = new ScreenExistsForm(); screenExistsForm.LoadData(action); screenExistsForm.ShowDialog(); break;
                case ActionType.ScreenFindClick: ScreenFindClickForm screenFindClickForm = new ScreenFindClickForm(); screenFindClickForm.LoadData(action); screenFindClickForm.ShowDialog(); break;
                case ActionType.ScreenFindMove: ScreenFindMoveForm screenFindMoveForm = new ScreenFindMoveForm(); screenFindMoveForm.LoadData(action); screenFindMoveForm.ShowDialog(); break;
                case ActionType.ScreenShot: ScreenShotForm screenShotForm = new ScreenShotForm(); screenShotForm.LoadData(action); screenShotForm.ShowDialog(); break;
                case ActionType.Wait: WaitForm waitForm = new WaitForm(); waitForm.LoadData(action); waitForm.ShowDialog(); break;
                case ActionType.While: WhileForm whileForm = new WhileForm(); whileForm.LoadData(action); whileForm.ShowDialog(); break;
            }
        }
        private void SetUI()
        {
            statesActionPick.Items.AddRange(ActionNames.Select(x => x.Name).ToArray());
            statesActionPick.SelectedIndex = 0;
            scriptFileName.Text = Script.Name;
        }
        private void UpdateUIOnLoad()
        {
            Text = $"Script: {Script.Name}";
            scriptFileName.Text = Script.Name;
            scriptFileVersion.Text = Script.Version;
        }
        private void UpdateUI(int selectedState = 0, int selectedAction = 0, int selectedMouseAction = 0, int selectedKeyboardAction = 0, int selectedGamepadAction = 0)
        {
            statesStatesList.Items.Clear();
            statesStatesList.Items.AddRange(Script.States.Select(x => $"State: [{x.Name}] Next State: [{x.NextState}]").ToArray());
            if (statesStatesList.Items.Count > 0)
                statesStatesList.SelectedIndex = selectedState;
            statesActionList.Items.Clear();
            if (statesStatesList.SelectedIndex != -1)
                statesActionList.Items.AddRange(Script.States[statesStatesList.SelectedIndex].Actions.Select(x => x.Info).ToArray());
            if (statesActionList.Items.Count > 0)
                statesActionList.SelectedIndex = selectedAction;

            passiveStatesList.Items.Clear();
            passiveStatesList.Items.AddRange(Script.PassiveStates.Select(x => $"State: [{x.Name}] Next State: [{x.NextState}]").ToArray());
            if (passiveStatesList.Items.Count > 0)
            {
                passiveStatesList.SelectedIndex = 0;
            }

            mouseActionList.Items.Clear();
            mouseActionList.Items.AddRange(Script.MouseActions.Select(x => $"Key: [{x.Key}] Next State: [{x.NextState}]").ToArray());
            if (mouseActionList.Items.Count > 0)
                mouseActionList.SelectedIndex = selectedMouseAction;
            keyboardActionList.Items.Clear();
            keyboardActionList.Items.AddRange(Script.KeyboardActions.Select(x => $"Key: [{x.KeyText}] Next State: [{x.NextState}]").ToArray());
            if (keyboardActionList.Items.Count > 0)
                keyboardActionList.SelectedIndex = selectedKeyboardAction;
            gamepadActionList.Items.Clear();
            gamepadActionList.Items.AddRange(Script.GamePadActions.Select(x => $"({x.GamepadType} {x.GamepadIndex}) Key: [{x.KeyText}] Next State: [{x.NextState}]").ToArray());
            if (gamepadActionList.Items.Count > 0)
                gamepadActionList.SelectedIndex = selectedGamepadAction;

            dataPointList.Items.Clear();
            dataPointList.Items.AddRange(Script.ScreenPoints.Select(x => $"Name: {x.Name} [{x.Point.X},{x.Point.Y}]").ToArray());
            if (dataPointList.Items.Count > 0)
                dataPointList.SelectedIndex = 0;

            dataAreaList.Items.Clear();
            dataAreaList.Items.AddRange(Script.ScreenAreas.Select(x => $"Name: {x.Name} [{x.LeftTop.X},{x.LeftTop.Y}] -> [{x.RightBottom.X},{x.RightBottom.Y}]").ToArray());
            if (dataAreaList.Items.Count > 0)
                dataAreaList.SelectedIndex = 0;

            dataColorList.Items.Clear();
            dataColorList.Items.AddRange(Script.ScreenColors.Select(x => $"Name: {x.Name} [R:{x.Color.R} G:{x.Color.G} B:{x.Color.B}]").ToArray());
            if (dataColorList.Items.Count > 0)
                dataColorList.SelectedIndex = 0;

            dataImagesList.Items.Clear();
            dataImagesList.Items.AddRange(Script.ScreenImages.Select(x => $"{x.Name}").ToArray());

        }
        private void scriptFileOpenLocation_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Environment.CurrentDirectory, ScriptFile.ScriptsFolder));
        }
        private void createEmptyScript()
        {
            Script = new ScriptFile();
            UpdateUIOnLoad();
            UpdateUI();
        }
        private void scriptFileNew_Click(object sender, EventArgs e)
        {
            createEmptyScript();
            dataImagesPreview.Image = null;
        }
        private void scriptFileLoad_Click(object sender, EventArgs e)
        {
            openFileDialogScript.InitialDirectory = Path.Combine(Environment.CurrentDirectory, ScriptFile.ScriptsFolder);
            if (openFileDialogScript.ShowDialog() == DialogResult.OK)
            {
                Script = ScriptFile.Load(openFileDialogScript.FileName);
                UpdateUIOnLoad();
                UpdateUI();
                dataImagesPreview.Image = null;
            }
        }
        private void scriptFileSave_Click(object sender, EventArgs e)
        {
            Script.Name = scriptFileName.Text;
            Script.Version = (int.Parse(Script.Version) + 1).ToString();
            UpdateUIOnLoad();
            ScriptFile.Save(Script);
        }
        private void dataPointAdd_Click(object sender, EventArgs e)
        {
            PointForm pointForm = new PointForm();
            pointForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }
        private void dataPointEdit_Click(object sender, EventArgs e)
        {
            if (dataPointList.SelectedIndex != -1)
            {
                PointForm pointForm = new PointForm();
                pointForm.LoadData(dataPointList.SelectedIndex);
                pointForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataPointRemove_Click(object sender, EventArgs e)
        {
            if (dataPointList.SelectedIndex != -1)
            {
                Script.ScreenPoints.RemoveAt(dataPointList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataAreaAdd_Click(object sender, EventArgs e)
        {
            AreaForm areaForm = new AreaForm();
            areaForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }
        private void dataAreaEdit_Click(object sender, EventArgs e)
        {
            if (dataAreaList.SelectedIndex != -1)
            {
                AreaForm areaForm = new AreaForm();
                areaForm.LoadData(dataAreaList.SelectedIndex);
                areaForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataAreaRemove_Click(object sender, EventArgs e)
        {
            if (dataAreaList.SelectedIndex != -1)
            {
                Script.ScreenAreas.RemoveAt(dataAreaList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataColorAdd_Click(object sender, EventArgs e)
        {
            ColorForm colorForm = new ColorForm();
            colorForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }
        private void dataColorEdit_Click(object sender, EventArgs e)
        {
            if (dataColorList.SelectedIndex != -1)
            {
                ColorForm colorForm = new ColorForm();
                colorForm.LoadData(dataColorList.SelectedIndex);
                colorForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataColorRemove_Click(object sender, EventArgs e)
        {
            if (dataColorList.SelectedIndex != -1)
            {
                Script.ScreenColors.RemoveAt(dataColorList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataImagesAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                    Script.ScreenImages.Add(new ScreenImage(Path.GetFileNameWithoutExtension(file), File.ReadAllBytes(file)));
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataImagesRemove_Click(object sender, EventArgs e)
        {
            if (dataImagesList.SelectedIndex != -1)
            {
                Script.ScreenImages.RemoveAt(dataImagesList.SelectedIndex);
                dataImagesPreview.Image = null;
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void dataImagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataImagesList.SelectedIndex != -1)
                dataImagesPreview.Image = Image.FromStream(new MemoryStream(Script.ScreenImages[dataImagesList.SelectedIndex].Data));
        }
        private void mouseActionAdd_Click(object sender, EventArgs e)
        {
            MouseActionForm mouseActionForm = new MouseActionForm();
            mouseActionForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, Script.MouseActions.Count - 1, keyboardActionList.SelectedIndex);
        }
        private void mouseActionEdit_Click(object sender, EventArgs e)
        {
            if (mouseActionList.SelectedIndex != -1)
            {
                MouseActionForm mouseActionForm = new MouseActionForm();
                mouseActionForm.LoadData(mouseActionList.SelectedIndex);
                mouseActionForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void mouseActionRemove_Click(object sender, EventArgs e)
        {
            if (mouseActionList.SelectedIndex != -1)
            {
                Script.MouseActions.RemoveAt(mouseActionList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex - 1, keyboardActionList.SelectedIndex);
            }
        }
        private void keyboardActionAdd_Click(object sender, EventArgs e)
        {
            KeyboardActionForm keyboardActionForm = new KeyboardActionForm();
            keyboardActionForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, Script.KeyboardActions.Count - 1);
        }
        private void keyboardActionEdit_Click(object sender, EventArgs e)
        {
            if (keyboardActionList.SelectedIndex != -1)
            {
                KeyboardActionForm keyboardActionForm = new KeyboardActionForm();
                keyboardActionForm.LoadData(keyboardActionList.SelectedIndex);
                keyboardActionForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void keyboardActionRemove_Click(object sender, EventArgs e)
        {
            if (keyboardActionList.SelectedIndex != -1)
            {
                Script.KeyboardActions.RemoveAt(keyboardActionList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex - 1);
            }
        }
        private void passiveStatesAddState_Click(object sender, EventArgs e)
        {
            PassiveStateForm passiveStateForm = new PassiveStateForm();
            passiveStateForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }
        private void passiveStatesEditState_Click(object sender, EventArgs e)
        {
            if (passiveStatesList.SelectedIndex != -1)
            {
                PassiveStateForm passiveStateForm = new PassiveStateForm();
                passiveStateForm.LoadData(passiveStatesList.SelectedIndex);
                passiveStateForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void passiveStatesRemoveState_Click(object sender, EventArgs e)
        {
            if (passiveStatesList.SelectedIndex != -1)
            {
                Script.PassiveStates.RemoveAt(passiveStatesList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void statesAddState_Click(object sender, EventArgs e)
        {
            StateForm stateForm = new StateForm();
            stateForm.ShowDialog();
            UpdateUI(Script.States.Count - 1, -1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }
        private void statesEditState_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1)
            {
                StateForm stateForm = new StateForm();
                stateForm.LoadData(statesStatesList.SelectedIndex);
                stateForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void statesRemoveState_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1)
            {
                Script.States.RemoveAt(statesStatesList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex - 1, -1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void statesStatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            statesActionList.Items.Clear();
            if (statesStatesList.SelectedIndex != -1)
                statesActionList.Items.AddRange(Script.States[statesStatesList.SelectedIndex].Actions.Select(x => x.Name).ToArray());
            statesActionList.Items.Clear();
            if (statesStatesList.SelectedIndex != -1)
                statesActionList.Items.AddRange(Script.States[statesStatesList.SelectedIndex].Actions.Select(x => x.Info).ToArray());
        }
        private void statesUpAction_Click(object sender, EventArgs e)
        {
            if (statesActionList.SelectedIndex != -1)
            {
                if (statesActionList.SelectedIndex > 0)
                {
                    IAction temp = Script.States[statesStatesList.SelectedIndex].Actions[statesActionList.SelectedIndex];
                    Script.States[statesStatesList.SelectedIndex].Actions.RemoveAt(statesActionList.SelectedIndex);
                    Script.States[statesStatesList.SelectedIndex].Actions.Insert(statesActionList.SelectedIndex - 1, temp);
                    UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex - 1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
                }
            }
        }
        private void statesDownAction_Click(object sender, EventArgs e)
        {
            if (statesActionList.SelectedIndex != -1)
            {
                if (statesActionList.SelectedIndex < Script.States[statesStatesList.SelectedIndex].Actions.Count - 1)
                {
                    IAction temp = Script.States[statesStatesList.SelectedIndex].Actions[statesActionList.SelectedIndex];
                    Script.States[statesStatesList.SelectedIndex].Actions.RemoveAt(statesActionList.SelectedIndex);
                    Script.States[statesStatesList.SelectedIndex].Actions.Insert(statesActionList.SelectedIndex + 1, temp);
                    UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex + 1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
                }
            }
        }
        private void statesAddAction_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1)
            {
                ActionType actionType = ActionNames[statesActionPick.SelectedIndex].Type;
                OpenForm(actionType, null);
                IAction? temp = GetAction();
                if (temp != null)
                {
                    if (statesActionList.SelectedIndex != -1)
                        Script.States[statesStatesList.SelectedIndex].Actions.Insert(statesActionList.SelectedIndex + 1, temp);
                    else
                        Script.States[statesStatesList.SelectedIndex].Actions.Add(temp);
                    UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex + 1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
                }
            }
        }
        private void statesRemoveAction_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1 && statesActionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in statesActionList.SelectedIndices)
                {
                    Script.States[statesStatesList.SelectedIndex].Actions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex - 1, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }
        private void scriptFileName_TextChanged(object sender, EventArgs e)
        {
            Script.Name = scriptFileName.Text;
            UpdateUIOnLoad();
        }
        private void dataColorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDisplay.BackColor = Script.ScreenColors[dataColorList.SelectedIndex].Color;
        }
        private void gamepadActionAdd_Click(object sender, EventArgs e)
        {
            GamePadActionForm gamePadActionForm = new GamePadActionForm();
            gamePadActionForm.ShowDialog();
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex, Script.GamePadActions.Count - 1);
        }
        private void gamepadActionEdit_Click(object sender, EventArgs e)
        {
            if (gamepadActionList.SelectedIndex != -1)
            {
                GamePadActionForm gamepadActionForm = new GamePadActionForm();
                gamepadActionForm.LoadData(gamepadActionList.SelectedIndex);
                gamepadActionForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex, gamepadActionList.SelectedIndex);
            }
        }
        private void gamepadActionRemove_Click(object sender, EventArgs e)
        {
            if (gamepadActionList.SelectedIndex != -1)
            {
                Script.GamePadActions.RemoveAt(gamepadActionList.SelectedIndex);
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex, gamepadActionList.SelectedIndex - 1);
            }
        }
        private void statesActionList_DoubleClick(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1 && statesActionList.SelectedIndex != -1)
            {
                ActionType actionType = Script.States[statesStatesList.SelectedIndex].Actions[statesActionList.SelectedIndex].ActionType;
                OpenForm(actionType, Script.States[statesStatesList.SelectedIndex].Actions[statesActionList.SelectedIndex]);
                IAction? temp = GetAction();
                if (temp != null)
                    Script.States[statesStatesList.SelectedIndex].Actions[statesActionList.SelectedIndex] = temp;
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }

        private void recorder_Click(object sender, EventArgs e)
        {
            RecorderForm form = new RecorderForm();
            form.Show();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
        }

        private void statesCopyAction_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1 && statesActionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in statesActionList.SelectedIndices)
                {
                    data.Add(Script.States[statesStatesList.SelectedIndex].Actions[i]);
                }
                Clipboard.SetData("TauWarrior", data);
            }
        }

        private void gamepadActionRemapping_Click(object sender, EventArgs e)
        {
            RemapGamePadForm form = new RemapGamePadForm();
            form.ShowDialog();
        }

        private void passiveStatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            passiveStatesActionList.Items.Clear();
            passiveStatesActionList.Items.Add(Script.PassiveStates[passiveStatesList.SelectedIndex].Action.Info);
        }

        private void actionPaste_Click(object sender, EventArgs e)
        {
            if (statesStatesList.SelectedIndex != -1)
            {
                List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
                if (data == null)
                {
                    return;
                }
                int mod = 0;
                foreach (var action in data)
                {
                    Script.States[statesStatesList.SelectedIndex].Actions.Insert(statesActionList.SelectedIndex + 1 + mod, action);
                    mod++;
                }
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
            }
        }

        private void dataImagesEdit_Click(object sender, EventArgs e)
        {
            if (dataImagesList.SelectedIndex != -1)
            {
                ImageEditForm imageEditForm = new ImageEditForm();
                imageEditForm.LoadData(dataImagesList.SelectedIndex);
                imageEditForm.ShowDialog();
                UpdateUI(statesStatesList.SelectedIndex, statesActionList.SelectedIndex, mouseActionList.SelectedIndex, keyboardActionList.SelectedIndex);
                dataImagesPreview.Image = null;
            }
        }


    }
}