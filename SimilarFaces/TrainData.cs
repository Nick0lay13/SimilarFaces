using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace SimilarFaces
{
    static class TrainData
    {
        static string Path = @"TrainPhoto\";
        public static int[,] VectorMatrix = new int[Variables.TrainPhotos, 16384];
        public static Bitmap[] Arr = new Bitmap[Variables.TrainPhotos];

        public static void CreateConvertedImgVectors()
        {
            // Центрируем все изображения базы
            CenterImages();
            //  Переводим их в матрицу векторов
            FillMatrix();
            // Вычитаем из каждого "среднее" лицо
            MainAlgorithm.SubstractMiddleFace();
        }

        static void CenterImages()
        {
            for (int img = 0; img < Variables.TrainPhotos; img++)
            {
                Arr[img] = new Bitmap(@Path + (img + 1) + ".jpg");
                Arr[img] = Centering.HorizontallyCenteredPhoto(Arr[img]);
            }
        }

        static void FillMatrix()
        {
            Bitmap Img;
            int x, y;

            for (int img = 0; img < Variables.TrainPhotos; img++)
            {
                Img = Arr[img];

                x = 0; y = 0;
                for (int str = 0; str < 16384; str++)
                {
                    if (x > 127)
                    {
                        x = 0; y++;
                    }

                    VectorMatrix[img, str] = Img.GetPixel(x, y).R;

                    x++;
                }
            }
        }
    }
}
