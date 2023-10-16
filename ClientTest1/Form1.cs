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
        private string selectFileName;
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
                textBox.AppendText("�г����� �Է����ּ���!!\n");
            }
            else
            {
                textBox.AppendText("���� �ּҸ� �Է����ּ���!!\n");
            }
            
        }

        private void sendToServer(object sender, EventArgs e)
        {
            string sendText = ""; ;
            if (textBox.Text != "")
            {
                sendText = "sendToNick" +"��" + textBox5.Text + "��"  + textBox4.Text + "��" + textBox2.Text;
                Client.sendAsync(Client.clientSocket, sendText);
            }
            else
            {
                textBox.AppendText("���� �޽����� �Է��ϼ���!!\n");
            }
        }

        private void AppendTextToTextBox(string text)
        {
            textBox.AppendText(text);
        }

        // �̺�Ʈ�� ���� �ڵ鷯
        private void execute_receiveDataC(string data)
        {
            textBox.AppendText(data + "\n");
        }

        private void searchFilePath(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { 
                selectFileName = openFileDialog.FileName;
                textBox3.Text = selectFileName;
            }
        }
        
        private async void sendFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectFileName))
            {
                textBox.AppendText("������ �����ϼ���.");
                return;
            }
            byte[] fileData = File.ReadAllBytes(selectFileName);
            string fileName = Path.GetFileName(selectFileName);
            string fileContent = Convert.ToBase64String(fileData);
            string sendText = $"sendFile��{textBox3.Text}��{fileName}��{fileContent}";
            await Client.sendAsync(Client.clientSocket, sendText);
            textBox.AppendText("���� ���� �Ϸ�!\n");
        }
        

    }
}