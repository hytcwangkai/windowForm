using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace feiqqq
{
    public partial class Form1 : Form
    {
        public delegate void delAddFriend(Friend friend); 
        public Form1()
        {
            InitializeComponent();
        }

        private void listen() {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                string msg = Encoding.Default.GetString(bmsg);
                string[] datas = msg.Split('|');
                if (datas.Length != 4)
                {
                    continue;
                }
                if (datas[0] == "LOGIN") 
                {
                    Friend friend = new Friend();
                    int curIndex = Convert.ToInt32(datas[2]);
                    if (curIndex < 0 || curIndex >= this.ilHeaderImage.Images.Count)
                    {
                        curIndex = 0;
                    }
                    friend.HeaderImageIndex = curIndex;
                    friend.Nickname = datas[1];
                    friend.ShuoShuo = datas[3];
                    delAddFriend delfriend = new delAddFriend(addUcf);
                    this.plFriendsList.Invoke(delfriend,friend);
                    
                }
                              
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            //侦听
            Thread th = new Thread(new ThreadStart(listen));
            Thread.Sleep(100);
            th.Start();
            th.IsBackground = true;
            //发广播
            UdpClient uc = new UdpClient();
            string msg = "LOGIN|都比|12|大家好";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            uc.Send(bmsg,bmsg.Length,new IPEndPoint(IPAddress.Parse("255.255.255.255"),9527));
        }
        public void addUcf(Friend f) 
        {
            UCFriend ucf = new UCFriend();
            ucf.Top = this.plFriendsList.Controls.Count * ucf.Height;
            ucf.CurFriend = f;
            this.plFriendsList.Controls.Add(ucf);
        }
    }
}
