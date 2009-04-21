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

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Interaction logic for ucNewPost.xaml
    /// </summary>
    public partial class ucNewPost : UserControl
    {
        public ucNewPost()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbBlogList.ItemsSource = ToolsUtility.GetBlogsList().Where(p => p.IsReadOnly == false);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cbBlogList.SelectedIndex == -1)
            {
                ToolsUtility.ShowMessage("Please select a blog to add post!");
                return;
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                ToolsUtility.ShowMessage("The title of post shouldn't be empty");
                return;
            }
            ManagePost mp = new ManagePost();
            TextRange trContetn = new TextRange(rtxtContent.Document.ContentStart, rtxtContent.Document.ContentEnd);
            bool result = mp.AddPost(cbBlogList.SelectedValue.ToString(), txtTitle.Text, trContetn.Text);
            if (result)
            {
                ToolsUtility.ShowMessage("Save sucessfully");
            }
            else
            {
                ToolsUtility.ShowMessage("Save failed");
            }
        }
    }
}
