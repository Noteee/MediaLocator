using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows;
using System.IO;

namespace MediaLocator.view
{
    class MediaView
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MediaElement mediaElement;
        ProgressBar slide;

        public MediaView(ProgressBar slide)
        {
            this.slide = slide;
            mediaElement = new MediaElement();

        }
        public void getMedia(string path, StackPanel panel)
        {

            if (panel.Children.Count != 0)
            {
              
                panel.Children.RemoveAt(panel.Children.Count - 1);
               
            }
            mediaElement =  new MediaElement();

            mediaElement.Source =  new Uri(@"" + path);
            mediaElement.MediaOpened += MediaElement_MediaOpened;
            mediaElement.LoadedBehavior = MediaState.Manual;
            

            panel.Children.Add(mediaElement);


        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            mediaElement.Stretch = Stretch.Uniform;
            int width = mediaElement.NaturalVideoWidth;
            int height = mediaElement.NaturalVideoHeight;
            

            if (width < 530 && height < 390)
            {
                mediaElement.Stretch = Stretch.None;
                mediaElement.HorizontalAlignment = HorizontalAlignment.Center;
                mediaElement.VerticalAlignment = VerticalAlignment.Center;
            }


        }

        public void setTimer ()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            slide.Value = progress();
        }

        public  void playMedia()
        {
            mediaElement.Play();
            
        }

        public  void stopMedia()
        {
            mediaElement.Stop();
        }

        public  void pauseMedia()
        {
            mediaElement.Pause();

        }

        public  double progress ()
        {
            if (mediaElement.NaturalDuration.HasTimeSpan)
            {
                double duration = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                double playNow = mediaElement.Position.TotalSeconds;
                double result = playNow / duration;
                return Math.Ceiling(result * 100);
            }

            else
            {
                return 0;
            }
            

        }
    }
}
