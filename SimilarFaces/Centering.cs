using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimilarFaces
{
    static class Centering
    {
        public static Bitmap HorizontallyCenteredPhoto(Bitmap photo)
        {
            int Shift = 63 - CalculateHorizontalCenter(photo);
            return ShiftImageOn(photo, Shift);
        }

        static Bitmap ShiftImageOn(Bitmap img, int shift)
        {
            Bitmap result = new Bitmap(128, 128);            

            int limitX = 0;

            shift *= -1;

            if (shift > 0)
            {
                Bitmap RightBorder = new Bitmap(1, 128);

                limitX = 128 - shift;

                for (int y = 0; y < 128; y++)
                    for (int x = shift; x < limitX; x++)
                        result.SetPixel(x, y, img.GetPixel(x - shift, y));

                for (int y = 0; y < 128; y++)
                    RightBorder.SetPixel(0, y, img.GetPixel(127, y));

                for (int y = 0; y < 128; y++)
                    for (int x = shift - 1; x > 0; x--)
                        result.SetPixel(x, y, RightBorder.GetPixel(0, y));
            }
            else if (shift == 0)
                return img;
            else
            {                
                limitX = 128 + shift;

                for (int y = 0; y < 128; y++)
                    for (int x = 0; x < limitX; x++)
                        result.SetPixel(x, y, img.GetPixel(x - shift, y));

                for (int y = 0; y < 128; y++)
                    for (int x = -shift - 1; x > 0; x--)
                        result.SetPixel(x, y, img.GetPixel(0, y));
            }

            return result;
        }

        static int CalculateHorizontalCenter(Bitmap Img)
        {
            int GeneralSum = 0;

            int[] ValuePxl = new int[128];                        

            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 128; y++)
                {
                    ValuePxl[x] += Img.GetPixel(x, y).R;
                }

                GeneralSum += ValuePxl[x];
            }

            int[] IntervalSums = new int[128]; // интервал от 0 до значения индекса
            int[] MinDiff = new int[128]; // Minimal Difference

            int MostMinimalDiff = 0;
            bool FirstTime = true;
            int CenterImg = 0;

            int var = 0;

            for (int center = 1; center < 127; center++)
            {
                for (int i = 0; i < center; i++)
                    IntervalSums[center] += ValuePxl[i];

                var = GeneralSum - IntervalSums[center];
                MinDiff[center] = Math.Abs(var - IntervalSums[center]);

                if (FirstTime)
                {
                    MostMinimalDiff = MinDiff[1];
                    CenterImg = 1;
                    FirstTime = false;
                }
                else
                {
                    if (MostMinimalDiff > MinDiff[center])
                    {
                        MostMinimalDiff = MinDiff[center];
                        CenterImg = center;
                    }                    
                }
            }

            return CenterImg;
        }
    }
}
