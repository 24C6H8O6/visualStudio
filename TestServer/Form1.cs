using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace TestServer
{
    public partial class Form1 : Form
    {
        private TcpListener _listener;
        private List<Socket> clientSockets;
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            clientSockets = new List<Socket>();
            connection = OpenDatabaseConnection();

            if (connection != null)
            {
                textBox.AppendText("DB 연결 성공!!" + Environment.NewLine);
            }
        }

        // 서버 열 때 Mysql 데이터베이스 열기
        private MySqlConnection OpenDatabaseConnection()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=testdb;User=test;Password=test;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open(); // 데이터베이스 연결을 엽니다.
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}");
                return null;
            }
        }

        // 
        private async void btnListen_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Parse("10.10.21.116"), 25000);
            _listener.Start();
            textBox.AppendText("서버 연결 준비!!" + Environment.NewLine);
            await AcceptClientsAsync();
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[25000000];
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        string dataString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Debug.WriteLine(dataString);

                        if (dataString.Contains('★'))
                        {
                            string[] parts = dataString.Split('★');

                            // 분리된 데이터 중 첫 부분이 "connects"인 경우
                            if (parts[1] == "connect")
                            {
                                // 메시지 박스 표시 및 새 폼 열기
                                MessageBox.Show($"서버 : {parts[1]}");
                                string test = "connects☆connect"; // 보낼 데이터
                                byte[] testData = Encoding.UTF8.GetBytes(test);
                                textBox.AppendText($"{client} : 연결!!" + Environment.NewLine);
                                // 데이터의 길이와 데이터를 클라이언트에게 다시 보내기
                                await SendDataAsync(client, testData);
                            }
                            else if (parts[1] == "browse")
                            {
                                // MessageBox.Show($"서버(영상ID) : {parts[2]}");
                                string test = "connects☆browse☆" + parts[2]; // 보낼 데이터
                                byte[] testData = Encoding.UTF8.GetBytes(test);
                                textBox.AppendText($"{client} : 영상ID!!" + parts[2] + Environment.NewLine);
                                // 데이터의 길이와 데이터를 클라이언트에게 다시 보내기
                                await SendDataAsync(client, testData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private async Task SendDataAsync(TcpClient client, byte[] data)
        {
            try
            {
                // 데이터의 길이 전송
                byte[] sizeBuffer = BitConverter.GetBytes(data.Length);
                await client.GetStream().WriteAsync(sizeBuffer, 0, sizeBuffer.Length);

                // 데이터 전송
                await client.GetStream().WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending data: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener?.Stop();
        }
    }
}
