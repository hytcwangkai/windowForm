using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace feiqqq
{
    public class Operation
    {
        public delegate void delAddFriend(Friend friend);
        public delegate void openChat(Friend friend,string msg); 
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
                        friend.IP = ipep.Address;
                        friend.IsOpen = false;
                        IPAddress myIp = Operation.getMyip();
                        if (myIp.ToString() != friend.IP.ToString())
                        {
                            _frm.Invoke(new delAddFriend(_frm.addUcf), friend);

                            //回发，告诉对方我也在

                            UdpClient onuc = new UdpClient();
                            string myName = "王凯";
                            string onmsg = "ALSOON|" + myName + "|13|大家好";
                            byte[] onbmsg = Encoding.Default.GetBytes(onmsg);
                            onuc.Send(onbmsg, onbmsg.Length, new IPEndPoint(ipep.Address, 9527));
                        }
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
                        onfriend.IP = ipep.Address;
                        _frm.Invoke(new delAddFriend(_frm.addUcf), onfriend);
                        break;
                    case "LOGOUT":
                        Panel pnlst = _frm.getPanl();
                        int deleIndex = 0;
                        //根据当前下线人的ip地址，找到pn中对应的用户控件，删除；
                        foreach (UCFriend ltUcf in pnlst.Controls)
                        {
                            if (ltUcf.CurFriend.IP.ToString() == ipep.Address.ToString()) 
                            {
                                pnlst.Controls.Remove(ltUcf);
                                break;
                            }
                            deleIndex++;
                        }
                        //让其下面的每一个用户控件对象依次上移
                        for (int i = deleIndex; i < pnlst.Controls.Count; i++)
                        {
                            pnlst.Controls[i].Top = i * pnlst.Controls[0].Height;
                        }
                        break;
                    case "MSG":
                        if (datas.Length != 3)
                        {
                            continue;
                        }
                        foreach (Friend olucf  in _frm.onlineFriends)
                        {
                            if(ipep.Address.ToString()==olucf.IP.ToString())
                            {
                                if (olucf.IsOpen == true)
                                {
                                    olucf.Frmchatting.txtChattingContent.AppendText(datas[2] + ":" + datas[1]+"\r\n");
                                }
                                if(olucf.IsOpen==false)
                                {
                                    object[] openPars = new object[2];
                                    openPars[0] = olucf;
                                    openPars[1] = datas[1];
                                    _frm.Invoke(new openChat(_frm.openChat),openPars);
                                 }
                                break;
                            }
                           
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
