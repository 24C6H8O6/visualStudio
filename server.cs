using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serverTest1
{
    public partial class server
    {
        private List<string> nicknameList = new List<string>();
        private List<Socket> socketList = new List<Socket>();
        private List<string> IPList = new List<string>();
        public event Action<string> receiveData_S;
        public Socket client;
        private byte[] receiveBuffer = new byte[1024];
        private string sendText;
        private Socket socket;
        private string receiveText;

        public async Task readyListen()
        {
            // First
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8080);
            socket.Bind(endPoint);
            socket.Listen(10);
        }

        public async Task clientAccept()
        {
            while (true)
            {
                client = await socket.AcceptAsync();
                IPEndPoint clientIP = (IPEndPoint)client.RemoteEndPoint;
                string client_IP = $"{clientIP.Address}:{clientIP.Port}";
                receiveData_S?.Invoke($"{client_IP} 연결 성공!");
                // 사용자 정보 리스트 저장
                socketList.Add(client);
                IPList.Add(client_IP);
                // 현재 접속자 표시
                string connectMembers = "";
                int connectCount = 0;
                foreach (string clientsIP in IPList)
                {
                    int index = IPList.IndexOf(clientsIP);
                    Socket socket1 = socketList[index];
                    // string clientsIP = clientSocket.Value;
                    
                    if (socket1.Connected)
                    {
                        connectMembers += "," + clientsIP;
                        connectCount++;
                    }
                }
                await sendAsync(client, $"환영합니다, {client_IP}!\n");
                await sendToAll(client_IP, $"현재 접속중인 멤버 수 : {connectCount}명\n" +
                    $"현재 접속중인 멤버 : {connectMembers}");
                Task.Run(() => receiveAsync(client, client_IP));
            }
        }

        
        public async Task receiveAsync(Socket client, string client_IP)
        {
            
            byte[] buffer = new byte[262144];
            while (true)
            {
                int bytesRead = await client.ReceiveAsync(buffer);
                // 데이터를 받지 않은 경우 루프 종료
                if (bytesRead == 0)
                {
                    break;
                }
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                // 받아온 데이터를 ★로 나누어서 0번째 인덱스가 nickname이면 1번째 인덱스를 nicknameList에 저장
                string[] datas = data.Split('★');
                if (datas[0] == "nickname")
                {
                    nicknameList.Add(datas[1]);
                    receiveData_S?.Invoke($"연결된 닉네임 : {datas[1]}");
                }
                else if (datas[0] == "sendToNick")
                {
                    if (datas[2] == "")
                    {
                        string cl_ip_data = $"From {datas[1]} To All) - {datas[3]}";
                        receiveData_S?.Invoke(cl_ip_data);
                        sendToAll(client_IP, cl_ip_data);
                    }
                    else
                    {
                        // string cl_ip_data = $"From {client_IP}) - {nicknames[2]}";
                        string cl_ip_data = $"From {datas[1]} To {datas[2]}) - {datas[3]}";
                        receiveData_S?.Invoke(cl_ip_data);
                        int index = nicknameList.IndexOf(datas[2]);
                        sendAsync(socketList[index], cl_ip_data);
                    }
                }
                else if (datas[0] == "sendFile")
                {
                    string savePath = "C:\\Users\\LMS116\\Documents\\test\\";
                    try
                    {
                        string fileName = datas[2];
                        byte[] fileData = Convert.FromBase64String(datas[3]);
                        string filePath = Path.Combine(savePath, fileName);
                        File.WriteAllBytes(filePath, fileData);
                        receiveData_S?.Invoke($"파일 수신 및 저장 완료: {fileName}");
                    }
                    catch (Exception ex)
                    {
                        receiveData_S?.Invoke($"파일 수신 중 오류: {ex.Message}");
                        MessageBox.Show($"파일 수신 중 오류: {ex.Message}");
                    }
                }
            }
        }
        


        public async Task sendAsync(Socket client, string sendText)
        {
            byte[] data = Encoding.UTF8.GetBytes(sendText);
            await client.SendAsync(data, SocketFlags.None);
        }

        // 사용자 정보 리스트 저장
        public async Task sendToAll(string client_IP, string message)
        {
            foreach (string clientsIP in IPList)
            {
                int index = IPList.IndexOf(clientsIP);
                Socket socket = socketList[index];
                // Socket socket = clientSocket.Key; // Socket에 접근
                // string clientIP = clientSocket.Value; // IP 주소에 접근
                if (socket.Connected)
                {
                    string fullMessage = $"{client_IP} - {message}";
                    await sendAsync(socket, fullMessage);
                }
            }
        }


    }
}
