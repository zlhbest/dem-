using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemLib
{
    class CreateTin
    {
        #region 私有字段
        /// <summary>
        /// X的最大值
        /// </summary>
        private double mXmax;
        /// <summary>
        /// X的最小值
        /// </summary>
        private double mXmin;
        /// <summary>
        /// Y的最大值
        /// </summary>
        private double mYmax;
        /// <summary>
        /// Y的最小值
        /// </summary>
        private double mYmin;
        /// <summary>
        /// 存放TIN数据的所有点数
        /// </summary>
        private vector[] mTinPoints;
        /// <summary>
        /// 存储所有的三角形
        /// </summary>
        private triangle[] mTintriangle;
        /// <summary>
        /// 创建TIN图幅的宽
        /// </summary>
        private double mWid;
        /// <summary>
        /// 创建TIN图幅的高
        /// </summary>
        private double mHig;
        #endregion

        #region 属性
        /// <summary>
        /// 取出所有的点数据
        /// </summary>
        public vector[] TinPoints
        {
            get
            {
                return this.mTinPoints;
            }
        }

        public double Xmax
        {
            get
            {
                return this.mXmax;
            }
        }
        public double Xmin
        {
            get
            {
                return this.mXmin;
            }
        }
        public double Ymax
        {
            get
            {
                return this.mYmax;
            }
        }
        public double Ymin
        {
            get
            {
                return this.mYmin;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tinPoints">点数</param>
        public CreateTin(vector[] tinPoints)
        {
            this.mTinPoints = tinPoints;
        }
        /// <summary>
        /// 找到最大值和最小值
        /// </summary>
        /// <param name="tinPoints">TIN的点数组</param>
        public void GetPointsRange(vector[] tinPoints)
        {
            for (int i = 0; i < tinPoints.Length; i++)
            {
                if (i == 0)
                {
                    this.mXmax = tinPoints[i].X;
                    this.mXmin = tinPoints[i].X;
                    this.mYmax = tinPoints[i].Y;
                    this.mYmin = tinPoints[i].Y;
                }
                else
                {
                    if (mXmax < tinPoints[i].X)
                        mXmax = tinPoints[i].X;
                    if (mYmax < tinPoints[i].Y)
                        mYmax = tinPoints[i].Y;
                    if (mXmin > tinPoints[i].X)
                        mXmin = tinPoints[i].X;
                    if (mYmin > tinPoints[i].Y)
                        mYmin = tinPoints[i].Y;
                }
            }
            mWid = (int)(10 * (mYmax - mYmin + 10));
            mHig = (int)(10 * (mXmax - mXmin + 10));
        }

        public void CreatTintri(vector[] tinPoints)
        {
            GetPointsRange(tinPoints);
//三角网生长算法步骤：（过程如图2）
//（1）       在所采集的离散点中任意找一点，然后查找距此点最近的点，连接后作为初始基线。
//（2）       在初始基线右侧运用Delaunay法则搜寻第三点，具体的做法是：在初始基线右侧的离散点中查找距此基线距离最短的点，做为第三点。
//（3）       生成Delaunay三角形，再以三角形的两条新边（从基线起始点到第三点以及第三点到基线终止点）作为新的基线。
//（4）       重复步骤（2），（3）直至所有的基线处理完毕。

        }
        #endregion
    }
}
