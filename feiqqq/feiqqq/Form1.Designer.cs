namespace feiqqq
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.TextBox();
            this.Iptext = new System.Windows.Forms.TextBox();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.denglu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // msg
            // 
            this.msg.Location = new System.Drawing.Point(43, 318);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(347, 21);
            this.msg.TabIndex = 2;
            this.msg.Text = " ";
            // 
            // Iptext
            // 
            this.Iptext.Location = new System.Drawing.Point(43, 37);
            this.Iptext.Name = "Iptext";
            this.Iptext.Size = new System.Drawing.Size(346, 21);
            this.Iptext.TabIndex = 3;
            this.Iptext.Text = "192.168.1.15";
            // 
            // txtHistory
            // 
            this.txtHistory.Location = new System.Drawing.Point(43, 64);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.Size = new System.Drawing.Size(346, 235);
            this.txtHistory.TabIndex = 4;
            // 
            // denglu
            // 
            this.denglu.Location = new System.Drawing.Point(496, 316);
            this.denglu.Name = "denglu";
            this.denglu.Size = new System.Drawing.Size(75, 23);
            this.denglu.TabIndex = 5;
            this.denglu.Text = "登录";
            this.denglu.UseVisualStyleBackColor = true;
            this.denglu.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 399);
            this.Controls.Add(this.denglu);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.Iptext);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "聊天室";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.TextBox Iptext;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Button denglu;
    }
}

