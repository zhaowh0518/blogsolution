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
    public partial class ucConvertPost : UserControl
    {
        public ucConvertPost()
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
            System.Windows.Forms.FolderBrowserDialog openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult dr = openFolderDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtAddress.Text = openFolderDialog.SelectedPath;
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (cbFromBlogList.SelectedIndex > -1 && cbToBlogList.SelectedIndex > -1 && !string.IsNullOrEmpty(txtAddress.Text))
            {
                ConvertPost cp = new ConvertPost();
                cp.Convert(cbFromBlogList.SelectedValue.ToString(),              
                    cbToBlogList.SelectedValue.ToString(),txtAddress.Text);
                ToolsUtility.ShowMessage("Convert sucessfully!");
            }
            else
            {
                ToolsUtility.ShowMessage("Parameter lost!");
            }
        }
    }
}
