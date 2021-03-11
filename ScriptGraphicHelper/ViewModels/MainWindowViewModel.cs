using Avalonia;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using ScriptGraphicHelper.Converters;
using ScriptGraphicHelper.Models;
using ScriptGraphicHelper.Models.UnmanagedMethods;
using ScriptGraphicHelper.ViewModels.Core;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Image = Avalonia.Controls.Image;
using Point = Avalonia.Point;
using Range = ScriptGraphicHelper.Models.Range;

namespace ScriptGraphicHelper.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            try
            {
                StreamReader sr = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
                string configStr = sr.ReadToEnd();
                sr.Close();
                configStr = configStr.Replace("\\\\", "\\").Replace("\\", "\\\\");
                Setting.Instance = JsonConvert.DeserializeObject<Setting>(configStr) ?? new Setting();
                SimSelectedIndex = Setting.Instance.SimSelectedIndex;
                FormatSelectedIndex = (FormatMode)Setting.Instance.FormatSelectedIndex;
            }
            catch { }

            ColorInfos = new ObservableCollection<ColorInfo>();
            LoupeWriteBmp = LoupeWriteBitmap.Init(241, 241);
            DataGridHeight = 40;
            Loupe_IsVisible = false;
            Rect_IsVisible = false;
            EmulatorSelectedIndex = -1;
            EmulatorInfo = EmulatorHelper.Init();
        }

        private Point StartPoint;

        public ICommand Img_PointerPressed => new Command((param) =>
        {
            if (param != null)
            {
                CommandParameters parameters = (CommandParameters)param;
                var eventArgs = (PointerPressedEventArgs)parameters.EventArgs;
                if (eventArgs.GetCurrentPoint(null).Properties.IsLeftButtonPressed)
                {

                    Loupe_IsVisible = false;
                    StartPoint = eventArgs.GetPosition(null);
                    RectMargin = new Thickness(StartPoint.X, StartPoint.Y, 0, 0);
                    Rect_IsVisible = true;
                }

            }
        });

        public ICommand Img_PointerMoved => new Command((param) =>
        {
            if (param != null)
            {
                CommandParameters parameters = (CommandParameters)param;
                var eventArgs = (PointerEventArgs)parameters.EventArgs;
                var point = eventArgs.GetPosition(null);
                if (Rect_IsVisible)
                {
                    double width = point.X - StartPoint.X - 1;
                    double height = point.Y - StartPoint.Y - 1;
                    if (width > 0 && height > 0)
                    {
                        RectWidth = width;
                        RectHeight = height;
                    }
                }
                else
                {
                    if (point.Y > 600)
                        LoupeMargin = new Thickness(point.X + 20, point.Y - 261, 0, 0);
                    else
                        LoupeMargin = new Thickness(point.X + 20, point.Y + 20, 0, 0);

                    var imgPoint = eventArgs.GetPosition((Image)parameters.Sender);


                    PointX = Math.Floor(imgPoint.X);
                    PointY = Math.Floor(imgPoint.Y);

                    int sx = (int)PointX - 7;
                    int sy = (int)PointY - 7;
                    List<byte[]> colors = new List<byte[]>();
                    for (int j = 0; j < 15; j++)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            int x = sx + i;
                            int y = sy + j;

                            if (x >= 0 && y >= 0 && x < ImgWidth && y < ImgHeight)
                            {
                                colors.Add(GraphicHelper.GetPixel(x, y));
                            }
                            else
                            {
                                colors.Add(new byte[] { 0, 0, 0 });
                            }
                        }
                    }
                    LoupeWriteBmp.WriteColor(colors);
                }
            }
        });

        public ICommand Img_PointerReleased => new Command((param) =>
        {
            if (param != null)
            {
                CommandParameters parameters = (CommandParameters)param;
                if (Rect_IsVisible)
                {
                    var eventArgs = (PointerEventArgs)parameters.EventArgs;
                    var point = eventArgs.GetPosition((Image)parameters.Sender);
                    int sx = (int)(point.X - RectWidth);
                    int sy = (int)(point.Y - rectHeight);
                    if (RectWidth > 10 && rectHeight > 10)
                    {
                        Rect = string.Format("[{0},{1},{2},{3}]", sx, sy, point.X, point.Y);
                    }
                    else
                    {
                        byte[] color = GraphicHelper.GetPixel(sx, sy);

                        if (FormatSelectedIndex == FormatMode.anchorsFindStr || FormatSelectedIndex == FormatMode.anchorsCompareStr)
                        {
                            AnchorType anchor = AnchorType.None;
                            double quarterWidth = imgWidth / 4;
                            if (sx > quarterWidth * 3)
                            {
                                anchor = AnchorType.Right;
                            }
                            else if (sx > quarterWidth)
                            {
                                anchor = AnchorType.Center;
                            }
                            else
                            {
                                anchor = AnchorType.Left;
                            }
                            if (ColorInfos.Count == 0)
                            {
                                ColorInfo.Width = ImgWidth;
                                ColorInfo.Height = ImgHeight;
                            }
                            ColorInfos.Add(new ColorInfo(ColorInfos.Count, anchor, sx, sy, color));
                        }
                        else
                        {
                            ColorInfos.Add(new ColorInfo(ColorInfos.Count, sx, sy, color));
                        }

                        DataGridHeight = (ColorInfos.Count + 1) * 40;
                    }
                }
                Rect_IsVisible = false;
                Loupe_IsVisible = true;
                RectWidth = 0;
                RectHeight = 0;
                RectMargin = new Thickness(0, 0, 0, 0);
            }
        });


        public ICommand Img_PointerEnter => new Command((param) => Loupe_IsVisible = true);

        public ICommand Img_PointerLeave => new Command((param) => Loupe_IsVisible = false);

        public async void Emulator_Selected(int value)
        {
            try
            {
                if (EmulatorHelper.State == EmlatorState.success)
                {
                    EmulatorHelper.Index = EmulatorSelectedIndex;
                }
                else if (EmulatorHelper.State == EmlatorState.Waiting)
                {
                    WindowCursor = new Cursor(StandardCursorType.Wait);
                    EmulatorHelper.Changed(EmulatorSelectedIndex);
                    EmulatorInfo = await EmulatorHelper.GetAll();
                    EmulatorSelectedIndex = -1;

                }
                else if (EmulatorHelper.State == EmlatorState.Starting)
                {
                    EmulatorHelper.State = EmlatorState.success;
                }
            }
            catch (Exception e)
            {
                EmulatorSelectedIndex = -1;
                EmulatorHelper.Dispose();
                EmulatorInfo.Clear();
                EmulatorInfo = EmulatorHelper.Init();
                Win32Api.MessageBox(e.Message);
            }
            WindowCursor = new Cursor(StandardCursorType.Arrow);

        }

        public async void ScreenShot_Click()
        {
            WindowCursor = new Cursor(StandardCursorType.Wait);
            if (EmulatorHelper.Select == -1 || EmulatorHelper.Index == -1)
            {
                Win32Api.MessageBox("请先配置 -> (模拟器/tcp/句柄)");
                WindowCursor = new Cursor(StandardCursorType.Arrow);
                return;
            }
            try
            {
                Img = await EmulatorHelper.ScreenShot();
            }
            catch (Exception e)
            {
                Win32Api.MessageBox(e.Message);
            }


            WindowCursor = new Cursor(StandardCursorType.Arrow);
        }

        public void ResetEmulatorOptions_Click()
        {
            if (EmulatorHelper.State == EmlatorState.Starting || EmulatorHelper.State == EmlatorState.success)
            {
                EmulatorSelectedIndex = -1;
                EmulatorHelper.Dispose();
                EmulatorInfo.Clear();
                EmulatorInfo = EmulatorHelper.Init();
            }
        }

        public async void TurnRight_Click()
        {
            if (Img == null)
            {
                return;
            }
            Img = await GraphicHelper.TurnRight();
        }

        public void Load_Click()
        {
            try
            {
                string[] result = new string[] { @"C:\Users\PC\Documents\leidian\Pictures\test.png" };

                OpenFileName ofn = new OpenFileName();

                ofn.structSize = Marshal.SizeOf(ofn);
                ofn.filter = "位图文件 (*.png;*.bmp;*.jpg)\0*.png;*.bmp;*.jpg\0";
                ofn.file = new string(new char[256]);
                ofn.maxFile = ofn.file.Length;
                ofn.fileTitle = new string(new char[64]);
                ofn.maxFileTitle = ofn.fileTitle.Length;
                ofn.title = "请选择文件";

                if (Win32Api.GetOpenFileName(ofn))
                {
                    string fileName = ofn.file;

                    var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    Img = new Bitmap(stream);
                    stream.Position = 0;
                    SKBitmap sKBitmap = SKBitmap.Decode(stream);
                    GraphicHelper.KeepScreen(sKBitmap);
                    sKBitmap.Dispose();
                    stream.Dispose();
                }
            }
            catch (Exception e)
            {
                Win32Api.MessageBox(e.Message, uType: 48);
            }
        }

        public void Save_Click()
        {
            if (Img == null)
            {
                return;
            }
            try
            {
                string[] result = new string[] { @"C:\Users\PC\Documents\leidian\Pictures\test.png" };

                OpenFileName ofn = new();

                ofn.structSize = Marshal.SizeOf(ofn);
                ofn.filter = "位图文件 (*.png;*.bmp;*.jpg)\0*.png;*.bmp;*.jpg\0";
                ofn.file = new string(new char[256]);
                ofn.maxFile = ofn.file.Length;
                ofn.fileTitle = new string(new char[64]);
                ofn.maxFileTitle = ofn.fileTitle.Length;
                ofn.title = "保存文件";
                ofn.defExt = ".png";
                if (Win32Api.GetSaveFileName(ofn))
                {
                    string fileName = ofn.file;
                    Img.Save(fileName);
                }
            }
            catch (Exception e)
            {
                Win32Api.MessageBox(e.Message, uType: 48);
            }
        }

        public void Test_Click()
        {
            if (Img != null && ColorInfos.Count > 0)
            {
                int[] sims = new int[] { 100, 95, 90, 85, 80, 0 };
                if (FormatSelectedIndex == FormatMode.compareStr || FormatSelectedIndex == FormatMode.ajCompareStr || FormatSelectedIndex == FormatMode.cdCompareStr || FormatSelectedIndex == FormatMode.diyCompareStr)
                {
                    string str = CreateColorStrHelper.Create(0, ColorInfos);
                    TestResult = GraphicHelper.CompareColorEx(str.Trim('"'), sims[SimSelectedIndex]).ToString();
                }
                else if (FormatSelectedIndex == FormatMode.anchorsCompareStr)
                {
                    double width = ColorInfo.Width;
                    double height = ColorInfo.Height;
                    string str = CreateColorStrHelper.Create(FormatMode.anchorsCompareStrTest, ColorInfos);
                    TestResult = GraphicHelper.AnchorsCompareColor(width, height, str.Trim('"'), sims[SimSelectedIndex]).ToString();
                }
                else if (FormatSelectedIndex == FormatMode.anchorsFindStr)
                {
                    Range rect = GetRange();
                    double width = ColorInfo.Width;
                    double height = ColorInfo.Height;
                    string str = CreateColorStrHelper.Create(FormatMode.anchorsFindStrTest, ColorInfos);
                    Point result = GraphicHelper.AnchorsFindColor(rect, width, height, str.Trim('"'), sims[SimSelectedIndex]);
                    if (result.X >= 0 && result.Y >= 0)
                    {
                        //Point point = e.Img.TranslatePoint(new Point(result.X, result.Y), e);
                        //FindResultMargin = new Thickness(point.X - 36, point.Y - 72, 0, 0);
                        //FindResultVisibility = Visibility.Visible;
                    }
                    TestResult = result.ToString();
                }
                else
                {
                    Range rect = GetRange();
                    string str = CreateColorStrHelper.Create(FormatMode.dmFindStr, ColorInfos, rect);
                    string[] strArray = str.Split("\",\"");
                    if (strArray[1].Length <= 3)
                    {
                        Win32Api.MessageBox("多点找色至少需要勾选两个颜色才可进行测试!", "错误");
                        TestResult = "error";
                        return;
                    }
                    string[] _str = strArray[0].Split(",\"");
                    Point result = GraphicHelper.FindMultiColor((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom, _str[^1].Trim('"'), strArray[1].Trim('"'), sims[SimSelectedIndex]);
                    if (result.X >= 0 && result.Y >= 0)
                    {
                        //Point point = e.Img.TranslatePoint(new Point(result.X, result.Y), e);
                        //FindResultMargin = new Thickness(point.X - 36, point.Y - 72, 0, 0);
                        //FindResultVisibility = Visibility.Visible;
                    }
                    TestResult = result.ToString();
                }
            }
        }

        public void Create_Click()
        {
            if (ColorInfos.Count > 0)
            {
                Range rect = GetRange();

                if (Rect.IndexOf("[") != -1)
                {
                    Rect = string.Format("[{0}]", rect.ToString());
                }
                else if (FormatSelectedIndex == FormatMode.anchorsCompareStr || FormatSelectedIndex == FormatMode.anchorsFindStr)
                {
                    Rect = rect.ToString(2);
                }
                else
                {
                    Rect = rect.ToString();
                }

                CreateStr = CreateColorStrHelper.Create((FormatMode)FormatSelectedIndex, ColorInfos, rect);
            }
        }

        public async void CreateStr_Copy_Click()
        {
            try
            {
                await Application.Current.Clipboard.SetTextAsync(CreateStr);
            }
            catch (Exception ex)
            {
                Win32Api.MessageBox("设置剪贴板失败 , 你的剪贴板可能被其他软件占用\r\n\r\n" + ex.Message, "error");
            }
        }
        public void Clear_Click()
        {
            if (CreateStr == string.Empty)
            {
                ColorInfos.Clear();
                DataGridHeight = 40;
            }
            else
            {
                CreateStr = string.Empty;
                Rect = string.Empty;
                TestResult = string.Empty;
            }
        }

        public ICommand Key_AddColorInfo => new Command((param) =>
        {
            if (!Loupe_IsVisible)
            {
                return;
            }
            int x = (int)PointX;
            int y = (int)PointY;
            string key = (string)param;
            byte[] color = GraphicHelper.GetPixel(x, y);

            AnchorType anchor = AnchorType.None;
            if (FormatSelectedIndex == FormatMode.anchorsFindStr || FormatSelectedIndex == FormatMode.anchorsCompareStr)
            {
                if (key == "A")
                    anchor = AnchorType.Left;
                else if (key == "S")
                    anchor = AnchorType.Center;
                else if (key == "D")
                    anchor = AnchorType.Right;
            }

            ColorInfos.Add(new ColorInfo(ColorInfos.Count, anchor, x, y, color));
            DataGridHeight = (ColorInfos.Count + 1) * 40;

        });

        public async void Rect_Copy_Click()
        {
            try
            {
                await Application.Current.Clipboard.SetTextAsync(Rect);
            }
            catch (Exception ex)
            {
                Win32Api.MessageBox("设置剪贴板失败 , 你的剪贴板可能被其他软件占用\r\n\r\n" + ex.Message, "error");
            }
        }

        public void Rect_Clear_Click()
        {
            Rect = string.Empty;
        }

        public void ColorInfo_Clear_Click()
        {
            ColorInfos.Clear();
            DataGridHeight = 40;
        }

        public async void Point_Copy_Click()
        {
            try
            {
                if (ColorInfoSelectedIndex == -1)
                {
                    Win32Api.MessageBox("当前选择项为-1, 必须先左键单击激活选择项再打开右键菜单!", "错误");
                    return;
                }
                Point point = ColorInfos[ColorInfoSelectedIndex].Point;
                string pointStr = string.Format("{0},{1}", point.X, point.Y);
                await Application.Current.Clipboard.SetTextAsync(pointStr);
            }
            catch (Exception ex)
            {
                Win32Api.MessageBox("设置剪贴板失败 , 你的剪贴板可能被其他软件占用\r\n\r\n" + ex.Message, "错误");
            }
        }

        public async void Color_Copy_Click()
        {
            try
            {
                if (ColorInfoSelectedIndex == -1)
                {
                    Win32Api.MessageBox("当前选择项为-1, 必须先左键单击激活选择项再打开右键菜单!", "错误");
                    return;
                }
                Color color = ColorInfos[ColorInfoSelectedIndex].Color;
                string hexColor = string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
                await Application.Current.Clipboard.SetTextAsync(hexColor);
            }
            catch (Exception ex)
            {
                Win32Api.MessageBox("设置剪贴板失败 , 你的剪贴板可能被其他软件占用\r\n\r\n" + ex.Message, "错误");
            }
        }

        private Range GetRange()
        {
            if (ColorInfos.Count == 0)
            {
                return new Range(0, 0, ImgWidth, ImgHeight);
            }
            if (Rect != string.Empty)
            {
                if (Rect.IndexOf("[") != -1)
                {
                    string[] range = Rect.TrimStart('[').TrimEnd(']').Split(',');

                    return new Range(int.Parse(range[0].Trim()), int.Parse(range[1].Trim()), int.Parse(range[2].Trim()), int.Parse(range[3].Trim()));
                }
            }
            double imgWidth = ImgWidth - 1;
            double imgHeight = ImgHeight - 1;

            if (FormatSelectedIndex == FormatMode.anchorsFindStr || FormatSelectedIndex == FormatMode.anchorsCompareStr)
            {
                imgWidth = ColorInfo.Width;
                imgHeight = ColorInfo.Height;
            }

            double left = imgWidth;
            double top = imgHeight;
            double right = 0;
            double bottom = 0;
            int mode_1 = -1;
            int mode_2 = -1;

            foreach (ColorInfo colorInfo in ColorInfos)
            {
                if (colorInfo.IsChecked)
                {
                    if (colorInfo.Point.X < left)
                    {
                        left = colorInfo.Point.X;
                        mode_1 = colorInfo.Anchor == AnchorType.Left ? 0 : colorInfo.Anchor == AnchorType.Center ? 1 : colorInfo.Anchor == AnchorType.Right ? 2 : -1;
                    }
                    if (colorInfo.Point.X > right)
                    {
                        right = colorInfo.Point.X;
                        mode_2 = colorInfo.Anchor == AnchorType.Left ? 0 : colorInfo.Anchor == AnchorType.Center ? 1 : colorInfo.Anchor == AnchorType.Right ? 2 : -1;
                    }
                    if (colorInfo.Point.Y < top)
                    {
                        top = colorInfo.Point.Y;
                    }
                    if (colorInfo.Point.Y > bottom)
                    {
                        bottom = colorInfo.Point.Y;
                    }

                }
            }
            //return new Range(left >= 50 ? left - 50 : 0, top >= 50 ? top - 50 : 0, right + 50 > imgWidth ? imgWidth : right + 50, bottom + 50 > imgHeight ? imgHeight : bottom + 50, mode_1, mode_2);
            return new Range(left >= 4 ? left - 4 : 0, top >= 4 ? top - 4 : 0, right + 4 > imgWidth ? imgWidth : right + 4, bottom + 4 > imgHeight ? imgHeight : bottom + 4, mode_1, mode_2);

        }
    }

}
