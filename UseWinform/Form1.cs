using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseWinform
{
    public partial class Form1 : Form
    {
        int result;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.ShowWaitDialog(this.setResultFibon);
                this.label1.Text = "Résult : "+ this.result;
        }

        private void setResultFibon()
        {
            ServiceReference1.mainSoapClient mainSoapClient = new ServiceReference1.mainSoapClient();
            result =  mainSoapClient.Fibonacci(10);
        }

        private void ShowWaitDialog(Action codeToRun)
        {
            ManualResetEvent dialogLoadedFlag = new ManualResetEvent(false);

            (new Thread(() =>
            {
                Form waitDialog = new Form()
                {
                    Name = "WaitForm",
                    Text = "Veuillez patienter svp...",
                    ControlBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    Width = 240,
                    Height = 50,
                    Enabled = true
                };

                ProgressBar ScrollingBar = new ProgressBar()
                {
                    Style = ProgressBarStyle.Marquee,
                    Parent = waitDialog,
                    Dock = DockStyle.Fill,
                    Enabled = true
                };

                waitDialog.Load += new EventHandler((x, y) =>
                {
                    dialogLoadedFlag.Set();
                });

                waitDialog.Shown += new EventHandler((x, y) =>
                {
                
                    (new Thread(() =>
                    {
                        codeToRun();
                        Thread.Sleep(2000);
                        this.Invoke((MethodInvoker)(() => waitDialog.Close()));
                    })).Start();
                    
                });
                this.Invoke((MethodInvoker)(() => waitDialog.ShowDialog(this)));
            })).Start();
            while (dialogLoadedFlag.WaitOne(100, true) == false)
                Application.DoEvents(); // note: this will block the main thread once the wait dialog shows
        }
    }
}
