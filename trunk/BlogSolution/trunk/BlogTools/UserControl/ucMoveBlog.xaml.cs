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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Interaction logic for ucMoveBlog.xaml
    /// </summary>
    public partial class ucMoveBlog : UserControl
    {
        public ucMoveBlog()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            cbFromBlogList.ItemsSource = blogList.Where(p => p.IsReadOnly == true);
            cbToBlogList.ItemsSource = blogList.Where(p => p.IsReadOnly == false);
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtAddress.Text = openFileDialog.FileName;
            }
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            if (cbFromBlogList.SelectedIndex > -1 && cbToBlogList.SelectedIndex > -1 && !string.IsNullOrEmpty(txtAddress.Text))
            {
                MovePost mp = new MovePost();
                MovePost.MoveResult result = mp.Move(cbFromBlogList.SelectedValue.ToString(),
                    txtAddress.Text,
                    cbToBlogList.SelectedValue.ToString());
                if (result.FailedCount > 0)
                {
                    ToolsUtility.ShowMessage("Failed count:" + result.FailedCount.ToString());
                    lbResult.ItemsSource = result.FailedList;
                    tbFailedList.Visibility = Visibility.Visible;
                    svFailedList.Visibility = Visibility.Visible;
                }
                else
                {
                    ToolsUtility.ShowMessage("Move sucessfully!");
                }
            }
            else
            {
                ToolsUtility.ShowMessage("Parameter lost!");
            }
            pbMoveStatus.Value = 100;
            pbMoveStatus.IsIndeterminate = false;
        }
    }
}
