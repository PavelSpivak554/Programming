using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет песню, исполнителя, название, альбом, продолжительность
    /// </summary>
    internal class Song
    {
        /// <summary>
        /// Исполнитель песни
        /// </summary>
        private string artist;

        /// <summary>
        /// Продолжительность песни в секундах
        /// </summary>
        private int duration;

        /// <summary>
        /// Название песни
        /// </summary>
        private string title;

        /// <summary>
        /// Название альбома
        /// </summary>
        private string album;

        /// <summary>
        /// Создает экземпляр класса Song с пустыми значениями
        /// </summary>
        public Song() { }

        /// <summary>
        /// Создает экземпляр класса Song с заданными параметрами
        /// </summary>
        /// <param name="artist">Исполнитель песни</param>
        /// <param name="duration">Продолжительность в секундах</param>
        /// <param name="title">Название песни</param>
        /// <param name="album">Название альбома</param>
        public Song(string artist, int duration, string title, string album)
        {
            Artist = artist;
            Duration = duration;
            Title = title;
            Album = album;
        }

        /// <summary>
        /// Исполнитель песни (не может быть пустым)
        /// </summary>
        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                if (string.IsNullOrEmpty(value))  
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                artist = value;
            }
        }

        /// <summary>
        /// Название песни (не может быть пустым)
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))  
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                title = value;
            }
        }

        /// <summary>
        /// Название альбома (не может быть пустым)
        /// </summary>
        public string Album
        {
            get
            {
                return album;
            }
            set
            {
                if (string.IsNullOrEmpty(value))  
                {
                    throw new ArgumentException("Значение не может быть пустым или состоять из пробелов.");
                }
                album = value;
            }
        }

        /// <summary>
        /// Продолжительность песни в секундах (должна быть положительной)
        /// </summary>
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(Duration)))
                {
                    duration = value;
                }
            }
        }
    }
}