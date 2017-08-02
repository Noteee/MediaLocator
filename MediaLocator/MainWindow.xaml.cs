using MahApps.Metro.Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaLocator.filesystem;
using MediaLocator.enums;

namespace MediaLocator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int clicks = 1;
        private string folderPath;

        public MainWindow()
        {
            InitializeComponent();
            slideMenu.Click += new RoutedEventHandler((sender, e) => SlideMenu_Click(sender,e, NavPanel));
            openFolder.Click += OpenFolder_Click;
            pictureBtn.Click += PictureBtn_Click;
            hidePlayer();
            
            
        }

        private void PictureBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            getMediaFolder();
            fillFileList();
            folderpath.Content = folderPath;
        }

        private void SlideMenu_Click(object sender, RoutedEventArgs e, StackPanel pnl)
        {
            if (clicks % 2 == 0)
            {
                ShowHideMenu("sbHideBottomMenu", NavPanel);
                
            }
            else
            {
                ShowHideMenu("sbShowBottomMenu", NavPanel);
            }
            clicks++;
        }



        private void ShowHideMenu(string Storyboard, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

        }

        private void hidePlayer()
        {
            playerBg.Opacity = 0;
            PalyingProgress.Opacity = 0;
            playBtn.Opacity = 0;
            pauseBtn.Opacity = 0;
            stopBtn.Opacity = 0;
            splitBtn.Opacity = 0;
            splitTime.Opacity = 0;
        }

        private void showPlayer()
        {
            playerBg.Opacity = 100;
            PalyingProgress.Opacity = 100;
            playBtn.Opacity = 100;
            pauseBtn.Opacity = 100;
            stopBtn.Opacity = 100;
            splitBtn.Opacity = 100;
            splitTime.Opacity = 100;
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
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(folderPath))
            {
                ListFiles.Items.Add(new ListviewText {Name = file.ToString()});
            }
        }
        public class ListviewText
        {
            public string Name { get; set; }
            
        }

        private void FillFilteredList()
        {
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.GetFilteredList(folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString() });
            }
        }



    }

}
