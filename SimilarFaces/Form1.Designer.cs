namespace SimilarFaces
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChoosenPhoto = new System.Windows.Forms.PictureBox();
            this.ResultPhoto = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosenPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // ChoosenPhoto
            // 
            this.ChoosenPhoto.Location = new System.Drawing.Point(28, 53);
            this.ChoosenPhoto.Name = "ChoosenPhoto";
            this.ChoosenPhoto.Size = new System.Drawing.Size(256, 256);
            this.ChoosenPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChoosenPhoto.TabIndex = 0;
            this.ChoosenPhoto.TabStop = false;
            // 
            // ResultPhoto
            // 
            this.ResultPhoto.Location = new System.Drawing.Point(334, 53);
            this.ResultPhoto.Name = "ResultPhoto";
            this.ResultPhoto.Size = new System.Drawing.Size(256, 256);
            this.ResultPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ResultPhoto.TabIndex = 1;
            this.ResultPhoto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(382, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наиболее похожее:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Выбрать фото";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(50, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выбрать фото";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 326);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResultPhoto);
            this.Controls.Add(this.ChoosenPhoto);
            this.Name = "Form1";
            this.Text = "SimilarFaces";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChoosenPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ChoosenPhoto;
        private System.Windows.Forms.PictureBox ResultPhoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

