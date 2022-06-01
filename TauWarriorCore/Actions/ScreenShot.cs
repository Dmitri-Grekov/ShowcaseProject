using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TauWarriorCore.Image;
using TauWarriorCore.Script;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class ScreenShot : IAction
    {
        public string Name => "ScreenShot";
        public ActionType ActionType => ActionType.ScreenShot;
        public bool FullScreen { get; }
        public string Area { get; }
        public string Folder { get; }
        public string FileName { get; }
        public bool AddTime { get; }
        public bool AddDate { get; }
        public ImgFormat Format { get; }
        public string Info
        {
            get
            {
                return $"ScreenShot {FileName}";
            }
        }
        public ScreenShot(string folder, string fileName, bool addTime, bool addDate, ImgFormat format, bool fullScreen, string area)
        {
            Folder = folder;
            FileName = fileName;
            AddTime = addTime;
            AddDate = addDate;
            Format = format;
            FullScreen = fullScreen;
            Area = area;
        }
        public IAction GetCopy()
        {
            ScreenShot copy = new ScreenShot(Folder, FileName, AddTime, AddDate, Format, FullScreen, Area);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                string path = Path.Combine(Warrior.GetCurrentScreenShotFolder, Folder);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                Bitmap image;
                if (FullScreen)
                {
                    image = Screen.ScreenShot();
                }
                else
                {
                    ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                    image = Screen.ScreenShot(area.LeftTop, area.RightBottom);
                }
                if (Warrior.ChangeState)
                    return false;
                string newFile = GetFreeName(path);
                if (Warrior.ChangeState)
                    return false;
                ImageFormat format = ImageFormat.Png;
                switch (Format)
                {
                    case ImgFormat.PNG: format = ImageFormat.Png; break;
                    case ImgFormat.JPEG: format = ImageFormat.Jpeg; break;
                    case ImgFormat.BMP: format = ImageFormat.Bmp; break;
                }
                image.Save(newFile, format);
                return true;
            }
            return false;
        }
        private string GetFreeName(string path)
        {
            int i = 0;
            string format = "";
            switch (Format)
            {
                case ImgFormat.PNG: format = ".png"; break;
                case ImgFormat.JPEG: format = ".jpeg"; break;
                case ImgFormat.BMP: format = ".bmp"; break;
            }
            DateTime dateTime = DateTime.Now;
            string preName = "";
            if (AddDate)
            {
                if (AddTime)
                {
                    preName = $"({dateTime.ToString("dd-MM-yyyy")} {dateTime.ToString("H.mm")}) ";
                }
                else
                {
                    preName = $"({dateTime.ToString("dd-MM-yyyy")}) ";
                }
            }
            else
            {
                if (AddTime)
                {
                    preName = $"({dateTime.ToString("H.mm")}) ";
                }
                else
                {
                    preName = $"";
                }
            }
            while (true)
            {
                if (File.Exists(Path.Combine(path, preName + FileName + i.ToString() + format)))
                {
                    i++;
                }
                else
                {
                    return Path.Combine(path, preName + FileName + i.ToString() + format);
                }
            }
        }
    }
}