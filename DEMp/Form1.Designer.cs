namespace DEMp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开散点文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分层设色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.散点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三维显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地貌渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坡度提取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坡向提取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载地形数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载贴图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.渲染ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.打开散点文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.打开文件ToolStripMenuItem.Text = "打开规则格网文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 打开散点文件ToolStripMenuItem
            // 
            this.打开散点文件ToolStripMenuItem.Name = "打开散点文件ToolStripMenuItem";
            this.打开散点文件ToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.打开散点文件ToolStripMenuItem.Text = "打开散点文件";
            this.打开散点文件ToolStripMenuItem.Click += new System.EventHandler(this.打开散点文件ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.二维显示ToolStripMenuItem,
            this.三维显示ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // 二维显示ToolStripMenuItem
            // 
            this.二维显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.灰度ToolStripMenuItem,
            this.分层设色ToolStripMenuItem,
            this.散点ToolStripMenuItem});
            this.二维显示ToolStripMenuItem.Name = "二维显示ToolStripMenuItem";
            this.二维显示ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.二维显示ToolStripMenuItem.Text = "二维显示";
            // 
            // 灰度ToolStripMenuItem
            // 
            this.灰度ToolStripMenuItem.Name = "灰度ToolStripMenuItem";
            this.灰度ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.灰度ToolStripMenuItem.Text = "灰度";
            this.灰度ToolStripMenuItem.Click += new System.EventHandler(this.灰度ToolStripMenuItem_Click);
            // 
            // 分层设色ToolStripMenuItem
            // 
            this.分层设色ToolStripMenuItem.Name = "分层设色ToolStripMenuItem";
            this.分层设色ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.分层设色ToolStripMenuItem.Text = "分层设色";
            this.分层设色ToolStripMenuItem.Click += new System.EventHandler(this.分层设色ToolStripMenuItem_Click);
            // 
            // 散点ToolStripMenuItem
            // 
            this.散点ToolStripMenuItem.Name = "散点ToolStripMenuItem";
            this.散点ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.散点ToolStripMenuItem.Text = "散点";
            this.散点ToolStripMenuItem.Click += new System.EventHandler(this.散点ToolStripMenuItem_Click);
            // 
            // 三维显示ToolStripMenuItem
            // 
            this.三维显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.加载地形数据ToolStripMenuItem,
            this.加载贴图ToolStripMenuItem});
            this.三维显示ToolStripMenuItem.Name = "三维显示ToolStripMenuItem";
            this.三维显示ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.三维显示ToolStripMenuItem.Text = "三维显示";
            // 
            // 渲染ToolStripMenuItem
            // 
            this.渲染ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地貌渲染ToolStripMenuItem,
            this.坡度提取ToolStripMenuItem,
            this.坡向提取ToolStripMenuItem});
            this.渲染ToolStripMenuItem.Name = "渲染ToolStripMenuItem";
            this.渲染ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.渲染ToolStripMenuItem.Text = "渲染";
            // 
            // 地貌渲染ToolStripMenuItem
            // 
            this.地貌渲染ToolStripMenuItem.Name = "地貌渲染ToolStripMenuItem";
            this.地貌渲染ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.地貌渲染ToolStripMenuItem.Text = "地貌渲染";
            this.地貌渲染ToolStripMenuItem.Click += new System.EventHandler(this.地貌渲染ToolStripMenuItem_Click);
            // 
            // 坡度提取ToolStripMenuItem
            // 
            this.坡度提取ToolStripMenuItem.Name = "坡度提取ToolStripMenuItem";
            this.坡度提取ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.坡度提取ToolStripMenuItem.Text = "坡度提取";
            this.坡度提取ToolStripMenuItem.Click += new System.EventHandler(this.坡度提取ToolStripMenuItem_Click);
            // 
            // 坡向提取ToolStripMenuItem
            // 
            this.坡向提取ToolStripMenuItem.Name = "坡向提取ToolStripMenuItem";
            this.坡向提取ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.坡向提取ToolStripMenuItem.Text = "坡向提取";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1482, 1009);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 加载地形数据ToolStripMenuItem
            // 
            this.加载地形数据ToolStripMenuItem.Name = "加载地形数据ToolStripMenuItem";
            this.加载地形数据ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.加载地形数据ToolStripMenuItem.Text = "加载地形数据";
            this.加载地形数据ToolStripMenuItem.Click += new System.EventHandler(this.加载地形数据ToolStripMenuItem_Click);
            // 
            // 加载贴图ToolStripMenuItem
            // 
            this.加载贴图ToolStripMenuItem.Name = "加载贴图ToolStripMenuItem";
            this.加载贴图ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.加载贴图ToolStripMenuItem.Text = "加载贴图";
            this.加载贴图ToolStripMenuItem.Click += new System.EventHandler(this.加载贴图ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 1037);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 二维显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三维显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分层设色ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地貌渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坡度提取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坡向提取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开散点文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 散点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载地形数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载贴图ToolStripMenuItem;
      
    }
}

