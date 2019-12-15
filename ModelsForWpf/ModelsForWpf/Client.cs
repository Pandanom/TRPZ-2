using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]    
    public class UserIp
    {
        
        public User User { get; set; }
        public IPEndPoint Address { get; set; }
    }
}
