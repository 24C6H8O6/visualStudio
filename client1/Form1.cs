using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Google.Apis.YouTube.v3.Data;

namespace client1
{
    public partial class Form1 : Form
    {
        public static Socket sck;
        private static Form1 form1Instance;
        public Form1()
        {
            InitializeComponent();
            form1Instance = this;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (sck != null && sck.Connected)
            {
                MessageBox.Show("이미 연결되어 있습니다.");
                return;
            }
            try
            {
                if (sck == null)
                {
                    sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                await ConnectToServerAsync();
                string message = "connects★connect";
                byte[] data = Encoding.UTF8.GetBytes(message);
                sck.Send(BitConverter.GetBytes(data.Length));
                sck.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect: {ex.Message}");
            }
        }

        public async Task ConnectToServerAsync()
        {
            // 이미 연결된 경우에는 추가적인 연결 시도를 하지 않음
            if (sck != null && sck.Connected)
            {
                return;
            }

            try
            {
                if (sck == null || !sck.Connected)
                {
                    sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    await Task.Run(() => sck.Connect(new IPEndPoint(IPAddress.Parse("10.10.21.116"), 25000)));

                    // 연결 성공 후 비동기적으로 데이터 수신
                    Task.Run(() => ReceiveData());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect: {ex.Message}");
            }
        }


        private async Task ReceiveData()
        {
            while (true)
            {
                try
                {
                    byte[] sizeBuf = new byte[25000000];
                    int bytesRead = await ReceiveAsync(sck, sizeBuf, SocketFlags.None);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    int size = BitConverter.ToInt32(sizeBuf, 0);
                    byte[] buffer = new byte[size];

                    bytesRead = await ReceiveAsync(sck, buffer, SocketFlags.None);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string receivedText = Encoding.UTF8.GetString(buffer);

                    if (receivedText.Contains("☆"))
                    {
                        string[] parts = receivedText.Split('☆');

                        if (parts[1] == "connect")
                        {
                            await Task.Run(() =>
                            {
                                // UI 스레드에서 실행되도록 Invoke 사용
                                this.Invoke((MethodInvoker)delegate
                                {
                                    // MessageBox.Show($"{parts[1]}");
                                    Form2 form2 = new Form2(this);
                                    form2.Show();
                                    this.Hide();
                                });
                            });
                        }
                        else if (parts[1] == "browse")
                        {
                            await Task.Run(() =>
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    Form2.OpenVideo(parts[2]);
                                });
                                
                            });
                        }
                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            MessageBox.Show("수신된 텍스트에 구분자 '☆'가 없습니다.");
                        });
                    }

                    Invoke((MethodInvoker)delegate
                    {
                        Console.WriteLine($"Received: {receivedText}{Environment.NewLine}");
                    });
                }
                catch (Exception ex)
                {
                    await Task.Run(() =>
                    {
                        MessageBox.Show($"Error receiving data: {ex.Message}");
                    });
                    break;
                }
            }
        }


        private async Task<int> ReceiveAsync(Socket sck, byte[] buffer, SocketFlags socketFlags)
        {
            var tcs = new TaskCompletionSource<int>();

            EventHandler<SocketAsyncEventArgs> completedHandler = null;
            completedHandler = (sender, args) =>
            {
                args.Completed -= completedHandler;
                tcs.SetResult(args.BytesTransferred);
            };

            var socketArgs = new SocketAsyncEventArgs();
            socketArgs.SetBuffer(buffer, 0, buffer.Length);
            socketArgs.SocketFlags = socketFlags;
            socketArgs.Completed += completedHandler;

            if (!sck.ReceiveAsync(socketArgs))
            {
                // 동기적으로 완료됨
                tcs.SetResult(socketArgs.BytesTransferred);
            }

            return await tcs.Task;
        }

        // 프로그램 종료 관련 (필요 시 수정 필요)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
