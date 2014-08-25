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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip=this.Iptext.Text;
            UdpClient uc = new UdpClient();
            string msg ="PUBLIC|"+ this.msg.Text+"|傻逼杰";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip),9527);
            uc.Send(bmsg,bmsg.Length,ipep);

        }
        private void listen() {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] bmsg = uc.Receive(ref ipep);
                string msg = Encoding.Default.GetString(bmsg);
                string[] str = msg.Split('|');

                if (str[0] == "PUBLIC" && str.Count()>=3)
                {
                    this.txtHistory.AppendText(str[2] + ":" + str[1]+"\r\n");
                }
                else if (str[0] == "INROOM" && str.Count()>=2)
                {
                    this.txtHistory.AppendText(str[1] + "上线了！！！\r\n");
                }
                else 
                {
                    this.txtHistory.AppendText("有人发乱码了！！！\r\n");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;   
            Thread th = new Thread(new ThreadStart(listen));
            th.Start();
            th.IsBackground = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ip = this.Iptext.Text;
            UdpClient uc = new UdpClient();
            string msg = "INROOM|傻逼杰";
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            uc.Send(bmsg, bmsg.Length, ipep);
        }
    }
}
