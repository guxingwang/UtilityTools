using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否开始
        /// </summary>
        bool isStart = false;

        Timer timer1 = new Timer();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dateTimePicker1.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            this.timer1.Interval = 1 * 1 * 1000;//时间间隔为5分钟一次
            this.timer1.Tick += Timer1_Tick;
        }
                

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"确定要在{this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")}休眠么?","提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.StartOrStop();
            }            
        }


        /// <summary>
        ///  启动或者停止服务
        /// </summary>
        private void StartOrStop()
        {
            this.isStart = !this.isStart;
            if (isStart)
            {
                this.btnShutdown.Text = "停止休眠";
                this.AddText("启动自动休眠模式");
                this.dateTimePicker1.Enabled = false;
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
            else
            {
                this.btnShutdown.Text = "开始休眠";
                this.AddText("停止自动休眠模式");
                this.dateTimePicker1.Enabled = true;
                this.timer1.Enabled = false;
                this.timer1.Stop();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            if (this.isStart && this.dateTimePicker1.Value <= DateTime.Now)
            {                
                this.StartOrStop();
                this.Dormancy();
                //int time = 10;//定义10秒中之后系统自动关机

                //var startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
                //startInfo.UseShellExecute = false;
                //startInfo.RedirectStandardInput = true;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;
                //startInfo.CreateNoWindow = true;
                //var myProcess = new System.Diagnostics.Process();
                //myProcess.StartInfo = startInfo;
                //myProcess.Start();
                //// myProcess.StandardInput.WriteLine("shutdown -s -t " + time);//自动关机
                //myProcess.StandardInput.WriteLine("shutdown -h");
            }
        }

        /// <summary>
        /// 添加信息到文本框的最后方
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private void AddText(string msg)
        {
            this.textBox1.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{msg}{Environment.NewLine}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要在马上休眠么?", "提示框", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dormancy();
            }
                
        }

        /// <summary>
        /// 休眠计算机
        /// </summary>
        private void Dormancy()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            var myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo = startInfo;
            myProcess.Start();
            // myProcess.StandardInput.WriteLine("shutdown -s -t " + time);//自动关机
            myProcess.StandardInput.WriteLine("shutdown -h");//休眠
        }
    }
}
