using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace feiqqq
{
    public class Friend
    {
        public string Nickname 
        {
            get ; 
            set ;
        }
        public int HeaderImageIndex { get; set; }
        public string ShuoShuo { get; set; }
        public IPAddress IP { get; set; }
        public bool IsOpen { get; set; }
    }
}
