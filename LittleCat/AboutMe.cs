using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LittleCat
{
    public partial class AboutMe : Form
    {
        public AboutMe()
        {
            InitializeComponent();
        }
        public LittleCat f1;
        static private String userMsgPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\这是Candy的记忆哦.txt";
        static private String pwd = "jxbasjxlsq2";
        private void AboutMe_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            string inFile = userMsgPath + ".candy";
            if (File.Exists(inFile))
            {
                string outFile = inFile.Substring(0, inFile.Length - 5);
                string password = pwd;
                DESFile.DecryptFile(inFile, outFile, password);//解密文件
                //删除解密前的文件
                File.Delete(inFile);
                String[] msgArr = File.ReadAllText(userMsgPath).Split('*');
                time.Text = "我已经累计陪伴你" + (Convert.ToInt64(msgArr[0].ToString()) * 0.5 / 60 / 60).ToString("f2") + "小时了";
                key.Text = "看着你敲打键盘" + msgArr[1].ToString() + "次";
                mouse.Text = "点击鼠标" + msgArr[2].ToString() + "次";
                distance.Text = "您的鼠标移动距离加起来有" + (Convert.ToInt64(msgArr[3]) / (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 0.3)).ToString("f2") + "米哦(当然只是粗略估计啦)";
                sleep.Text = "在这期间我睡着了"+ Convert.ToInt64(msgArr[4])+ "次，嘻嘻，真是不好意思呢(✿◡‿◡)";

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
                    File.Delete(inFile2);
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

        private void key_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = "我已经累计陪伴你" + ((f1.stayTime) * 0.5 / 60 / 60).ToString("f2") + "小时了";
            key.Text = "看着你敲打键盘" + f1.typeNum.ToString() + "次";
            mouse.Text = "点击鼠标" + f1.mouseNum.ToString() + "次";
            distance.Text = "您的鼠标移动距离加起来有" + (f1.distanceNum / (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 0.3)).ToString("f2") + "米哦(当然只是粗略估计啦)";
            sleep.Text = "在这期间我睡着了" +f1.sleepNum + "次，嘻嘻，真是不好意思呢(✿◡‿◡)";
        }
    }
}
