using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace feiqqq
{
    public partial class FrmChat : Form
    {
        public bool isOpen=false;
        private Friend chatFriend;
        public Friend ChatFriend
        {
            get { return chatFriend; }
            set
            {
                chatFriend = value;
                this.Text ="与" +value.Nickname+"聊天中" ;
                
            }
        }
        public FrmChat()
        {
            InitializeComponent();
        }
        public FrmChat(Friend f)
        {
            InitializeComponent();
            this.ChatFriend=f;
        }
        private void FrmChat_Load(object sender, EventArgs e)
        {
            //Friend friend=new Friend();
           
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.chatFriend.IsOpen = false;
          
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UdpClient uc = new UdpClient();
            string msg = "MSG|" + this.txtSendContent.Text + "|傻逼杰";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(ChatFriend.IP, 9527);
            uc.Send(bmsg, bmsg.Length, ipep);
        }


        
    }
}
