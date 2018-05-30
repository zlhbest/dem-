using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemLib
{

   public class Geomorphicvertigo
    {
        /// <summary>
        /// 计算三角形的法向量，按照顺时针进行计算
        /// </summary>
        /// <param name="tri">索要计算的法向量</param>
        /// <returns></returns>
        vector Normalvector(triangle tri)
        {
            vector vec1 = new vector();//P1P2
            vector vec2= new vector();//P1P3
            vector normal = new vector();//法向量
            //这是p1p2向量
            vec1.X=tri.P2.x-tri.P1.x;
            vec1.Y = tri.P2.y - tri.P1.y;
            vec1.Z = tri.P2.z - tri.P1.z;
            //这是p1p3向量
            vec2.X = tri.P3.x - tri.P1.x;
            vec2.Y = tri.P3.y - tri.P1.y;
            vec2.Z = tri.P3.z - tri.P1.z;
            //计算法向量
            normal.X = (vec1.Y * vec2.Z) - (vec1.Z * vec2.Y);
            normal.Y = (vec1.X * vec2.Z) - (vec1.Z * vec2.X);
            normal.Z = (vec1.X * vec2.Y) - (vec1.Y * vec2.X);
            //法向量单位化
            double ji = Math.Abs(normal.X * normal.X + normal.Y * normal.Y + normal.Z*normal.Z);
            double fenmu = Math.Sqrt(ji);
            normal.X = normal.X/fenmu;
            normal.Y = normal.Y/fenmu;
            normal.Z = normal.Z / fenmu;
            return normal;

        }
        //将每个方格的中心点向量化
        public vector[,] brightness(double[,] ElementData, int cellsize, int RowsNum, int ColsNum)
        {
             point[] pointa=null;
            triangle[] tri = new triangle[2];
            triangle[] tri1 = new triangle[4];
            triangle[] tri2 = new triangle[8];
            vector[,] vec = new vector[RowsNum, ColsNum];
            //当遍历时有九种可能
            //左下角的向量计算
            pointa = new point[4];
            int n = 0;
            for (int i = 0; i < 2;i++ )
            {
                for (int j = 0; j < 2; j++)
                {
                    pointa[n].x = 1 / 2 * cellsize + i * cellsize ;
                    pointa[n].y = 1 / 2 * cellsize +  j * cellsize;
                    pointa[n].z = ElementData[i,j];
                    n++;
                }
            }
           
            tri[0].P1 = pointa[0]; tri[0].P2 = pointa[3]; tri[0].P3 = pointa[1];
            tri[1].P1 = pointa[0]; tri[1].P2 = pointa[2]; tri[1].P3 = pointa[3];
            vec[0,0].X = jiaodian(tri).X;
            vec[0, 0].Y = jiaodian(tri).Y;
            vec[0, 0].Z = jiaodian(tri).Z;
            //左上角的向量计算
            n = 0;
            for (int i = 0; i <2; i++)
            {
                for (int j = RowsNum - 1; j > RowsNum - 3; j--)
                {
                    pointa[n].x = 1 / 2 * cellsize + i * cellsize ;
                    pointa[n].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[n].z = ElementData[i, j];
                    n++;
                }
            }
             tri[0].P1 = pointa[0]; tri[0].P2 = pointa[1]; tri[0].P3 = pointa[3];
            tri[1].P1 = pointa[0]; tri[1].P2 = pointa[3]; tri[1].P3 = pointa[2];
            vec[0, ColsNum-1].X = jiaodian( tri).X;
            vec[0, ColsNum - 1].Y = jiaodian(tri).Y;
            vec[0, ColsNum - 1].Z = jiaodian(tri).Z;
            //右上角的向量计算
            n = 0;
            for (int i = RowsNum - 1; i > RowsNum - 3; i--)
            {
                for (int j = RowsNum - 1; j > RowsNum - 3; j--)
                {
                    pointa[n].x = 1 / 2 * cellsize + i * cellsize;
                    pointa[n].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[n].z = ElementData[i, j];
                    n++;
                }
            }
            tri[0].P1 = pointa[0]; tri[0].P2 = pointa[1]; tri[0].P3 = pointa[3];
            tri[1].P1 = pointa[0]; tri[1].P2 = pointa[3]; tri[1].P3 = pointa[2];
            vec[RowsNum - 1, ColsNum - 1].X = jiaodian( tri).X;
            vec[RowsNum - 1, ColsNum - 1].Y = jiaodian(tri).Y;
            vec[RowsNum - 1, ColsNum - 1].Z = jiaodian(tri).Z;
            //右下角的向量计算
            n = 0;
            for (int i = RowsNum - 1; i > RowsNum - 3; i--)
            {
                for (int j = 0; j <2; j++)
                {
                    pointa[n].x = 1 / 2 * cellsize + i * cellsize;
                    pointa[n].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[n].z = ElementData[i, j];
                    n++;
                }
            }
            tri[0].P1 = pointa[0]; tri[0].P2 = pointa[3]; tri[0].P3 = pointa[1];
            tri[1].P1 = pointa[0]; tri[1].P2 = pointa[2]; tri[1].P3 = pointa[3];
            vec[RowsNum - 1, 0].X = jiaodian( tri).X;
            vec[RowsNum - 1, 0].Y = jiaodian(tri).Y;
            vec[RowsNum - 1, 0].Z = jiaodian(tri).Z;
            //y为0的一横行点
            pointa = new point[6];
            for (int i = 1; i < RowsNum -1; i++)
            {
                int m = 0;
                for (int j = 0; j < 2; j++)
                {
                    pointa[j + m].x = 1 / 2 * cellsize + i-1 * cellsize;
                    pointa[j + m].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[j + m].z = ElementData[i - 1, j];
                    pointa[j + 1 + m].x = 1 / 2 * cellsize + i * cellsize;
                    pointa[j + 1 + m].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[j + 1 + m].z = ElementData[i, j];
                    pointa[j + 2 + m].x = 1 / 2 * cellsize + i + 1 * cellsize;
                    pointa[j + 2 + m].y = 1 / 2 * cellsize + j * cellsize;
                    pointa[j + 2 + m].z = ElementData[i + 1, j];
                    m = 2;
                }
                tri1[0].P1 = pointa[1]; tri1[0].P2 = pointa[0]; tri1[0].P3 = pointa[3];
                tri1[1].P1 = pointa[1]; tri1[1].P2 = pointa[3]; tri1[1].P3 = pointa[4];
                tri1[2].P1 = pointa[1]; tri1[2].P2 = pointa[4]; tri1[2].P3 = pointa[5];
                tri1[3].P1 = pointa[1]; tri1[3].P2 = pointa[5]; tri1[3].P3 = pointa[2];
                vec[i, 0].X = hang( tri1).X;
                vec[i, 0].Y = hang(tri1).Y;
                vec[i, 0].Z = hang(tri1).Z;
            }
            //最上面一行
            for (int i = 1; i < RowsNum - 1; i++)
            {
                int m = 0;
                for (int j = 0; j < 2; j++)
                {
                    pointa[j + m].x = 1 / 2 * cellsize + i - 1 * cellsize;
                    pointa[j + m].y = 1 / 2 * cellsize + (j - m + ColsNum-1) * cellsize;
                    pointa[j + m].z = ElementData[i - 1, j];
                    pointa[j + 1 + m].x = 1 / 2 * cellsize + i * cellsize;
                    pointa[j + 1 + m].y = 1 / 2 * cellsize + (j - m + ColsNum-1) * cellsize;
                    pointa[j + 1 + m].z = ElementData[i, j];
                    pointa[j + 2 + m].x = 1 / 2 * cellsize + i + 1 * cellsize;
                    pointa[j + 2 + m].y = 1 / 2 * cellsize + (j - m + ColsNum-1) * cellsize;
                    pointa[j + 2 + m].z = ElementData[i + 1, (j - m + ColsNum-1)];
                    m = 2;
                }
                tri1[0].P1 = pointa[1]; tri1[0].P2 = pointa[3]; tri1[0].P3 = pointa[0];
                tri1[1].P1 = pointa[1]; tri1[1].P2 = pointa[4]; tri1[1].P3 = pointa[3];
                tri1[2].P1 = pointa[1]; tri1[2].P2 = pointa[5]; tri1[2].P3 = pointa[4];
                tri1[3].P1 = pointa[1]; tri1[3].P2 = pointa[2]; tri1[3].P3 = pointa[5];
                vec[i, ColsNum-1].X = hang(tri1).X;
                vec[i, ColsNum-1].Y = hang(tri1).Y;
                vec[i, ColsNum-1].Z = hang(tri1).Z;
            }
            //左侧一行
            for (int j = 1; j < ColsNum - 1; j++)
            {
                int m = 0;
                for (int i = 0; i < 2; i++)
                {
                    pointa[i + m].x = 1 / 2 * cellsize + j - 1 * cellsize;
                    pointa[i + m].y = 1 / 2 * cellsize + i * cellsize;
                    pointa[i + m].z = ElementData[j - 1, i];
                    pointa[i + 1 + m].x = 1 / 2 * cellsize + j * cellsize;
                    pointa[i + 1 + m].y = 1 / 2 * cellsize + i * cellsize;
                    pointa[i + 1 + m].z = ElementData[j, i];
                    pointa[i + 2 + m].x = 1 / 2 * cellsize + j + 1 * cellsize;
                    pointa[i + 2 + m].y = 1 / 2 * cellsize + i * cellsize;
                    pointa[i + 2 + m].z = ElementData[j + 1, i];
                    m = 2;
                }
                tri1[0].P1 = pointa[1]; tri1[0].P2 = pointa[2]; tri1[0].P3 = pointa[5];
                tri1[1].P1 = pointa[1]; tri1[1].P2 = pointa[5]; tri1[1].P3 = pointa[4];
                tri1[2].P1 = pointa[1]; tri1[2].P2 = pointa[4]; tri1[2].P3 = pointa[3];
                tri1[3].P1 = pointa[1]; tri1[3].P2 = pointa[3]; tri1[3].P3 = pointa[0];
                vec[0, j].X = hang( tri1).X;
                vec[0, j].Y = hang(tri1).Y;
                vec[0, j].Z = hang(tri1).Z;
            }
            //右边一行
            for (int j = 1; j < ColsNum - 1; j++)
            {
                int m = 0;
                for (int i = 0; i < 2; i++)
                {
                    pointa[i + m].x = 1 / 2 * cellsize + j - 1 * cellsize;
                    pointa[i + m].y = 1 / 2 * cellsize + (i - m + ColsNum-1) * cellsize;
                    pointa[i + m].z = ElementData[j - 1, i];
                    pointa[i + 1 + m].x = 1 / 2 * cellsize + j * cellsize;
                    pointa[i + 1 + m].y = 1 / 2 * cellsize + (i - m + ColsNum-1) * cellsize;
                    pointa[i + 1 + m].z = ElementData[j, i];
                    pointa[i + 2 + m].x = 1 / 2 * cellsize + j + 1 * cellsize;
                    pointa[i + 2 + m].y = 1 / 2 * cellsize + (i - m + ColsNum-1) * cellsize;
                    pointa[i + 2 + m].z = ElementData[i + 1, (i - m + ColsNum-1)];
                    m = 2;
                }
                tri1[0].P1 = pointa[1]; tri1[0].P2 = pointa[5]; tri1[0].P3 = pointa[2];
                tri1[1].P1 = pointa[1]; tri1[1].P2 = pointa[4]; tri1[1].P3 = pointa[5];
                tri1[2].P1 = pointa[1]; tri1[2].P2 = pointa[3]; tri1[2].P3 = pointa[4];
                tri1[3].P1 = pointa[1]; tri1[3].P2 = pointa[0]; tri1[3].P3 = pointa[3];
                vec[RowsNum-1, j].X = hang( tri1).X;
                vec[RowsNum-1, j].Y = hang(tri1).Y;
                vec[RowsNum-1, j].Z = hang(tri1).Z;
            }
            //普通点
            pointa = new point[9];
            for (int i = 1; i < RowsNum - 1; i++)
            {
                for (int j = 1; j < ColsNum - 1; j++)
                {
                    int q = 0;
                        pointa[q].x = 1 / 2 * cellsize + i - 1 * cellsize;
                        pointa[q].y = 1 / 2 * cellsize + j - 1 * cellsize;
                        pointa[q].z = ElementData[i-1, j-1];

                        pointa[q + 1].x = 1 / 2 * cellsize + i - 1 * cellsize;
                        pointa[q + 1].y = 1 / 2 * cellsize + j  * cellsize;
                        pointa[q + 1].z = ElementData[i - 1, j ];

                        pointa[q + 2].x = 1 / 2 * cellsize + i - 1 * cellsize;
                        pointa[q + 2].y = 1 / 2 * cellsize + j + 1 * cellsize;
                        pointa[q + 2].z = ElementData[i - 1, j + 1];

                        pointa[q + 3].x = 1 / 2 * cellsize + i  * cellsize;
                        pointa[q + 3].y = 1 / 2 * cellsize + j - 1 * cellsize;
                        pointa[q + 3].z = ElementData[i, j - 1];

                        pointa[q + 4].x = 1 / 2 * cellsize + i  * cellsize;
                        pointa[q + 4].y = 1 / 2 * cellsize + j * cellsize;
                        pointa[q + 4].z = ElementData[i , j ];

                        pointa[q + 5].x = 1 / 2 * cellsize + i  * cellsize;
                        pointa[q + 5].y = 1 / 2 * cellsize + j + 1 * cellsize;
                        pointa[q + 5].z = ElementData[i , j + 1];

                        pointa[q + 6].x = 1 / 2 * cellsize + i + 1 * cellsize;
                        pointa[q + 6].y = 1 / 2 * cellsize + j - 1 * cellsize;
                        pointa[q + 6].z = ElementData[i + 1, j - 1];

                        pointa[q + 7].x = 1 / 2 * cellsize + i + 1 * cellsize;
                        pointa[q + 7].y = 1 / 2 * cellsize + j * cellsize;
                        pointa[q + 7].z = ElementData[i + 1, j ];

                        pointa[q + 8].x = 1 / 2 * cellsize + i + 1 * cellsize;
                        pointa[q + 8].y = 1 / 2 * cellsize + j + 1 * cellsize;
                        pointa[q + 8].z = ElementData[i + 1, j + 1];
                tri2[0].P1 = pointa[4]; tri2[0].P2 = pointa[0]; tri2[0].P3 = pointa[1];
                tri2[1].P1 = pointa[4]; tri2[1].P2 = pointa[1]; tri2[1].P3 = pointa[2];
                tri2[2].P1 = pointa[4]; tri2[2].P2 = pointa[2]; tri2[2].P3 = pointa[5];
                tri2[3].P1 = pointa[4]; tri2[3].P2 = pointa[5]; tri2[3].P3 = pointa[8];
                tri2[4].P1 = pointa[4]; tri2[4].P2 = pointa[8]; tri2[4].P3 = pointa[7];
                tri2[5].P1 = pointa[4]; tri2[5].P2 = pointa[7]; tri2[5].P3 = pointa[6];
                tri2[6].P1 = pointa[4]; tri2[6].P2 = pointa[6]; tri2[6].P3 = pointa[3];
                tri2[7].P1 = pointa[4]; tri2[7].P2 = pointa[3]; tri2[7].P3 = pointa[0];

                vec[i, j].X = putong(tri2).X;
                vec[i, j].Y = putong(tri2).Y;
                vec[i, j].Z = putong(tri2).Z;
                }
            }
            return vec;
        }

        public vector jiaodian(triangle[] tri)
        {
            vector zhi = new vector(); 
            vector vectup = new vector();
            vectup = Normalvector(tri[1]);
            vector vectdoen = new vector();
            vectdoen = Normalvector(tri[0]);
            zhi.X = (vectup.X + vectdoen.X) / 2;
            zhi.Y = (vectup.Y + vectdoen.Y) / 2;
            zhi.Z = (vectup.Z + vectdoen.Z) / 2;
            return zhi;
        }

        public vector hang( triangle[] tri)
        {
            vector zhi = new vector();
            vector vect1 = new vector();
            vect1 = Normalvector(tri[1]);
            vector vect2 = new vector();
            vect2 = Normalvector(tri[0]);
            vector vect3 = new vector();
            vect3 = Normalvector(tri[2]);
            vector vect4 = new vector();
            vect4 = Normalvector(tri[3]);
            zhi.X = (vect1.X + vect2.X+vect3.X + vect4.X) / 4;
            zhi.Y = (vect1.Y + vect2.Y + vect3.Y + vect4.Y) / 4;
            zhi.Z = (vect1.Z + vect2.Z + vect3.Z + vect4.Z) / 4;
            return zhi;
        }

        public vector putong( triangle[] tri)
        {
            vector zhi = new vector();
            vector vect1 = new vector();
            vect1 = Normalvector(tri[1]);
            vector vect2 = new vector();
            vect2 = Normalvector(tri[0]);
            vector vect3 = new vector();
            vect3 = Normalvector(tri[2]);
            vector vect4 = new vector();
            vect4 = Normalvector(tri[3]);
            vector vect5 = new vector();
            vect5 = Normalvector(tri[4]);
            vector vect6 = new vector();
            vect6 = Normalvector(tri[5]);
            vector vect7 = new vector();
            vect7 = Normalvector(tri[6]);
            vector vect8 = new vector();
            vect8 = Normalvector(tri[7]);
            zhi.X = (vect1.X + vect2.X + vect3.X + vect4.X + vect5.X + vect6.X + vect7.X+vect8.X) / 8;
            zhi.Y = (vect1.Y + vect2.Y + vect3.Y + vect4.Y + vect5.Y + vect6.Y + vect7.Y + vect8.Y) / 8;
            zhi.Z = (vect1.Z + vect2.Z + vect3.Z + vect4.Z + vect5.Z + vect6.Z + vect7.Z + vect8.Z) / 8;
            return zhi;
        }
       
        /// <summary>
        ///  //计算单个向量的夹角
        /// </summary>
        /// <param name="ray">太阳高度角的矢量</param>
        /// <param name="vectorvalue">规则格网的矢量</param>
        /// <returns></returns>
        public double d_raytovector_angle(vector ray, vector vectorvalue)
        {
            double d_Raytovector_Angle;
            double d_temp;
            double a = vectorvalue.X-ray.X;
            double b = vectorvalue.Y-ray.Y;
            double c = vectorvalue.Z-ray.Z;
            d_temp = Math.Sqrt(a * a + b * b + c * c);
            d_Raytovector_Angle = Math.Asin(d_temp / 2) * 2;
            return d_Raytovector_Angle;
        }
        //计算全部的角度
        public double[,] d_raytovector_angle_all(vector[,] vec,int RowsNum,int ColsNum, vector vectorvalue)
        {
            double[,] d_Raytovector_Angle_All = new double[RowsNum, ColsNum];
            for (int i = 0; i < RowsNum;i++ )
            {
                for (int j = 0; j < ColsNum; j++)
                {
                    d_Raytovector_Angle_All[i, j] = d_raytovector_angle(vectorvalue,vec[i, j]);
                }
            }
            return d_Raytovector_Angle_All;
        }
        /// <summary>
        /// 重头戏！！！！输出灰度值
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="RowsNum"></param>
        /// <param name="ColsNum"></param>
        /// <returns></returns>
        public double[,] i_cellvalue_hillshade(double[,] angle, int RowsNum, int ColsNum)
        {
            double[,] i_Cellvalue_Hillshade = new double[RowsNum, ColsNum];
            for (int i = 0; i < RowsNum; i++)
            {
                for (int j = 0; j < ColsNum; j++)
                {
                    if (angle[i, j] > Math.PI / 2)
                    {
                        i_Cellvalue_Hillshade[i, j] = 255;
                    }
                    else
                    {
                        i_Cellvalue_Hillshade[i, j] = angle[i,j]/(Math.PI/2)*255;
                    }
                }
            }
            return i_Cellvalue_Hillshade;
        }
    }
}
