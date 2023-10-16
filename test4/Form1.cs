
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
            // YouTubeService 객체 생성
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDRu2JhMKBm93iWrv4A6Ra4pdjJ7bz05wQ", // 키 지정
                ApplicationName = "My YouTube Search"
            });

            // Search용 Request 생성
            var request = youtube.Search.List("snippet");
            request.Q = txtSearch.Text;  //ex: "리제로"
            request.MaxResults = 25;

            // Search용 Request 실행
            var result = await request.ExecuteAsync();

            // Search 결과를 리스트뷰에 담기
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

