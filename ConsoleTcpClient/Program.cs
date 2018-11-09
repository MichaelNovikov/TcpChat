using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTcpClient
{
    class Program
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        private async Task Listen()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (_client.Connected && _client.GetStream().DataAvailable)
                    {
                        var text = _reader.ReadLine();
                        Console.WriteLine(text);
                    }
                }
            });
        }

        private void StartClient()
        {
            Random random = new Random();

            _client = new TcpClient();
            _client.Connect("localhost", 50);
            var stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream);

            var name = "Alex";
            _writer.WriteLine(name);
            _writer.Flush();


            Listen();

            while (true)
            {
                var str = Console.ReadLine();
                _writer.WriteLine(str);
                _writer.Flush();
            }
        }

        static void Main(string[] args)
        {
            new Program().StartClient();
        }
    }
}
