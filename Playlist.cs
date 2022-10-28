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
            playlist = new List<MP3>(5);
            name = "Playlist";
            author = "Placeholder McDude";
            creationDate = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public Playlist(int capacity, string name, string author, string creationDate)
        {
            playlist = new List<MP3>(capacity);
            this.name = name;
            this.author = author;
            this.creationDate = creationDate;
        }
    }
}
