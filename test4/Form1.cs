
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        async void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            // YouTubeService ��ü ����
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDRu2JhMKBm93iWrv4A6Ra4pdjJ7bz05wQ", // Ű ����
                ApplicationName = "My YouTube Search"
            });

            // Search�� Request ����
            var request = youtube.Search.List("snippet");
            request.Q = txtSearch.Text;  //ex: "������"
            request.MaxResults = 25;

            // Search�� Request ����
            var result = await request.ExecuteAsync();

            // Search ����� ����Ʈ�信 ���
            foreach (var item in result.Items)
            {
                if (item.Id.Kind == "youtube#video")
                {
                    listView1.View = View.List;
                    listView1.Items.Add(item.Id.VideoId.ToString(), item.Snippet.Title, 0);


                }
            }
        }
    }
}

