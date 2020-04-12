using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SimilarFaces
{
    static class Variables
    {
        public static string ChoosenPhotoPath = "";
        public static Bitmap ChoosenPhoto;
        public static readonly int TrainPhotos = 32;
        public static readonly double Threshold = 9000; //порог        
        public static Bitmap ChoosenCentered;
        public static Bitmap ResultCentered;
    }
}
