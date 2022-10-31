/*
 *  Project: Project 3
    File name: Playlist
    Description: stores an organized list of MP3s
    Course: CSCI 1260
    Author: Ash North
    Created: 2022-10-28
    Copyright: Ash North 2022
*/
using System;
using System.Collections.Generic;

namespace MP3Project
{
    /// <summary>
    /// list of mp3s
    /// </summary>
    public class Playlist
    {
        private List<MP3> playlist;
        private string name;
        private string author;
        private string creationDate;

        /// <summary>
        /// default constructor
        /// </summary>
        public Playlist()
        {
            playlist1 = new List<MP3>(0);
            name1 = "Playlist";
            author1 = "Placeholder McDude";
            creationDate1 = DateTime.Now.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// standard constructor
        /// </summary>
        /// <param name="capacity">initial capacity of the list</param>
        /// <param name="name">playlist title</param>
        /// <param name="author">playlist creator</param>
        /// <param name="creationDate">date playlist was made</param>
        public Playlist(int capacity, string name, string author, string creationDate)
        {
            playlist = new List<MP3>(capacity);
            name1 = name;
            author1 = author;
            creationDate1 = creationDate;
        }

        /// <summary>
        /// pseudo copy constructor, makes another playlist with the list entered but other properties
        /// </summary>
        /// <param name="playlist">playlist to copy</param>
        /// <param name="name">playlist title</param>
        /// <param name="author">playlist creator</param>
        /// <param name="creationDate">date playlist was made</param>
        public Playlist(List<MP3> playlist,  string name, string author, string creationDate)
        {
            playlist1 = new List<MP3>(playlist);
            name1 = name;
            author1 = author;
            creationDate1 = creationDate;
        }

        /// <summary>
        /// check if string is null or empty
        /// </summary>
        /// <param name="input">string to check</param>
        /// <returns>validity indicator</returns>
        public static bool ValidString(string input)
        {
            return input != null && input.Length > 0;
        }

        /// <summary>
        /// checks if a date can exist on the caldendar
        /// allows for any kind of splitting character, which is intentional,
        /// as it provides harmless freedom to the user, in exchange for letting them do...stupid things
        /// you can say "10Æ11Þ1999" if you so desire
        /// </summary>
        /// <param name="input">date to check</param>
        /// <returns>validity indicator</returns>
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

        /// <summary>
        /// tostring method
        /// </summary>
        /// <returns>string interpretation of the object</returns>
        public override string ToString()
        {
            string output =
                "Playlist name:\t" + name + "\n" +
                "Playlist author:\t" + author + "\n" +
                "Created on:\t" + creationDate + "\n";
            foreach(MP3 mp3 in playlist)
            {
                output += "\n" + mp3;
            }
            return output;
        }

        /// <summary>
        /// playlist property (hey look I learned a neat C# feature)
        /// </summary>
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

        /// <summary>
        /// name property
        /// </summary>
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

        /// <summary>
        /// author property
        /// </summary>
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

        /// <summary>
        /// creationDate property
        /// </summary>
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

        /// <summary>
        /// adds mp3 to the list
        /// </summary>
        /// <param name="mp3">mp3 to add</param>
        public void AddMP3(MP3 mp3)
        {
            playlist.Add(new MP3(mp3));
        }

        /// <summary>
        /// edits an mp3 in the list
        /// </summary>
        /// <param name="mp3">mp3 to change to</param>
        /// <param name="location">location of mp3 to change</param>
        public void EditMP3(MP3 mp3, int location)
        {
            playlist[location] = new MP3(mp3);
        }

        /// <summary>
        /// removes mp3 from the list
        /// </summary>
        /// <param name="location">place to remove from</param>
        public void RemoveMP3(int location)
        {
            playlist.RemoveAt(location);
        }

        /// <summary>
        /// give a list of all songs in a certain genre
        /// </summary>
        /// <param name="genre">genre to filter by</param>
        /// <returns>list of songs in the genre</returns>
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

        /// <summary>
        /// filter by author
        /// </summary>
        /// <param name="author">author to filter by</param>
        /// <returns>list of song with the author</returns>
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

        /// <summary>
        /// finds the first song in the list with a certain title
        /// if a full list of anything with matching titles is needed, it will have to be a new method
        /// </summary>
        /// <param name="title">title to search for</param>
        /// <returns>the song with that title (and its location in the list)</returns>
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

        /// <summary>
        /// sorts the list in alphabetical order by title
        /// </summary>
        public void SortByTitle()
        {
            for(int stop = playlist.Count; stop > 0; stop--)
            {
                for(int i = 0; i < stop-1; i++)
                {
                    if (GreaterThan(playlist[i].getTitle(), playlist[i+1].getTitle()))
                    {
                        MP3 temp = new MP3(playlist[i]);
                        playlist[i] = playlist[i+1];
                        playlist[i+1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// sorts the list by dat created (oldest to newest)
        /// </summary>
        public void SortByDate()
        {
            for (int stop = playlist.Count; stop > 0; stop--)
            {
                for (int i = 0; i < stop - 1; i++)
                {
                    if (GreaterThanDate(playlist[i].getReleaseDate(), playlist[i+1].getReleaseDate()))
                    {
                        MP3 temp = new MP3(playlist[i]);
                        playlist[i] = playlist[i + 1];
                        playlist[i + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// compares strings for alphabetical primity
        /// </summary>
        /// <param name="str1">string to check</param>
        /// <param name="str2">string to compare to</param>
        /// <returns>whether first string is greater than second one</returns>
        public static bool GreaterThan(string str1, string str2)
        {
            str1.ToLower();
            str2.ToLower();
            for(int i = 0; i < str1.Length; i++)
            {
                if (i > str2.Length)
                {
                    return false;
                }
                if (str1[i] > str2[i])
                {
                    return true;
                }
                if (str1[i] < str2[i])
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// compares dates for primity
        /// </summary>
        /// <param name="str1">date to check</param>
        /// <param name="str2">date to compare to</param>
        /// <returns>whether first date is newer than second</returns>
        public static bool GreaterThanDate(string str1, string str2)
        {
            int year1 = int.Parse(str1.Substring(6, 4));
            int year2 = int.Parse(str2.Substring(6, 4));
            if(year1 > year2)
            {
                return true;
            }
            if(year1 < year2)
            {
                return false;
            }
            int month1 = int.Parse(str1.Substring(0, 2));
            int month2 = int.Parse(str2.Substring(0, 2));
            if(month1 > month2)
            {
                return true;
            }
            if(month1 < month2)
            {
                return false;
            }
            int day1 = int.Parse(str1.Substring(3, 2));
            int day2 = int.Parse(str2.Substring(3, 2));
            if(day1 > day2)
            {
                return true;
            }
            return false;
        }
    }
}
