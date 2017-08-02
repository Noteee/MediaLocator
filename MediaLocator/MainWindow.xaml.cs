using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaLocator.filesystem;
namespace MediaLocator
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getMediaFolder();
            fillFileList();


        }

        private void getMediaFolder()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                pathLabel.Content = dialog.SelectedPath;
            }
        }



        private void fillFileList()
        {
            fileListBox.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(pathLabel.Content.ToString()))
            {
                fileListBox.Items.Add(file.ToString());
            }
        }

        private void FillFilteredList(string extension)
        {
            fileListBox.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(pathLabel.Content.ToString()))
            {
                if(extens)
                fileListBox.Items.Add(file.ToString());
            }
        }

    }
}
