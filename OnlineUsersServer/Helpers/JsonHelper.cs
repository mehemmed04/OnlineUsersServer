using Newtonsoft.Json;
using OnlineUsersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUsersServer.Helpers
{
    public class JsonHelper
    {
        public static Message GetMessageFromString(string str)
        {
            var msg = JsonConvert.DeserializeObject<Message>(str);
            return msg;
        }
    }
}
