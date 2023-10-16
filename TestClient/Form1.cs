using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestClient
{
    public partial class Form1 : Form
    {
        private Socket sck;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await ConnectToServerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect: {ex.Message}");
            }
        }

        private async Task ConnectToServerAsync()
        {
            await Task.Run(() => sck.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8)));

            // 연결 성공 후 비동기적으로 데이터 수신
            Task.Run(() => ReceiveData());
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(textBox.Text);

            sck.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
            sck.Send(data);
        }

        private async Task ReceiveData()
        {
            while (true)
            {
                try
                {
                    byte[] sizeBuf = new byte[4];
                    await sck.ReceiveAsync(sizeBuf, SocketFlags.None);

                    int size = BitConverter.ToInt32(sizeBuf, 0);
                    byte[] buffer = new byte[size];

                    await sck.ReceiveAsync(buffer, SocketFlags.None);

                    string receivedText = Encoding.Default.GetString(buffer);

                    // UI 스레드에서 TextBox에 값을 추가
                    Invoke((MethodInvoker)delegate
                    {
                        textBox.AppendText($"Received: {receivedText}{Environment.NewLine}");
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error receiving data: {ex.Message}");
                    break;
                }
            }
        }

        private async void browseButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var selectedFile = openFileDialog.FileName;

                    using (var httpClient = new HttpClient())
                    using (var fileStream = File.OpenRead(selectedFile))
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new StreamContent(fileStream), "file", Path.GetFileName(selectedFile));

                        var response = await httpClient.PostAsync("http://localhost:5000/api/FileUpload/upload", content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("File uploaded successfully");
                        }
                        else
                        {
                            MessageBox.Show("File upload failed");
                        }
                    }
                }
            }
        }
    }
}
