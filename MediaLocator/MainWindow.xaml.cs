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
using MediaLocator.enums;
using System.Collections;

namespace MediaLocator
{

    
    public partial class MainWindow : Window
    {
        private ArrayList selectedFormat = new ArrayList();

        private string folderPath;
        public MainWindow()
        {
            selectedFormat = MusicFormats.getMusicFormatList();
            InitializeComponent();
            getMediaFolder();
            fillFileList();
            FillFilteredList(selectedFormat);
            FolderBrowser.GetFilteredList(selectedFormat,folderPath);
        }


        private void getMediaFolder()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                folderPath = dialog.SelectedPath;
            }
        }



        private void fillFileList()
        {
            fileListBox.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(folderPath))
            {
                fileListBox.Items.Add(file);
            }
        }

        private void FillFilteredList(ArrayList formatFilter)
        {
            fileListBox2.Items.Clear();
            foreach (var file in FolderBrowser.GetFilteredList(formatFilter,folderPath))
            {
                fileListBox2.Items.Add(file);

            }
        }

        private void fileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
