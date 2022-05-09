using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public List<Image> Img { get; set; }

        public View(List<Image> img, int index)
        {
            InitializeComponent();
            Img = img;
            ImgFromListBox.Source = Img[index].Source;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var NW = new MainWindow();
            this.Hide();
            NW.Show();
        }
    }
}
