using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace Test
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public List<Image> Img { get; set; }
        private int _counter = default;
        public View(List<Image> img, int index)
        {
            InitializeComponent();
            Img = img;
            ImgListBox.Source = Img[index].Source;

            _counter = index;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            var NW = new MainWindow();
            NW.ShowDialog();
            Show();
        }
    }
}
