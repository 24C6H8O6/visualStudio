using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientTest1
{
    public partial class Form1 : Form
    {
        client Client = new client();
        private string selectFilePath;
        public Form1()
        {
            InitializeComponent();
            Client.receiveData_C += execute_receiveDataC;
        }

        private void connectToServer(object sender, EventArgs e)
        {
            string serverIP = textBox1.Text;
            string nickName = textBox5.Text;
            if (serverIP != "" && nickName != "")
            {
                Client.connectServer(nickName, serverIP);
            }
            else if (nickName == "")
            {
                textBox.AppendText("닉네임을 입력해주세요!!\n");
            }
            else
            {
                textBox.AppendText("서버 주소를 입력해주세요!!\n");
            }
            
        }

        private void sendToServer(object sender, EventArgs e)
        {
            string sendText = ""; ;
            if (textBox.Text != "")
            {
                sendText = "sendToNick" +"★" + textBox5.Text + "★"  + textBox4.Text + "★" + textBox2.Text;
                Client.sendAsync(Client.clientSocket, sendText);
            }
            else
            {
                textBox.AppendText("보낼 메시지를 입력하세요!!\n");
            }
        }

        private void AppendTextToTextBox(string text)
        {
            textBox.AppendText(text);
        }

        // 이벤트에 대한 핸들러
        private void execute_receiveDataC(string data)
        {
            textBox.AppendText(data + "\n");
        }

        private void searchFilePath(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { 
                selectFilePath = openFileDialog.FileName;
                textBox3.Text = selectFilePath;
            }
        }
        
        private async void sendFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectFilePath))
            {
                textBox.AppendText("파일을 선택하세요.");
                return;
            }
            byte[] buffer = new byte[1024];
            byte[] fileData = File.ReadAllBytes(selectFilePath);
            string fileName = Path.GetFileName(selectFilePath);
            string fileContent = Convert.ToBase64String(fileData);
            string sendText = $"sendFile★{textBox3.Text}★{fileName}★{fileContent}";
            using (FileStream fileStream = new FileStream(selectFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] message_data = Encoding.UTF8.GetBytes(sendText);
                Client.clientSocket.Send(message_data, 0, message_data.Length, SocketFlags.None);
                byte[] file_buffer = new byte[1024];
                int read_file_byte;
                long total_byte = 0;
                while ((read_file_byte = fileStream.Read(file_buffer, 0, file_buffer.Length)) > 0)
                {
                    Client.clientSocket.Send(file_buffer, 0, read_file_byte, SocketFlags.None);
                    total_byte += read_file_byte;
                }
            }
            
            await Client.sendAsync(Client.clientSocket, sendText);
            textBox.AppendText("파일 전송 완료!\n");
        }
        

    }
}