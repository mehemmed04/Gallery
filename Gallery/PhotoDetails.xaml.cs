using Gallery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for PhotoDetails.xaml
    /// </summary>
    public partial class PhotoDetails : Window, INotifyPropertyChanged
    {
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }

        public List<Photo> Photos { get; set; }
        public int PhotosIndex { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        public PhotoDetails()
        {
            InitializeComponent();
            this.DataContext = this;
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            nextImage.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private void PrevImage_Click(object sender, RoutedEventArgs e)
        {
            if (PhotosIndex > 0)
            {
                PhotosIndex--;
            }
            else
            {
                PhotosIndex = Photos.Count - 1;
            }
            Path = Photos[PhotosIndex].ImagePath;
        }

        public void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
            }
        }

        private void AutoPlay_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
            }

        }

        private void nextImage_Click(object sender, RoutedEventArgs e)
        {
            if (PhotosIndex < Photos.Count - 1)
            {
                PhotosIndex++;
            }
            else
            {
                PhotosIndex = 0;
            }
            Path = Photos[PhotosIndex].ImagePath;
        }
    }
}
