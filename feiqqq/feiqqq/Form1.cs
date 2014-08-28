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
       public Panel getPanl()
       {
           return this.plFriendsList;
       }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress myIp = Operation.getMyip();
            if (myIp == null)
            {
                MessageBox.Show("对不起，网络连接失败，请检查网络连接");
                Application.Exit();
            }
            Form1.CheckForIllegalCrossThreadCalls = false;
            Operation ope = new Operation(this);
            //侦听
            Thread th = new Thread(new ThreadStart(ope.listen));
           
            th.Start();
            Thread.Sleep(100);
            th.IsBackground = true;
            //发广播
            UdpClient uc = new UdpClient();
            string myName = myIp.ToString();
            string msg = "LOGIN|"+myName+"|13|大家好";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            uc.Send(bmsg,bmsg.Length,new IPEndPoint(IPAddress.Parse("255.255.255.255"),9527));
        }
        public void addUcf(Friend f) 
        {
            UCFriend ucf = new UCFriend();
            ucf.Frm = this;
            ucf.CurFriend = f;
            ucf.Top = this.plFriendsList.Controls.Count * ucf.Height;
           ucf.myDBClick += ucf_myDBClick;
            this.plFriendsList.Controls.Add(ucf);
        }
        void ucf_myDBClick(object sender, EventArgs e) 
        {
            UCFriend ucf = (UCFriend)sender;
            if (ucf.CurFriend.IsOpen == false)
            {
                FrmChat frm = new FrmChat(ucf.CurFriend);
                frm.Show();
                ucf.CurFriend.IsOpen = true;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UdpClient closeUcf = new UdpClient();
            string clMsg = "LOGOUT";
            byte[] clbmsg = Encoding.Default.GetBytes(clMsg);
            closeUcf .Send(clbmsg, clbmsg .Length, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527));
        }
    }
}
