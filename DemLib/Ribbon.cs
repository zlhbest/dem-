using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DemLib
{
    public class Ribbon
    {
        private Dictionary<int, Color> mRibbon = null;
        private int step = 0;

        public int Step
        {
            set { step = value; }
        }
        public Ribbon(int STEP)
        {
            this.step = STEP;
            mRibbon = InitializeRibbon();
        }

        private Dictionary<int, Color> InitializeRibbon()
        {
            Dictionary<int, Color> pRibbon = new Dictionary<int, Color>();
            int R, G, B;
            Random mRandom = new Random();
            if (step == 20)
            {
                pRibbon.Add(0, Color.FromArgb(0, 0, 255));
                pRibbon.Add(1, Color.FromArgb(173, 246, 177));
                pRibbon.Add(2, Color.FromArgb(183, 246, 237));
                pRibbon.Add(3, Color.FromArgb(186, 254, 197));
                pRibbon.Add(4, Color.FromArgb(227, 255, 183));
                pRibbon.Add(5, Color.FromArgb(252, 255, 184));
                pRibbon.Add(6, Color.FromArgb(187, 223, 113));
                pRibbon.Add(7, Color.FromArgb(44, 177, 52));
                pRibbon.Add(8, Color.FromArgb(0, 133, 64));
                pRibbon.Add(9, Color.FromArgb(158, 164, 40));
                pRibbon.Add(10, Color.FromArgb(241, 187, 19));
                pRibbon.Add(11, Color.FromArgb(219, 103, 0));
                pRibbon.Add(12, Color.FromArgb(179, 43, 3));
                pRibbon.Add(13, Color.FromArgb(122, 10, 0));
                pRibbon.Add(14, Color.FromArgb(117, 25, 0));
                pRibbon.Add(15, Color.FromArgb(109, 44, 12));
                pRibbon.Add(16, Color.FromArgb(210, 82, 0));
                pRibbon.Add(17, Color.FromArgb(132, 81, 52));
                pRibbon.Add(18, Color.FromArgb(167, 149, 135));
                pRibbon.Add(19, Color.FromArgb(206, 202, 203));
                pRibbon.Add(20, Color.FromArgb(241, 231, 242));
                pRibbon.Add(21, Color.White);
            }
            else
            {
                for (int i = 0; i <= step; i++)
                {
                    R = mRandom.Next((int)255 / step * i,(int)255 / step * i+1);
                    G = mRandom.Next((int)255 / (step * 2) * i, (int)255 / (step * 2) * i + 1);
                    B = mRandom.Next((int)255 / (step * 3) * i, (int)255 / (step * 3) * i + 1);
                    pRibbon.Add(i, Color.FromArgb(R, G, B));
                }
            }
           
            return pRibbon;
        }

        public Color GetColor(int index)
        {
            return mRibbon[index];
        }
    }
}
