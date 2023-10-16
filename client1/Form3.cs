using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using CefSharp;
using CefSharp.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace client1
{
    public partial class Form3 : Form
    {
        private string videoId;
        private static Form1 form1Instance;

        public Form3(string videoId, Form1 form1)
        {
            InitializeComponent();
            this.videoId = videoId;
            form1Instance = form1;  // Form1 인스턴스 설정
            InitializeChromium();
        }


        private async void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            await Cef.InitializeAsync(settings);

            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser($"https://www.youtube.com/embed/{videoId}");
            chromeBrowser.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(chromeBrowser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Form2 생성자에서 form1을 받아서 저장하도록 수정
            Form2 form2 = new Form2(form1Instance);
            form2.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            // Application.Exit() 호출을 제거하고 단순히 폼을 닫기만 합니다.
            // 추가 작업이 필요하다면 이 부분을 수정하세요.
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }

}
