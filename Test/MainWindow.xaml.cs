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

        private void LstBxImage_DragLeave(object sender, DragEventArgs e)
        {
            LstBxImage.Background = Brushes.WhiteSmoke;
        }

        private void LstBxImage_DragEnter(object sender, DragEventArgs e)
        {
            LstBxImage.Background = Brushes.SpringGreen;
        }

        public static class ImageHelper
        {

            public static string GetFileNamesFromFiles(string[] files)
            {
                StringBuilder allFileNames = new StringBuilder();

                foreach (var file in files)
                {
                    allFileNames.Append(file);
                }

                return allFileNames.ToString();
            }
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
