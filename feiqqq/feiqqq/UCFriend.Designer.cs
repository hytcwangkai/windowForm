namespace feiqqq
{
    partial class UCFriend
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFriend));
            this.picHeaderImage = new System.Windows.Forms.PictureBox();
            this.lbNikeName = new System.Windows.Forms.Label();
            this.lbShuoShuo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeaderImage
            // 
            this.picHeaderImage.Image = ((System.Drawing.Image)(resources.GetObject("picHeaderImage.Image")));
            this.picHeaderImage.Location = new System.Drawing.Point(3, 3);
            this.picHeaderImage.Name = "picHeaderImage";
            this.picHeaderImage.Size = new System.Drawing.Size(60, 60);
            this.picHeaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeaderImage.TabIndex = 0;
            this.picHeaderImage.TabStop = false;
            // 
            // lbNikeName
            // 
            this.lbNikeName.AutoSize = true;
            this.lbNikeName.Location = new System.Drawing.Point(69, 13);
            this.lbNikeName.Name = "lbNikeName";
            this.lbNikeName.Size = new System.Drawing.Size(41, 12);
            this.lbNikeName.TabIndex = 1;
            this.lbNikeName.Text = "label1";
            // 
            // lbShuoShuo
            // 
            this.lbShuoShuo.AutoSize = true;
            this.lbShuoShuo.Location = new System.Drawing.Point(69, 40);
            this.lbShuoShuo.Name = "lbShuoShuo";
            this.lbShuoShuo.Size = new System.Drawing.Size(41, 12);
            this.lbShuoShuo.TabIndex = 2;
            this.lbShuoShuo.Text = "label2";
            // 
            // UCFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbShuoShuo);
            this.Controls.Add(this.lbNikeName);
            this.Controls.Add(this.picHeaderImage);
            this.Name = "UCFriend";
            this.Size = new System.Drawing.Size(300, 66);
            this.Load += new System.EventHandler(this.UCFriend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeaderImage;
        private System.Windows.Forms.Label lbNikeName;
        private System.Windows.Forms.Label lbShuoShuo;
    }
}
