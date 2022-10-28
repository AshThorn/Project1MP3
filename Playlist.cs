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
            playlist1 = new List<MP3>(5);
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

        public static bool ValidString(string input)
        {
            return input != null && input.Length > 0;
        }

        public static bool ValidDate(string input)
        {
            int month;
            int day;
            int year;
            return input.Length == 0 &&
                int.TryParse(input.Substring(0, 2), out month) &&
                int.TryParse(input.Substring(3, 2), out day) &&
                int.TryParse(input.Substring(6, 4), out year) &&
                //day can exist at all
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
                        month % 2 == 0//in remaining months, all evens have 31
                    )
                );
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
                    throw new ArgumentNullException();
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
                if(ValidString(value))
                    author = value;
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
                    throw new ArgumentException();
                }
            }
        }
    }
}
