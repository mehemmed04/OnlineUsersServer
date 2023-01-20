using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUsersServer.Models
{
    public class Message
    {
        public TcpClient Client { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }

    }
}
