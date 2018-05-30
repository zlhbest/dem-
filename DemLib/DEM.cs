using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace DemLib
{
    public class DEM
    {

        #region 私有字段
        /// <summary>
        /// 行数
        /// </summary>
        private double mRowsNum;
        private double mColsNum;//列数
        private double Xmin;//x的最小值
        private double Xmax;//x的最大值
        private double Ymin;//Y的最小值
        private double Ymax;//Y的最大值
        private double Zmin;//Z的最小值
        private double Zmax;//Z的最大值
        private double[,] mElementData;//用来存点的
        private int cellsize; //有个栅格的大小
        /// <summary>
        /// 色带类
        /// </summary>
        private Ribbon mRibbon = null;
        /// <summary>
        /// 定义的色带分层数
        /// </summary>
        private int COLOR_NUM = 20;
        /// <summary>
        /// 用来存储不规则格网
        /// </summary>
        private List<point> mIrregularGridPoints = new List<point>();
        #endregion

        public double RowsNum
        {
            get
            {
                return this.mRowsNum;
            }
        }

        public double ColsNum
        {
            get
            {
                return this.mColsNum;
            }
        }

        public int Cellsize
        {
            get
            {
                return this.cellsize;
            }
        }

        public double[,] ElementData
        {
            get
            {
                return this.mElementData;
            }
        }

        public List<point> IrregularGridPoints
        {
            get
            {
                return this.mIrregularGridPoints;
            }
        }
        /// <summary>
        /// 根据文件进行初始化Dem对象，规则格网数据的读取
        /// </summary>
        /// <param name="filePath"></param>
        public void InitializeByGridFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string text = streamReader.ReadLine();
            if ((text = streamReader.ReadLine()) != null)
            {
                ReadRowCol(text);
            }
            this.mElementData = new double[(int)this.mRowsNum, (int)this.mColsNum];//创建好矩阵
            this.cellsize = (int)(1001.0 / this.mColsNum);//将对象单元的方块写出来
            if ((text = streamReader.ReadLine()) != null)
            {
                this.Xmin = Double.Parse(text.Split(' ')[0]);
                this.Xmax = Double.Parse(text.Split(' ')[1]);
            }
            if ((text = streamReader.ReadLine()) != null)
            {
                this.Ymin = Double.Parse(text.Split(' ')[0]);
                this.Ymax = Double.Parse(text.Split(' ')[1]);
            }
            if ((text = streamReader.ReadLine()) != null)
            {
                this.Zmin = Double.Parse(text.Split(' ')[0]);
                this.Zmax = Double.Parse(text.Split(' ')[1]);
            }
            int num = 0;
            int num2 = 0;
            int length = this.mElementData.GetLength(1);
            while ((text = streamReader.ReadLine()) != null)
            {
                if (num2 < length)
                {
                    for (int i = 0; i < text.Split(' ').Length; i++)
                    {
                        this.mElementData[num, num2] = Double.Parse(text.Split(' ')[i]);
                        num2++;
                    }
                }
                else
                {
                    num2 = 0;
                    num++;
                }
            }
        }
        /// <summary>
        /// 根据文件进行初始化Dem对象，不规则离散数据的读取
        /// </summary>
        /// <param name="filePath"></param>
        public void InitializeByIrregularFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string text;
            while ((text = streamReader.ReadLine()) != null)
            {
                ReadPoints(text);
            }
            
        }
        private void ReadPoints(string readLine)
        {
            point mpoint = new point();
            mpoint.x = Convert.ToDouble(readLine.Split(' ')[0]);
            mpoint.y = Convert.ToDouble(readLine.Split(' ')[1]);
            mpoint.z = Convert.ToDouble(readLine.Split(' ')[2]);
            this.mIrregularGridPoints.Add(mpoint);
        }

        private void ReadRowCol(string readLine)
        {
            this.mRowsNum = Double.Parse(readLine.Split(' ')[0]);
            this.mColsNum = Double.Parse(readLine.Split(' ')[1]);
        }

        /// <summary>
        /// 灰度显示
        /// </summary>
        /// <param name="graphics">需要绘制的载体</param>
        public Image GaryShow()
        {
            Image image = new Bitmap((int)(this.mColsNum * (double)this.Cellsize), (int)(this.mRowsNum * (double)this.cellsize));
            Graphics graphics = Graphics.FromImage(image);
            double pHeightRange = this.Zmax - this.Zmin;
            SolidBrush pBrush = null;
            for (int rowIndex = 0; rowIndex < this.mRowsNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.mColsNum; colIndex++)
                {
                    double pRelateHeight = this.mElementData[rowIndex, colIndex] - this.Zmin;
                    double pCellValue = pRelateHeight * 255.0 / pHeightRange;
                    Rectangle rect = new Rectangle(colIndex * cellsize, rowIndex * cellsize, cellsize, cellsize);//定义一个方形的大小
                    if (pCellValue > 255.0)
                    {
                        pCellValue = 255.0;
                    }
                    else if (pCellValue < 0.0)
                    {
                        pCellValue = 0.0;
                    }
                    pBrush = new SolidBrush(Color.FromArgb(255 - (int)pCellValue, Color.Black));
                    graphics.FillRectangle(pBrush, rect);
                }
            }
            return image;
        }

        /// <summary>
        /// 分层设色渲染
        /// </summary>
        /// <returns></returns>
        public Image LayeredColor()
        {
            RibbonWin mRibbonWin = new RibbonWin();
            if (mRibbonWin.ShowDialog() == DialogResult.OK)
            {
                this.COLOR_NUM = mRibbonWin.getRibbon();
            }

            Image image = new Bitmap((int)(this.mColsNum * (double)this.Cellsize), (int)(this.mRowsNum * (double)this.cellsize));
            Graphics graphics = Graphics.FromImage(image);
            double pHeightRange = Zmax - Zmin;//将dem的高差差值计算出来
            double[] array = new double[COLOR_NUM];//用来存储分层后的dem的z值
            int pAverageHeightRange = Convert.ToInt32(pHeightRange / COLOR_NUM);//存储z值得分层区间
            for (int i = 1; i <= array.Length; i++)
            {
                array[i - 1] = Zmin + (double)(i * pAverageHeightRange);//分层设色所用
            }
            SolidBrush pBrush = null;
            for (int rowIndex = 0; rowIndex < mRowsNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < mColsNum; colIndex++)
                {
                    Rectangle rect = new Rectangle(colIndex * cellsize, rowIndex * cellsize, cellsize, cellsize);//定义一个方形的大小
                    double pRelateHeight = this.mElementData[rowIndex, colIndex] - this.Zmin;
                    pBrush = new SolidBrush(FindColor_DEM(pRelateHeight, array));
                    graphics.FillRectangle(pBrush, rect);
                }
            }
            return image;
        }

        private Color FindColor_DEM(double depthValue, double[] HeightArray)
        {
            mRibbon = new Ribbon(COLOR_NUM);
            if (depthValue == this.Zmin)
            {
                return mRibbon.GetColor(0);
            }
            for (int i = 0; i < HeightArray.Length; i++)
            {
                if (depthValue <= HeightArray[i])
                {
                    return mRibbon.GetColor(i + 1);
                }
            }
            return Color.White;
        }

    }
}
