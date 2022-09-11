using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Models
{
    public class Photo:INotifyPropertyChanged
    {
        public string ImagePath { get; set; }
        private int photosize=100;

        public int PhotoSize
        {
            get { return photosize; }
            set { photosize = value; OnPropertyChanged(); }
        }

        private int photobordersize = 100;

        public int PhotoBorderSize
        {
            get { return photobordersize; }
            set { photobordersize = value; OnPropertyChanged(); }
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
    }
}
