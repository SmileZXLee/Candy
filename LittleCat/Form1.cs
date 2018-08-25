using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

namespace LittleCat
{
    public partial class LittleCat : Form
    {
        public LittleCat()
        {
            InitializeComponent();
        }
        //定义动画每秒执行间隔 单位：毫秒
        static private int interval = 500;
        public static AboutMe am;
        private int step = 3;
        public long stayTime;
        private long excuteTime;
        public long typeNum;
        public long mouseNum;
        public long distanceNum;
        public long sleepNum;
        private long delayTimeIndex;
        private long delayTime;
        private int donotMove;
        private String forMainName;
        static private String pwd = "jxbasjxlsq2";
        static private String userMsgPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\这是Candy的记忆哦.txt";
        static private String resourcePath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\neko\\";
        //图片路径
        private String imgPath;
        //动画名称
        private String mainName;
        private MouseHook mh;
        private KeyboardHook k_hook;
        //鼠标的x，y
        private int x, y;
        private void LittleCat_Load(object sender, EventArgs e)
        {
            CreateShortCut();
            this.ShowInTaskbar = false;
            this.Size = new Size(50, 50);
            imgShowPB.Size = this.Size;
            imgShowPB.Location = new Point(0, 0);
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            this.TopMost = true;
            //初始动画
            animateTimer.Interval = interval;
            animateTimer.Enabled = true;
            //初始图片路径
            mainName = "sleep";
            imgPath = resourcePath + mainName + "1.gif";
            imgShowPB.Image = Image.FromFile(imgPath);
            //安装钩子
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseMoveEvent += mh_MouseMoveEvent;
            mh.MouseClickEvent += mh_MouseClickEvent;
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下 
            k_hook.Start();//安装键盘钩子
            string inFile = userMsgPath + ".candy";
            if (System.IO.File.Exists(inFile))
            {
                string outFile = inFile.Substring(0, inFile.Length - 5);
                string password = pwd;
                DESFile.DecryptFile(inFile, outFile, password);//解密文件
                //删除解密前的文件
                System.IO.File.Delete(inFile);
                String[] msgArr = System.IO.File.ReadAllText(userMsgPath).Split('*');
                stayTime = Convert.ToInt64(msgArr[0].ToString());
                typeNum = Convert.ToInt64(msgArr[1].ToString());
                mouseNum = Convert.ToInt64(msgArr[2].ToString());
                distanceNum = Convert.ToInt64(msgArr[3].ToString());
                sleepNum = Convert.ToInt64(msgArr[4].ToString());
            }
            try
            {
                
                string inFile2 = userMsgPath;
                string outFile2 = inFile2 + ".candy";
                string password2 = pwd;
                DESFile.EncryptFile(inFile2, outFile2, password2);//加密文件
                // MessageBox.Show(path);
                //删除加密前的文件
                try
                {
                    System.IO.File.Delete(inFile2);
                }
                catch
                {
                    MessageBox.Show("文件保存异常！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                //MessageBox.Show("本程序没有权限访问您的目标文件夹，数据存储失败，请使用管理员身份运行并再次尝试！", "账号信息存储失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //remPwd.Checked = false;
            }
        }
        private void CreateShortCut()
        {
            string DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);//得到桌面文件夹
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(DesktopPath + "\\Candy.lnk");
            shortcut.TargetPath = System.Windows.Forms.Application.ExecutablePath;
            shortcut.Arguments = "";// 参数
            shortcut.Description = "Candy快捷方式";
            shortcut.WorkingDirectory = System.Windows.Forms.Application.ExecutablePath;//程序所在文件夹，在快捷方式图标点击右键可以看到此属性
            //shortcut.IconLocation = @"D:\software\cmpc\zy.exe,0";//图标
            shortcut.Hotkey = "CTRL+SHIFT+C";//热键
            shortcut.WindowStyle = 1;
            shortcut.Save();
            
        }
        private void LittleCat_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗口关闭时移除钩子
            mh.UnHook();
        }
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            typeNum++;
        }
        private void animateTimer_Tick(object sender, EventArgs e)
        {
            stayTime++;
            if (stayTime * (interval / 1000.0) % 20 == 0) {
                if (System.IO.File.Exists(userMsgPath + ".candy"))
                {
                    System.IO.File.Delete(userMsgPath + ".candy");
                }

                String userMsgStr = stayTime.ToString() + "*" + typeNum.ToString() + "*" + mouseNum.ToString() + "*" + distanceNum.ToString() + "*" + sleepNum.ToString();
                System.IO.File.AppendAllText(userMsgPath, userMsgStr);
                string inFile2 = userMsgPath;
                string outFile2 = inFile2 + ".candy";
                string password2 = pwd;
                
                 DESFile.EncryptFile(inFile2, outFile2, password2);//加密文件
                // MessageBox.Show(path);
                //删除加密前的文件
                try
                {
                    System.IO.File.Delete(inFile2);
                }
                catch
                {
                    MessageBox.Show("文件保存异常！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
            }
            if (mainName == "kaki" || mainName == "fool" || mainName == "mati")
            {
                //开始计算cat休息时间
                excuteTime++;
            }
            if (excuteTime * (interval / 1000.0) > 10) { 
                //若休息时间大于10秒
                mainName = "fool";
                if (excuteTime * (interval / 1000.0) > 12)
                {
                    //若休息时间大于12秒
                    mainName = "mati";
                    if (excuteTime * (interval / 1000.0) > 15)
                    {
                        //若休息时间大于20秒
                        mainName = "sleep";
                        sleepNum++;
                        excuteTime = 0;
                    }
                }
            }
            
            animateopr();
        }

        private void operateTimer_Tick(object sender, EventArgs e)
        {
            //移动动画
            forMainName = mainName;
            if (Math.Abs(x - this.Location.X) > step  || Math.Abs(y - this.Location.Y) > step )
            {
                
                //未追到 设置cat未知
                //因为此次this.Location.X，this.Location.Y为只读的
                //此处冗余为了易于修改
                //判断方位
                if (!(Math.Abs(x - this.Location.X) < step) && !(Math.Abs(y - this.Location.Y) < step))
                {
                    if (x - this.Location.X > step)
                    {
                        //鼠标在右方
                        if (y - this.Location.Y > step)
                        {
                            //鼠标在右下方
                            mainName = @"dwright";

                        }
                        else
                        {
                            //鼠标在右上方
                            mainName = @"upright";

                        }
                    }
                    else
                    {
                        //鼠标在左方
                        if (y > this.Location.Y)
                        {
                            //鼠标在左下方
                            mainName = @"dwleft";


                        }
                        else
                        {
                            //鼠标在左上方
                            mainName = @"upleft";


                        }
                    }
                }
                else
                {

                    //垂直，水平方向
                    if (Math.Abs(y - this.Location.Y) < step)
                    {
                        if (x > this.Location.X)
                        {
                            //向右
                            mainName = @"right";

                        }
                        else
                        {
                            //向左
                            mainName = @"left";
                        }
                    }
                    if (Math.Abs(x - this.Location.X) < step)
                    {
                        if (y > this.Location.Y )
                        {
                            //向上
                            mainName = @"down";
                        }
                        else
                        {
                            //向下
                            mainName = @"up";
                        }
                    }
                }
                if (!(mainName == forMainName))
                {
                    animateopr();
                }
                int lx = this.Location.X;
                int ly = this.Location.Y;
                lx = x > this.Location.X ? lx + step : lx - step;
                ly = y > this.Location.Y ? ly + step : ly - step;
                if (Math.Abs(x - this.Location.X) < step) {
                    lx = this.Location.X;
                }
                if (Math.Abs(y - this.Location.Y) < step)
                {
                    ly = this.Location.Y;
                }
                if (!(this.Location.X >= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50 - 10 && mainName.Contains("right")))
                {
                    this.Location = new Point(lx, ly);

                }
                else {
                    if (this.Location.X >= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50 - 10)
                    {
                        operateTimer.Enabled = false;
                        this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50, this.Location.Y);
                        mainName = "rtogi";
                        donotMove = 1;

                    }
                }
                
                
                
            }
            else {
                //追到鼠标了
                //停用此定时器
                operateTimer.Enabled = false;
                //更改动画效果
                if (this.Location.X <= 10)
                {
                    this.Location = new Point(0, this.Location.Y);
                    mainName = "ltogi";
                    donotMove = 1;
                }
                else if (this.Location.Y <= 10)
                {
                    this.Location = new Point(this.Location.X, 0);
                    mainName = "utogi";
                    donotMove = 1;
                }
                else if (this.Location.X >= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50)
                {
                    this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50, this.Location.X);
                    mainName = "rtogi";
                    donotMove = 1;
                    
                }
                else if (this.Location.Y >= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 10)
                {   

                    //mainName = "utogi";
                    //this.Location = new Point(lx, ly);
                }
                else
                {
                    mainName = @"kaki";
                }
                
            }
        }
        private void animateopr() { 
             //fi为文件动画的1，2
            String fi = "1";
            //获取当前路径文件名
            String fileName = System.IO.Path.GetFileName(imgPath);
            //1,2判定
            fi = fileName.Contains(fi) ? @"1" == fi ? @"2" : @"1" : @"1" == fi ? @"1" : @"2";
            //拼接新路径
            imgPath = resourcePath + mainName + fi + ".gif";
            //定时器操作 播放动画 
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(imgPath, FileMode.Open, FileAccess.Read);

                int byteLength = (int)fs.Length;
                byte[] fileBytes = new byte[byteLength];
                fs.Read(fileBytes, 0, byteLength);
                fs.Close();
                Image image = Image.FromStream(new MemoryStream(fileBytes));
                imgShowPB.Image = image;
                //img.Dispose();
            }
            catch {
                MessageBox.Show("图片资源丢失，请重新安装","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
        }
        private void mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                mouseNum ++;
                //鼠标左击
                this.x = e.X;
                this.y = e.Y;
                //cat休息时间归0
                excuteTime = 0;
                if (donotMove == 1) {
                    return;
                }
                //如果在睡觉 惊醒
                if (mainName == "sleep")
                {   
                    //惊醒过1秒开始追鼠标
                    delayTime = 1;
                    mainName = "awake";
                    delayTimer.Enabled = true;
                }
                else
                {
                    //移动Cat
                    operateTimer.Enabled = true;
                }
            }

        }
        
        private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {   
            //鼠标移动
            int x = e.Location.X;
            int y = e.Location.Y;
            this.x = x;
            this.y = y;
            distanceNum++;
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            
            delayTimeIndex++;
           // MessageBox.Show(delayTimeIndex.ToString() + "-" + delayTime.ToString());
            if (delayTime == delayTimeIndex) {
                //移动Cat
                operateTimer.Enabled = true;
                delayTimeIndex = 0;
                delayTimer.Enabled = false;
            }
        }

        private void imgShowPB_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void imgShowPB_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void imgShowPB_Click(object sender, EventArgs e)
        {
            donotMove = 0;
            if (!(mainName == "sleep"))
            {
                operateTimer.Enabled = true;
            }
            
        }

        private void candyNI_Click(object sender, EventArgs e)
        {
            donotMove = 0;
            if (!(mainName == "sleep"))
            {
                operateTimer.Enabled = true;
            }
        }

        private void 偏好设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于我ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (am == null)
            {
                am = new AboutMe();
                am.f1 = this;
                am.Show();
            }
            else {
                am.Activate();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void candyNI_MouseDown(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Right) {
                this.myMenu.Show(Control.MousePosition);  
            }
        }

        
    }
    //因为懒所以把类放在一起了
    //鼠标Hook类
    public class MouseHook
    {
        private Point point;
        private Point Point
        {
            get { return point; }
            set
            {
                if (point != value)
                {
                    point = value;
                    if (MouseMoveEvent != null)
                    {
                        var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
                        MouseMoveEvent(this, e);
                    }
                }
            }
        }
        private int hHook;
        private const int WM_LBUTTONDOWN = 0x201;
        public const int WH_MOUSE_LL = 14;
        public Win32Api.HookProc hProc;
        public MouseHook()
        {
            this.Point = new Point();
        }
        public int SetHook()
        {
            hProc = new Win32Api.HookProc(MouseHookProc);
            hHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
            return hHook;
        }
        public void UnHook()
        {
            Win32Api.UnhookWindowsHookEx(hHook);
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Win32Api.MouseHookStruct MyMouseHookStruct = (Win32Api.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseHookStruct));
            if (nCode < 0)
            {
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                if (MouseClickEvent != null)
                {
                    MouseButtons button = MouseButtons.None;
                    int clickCount = 0;
                    switch ((Int32)wParam)
                    {
                        case WM_LBUTTONDOWN:
                            button = MouseButtons.Left;
                            clickCount = 1;
                            break;
                    }

                    var e = new MouseEventArgs(button, clickCount, point.X, point.Y, 0);
                    MouseClickEvent(this, e);
                }
                this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }

        public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
        public event MouseMoveHandler MouseMoveEvent;

        public delegate void MouseClickHandler(object sender, MouseEventArgs e);
        public event MouseClickHandler MouseClickEvent;
    }
    //Win32Api类
    public class Win32Api
    {
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
    }
}
