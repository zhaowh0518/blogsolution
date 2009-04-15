using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Disappearwind.BlogSolution.BlogTools
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

        private void btnMoveBlog_Click(object sender, RoutedEventArgs e)
        {
            dpContent.Children.Clear();
            dpContent.Children.Add(new ucMoveBlog());
        }

        private void btnNewPost_Click(object sender, RoutedEventArgs e)
        {
            dpContent.Children.Clear();
            dpContent.Children.Add(new ucNewPost());
        }

        private void btnSystemMange_Click(object sender, RoutedEventArgs e)
        {
            dpContent.Children.Clear();
            dpContent.Children.Add(new ucSystemManage());
        }
    }
}
