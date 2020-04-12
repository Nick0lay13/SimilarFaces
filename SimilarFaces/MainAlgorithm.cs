using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimilarFaces
{
    static class MainAlgorithm
    {
        public static int[,] MiddleFace;
        public static int[,] ChoosenVector;

        public static bool Do()
        {            
            CenterChsnImgAndConvertToVect();
            SubMidFaceFromChoosen();
            int NumberOfPhoto = FindSimilarFaceByMinDistance();

            if (NumberOfPhoto != -1)
            {
                Variables.ResultCentered = TrainData.Arr[NumberOfPhoto - 1];
                return true;
            }
            else
            {
                Variables.ResultCentered = new Bitmap(128, 128); 
                return false;
            }
        }

        static int FindSimilarFaceByMinDistance()
        {
            double[] Distances = new double[Variables.TrainPhotos];

            double MinDist = 0;
            int SimilarFace = 0;
            bool FirstTime = true;

            for (int img = 0; img < Variables.TrainPhotos; img++)
            {
                Distances[img] = DistanceBetweenVectors(img);

                if (FirstTime)
                {
                    MinDist = Distances[0];
                    SimilarFace = 0;
                    FirstTime = false;
                }
                else
                {
                    if (MinDist > Distances[img])
                    {
                        MinDist = Distances[img];
                        SimilarFace = img;
                    }
                }

            }


            if (MinDist > Variables.Threshold)
                return -1;


            return SimilarFace + 1;   // т. к. в массиве нумерация с 0, а в папке с 1
        }



        static double DistanceBetweenVectors(int ImageNumber)
        {
            double result = 0, var = 0;

            for (int pxl = 0; pxl < 16384; pxl++)
            {
                var = ChoosenVector[0, pxl] - TrainData.VectorMatrix[ImageNumber, pxl];
                var = Math.Pow(var, 2);
                result += var;
            }

            result = Math.Sqrt(result);

            return result;
        }

        static void SubMidFaceFromChoosen()
        {
            for (int pxl = 0; pxl < 16384; pxl++)
            {
                ChoosenVector[0, pxl] -= MiddleFace[0, pxl];
            }
        }

        static void CenterChsnImgAndConvertToVect()
        {
            Bitmap Img = new Bitmap(Variables.ChoosenPhoto);

            Img = Centering.HorizontallyCenteredPhoto(Img);

            Variables.ChoosenCentered = new Bitmap(Img);

            ChoosenVector = new int[1, 16384];

            int x = 0, y = 0;

            for (int pxl = 0; pxl < 16384; pxl++)
            {
                if (x > 127)
                {
                    x = 0; y++;
                }

                ChoosenVector[0, pxl] = Img.GetPixel(x, y).R;

                x++;
            }

        }

        public static void SubstractMiddleFace()
        {
            CalculateMiddleFace();

            for (int img = 0; img < Variables.TrainPhotos; img++)
                for (int pxl = 0; pxl < 16384; pxl++)
                {
                    TrainData.VectorMatrix[img, pxl] -= MiddleFace[0, pxl];
                }
        }

        static void CalculateMiddleFace()
        {
            MiddleFace = new int[1, 16384];

            for(int img = 0; img < Variables.TrainPhotos; img++)
                for(int pxl = 0; pxl < 16384; pxl++)
                {
                    MiddleFace[0, pxl] += TrainData.VectorMatrix[img, pxl];
                }

            for (int pxl = 0; pxl < 16384; pxl++)
            {
                MiddleFace[0, pxl] /= Variables.TrainPhotos;
            }
        }
    }
}
