using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Sockets;
namespace zergling
{
    public partial class Form1 : Form
    {
        List<string> values = new List<string>();
        int valuesCount = 0;
        ProcessStartInfo MinerInfo = new ProcessStartInfo();
        Process process;
        //Process cuda;
        public Form1()
        {
            InitializeComponent();
            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProcessCheck() == false)
                StartMining(); 
        }

        private void StartMining()
        {
            WebClient client = new WebClient();
            string ConnectionInfo = client.DownloadString("http://hiveminedtest.azurewebsites.net/HMaccess/GetConnectionInfo/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey);
            ConnectionInfo = ConnectionInfo.Replace("\r\n", "");
            ConnectionInfo = ConnectionInfo.Replace(" ", "");
            ConnectionInfo = ConnectionInfo.Replace("\"", "");
            string[] SplitSource1 = ConnectionInfo.Split(new string[] { "<body>", "</body>", "<divid=PoolURL>", "</div>", "<divid=PoolUsername>", "<divid=PoolPassword>", "<divid=AddArgs>" }, StringSplitOptions.None);
            worker.PoolURL = SplitSource1[2];
            worker.PoolUsername = SplitSource1[4];
            worker.PoolPassword = SplitSource1[6];
            worker.AdditionalArgs = SplitSource1[8];
            timer1.Start();
            if (this.comboBox1.Text == "Cudaminer")
            {
                if (File.Exists(Application.StartupPath + "\\cuda\\cudaminer.exe"))
                {
                    MinerInfo.FileName = Application.StartupPath + "\\cuda\\cudaminer.exe";
                    MinerInfo.Arguments = "-o " + worker.PoolURL + " -u " + worker.PoolUsername + " -p " + worker.PoolPassword + worker.AdditionalArgs;
                    MinerInfo.RedirectStandardOutput = true;
                    MinerInfo.UseShellExecute = false;
                    MinerInfo.RedirectStandardError = true;
                    process = Process.Start(MinerInfo);
                    process.OutputDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                        }
                    };
                    process.ErrorDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                        }
                    };
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("exe file not found");
                }
            }
            if (this.comboBox1.Text == "CGminer")
            {

                if (File.Exists(Application.StartupPath + "\\cgminer\\cgminer.exe"))
                {
                    MinerInfo.FileName = Application.StartupPath + "\\cgminer\\cgminer.exe";
                    MinerInfo.Arguments = " --per-device-stats -o " + worker.PoolURL + " -u " + worker.PoolUsername + " -p " + worker.PoolPassword;
                    MinerInfo.RedirectStandardOutput = true;
                    MinerInfo.UseShellExecute = false;
                    MinerInfo.RedirectStandardError = true;
                    process = Process.Start(MinerInfo);
                    process.OutputDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                            
                        }
                    };
                    process.ErrorDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                            Debug.WriteLine(a.Data);
                        }
                    };
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("exe file not found");
                }
            }
            if (this.comboBox1.Text == "SGminer")
            {

                if (File.Exists(Application.StartupPath + "\\sgminer\\sgminer.exe"))
                {
                    MinerInfo.FileName = Application.StartupPath + "\\sgminer\\sgminer.exe";
                    MinerInfo.Arguments = " --per-device-stats -o " + worker.PoolURL + " -u " + worker.PoolUsername + " -p " + worker.PoolPassword;
                    MinerInfo.RedirectStandardOutput = true;
                    MinerInfo.UseShellExecute = false;
                    MinerInfo.RedirectStandardError = true;
                    process = Process.Start(MinerInfo);
                    process.OutputDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                            Debug.WriteLine(a.Data);
                        }
                    };
                    process.ErrorDataReceived += (s, a) =>
                    {
                        lock (values)
                        {
                            values.Add(a.Data);
                            Debug.WriteLine(a.Data);
                        }
                    };
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("exe file not found");
                }
            }
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string[] usernamesplit = this.EmailInput.Text.Split( new string[] {"."}, StringSplitOptions.None);
            worker.OwnerID = usernamesplit[0];
            worker.WorkerName = usernamesplit[1];
            worker.WorkerKey = this.IDInput.Text;
            string handshakeurl = "http://hiveminedtest.azurewebsites.net/HMaccess/handshake/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey;
            string check = client.DownloadString(handshakeurl);
            string[] SplitSource1 = check.Split(new string[] { "<body>", "</body>" }, StringSplitOptions.None);
            string[] SplitSource2 = SplitSource1[1].Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (SplitSource2[2] =="Success")
            {
                this.EmailInput.Enabled = false;
                this.IDInput.Enabled = false;
                this.LoginBtn.Enabled = false;
                this.comboBox1.Enabled = true;
                this.button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("login failed, check account details");
            }
            
        }
        static int RandomNumber(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);

        }
        ///HMaccess/Handoff/?OwnerID=steve&WorkerName=panda1&WorkerKey=7Z12GR4MTIYB7YH&Status=Dead&TotalHR=1200&Shares=15/15&GPU1HR=200&GPU1Temp=60c&GPU2HR=200&GPU2Temp=60c&GPU3HR=200&GPU3Temp=60c&GPU4HR=200&GPU4Temp=60c&GPU5HR=200&GPU5Temp=60c&GPU6HR=200&GPU6Temp=60c
        private void timer1_Tick(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            worker.TotalHashRate = (Convert.ToDouble(worker.GPU1HashRate) + Convert.ToDouble(worker.GPU2HashRate) + Convert.ToDouble(worker.GPU3HashRate) + Convert.ToDouble(worker.GPU4HashRate) + Convert.ToDouble(worker.GPU5HashRate) + Convert.ToDouble(worker.GPU6HashRate)).ToString();
            string check = client.DownloadString("http://hiveminedtest.azurewebsites.net/HMaccess/Handoff/?OwnerID=steve&WorkerName=panda1&WorkerKey=7Z12GR4MTIYB7YH&TotalHR=" + worker.TotalHashRate + "&Shares=" + worker.Shares + "&GPU1HR=" + worker.GPU1HashRate + "&GPU1Temp=" + worker.GPU1Temp + "&GPU2HR=" + worker.GPU2HashRate + "&GPU2Temp=" + worker.GPU2Temp + "&GPU3HR=" + worker.GPU3HashRate + "&GPU3Temp=" + worker.GPU3Temp + "&GPU4HR=" + worker.GPU4HashRate + "&GPU4Temp=" + worker.GPU4Temp + "&GPU5HR=" + worker.GPU5HashRate + "&GPU5Temp=" + worker.GPU5Temp + "&GPU6HR=" + worker.GPU6HashRate + "&GPU6Temp=" + worker.GPU6Temp);
            check = check.Replace("\r\n", "");
            check = check.Replace(" ", "");
            check = check.Replace("\"", ""); // <divid=RemoteCommand> </div>
            string[] SplitSource1 = check.Split(new string[] { "<divid=RemoteCommand>", "</div>" }, StringSplitOptions.None);
            if (SplitSource1[1] == "Restart")
            {
                string AcceptURL = "http://hiveminedtest.azurewebsites.net/HMaccess/RemoteAccept/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey;
                client.DownloadString(AcceptURL);
                worker.GPU1HashRate = null; worker.GPU1Temp = null;
                worker.GPU2HashRate = null; worker.GPU2Temp = null;
                worker.GPU3HashRate = null; worker.GPU3Temp = null;
                worker.GPU4HashRate = null; worker.GPU4Temp = null;
                worker.GPU5HashRate = null; worker.GPU5Temp = null;
                worker.GPU6HashRate = null; worker.GPU6Temp = null;
                values.Clear();
                if (ProcessCheck() == false)
                    StartMining(); 
            }
            if (SplitSource1[1] == "Idle")
            {
                string IdleURL = "http://hiveminedtest.azurewebsites.net/HMaccess/KillWorker/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey + "&Status=Idle";
                string AcceptURL = "http://hiveminedtest.azurewebsites.net/HMaccess/RemoteAccept/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey;
                client.DownloadString(IdleURL);
                if (ProcessCheck())
                    process.Kill();
                client.DownloadString(AcceptURL);
                Debug.WriteLine("killed miner staying on");
                

            }
            if (SplitSource1[1] == "Kill")
            {
                string KillURL = "http://hiveminedtest.azurewebsites.net/HMaccess/KillWorker/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey + "&Status=Dead";
                string AcceptURL = "http://hiveminedtest.azurewebsites.net/HMaccess/RemoteAccept/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey;
                client.DownloadString(KillURL);
                if (ProcessCheck())
                    process.Kill();
                client.DownloadString(AcceptURL);
                Application.Exit();

            }
            if (SplitSource1[1] == "0")
            {
                
                if (ProcessCheck())
                {
                    string AliveURL = "http://hiveminedtest.azurewebsites.net/HMaccess/KillWorker/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey + "&Status=Alive";
                    client.DownloadString(AliveURL);
                    if (values.Count > valuesCount)
                    {
                        for (int i = valuesCount; i < values.Count; i++)
                        {
                            Parser.ParseDirect(values[i], CheckMiner());
                            Debug.WriteLine(i);
                            Debug.WriteLine(values[i]);
                        }
                    }
                    Debug.WriteLine(values.Count);
                    valuesCount = values.Count;
                }
            }
            //string result = valuesCount.ToString() + " " + (values.Count - 1).ToString();
            //MessageBox.Show(result);
        }

        private int CheckMiner()
        {
            if (comboBox1.Text == "CGminer")
                return 1;
            if (comboBox1.Text == "Cudaminer")
                return 2;
            if (comboBox1.Text == "CPUminer")
                return 3;
            return 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebClient client = new WebClient();
            string KillURL = "http://hiveminedtest.azurewebsites.net/HMaccess/KillWorker/?OwnerID=" + worker.OwnerID + "&WorkerName=" + worker.WorkerName + "&WorkerKey=" + worker.WorkerKey + "&Status=Dead";
            client.DownloadString(KillURL);
            if (ProcessCheck())
                process.Kill();
        }
        private bool ProcessCheck()
        {
            if (process != null)
            { 
                process.Refresh();
                if (process.HasExited)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        private void EmailInput_TextChanged(object sender, EventArgs e)
        {
            this.EmailInput.ForeColor = Color.Black;
            this.EmailInput.TextAlign = HorizontalAlignment.Left;
        }

        private void IDInput_TextChanged(object sender, EventArgs e)
        {
            this.IDInput.ForeColor = Color.Black;
            this.IDInput.TextAlign = HorizontalAlignment.Left;
        }

        private void EmailInput_Leave(object sender, EventArgs e)
        {
            if (this.EmailInput.Text == "")
            {
                this.EmailInput.Text = "Username";
                this.EmailInput.ForeColor = Color.SlateGray;
                this.EmailInput.TextAlign = HorizontalAlignment.Center;
            }
        }  

        private void IDInput_Leave(object sender, EventArgs e)
        {
            if (this.IDInput.Text == "")
            {
                this.IDInput.Text = "worker key";
                this.IDInput.ForeColor = Color.SlateGray;
                this.IDInput.TextAlign = HorizontalAlignment.Center;          
            }
        }
        private int ConnectTest()
        {

            return 0;
        }
    }
}
