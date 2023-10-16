using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serverTest1
{
    public partial class Form1 : Form
    {
        server Server = new server();
        private string sendText;
        public Form1()
        {
            InitializeComponent();
            Server.receiveData_S += execute_receiveDataS;
        }

        // ��ư 1
        private async void clientListen(object sender, EventArgs e)
        {
            await Server.readyListen();
            textBox.AppendText("��������\n");
            await Server.clientAccept();
        }

        // ��ư 2
        private async void sendTextTo(object sender, EventArgs e)
        {
            if (Server.client == null || !Server.client.Connected)
            {
                textBox.AppendText("Ŭ���̾�Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.\n");
                return;
            }


            sendText = "���� : " + textBox1.Text;
            await Server.sendAsync(Server.client, sendText);
            textBox.AppendText("Ŭ���̾�Ʈ�� ���� ����!\n");
        }

        private void execute_receiveDataS(string data)
        {
            textBox.AppendText(data + "\n");
        }
    }
}