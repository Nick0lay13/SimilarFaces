using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimilarFaces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateTrainMatrix();
            /*
             В этом методе:             
            1. Центрируем все изображения базы
            2. Переводим их в матрицу векторов            
            3. Вычитаем из каждого "среднее" лицо
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            // Если нажата ОК
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Если удалось загрузить фото
                if (PhotoOpenedSucceed())
                {                    
                    // Возвращаем, значение, найдено ли похожее число
                    // (под методом нажатия кнопки описано, что делает этот  метод)
                    bool SimilarFaceFinded = MainAlgorithm.Do();

                    // Загружаем выбранное фото в левый PictureBox
                    // (только после алгоритма, т. к. там оно центрируется и сохраняется)
                    ChoosenPhoto.Image = new Bitmap(Variables.ChoosenCentered);

                    // Выводим найденное фото в правый PictureBox
                    // (выводить в любом случае, т. к. пустое тоже надо выводить)
                    ResultPhoto.Image = new Bitmap(Variables.ResultCentered);

                    //  Пишем, что похожих нет, если возвращенное число = -1
                    if (!SimilarFaceFinded)
                        MessageBox.Show("Похожих изображений нет", "Внимание!");
                }
            }
        }
        /*
         Что делает метод MainAlgorithm.Do() :
         
            1. Центрирует выбранное фото и переводит в вектор
            2. Вычитает из выбранного фото "среднее" лицо
            3. Ищет дистанции и сравнивает минимальную с порогом
            4. Если похожее есть - загружает соответствующее
            изображение в Variables.ResultCentered, если нет - очищает его
            5. Возвращает true или false. False, если похожих нет
            (чтобы вывести соответствующее сообщение)

             */

        void CreateTrainMatrix()
        {
            TrainData.CreateConvertedImgVectors();
        }

        bool PhotoOpenedSucceed()
        {
            Variables.ChoosenPhotoPath = openFileDialog1.FileName;

            try
            {
                Variables.ChoosenPhoto = new Bitmap(@Variables.ChoosenPhotoPath);
                return true;
            }
            catch
            {
                MessageBox.Show("Не удалось открыть изображение", "Ошибка!");
                return false;
            }
        }
    }
}
