using Gallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Gallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       // public int PhotoSize {get; set; }=100;
        public bool IsFullScreen { get; set; } = false;
        public List<Photo> photos = new List<Photo>()
            {
                new Photo
                {
                     ImagePath="Images/image1.jpeg"
                },
                new Photo
                {
                     ImagePath="Images/image2.jpeg"
                },
                 new Photo
                {
                     ImagePath="Images/image3.jpeg"
                },
                  new Photo
                {
                     ImagePath="Images/image4.jpeg"
                },
                   new Photo
                {
                     ImagePath="Images/image5.jpeg"
                },
                    new Photo
                {
                     ImagePath="Images/image6.jpeg"
                },
                     new Photo
                {
                     ImagePath="Images/image7.jpeg"
                },
                      new Photo
                {
                     ImagePath="Images/image8.jpeg"
                },
                             new Photo
                {
                     ImagePath="Images/image9.jpeg"
                },
                                    new Photo
                {
                     ImagePath="Images/image10.jpeg"
                },
                                           new Photo
                {
                     ImagePath="Images/image11.jpeg"
                },
            };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            if (photos.Count > 0)
            {
                ListViewProducts.ItemsSource = photos;
            }
        }

        private void close_app_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

 

        private void minimize_app_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maximize_app_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFullScreen)
            {
                WindowState = WindowState.Maximized;
                IsFullScreen = true;
            }
            else
            {
                WindowState = WindowState.Normal;
                IsFullScreen=false;
            }

        }


        public void mediumicons_Click(object sender, RoutedEventArgs e)
        {
            photos.ForEach(p => { p.PhotoSize = 100; p.PhotoBorderSize = 110; });
        }

        private void smallicons_Click(object sender, RoutedEventArgs e)
        {
            photos.ForEach(p => { p.PhotoSize = 60; p.PhotoBorderSize = 70; });


        }

        private void largeicons_Click(object sender, RoutedEventArgs e)
        {
            photos.ForEach(p => { p.PhotoSize = 150; p.PhotoBorderSize = 160; });


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFullPath(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                     photos.Add(new Photo
                    {
                        ImagePath = filename,
                        PhotoBorderSize = photos[0].PhotoBorderSize,
                        PhotoSize = photos[0].PhotoBorderSize
                    }); ;
                }
                ListViewProducts.ItemsSource = null;
                ListViewProducts.ItemsSource = photos;
            }
        }

        private void ListViewProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           if(sender is ItemsControl i)
            {
                var photo = i.ItemsSource as List<Photo>;
                MessageBox.Show(photo[0].ImagePath);
            }
        }
    }
}
