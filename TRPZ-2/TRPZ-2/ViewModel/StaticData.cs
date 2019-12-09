using ModelsForWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ_2.ViewModel
{
    static class StaticData
    {
        public static User CurUser { get; set; }
        public static IPEndPoint MyAddress { get; set; }
        public static Task bc;
    }
}
