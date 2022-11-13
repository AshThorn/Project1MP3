﻿/*
 *  Project: Projecct 1
    File name: MP3
    Description: mp3 objects
    Course: CSCI 1260
    Author: Ash North
    Created: 2022-09-14
    Copyright: Ash North 2022
*/

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MP3Project
{
    /// <summary>
    /// a file containing all of the information about an mp3
    /// the setters should have error handling but they don't
    /// </summary>
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

        /// <summary>
        /// the main constructor
        /// </summary>
        /// <param name="title">title of the song</param>
        /// <param name="artist">composer</param>
        /// <param name="releaseDate">date of release</param>
        /// <param name="playtime">length of song</param>
        /// <param name="genre">type of music</param>
        /// <param name="downloadCost">price to download</param>
        /// <param name="fileSize">size of the file</param>
        /// <param name="path">path to album cover</param>
        public MP3(string title, string artist, string releaseDate, double playtime, Genre genre, 
            decimal downloadCost, double fileSize, string path)
        {
            setTitle(title);
            setArtist(artist);
            setReleaseDate(releaseDate);
            setPlaytime(playtime);
            setGenre(genre);
            setDownloadCost(downloadCost);
            setFileSize(fileSize);
            setPath(path);
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="toCopy">object to dupiicate</param>
        public MP3(MP3 toCopy)
        {
            setTitle(toCopy.title);
            setArtist(toCopy.artist);
            setReleaseDate(toCopy.releaseDate);
            setPlaytime(toCopy.playtime);
            setGenre(toCopy.genre);
            setDownloadCost(toCopy.downloadCost);
            setFileSize(toCopy.fileSize);
            setPath(toCopy.path);
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public MP3()
        {
            //hopefully this never makes it to a print
        }

        /// <summary>
        /// title setter
        /// </summary>
        /// <param name="title">input</param>
        public void setTitle(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// title getter
        /// </summary>
        /// <returns>the title</returns>
        public string getTitle()
        {
            return title;
        }

        /// <summary>
        /// aartist setter
        /// </summary>
        /// <param name="artist">input</param>
        public void setArtist(string artist)
        {
            this.artist = artist;
        }

        /// <summary>
        /// artist getter
        /// </summary>
        /// <returns>the artist</returns>
        public string getArtist()
        {
            return artist;
        }

        /// <summary>
        /// date setter
        /// </summary>
        /// <param name="releaseDate">input</param>
        public void setReleaseDate(string releaseDate)
        {
            this.releaseDate = releaseDate;
        }

        /// <summary>
        /// date getter
        /// </summary>
        /// <returns>the date</returns>
        public string getReleaseDate()
        {
            return releaseDate;
        }

        /// <summary>
        /// playtime setter
        /// </summary>
        /// <param name="playtime">input</param>
        public void setPlaytime(double playtime)
        {
            this.playtime = playtime;
        }

        /// <summary>
        /// playtime setter
        /// </summary>
        /// <returns>the playtime</returns>
        public double getPlaytime()
        {
            return playtime;
        }

        /// <summary>
        /// genre setter
        /// </summary>
        /// <param name="genre">input</param>
        public void setGenre(Genre genre)
        {
            this.genre = genre;
        }

        /// <summary>
        /// genre getter
        /// </summary>
        /// <returns>the genre</returns>
        public Genre getGenre()
        {
            return genre;
        }

        /// <summary>
        /// cost setter
        /// </summary>
        /// <param name="downloadCost">input</param>
        public void setDownloadCost(decimal downloadCost)
        {
            this.downloadCost = downloadCost;
        }

        /// <summary>
        /// cost getter
        /// </summary>
        /// <returns>the cost</returns>
        public decimal getDownloadCost()
        {
            return downloadCost;
        }

        /// <summary>
        /// size setter
        /// </summary>
        /// <param name="fileSize">input</param>
        public void setFileSize(double fileSize)
        {
            this.fileSize = fileSize;
        }

        /// <summary>
        /// size getter
        /// </summary>
        /// <returns>the size</returns>
        public double getFileSize()
        {
            return fileSize;
        }

        /// <summary>
        /// path setter
        /// </summary>
        /// <param name="path">input</param>
        public void setPath(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// path setter
        /// </summary>
        /// <returns>the path</returns>
        public string getPath()
        {
            return path;
        }

        /// <summary>
        /// a normal tostring method
        /// </summary>
        /// <returns>take a guess</returns>
        public override string ToString()
        {
            return
                "MP3 Title:\t" + title + "\n" +
                "Artist:\t\t" + artist + "\t\tGenre:\t" + genre + "\n" +
                "Download Cost:\t" + downloadCost + "\tFile Size:\t" + fileSize + "\n" +
                "Song Playtime:\t" + playtime + "\tAlbum Photo:\t" + path;
        }

        public string ToStringDelimited()
        {
            return getTitle() + "|" + getArtist() + "|" + getReleaseDate() + "|" +
                getPlaytime() + "|" + getGenre() + "|" + getDownloadCost() + "|" +
                getFileSize() + "|" + getPath();
        }
    }
}
