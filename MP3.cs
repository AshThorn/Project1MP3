using System;

namespace Project1MP3
{
    public class MP3
    {
        private string title;
        private string artist;
        private string releaseDate;
        private double playtime;
        private Genre genre;
        private decimal downloadCost;
        private double fileSize;
        private string path;

        public MP3(string title, string artist, string releaseDate, double playtime, Genre genre, 
            decimal downloadCost, double fileSize, string path)
        {
            setTitle(title);
            setArtist(artist);
            setReleaseDate(releaseDate);
            setPlaytime(playtime);
            setGenre(genre);
            setFileSize(fileSize);
            setPath(path);
        }

        public MP3()
        {
            //hopefully this never makes it to a print
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getTitle()
        {
            return title;
        }

        public void setArtist(string artist)
        {
            this.artist = artist;
        }

        public string getArtist()
        {
            return artist;
        }

        public void setReleaseDate(string releaseDate)
        {
            this.releaseDate = releaseDate;
        }

        public string getReleaseDate()
        {
            return releaseDate;
        }

        public void setPlaytime(double playtime)
        {
            this.playtime = playtime;
        }

        public double getPlaytime()
        {
            return playtime;
        }

        public void setGenre(Genre genre)
        {
            this.genre = genre;
        }

        public Genre getGenre()
        {
            return genre;
        }

        public void setDownloadCost(decimal downloadCost)
        {
            this.downloadCost = downloadCost;
        }

        public decimal getDownloadCost()
        {
            return downloadCost;
        }

        public void setFileSize(double fileSize)
        {
            this.fileSize = fileSize;
        }

        public double getFileSize()
        {
            return fileSize;
        }

        public void setPath(string path)
        {
            this.path = path;
        }

        public string getPath()
        {
            return path;
        }

        public string toString()
        {
            return
                "MP3 Title:\t" + title + "\n" +
                "Artist:\t" + artist + "\tGenre:\t" + genre + "\n" +
                "Download Cost:\t" + downloadCost + "\tFile Size:\t" + fileSize + "\n" +
                "Song Playtime:\t" + playtime + "\tAlbum Photo:\t" + path;
        }
    }
}
