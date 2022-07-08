using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Monitor
{
    public partial class Form1 : Form
    {
        #region Private Fields

        private int t = 0;

        #endregion Private Fields

        #region Public Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                timer.Enabled = true;
                lblTimerState.Text = "Timer Running";

                btnStart.Text = "Stop Timer";
                CheckStatus();
            }
            else
            {
                timer.Enabled = false;
                lblTimerState.Text = "Timer Stopped";
                btnStart.Text = "Start Timer";
            }
        }

        private void CheckStatus()
        {
            log("Checking Status..");
            TimeSpan apiTime = new TimeSpan(0, 0, 0, 0);
            DateTime start = DateTime.Now;
            string x = new System.Net.WebClient().DownloadString(txtApi.Text);
            DateTime end = DateTime.Now;
            apiTime = DateTime.Now.Subtract(start);
            if (apiTime.TotalMilliseconds < 1000)
            {
                panelAPITime.BackColor = Color.Green;
            }
            else
            {
                panelAPITime.BackColor = Color.Red;
            }
            lblAPIResponsetime.Text = apiTime.TotalMilliseconds.ToString() + " ms";
            log("API Response Time: " + Math.Round((decimal)apiTime.TotalMilliseconds, 1) + " ms");
            LogResponseToDB(txtApi.Text, (int)apiTime.TotalMilliseconds);

            start = DateTime.Now;
            x = new System.Net.WebClient().DownloadString(txtGoogle.Text);
            TimeSpan websiteTime = new TimeSpan(0, 0, 0, 0);
            websiteTime = DateTime.Now.Subtract(start);
            lblGoogleResponsetime.Text = websiteTime.TotalMilliseconds.ToString() + " ms";
            log("Google Response Time: " + Math.Round((decimal)websiteTime.TotalMilliseconds, 1) + " ms");

            LogResponseToDB(txtGoogle.Text, (int)websiteTime.TotalMilliseconds);

            if (websiteTime.TotalMilliseconds < 1000)
            {
                panelWebSiteTime.BackColor = Color.Green;
            }
            else
            {
                panelWebSiteTime.BackColor = Color.Red;
            }

            Process[] p = System.Diagnostics.Process.GetProcessesByName("sqlservr");
            if (p.Length > 0)
            {
                panelDBStatus.BackColor = Color.Green;
            }
            else
            {
                panelDBStatus.BackColor = Color.Red;
            }
            p = System.Diagnostics.Process.GetProcessesByName("christopher");
            if (p.Length > 0)
            {
                panelTradeProc.BackColor = Color.Green;
            }
            else
            {
                panelTradeProc.BackColor = Color.Red;
            }
        }

        private void log(string message)
        {
            listbox.Items.Insert(0, message);
            if (listbox.Items.Count == 1000)
            {
                listbox.Items.RemoveAt(1000);
            }
        }

        private void LogResponseToDB(string url, double responsetime)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("url", SqlDbType.NVarChar, 128)
            {
                Value = url
            };
            parms[1] = new SqlParameter("time", SqlDbType.BigInt)
            {
                Value = responsetime
            };

            string dbconn = "Server=127.0.0.1;Database=trade;Trusted_Connection=True;";

            SqlHelper.ExecuteNonQuery(dbconn, CommandType.StoredProcedure, "ResponseTime_INSERT", parms);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            t++;
            lblTimerInfo.Text = t.ToString() + " Seconds";

            if (t == 10)
            {
                timer.Enabled = false;
                CheckStatus();
                t = 0;
                timer.Enabled = true;
            }
        }

        #endregion Private Methods
    }
}