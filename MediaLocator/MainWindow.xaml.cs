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
using System.Collections;
using MediaLocator.view;
using System.IO;
using MediaLocator.logging;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MediaLocator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int clicks = 1;
        private string folderPath;
        public static ArrayList check = new ArrayList();
        private static MediaView getView;
        private string mp3FilePath;
        private static List<FileModification> fileModificationList = new List<FileModification>();



        public MainWindow()
        {
            InitializeComponent();
            slideMenu.Click += new RoutedEventHandler((sender, e) => SlideMenu_Click(sender, e, NavPanel));
            openFolder.Click += OpenFolder_Click;
            pictureBtn.Click += PictureBtn_Click;
            musicBtn.Click += MusicBtn_Click;
            videoBtn.Click += VideoBtn_Click;
            albumBtn.Click += AlbumBtn_Click;
            ListFiles.MouseDoubleClick += ListFiles_MouseDoubleClick;
            hidePlayer();
            getView = new MediaView(PalyingProgress);

            
    }

        private void AlbumBtn_Click(object sender, RoutedEventArgs e)
        {
            MediaFunctions createAlbum = new MediaFunctions();
            string input = Microsoft.VisualBasic.Interaction.InputBox("Provide your playlist name in the box filed.", "Give your playlist a name", "MyPlayList", -1, -1);
            
            createAlbum.CreateM3UData(check, folderPath, input);
        }

        private void ListFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PalyingProgress.Value = 0;
                var selectedStockObject = ListFiles.SelectedItem as ListviewText;
                string filename = selectedStockObject.ToString();
                string fullPath = folderPath + @"\" + filename;
                getView.getMedia(fullPath, mediaPanel);

                FileInfo file = new FileInfo(fullPath);
                string ex = file.Extension.Substring(1, file.Extension.Length - 1);

                HideSplitBtn();

                if (System.IO.Path.GetExtension(fullPath).Equals(".mp3"))
                {
                    ShowSplitBtn();
                    mp3FilePath = fullPath;
                    FillIDList();

                }
                foreach (string item in FolderBrowser.getMusics())
                {
                    if (item.Equals(ex.ToUpper()))
                    {
                        showPlayer();

                    }

                }
                foreach (string item in FolderBrowser.getVideos())
                {
                    if (item.Equals(ex.ToUpper()))
                    {
                        showPlayer();
                    }
                }
                MediaView.playMedia();
                getView.setTimer();


                if (!System.IO.Path.GetExtension(fullPath).Equals(".mp3"))
                {
                    HideSplitBtn();

                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("No item selected: " + nre.Message);
            }
            catch (Exception allE)
            {
                Console.WriteLine("Error: " + allE.Message);
            }
            
            

        }

        private void VideoBtn_Click(object sender, RoutedEventArgs e)
        {
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.GetFilteredList(FolderBrowser.getVideos(), folderPath, folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString() });
            }
        }

        private void MusicBtn_Click(object sender, RoutedEventArgs e)
        {
            ListFiles.Items.Clear();
            try
            {
                foreach (var file in FolderBrowser.GetFilteredList(FolderBrowser.getMusics(), folderPath, folderPath))
                {
                    ListFiles.Items.Add(new ListviewText { Name = file.ToString() });
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
                
            }

         



        }

        private void PictureBtn_Click(object sender, RoutedEventArgs e)
        {
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.GetFilteredList(FolderBrowser.getPictures(), folderPath, folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString() });
            }
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            getMediaFolder();
            fillFileList();
            folderpath.Content = folderPath;
            //watchFolder();
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
            concateBtn.Opacity = 0;
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
            concateBtn.Opacity = 100;
            playerBg.Opacity = 100;
            PalyingProgress.Opacity = 100;
            playBtn.Opacity = 100;
            playBtn.Click += PlayBtn_Click;
            pauseBtn.Opacity = 100;
            pauseBtn.Click += PauseBtn_Click;
            stopBtn.Opacity = 100;
            stopBtn.Click += StopBtn_Click;
            splitBtn.Opacity = 100;
            splitBtn.Click += SplitBtn_Click;
            splitTime.Opacity = 100;
        }
        private void ShowIDTagBox()
        {
            IDTagBox.Opacity = 100;
           
        }
        private void HideIDTagBox()
        {
            IDTagBox.Opacity = 0;

        }
        private void SplitBtn_Click(object sender, RoutedEventArgs e)
        {
            FileModification fileModification = new FileModification(DateTime.Now, mp3FilePath, ".mp3", "Split interval: " + splitTime.Text);
            fileModification.addModificationToList(fileModificationList);
            Logging.AppendToLogFile(fileModificationList);
            MediaFunctions splitter = new MediaFunctions();
            var selectedStockObject = ListFiles.SelectedItem as ListviewText;       
            string filename = selectedStockObject.ToString();
            string fullPath = folderPath + @"\" + filename;
            splitter.SplitMp3(fullPath, Convert.ToInt32(splitTime.Text));
            
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            MediaView.stopMedia();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            MediaView.pauseMedia();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {

            MediaView.playMedia();
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
            foreach (var file in FolderBrowser.getFileList(folderPath, folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString()});
                
            }
        }
        public class ListviewText
        {
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            check.Clear();

            int count = ListFiles.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                var selectedStockObject = ListFiles.SelectedItems[i] as ListviewText;
                check.Add(folderPath + "\\" + selectedStockObject);

            }


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IDTagBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void IDTagBox_ItemDoubleClicked(object sender,MouseButtonEventArgs e)
        {

            try
            {
                MediaView.CloseMedia();
                if (IDTagBox.SelectedIndex == 0)
                {
                    MediaFunctions.SetTitle(mp3FilePath, Microsoft.VisualBasic.Interaction.InputBox("Please enter the value you wish to assign?", "Title", IDTagBox.Items.GetItemAt(0).ToString()));
                }
                if (IDTagBox.SelectedIndex == 1)
                {
                    MediaFunctions.SetArtist(mp3FilePath, Microsoft.VisualBasic.Interaction.InputBox("Please enter the value you wish to assign?", "Artist", IDTagBox.Items.GetItemAt(1).ToString()));
                }
                if (IDTagBox.SelectedIndex == 2)
                {
                    MediaFunctions.SetAlbum(mp3FilePath, Microsoft.VisualBasic.Interaction.InputBox("Please enter the value you wish to assign?", "Album", IDTagBox.Items.GetItemAt(2).ToString()));
                }
                if (IDTagBox.SelectedIndex == 3)
                {
                    string yearString = Microsoft.VisualBasic.Interaction.InputBox("Please enter the value you wish to assign?", "Year", (IDTagBox.Items.GetItemAt(3).ToString()));
                    short yearShort = short.Parse(yearString);
                    MediaFunctions.SetYear(mp3FilePath, yearShort);
                }
                if (4 <= IDTagBox.SelectedIndex)
                {
                    System.Windows.MessageBox.Show("Unmodifiable parameter :( !");
                }
                FillIDList();
        
            }
            catch(Exception) { }


        }
        private void FillIDList()
        {
            hidePlayer();
            IDTagBox.Items.Clear();
            ShowIDTagBox();
        
           
            foreach (String idTag in MediaFunctions.ViewMp3Tags(mp3FilePath))
            {
                Console.WriteLine(idTag);
                IDTagBox.Items.Add(idTag);

            }
        }

       private void HideSplitBtn()
        {
            concateBtn.Opacity = 0;
            splitBtn.Opacity = 0;
            splitTime.Opacity = 0;
        }
       
       private void ShowSplitBtn()
        {
            concateBtn.Opacity = 100;
            splitBtn.Opacity = 100;
            splitTime.Opacity = 100;
        }

        private void concateBtn_Click(object sender, RoutedEventArgs e)
        {
            FileModification fileModification = new FileModification(DateTime.Now, mp3FilePath, ".mp3", "concate");
            fileModification.addModificationToList(fileModificationList);
            Logging.AppendToLogFile(fileModificationList);
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                folderPath = dialog.SelectedPath;
            }
        }








        /*public void watchFolder()
        {
            
            FileSystemWatcher Watcher = new FileSystemWatcher();
            Watcher.Path = folderPath + @"\";
            Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            Watcher.EnableRaisingEvents = true;

            Watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
            Watcher.Changed += new FileSystemEventHandler(Watcher_OnChanged);
            Watcher.Created += new FileSystemEventHandler(Watcher_OnChanged);
            Watcher.Deleted += new FileSystemEventHandler(Watcher_OnChanged);


        }

        private void Watcher_OnChanged(object sender, FileSystemEventArgs e)
        {
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(folderPath, folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString() });

            }
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            ListFiles.Items.Clear();
            foreach (var file in FolderBrowser.getFileList(folderPath, folderPath))
            {
                ListFiles.Items.Add(new ListviewText { Name = file.ToString() });

            }
        }
        */


    }


}
