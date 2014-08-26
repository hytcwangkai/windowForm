using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace feiqqq
{
    public partial class UCFriend : UserControl
    {
        private Form1 frm;
        public Form1 Frm 
        {
            get { return frm; }
            set { frm = value; }
        }
        private Friend curFriend;
        public Friend CurFriend
        {
            get { return curFriend; }

            set 
            {
                curFriend=value;
                this.lbNikeName.Text = value.Nickname;
                this.lbShuoShuo.Text = value.ShuoShuo;
                this.picHeaderImage.Image=this.frm.ilHeaderImage.Images[value.HeaderImageIndex];
            }
        }
        public UCFriend()
        {
            InitializeComponent();
        }

        private void UCFriend_Load(object sender, EventArgs e)
        {

        }

    }
}
