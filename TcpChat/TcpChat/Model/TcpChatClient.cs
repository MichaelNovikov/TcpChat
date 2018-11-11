using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpChat.Model
{
    public class TcpChatClient
    {
        TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public Action<string> ReceivedMessageEvent;

        private  void Listen()
        {
             Task.Run(() =>
            {
                while (true)
                {                
                    if (_client.Connected && _client.GetStream().DataAvailable)
                    {
                        var text = _reader.ReadLine();
                        if (text == "278_01close")
                            _client.Close();
                        else
                            ReceivedMessageEvent(text);
                    }
                }
            });
        }

        public void SendMessage(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public void StartClient(string name)
        {
            Task.Run(() =>
            {
                _client = new TcpClient();
                _client.Connect("192.168.56.1", 1777);

                var stream = _client.GetStream();
                _reader = new StreamReader(stream);
                _writer = new StreamWriter(stream);
                _writer.WriteLine(name);
                _writer.Flush();

            });
            Listen();
        }
    }
}
