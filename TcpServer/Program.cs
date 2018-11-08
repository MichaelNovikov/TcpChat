using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpServer
{
    class Program
    {
        private static ConcurrentDictionary<TcpClient, string> _clients = new ConcurrentDictionary<TcpClient, string>();
        private static TcpListener server = new TcpListener(new IPEndPoint(IPAddress.Any, 50));

        public void StartTcpListener()
        {
            server.Start();

            Listen();

            while (true)
            {
                var client = server.AcceptTcpClient();

                Task.Run(() =>
                {
                    var stream = client.GetStream();
                    var reader = new StreamReader(stream);

                    var name = "";

                    while (!stream.DataAvailable) { }
                    if (stream.DataAvailable)
                    {
                        name = reader.ReadLine();
                    }

                    while (!_clients.TryAdd(client, name)) { }
                    Console.WriteLine(name + " entered");
                    SendMessageToAll(name + " entered");
                });
            }
        }

        private async static void Listen()
        {
            await Task.Run(() =>
            {
                var flag = true;
                string rValue = "";
                TcpClient rKey = default(TcpClient);

                while (true)
                {
                    while (flag)
                    {
                        foreach (var item in _clients)
                        {
                            var stream = item.Key.GetStream();
                            var reader = new StreamReader(stream);
                            if (stream.DataAvailable)
                            {
                                var msg = reader.ReadLine();

                                if (msg == "278_01close")
                                {
                                    var writer = new StreamWriter(stream);
                                    writer.WriteLine(msg);
                                    writer.Flush();

                                    rKey = item.Key;
                                    rValue = item.Value;

                                    flag = false;
                                    break;
                                }
                                SendMessageToAll($"{item.Value}: {msg}");
                                Console.WriteLine($"{item.Value}: {msg}");
                            }
                        }
                    }
                    rKey.Close();
                    flag = _clients.TryRemove(rKey, out rValue);
                    var str = rValue + " left the chat";
                    SendMessageToAll(str);
                    Console.WriteLine(str);
                }
            });
        }

        private static void SendMessageToAll(string message)
        {
            foreach (var item in _clients)
            {
                var stream = item.Key.GetStream();
                var writer = new StreamWriter(stream);

                writer.WriteLine(message);
                writer.Flush();
            }
        }

        static void Main(string[] args)
        {
            new Program().StartTcpListener();
        }
    }
}
