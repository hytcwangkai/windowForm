using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        
        private void FrmChat_Load(object sender, EventArgs e)
        {
            //Friend friend=new Friend();
           
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.chatFriend.IsOpen = false;
        }

        
    }
}
