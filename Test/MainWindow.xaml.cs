using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Text;


namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LstImg_DragLeave(object sender, DragEventArgs e)
        {
            LstImage.Background = Brushes.WhiteSmoke;
        }

        private void LstImg_DragEnter(object sender, DragEventArgs e)
        {
            LstImage.Background = Brushes.LightSkyBlue;
        }

        private void LstImg_Drop(object sender, DragEventArgs e)
        {
            LstImage.Background = Brushes.WhiteSmoke;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string path = ImagineView.GetFileNamesFromFiles(files);

            if (ImagineView.FileImg(path) == false)
            {
                MessageBox.Show("Ошибка", "Drag and Drop", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Image image = new Image
            {
                Source = new BitmapImage(new Uri(path)),
                Width = 350,
                Height = 250,
                Stretch = Stretch.Fill
            };

            image.MouseUp += Image_MouseUp;

            LstImage.Items.Add(image);
            LstImage.ScrollIntoView(LstImage.Items[LstImage.Items.Count - 1]);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();

            View vw = new View(GetChangedImages(350, 250), LstImage.SelectedIndex);
            vw.ShowDialog();

            this.Show();
            LstImage.SelectedIndex = 0;
        }

        private List<Image> GetChangedImages(int width, int height)
        {
            List<Image> img_ = new List<Image>();

            for (int i = 0; i < LstImage.Items.Count; i++)
            {
                img_.Add(LstImage.Items[i] as Image);
                img_[i].Width = width;
                img_[i].Height = height;
                img_[i].Stretch = Stretch.Fill;
            }

            return img_;
        }

        public static class ImagineView
        {

            public static string GetFileNamesFromFiles(string[] files)
            {
                StringBuilder filesname = new StringBuilder();

                foreach (var file in files)
                {
                    filesname.Append(file);
                }

                return filesname.ToString();
            }

            public static bool FileImg(string path)
            {
                List<string> imageExtensions = new List<string> { ".jpg", ".jpeg", ".jfif", ".png", ".jpe" };

                for (int i = 0; i < imageExtensions.Count; i++)
                {
                    if (path.ToLower().EndsWith(imageExtensions[i].ToLower()))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }

}
