using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace SomonERP
{
    public class MainForm : Form
    {
        private WebView2 webView;

        public MainForm()
        {
            this.Text = "Somon ERP";
            this.Width = 1280;
            this.Height = 800;
            this.StartPosition = FormStartPosition.CenterScreen;

            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            // 把缓存和cookies保存到exe同目录下的 UserData 文件夹
            string userDataFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "UserData");

            var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);
            await webView.EnsureCoreWebView2Async(env);

            webView.CoreWebView2.Navigate("https://erp.somon.cc");
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
