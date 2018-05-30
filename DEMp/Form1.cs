using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DemLib;

namespace DEMp
{
    public partial class Form1 : Form
    {
        #region 私有字段

        Bitmap image = null;
        DEM dem = new DEM();
        /// <summary>
        /// 显示方式
        /// </summary>
        vector[,] vec = null;//这是网格的法向量
        //rayvector vo = new rayvector();
        Geomorphicvertigo Gp = new Geomorphicvertigo();
        static Form form = new Form
        {
            Width = 800,
            Height = 600
        };
        static MyGLControl mc = new MyGLControl();
        #endregion

        #region 构造函数
        public Form1()
        {
            InitializeComponent();
        }
        #endregion


        #region 窗体事件

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt|(*.grd)|*.grd|(*.*)|*.*";//允许文件打开的格式
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dem.InitializeByGridFile(openFileDialog.FileName);
                    MessageBox.Show("读取完毕", "提示");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎学习DEM");
        }

        private void 灰度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox1.Image = dem.GaryShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先输入数据" + ex);
            }
        }

        private void 分层设色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox1.Image = dem.LayeredColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入数据" + ex);
            }
        }


        #endregion

        private void 地貌渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                image = new Bitmap((int)(this.dem.ColsNum * (double)this.dem.Cellsize), (int)(this.dem.RowsNum * (double)this.dem.Cellsize));
                Graphics graphics = Graphics.FromImage(image);
                this.xuanranshow(graphics);
                this.pictureBox1.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入数据" + ex);
            }
        }

        private void xuanranshow(Graphics g)
        {
            try
            {
                vector pVector = new vector();
                SolidBrush brush = null;
                //this.vo.ShowDialog();
                rayvector pFrmRayVector = new rayvector();
                // 模态窗口
                if (pFrmRayVector.ShowDialog() == DialogResult.OK)
                {
                    pVector = pFrmRayVector.GetRayvector();
                }
                //用于存储网格向量
                vec = new vector[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                vec = Gp.brightness(dem.ElementData, dem.Cellsize, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum));
                //用于存储所有的角度
                double[,] anger = new double[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                anger = Gp.d_raytovector_angle_all(vec, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum),pVector);
                //用来存放所有的灰度值
                double[,] huidu = new double[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                huidu = Gp.i_cellvalue_hillshade(anger, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum));
                for (int i = 0; i < dem.ColsNum; i++)
                {
                    for (int j = 0; j < dem.RowsNum; j++)
                    {
                        Rectangle rect = new Rectangle(i * this.dem.Cellsize, j * this.dem.Cellsize, this.dem.Cellsize, this.dem.Cellsize);//定义一个方形的大小
                        brush = new SolidBrush(Color.FromArgb((int)huidu[i, j], Color.Black));
                        g.FillRectangle(brush, rect);
                    }

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数组为空");
            }
        }

        public void poduxianran(Graphics g)
        {
            try
            {
                //SolidBrush brush = null;
                ////用于存储网格向量
                //vec = new vector[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                //vec = Gp.brightness(dem.ElementData, dem.Cellsize, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum));
                ////用于存储所有的角度
                //double[,] anger = new double[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                //anger = Gp.d_raytovector_angle_all(vec, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum), rayvector.Rayvector);
                ////用来存放所有的灰度值
                //double[,] huidu = new double[Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum)];
                //huidu = Gp.i_cellvalue_hillshade(anger, Convert.ToInt32(dem.RowsNum), Convert.ToInt32(dem.ColsNum));
                //for (int i = 0; i < dem.ColsNum; i++)
                //{
                //    for (int j = 0; j < dem.RowsNum; j++)
                //    {
                //        Rectangle rect = new Rectangle(i * this.dem.Cellsize, j * this.dem.Cellsize, this.dem.Cellsize, this.dem.Cellsize);//定义一个方形的大小
                //        brush = new SolidBrush(Color.FromArgb((int)huidu[i, j], Color.Black));
                //        g.FillRectangle(brush, rect);
                //    }

                //}

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数组为空");
            }
        }

        private void 坡度提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                image = new Bitmap((int)(this.dem.ColsNum * (double)this.dem.Cellsize), (int)(this.dem.RowsNum * (double)this.dem.Cellsize));
                Graphics graphics = Graphics.FromImage(image);
                this.poduxianran(graphics);
                this.pictureBox1.Image = image;

            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入数据" + ex);
            }
        }

        private void 打开散点文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt|(*.grd)|*.grd|(*.*)|*.*";//允许文件打开的格式
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dem.InitializeByIrregularFile(openFileDialog.FileName);
                    MessageBox.Show("读取完毕", "提示");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 散点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Graphics mGraphics = this.pictureBox1.CreateGraphics();
            Image image = new Bitmap(1000,2400);
            mGraphics = Graphics.FromImage(image);
            foreach (point mpoint in dem.IrregularGridPoints)
            {
                mGraphics.DrawEllipse(new Pen(Color.Black,1),(int)mpoint.x, (int)mpoint.y, 1, 1);
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mc.Dock = DockStyle.Fill;
           mc.Margin = new Padding(8);
          
           form.Controls.Add(mc);
           form.Show();
        }

        private void 加载地形数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            mc.Dixing = true;
            mc.Tietu = false;
            mc.yes = false;
            
        }

        private void 加载贴图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mc.Dixing = true;
            mc.Tietu = true;
            mc.yes = false;
          
        }
    }
}
