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
        Nullable<bool> imgtitle = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LstImg_DragLeave(object sender, DragEventArgs e)
        {
            LstBxImage.Background = Brushes.WhiteSmoke;
        }

        private void LstImg_DragEnter(object sender, DragEventArgs e)
        {
            LstBxImage.Background = Brushes.LightSkyBlue;
        }

        private void LstImg_Drop(object sender, DragEventArgs e)
        {
            LstBxImage.Background = Brushes.WhiteSmoke;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string path = ImagineView.GetFileNamesFromFiles(files);

            if (ImagineView.FileImg(path) == false)
            {
                MessageBox.Show("Ошибка формата изображения.");
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

            LstBxImage.Items.Add(image);
            LstBxImage.ScrollIntoView(LstBxImage.Items[LstBxImage.Items.Count - 1]);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();

            View vw = new View(GetChangedImages(350, 250), LstBxImage.SelectedIndex);
            vw.ShowDialog();

            this.Show();
            LstBxImage.SelectedIndex = 0;
        }

        private void MnItmTiles_Click(object sender, RoutedEventArgs e)
        {
            ChangeImagesInsideListBox(100, 100);
            imgtitle = true;
        }

        private void MnItmSmallIcons_Click(object sender, RoutedEventArgs e)
        {
            ChangeImagesInsideListBox(250, 150);
            imgtitle = false;
        }

        private void MnItmNormalIcons_Click(object sender, RoutedEventArgs e)
        {
            ChangeImagesInsideListBox(350, 250);
            imgtitle = null;
        }
        private void ChangeImagesInsideListBox(int width, int height)
        {
            List<Image> img_ = GetChangedImages(width, height);
            LstBxImage.Items.Clear();
            img_.ForEach(img => LstBxImage.Items.Add(img));
        }

        private List<Image> GetChangedImages(int width, int height)
        {
            List<Image> img_ = new List<Image>();

            for (int i = 0; i < LstBxImage.Items.Count; i++)
            {
                img_.Add(LstBxImage.Items[i] as Image);
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
