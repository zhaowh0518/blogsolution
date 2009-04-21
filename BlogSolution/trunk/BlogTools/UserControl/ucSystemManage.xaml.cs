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
using System.IO;
using System.Xml;

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Interaction logic for ucSystemManage.xaml
    /// </summary>
    public partial class ucSystemManage : UserControl
    {
        public ucSystemManage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindBlogList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBlogName.Text))
            {
                ToolsUtility.ShowMessage("Blog name should not be empty");
                return;
            }
            if (UploadAssemebly(txtAssembly.Text))
            {
                int index = txtAssembly.Text.LastIndexOf("\\") + 1;
                string assemblyName = txtAssembly.Text.Substring(index, txtAssembly.Text.Length - index);
                BlogInfo bi = new BlogInfo();
                bi.BlogName = txtBlogName.Text;
                bi.AssemblyName = assemblyName;
                bi.TypeName = txtTypeName.Text;
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    bi.IsReadOnly = true;
                }
                else
                {
                    bi.IsReadOnly = false;
                    bi.UserName = txtUserName.Text;
                    bi.Password = txtPassword.Text;
                }
                SavaBlogInfo(bi);
                ToolsUtility.ShowMessage("Save sucessfully!");
            }
            BindBlogList();
        }

        private void BindBlogList()
        {
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            lvBlogList.ItemsSource = blogList;
        }

        private void btnSelectAssembly_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.EndsWith("dll"))
            {
                txtAssembly.Text = openFileDialog.FileName;
            }
            else
            {
                ToolsUtility.ShowMessage("Please select a valid assmebly!");
            }
        }

        private bool UploadAssemebly(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    string currentPath = AppDomain.CurrentDomain.BaseDirectory;
                    int index = fileName.LastIndexOf("\\") + 1;
                    string newFileName = fileName.Substring(index, fileName.Length - index);
                    newFileName = System.IO.Path.Combine(currentPath, newFileName);
                    File.Copy(fileName, newFileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ToolsUtility.ShowMessage(string.Format("File upload failed.Detail:{0}", ex.Message));
                return false;
            }
        }

        private void SavaBlogInfo(BlogInfo bi)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ToolsUtility.BlogListFilePath);

                XmlNode root = xmlDoc.DocumentElement;
                XmlElement newElement = xmlDoc.CreateElement("list:BlogInfo");
                newElement.SetAttribute("x:Key", bi.BlogName.ToLower());
                newElement.SetAttribute("BlogName", bi.BlogName);
                newElement.SetAttribute("AssemblyName", bi.AssemblyName);
                newElement.SetAttribute("TypeName", bi.TypeName);
                newElement.SetAttribute("IsReadOnly", bi.IsReadOnly.ToString());
                newElement.SetAttribute("UserName", bi.UserName);
                newElement.SetAttribute("Password", bi.Password);
                root.AppendChild(newElement);

                using (FileStream fs = new FileStream(ToolsUtility.BlogListFilePath, FileMode.OpenOrCreate))
                {
                    fs.SetLength(0);
                    xmlDoc.Save(fs);
                }
            }
            catch (Exception ex)
            {
                ToolsUtility.ShowMessage("Save blog info to xaml file failed.Detail:" + ex.Message);
            }
        }
    }
}
