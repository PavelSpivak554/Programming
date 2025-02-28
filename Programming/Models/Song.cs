using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Song
    {
        private string artist;
        private int duration;
        private string title;
        private string album;
        public Song() { }
        public Song(string artist, int duration, string title, string album)
        {
            Artist = artist;
            Duration = duration;
            Title = title;
            Album = album;
        }

        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                artist = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                title = value;
            }
        }
        public string Album
        {
            get
            {
                return album;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                album = value;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Недопустимое значение");
                }
                duration = value;
            }
        }
    }
}

