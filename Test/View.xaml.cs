using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            ImgListBox.Source = Img[index].Source;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
