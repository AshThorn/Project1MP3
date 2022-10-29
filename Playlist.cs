using System;
using System.Collections.Generic;

namespace MP3Project
{
    public class Playlist
    {
        private List<MP3> playlist;
        private string name;
        private string author;
        private string creationDate;

        public Playlist()
        {
            playlist1 = new List<MP3>(0);
            name1 = "Playlist";
            author1 = "Placeholder McDude";
            creationDate1 = DateTime.Now.ToString("MM/dd/yyyy");
        }

        public Playlist(int capacity, string name, string author, string creationDate)
        {
            playlist = new List<MP3>(capacity);
            name1 = name;
            author1 = author;
            creationDate1 = creationDate;
        }

        public Playlist(List<MP3> playlist,  string name, string author, string creationDate)
        {
            playlist1 = new List<MP3>(playlist);
            name1 = name;
            author1 = author;
            creationDate1 = creationDate;
        }

        public static bool ValidString(string input)
        {
            return input != null && input.Length > 0;
        }

        public static bool ValidDate(string input)
        {
            int month = int.Parse(input.Substring(0,2));
            int day = int.Parse(input.Substring(3,2));
            int year = int.Parse(input.Substring(6,4));
            return//day can exist at all
                day >= 1 &&
                day <= 31 &&
                //month can exist at all
                month >= 1 &&
                month <= 12 &&
                //day is not higher than max for its month and year
                (
                    (month == 2 &&//February
                        (
                            day <= 28 ||//normal year
                            ((year % 400 == 0 || (year % 100 != 0 && year % 4 == 0)) && day == 29)//leap year
                        )
                    ) ||
                    day <= 30 ||//all months besides Feb have at least 30 days
                    day == 31 &&
                    (
                        (month <= 7 && month % 2 == 1) ||//in first 7 months, all odds have 31
                        (month > 7 && month % 2 == 0)//in remaining months, all evens have 31
                    )
                );
        }

        public override string ToString()
        {
            string output =
                "Playlist name:\t" + name + "\n" +
                "Playlist author:\t" + author + "\n" +
                "Created on:\t" + creationDate + "\n";
            foreach(MP3 mp3 in playlist)
            {
                output += mp3.ToString();
            }
            return output;
        }

        public List<MP3> playlist1
        {
            get
            {
                return playlist;
            }
            set
            {
                playlist = value;
            }
        }

        public string name1
        {
            get
            {
                return name;
            }
            set
            {
                if (ValidString(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException("name", "Empty playlist field.");
                }
            }
        }

        public string author1
        {
            get
            {
                return author;
            }
            set
            {
                if (ValidString(value))
                {
                    author = value;
                }
                else
                {
                    throw new ArgumentNullException("author", "Empty author field.");
                }
            }
        }

        public string creationDate1
        {
            get
            {
                return creationDate;
            }
            set
            {
                if (ValidDate(value))
                {
                    creationDate = value;
                }
                else
                {
                    throw new ArgumentException("creationDate", "Invalid date.");
                }
            }
        }

        public void AddMP3(MP3 mp3)
        {
            playlist.Add(new MP3(mp3));
        }

        public void EditMP3(MP3 mp3, int location)
        {
            playlist[location] = new MP3(mp3);
        }

        public void RemoveMP3(int location)
        {
            playlist.RemoveAt(location);
        }

        public List<MP3> ListByGenre(Genre genre)
        {
            List<MP3> output = new List<MP3>();
            foreach(MP3 mp3 in playlist)
            {
                if(mp3.getGenre() == genre)
                {
                    output.Add(new MP3(mp3));
                }
            }
            return output;
        }

        public List<MP3> ListByAuthor(string author)
        {
            List<MP3> output = new List<MP3>();
            foreach(MP3 mp3 in playlist)
            {
                if(mp3.getArtist() == author)
                {
                    output.Add(new MP3(mp3));
                }
            }
            return output;
        }

        public MP3 SearchByTitle(string title)
        {
            MP3 output = new MP3();
            int index = 0;
            foreach(MP3 mp3 in playlist)
            {
                if(mp3.getTitle() == title)
                {
                    Console.WriteLine("LOCATION:" + index);
                    output = new MP3(mp3);
                }
                index++;
            }
            return output;
        }
    }
}
