using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace client1
{
    public partial class Form2 : Form
    {
        private static Form2 form2Instance;
        private static Form1 form1Instance;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            form2Instance = this;
            form1Instance = form1;
            // FlowLayoutPanel을 포함하는 Panel 생성
            Panel scrollPanel = new Panel();
            scrollPanel.AutoScroll = true;
            scrollPanel.Enabled = true;
            // Panel이 폼의 크기에 맞춰짐
            scrollPanel.Dock = DockStyle.Fill;

            // flowLayoutPanel1을 scrollPanel에 추가
            scrollPanel.Controls.Add(flowLayoutPanel1);

            // scrollPanel을 form2에 추가
            this.Controls.Add(scrollPanel);

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = true;
        }

        async void btnSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear(); // 기존 컨트롤 지우기

            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                // 유튜브 api key
                ApiKey = "AIzaSyDRu2JhMKBm93iWrv4A6Ra4pdjJ7bz05wQ",
                ApplicationName = "My YouTube Search"
            });

            var request = youtube.Search.List("snippet");
            request.Q = txtSearch.Text;
            request.MaxResults = 25;

            var result = await request.ExecuteAsync();

            foreach (var item in result.Items)
            {
                if (item.Id.Kind == "youtube#video")
                {
                    // 영상 틀 때 필요한 부분
                    string videoId = item.Id.VideoId;
                    // 영상 제목
                    string videoTitle = item.Snippet.Title;
                    string imageUrl = item.Snippet.Thumbnails.Default__.Url;

                    // Panel 생성
                    Panel panel = new Panel();
                    panel.Enabled = true;
                    panel.Width = 332;
                    panel.Height = 120;

                    // PictureBox 생성
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Width = 120;
                    pictureBox.Height = 90;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    // 이미지 로드
                    pictureBox.Load(imageUrl);

                    // Label 생성
                    Label label = new Label();
                    label.Text = videoTitle;
                    label.TextAlign = ContentAlignment.MiddleLeft;
                    label.Dock = DockStyle.Fill;
                    label.Padding = new Padding(130, 0, 0, 0);

                    // PictureBox와 Label을 Panel에 추가
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(label);
                    // Panel을 FlowLayoutPanel에 추가
                    flowLayoutPanel1.Controls.Add(panel);

                    pictureBox.Click += (s, args) =>
                    {
                        Console.WriteLine($"PictureBox clicked: {videoId}");
                        sendServer(videoId);
                        
                    };
                }
            }
        }

        private async void sendServer(string data)
        {
            try
            {
                await form1Instance.ConnectToServerAsync();
                
                byte[] dataBytes = Encoding.UTF8.GetBytes("connects★browse★" + data);
                // MessageBox.Show($"send : {dataBytes}");
                Form1.sck.Send(BitConverter.GetBytes(dataBytes.Length));
                Form1.sck.Send(dataBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending data to server: {ex.Message}");
            }
        }

        public static void OpenVideo(string videoId)
        {
            try
            {
                // MessageBox.Show($"Open video: {videoId}");
                MessageBox.Show("동영상 열기 성공!!");
                Form3 form3 = new Form3(videoId, form1Instance);
                form3.Show();
                // this.Hide();
                form2Instance.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Open video");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

                Application.Exit(); // 프로그램 종료
            }
        }
    }
}
