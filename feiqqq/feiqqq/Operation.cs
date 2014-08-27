using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace feiqqq
{
    public class Operation
    {
        public delegate void delAddFriend(Friend friend); 
        private Form1 _frm;
        public Operation(Form1 frm)
        {
            _frm = frm;
        }
        public static IPAddress getMyip()
        {
            IPAddress[] ips = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            foreach(IPAddress ip in ips )
            {
                if (ip.AddressFamily.ToString() == "InterNetwork") 
                {
                    return ip;
                }
               
            }
            return null;
        }

        public void listen()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                string msg = Encoding.Default.GetString(bmsg);
                string[] datas = msg.Split('|');
                string messageHead = datas[0];
                switch (messageHead)
                {
                    case "LOGIN":
                        if (datas.Length != 4)
                    {
                        continue;
                    }
                    Friend friend = new Friend();
                    int curIndex = Convert.ToInt32(datas[2]);
                    if (curIndex < 0 || curIndex >= _frm.ilHeaderImage.Images.Count)
                    {
                        curIndex = 0;
                    }
                    friend.HeaderImageIndex = curIndex;
                    friend.Nickname = datas[1];
                    friend.ShuoShuo = datas[3];
                    _frm.Invoke(new delAddFriend(_frm.addUcf), friend);
                    //回发，告诉对方我也在
                     IPAddress myIp = Operation.getMyip();
                     UdpClient onuc = new UdpClient();
                     string myName =myIp.ToString() ;
                     string onmsg = "ALSOON|"+myName+"|13|大家好";
                     byte[] onbmsg = Encoding.Default.GetBytes(msg);
                     onuc.Send(onbmsg, onbmsg.Length, new IPEndPoint(ipep.Address, 9527));
                    break;
                       
                    case "ALSOON":
                    if (datas.Length != 4)
                    {
                        continue;
                    }
                    Friend onfriend = new Friend();
                    int oncurIndex = Convert.ToInt32(datas[2]);
                    if (oncurIndex < 0 || oncurIndex >= _frm.ilHeaderImage.Images.Count)
                    {
                        oncurIndex = 0;
                    }
                    onfriend.HeaderImageIndex = oncurIndex;
                    onfriend.Nickname = datas[1];
                    onfriend.ShuoShuo = datas[3];
                    _frm.Invoke(new delAddFriend(_frm.addUcf), onfriend);
                    break;
                    default:
                        break;
                }
            }
        }
    }
}
