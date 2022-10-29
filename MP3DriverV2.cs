﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MP3Project
{
    public class MP3DriverV2
    {
        private static Playlist mp3s;
        private static readonly string welcomeMessage = "Welcome to my playlist program.\nHere you can store headers of MP3s, remove, edit, sort, search, and filter them, to be viewed.";
        private static readonly string menuMessage =
            "MAIN MENU\n" +
            "---------------------------------------------------------------------------\n" +
            "Type the number of the option you would like to select from the menu below:\n" +
            "---------------------------------------------------------------------------\n" +
            "\t1)\tCreate new playlist (if one already exists, it will be deleted.)\n" +
            "\t2)\tAdd a new MP3\n" +
            "\t3)\tEdit an MP3\n" +
            "\t4)\tDrop an MP3 from the playlist\n" +
            "\t5)\tDisplay the playlist\n" +
            "\t6)\tSearch for song by title\n" +
            "\t7)\tDisplay list filtered by genre\n" +
            "\t8)\tDisplay list filtered by artist\n" +
            "\t9)\tSort by song title\n" +
            "\t10)\tSort by release date\n" +
            "\t11)\tExit";
        private static readonly string exitMessage = "Thank you for using my program.";
        private static readonly string emptyPlaylistMessage = "The playlist is still empty, put something in it before you try to do that.";

        public static void Main(string[] args)
        {
            int input = 0;
            mp3s = new Playlist();
            Console.WriteLine(welcomeMessage);
            while (input != 11)
            {
                try
                {
                    input = Menu();
                    if(input == 0)
                    {
                        break;
                    }
                    Select(input);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(exitMessage);
        }

        public static int Menu()
        {
            Console.WriteLine(menuMessage);
            return int.Parse(Console.ReadLine());
        }

        public static void Select(int input)
        {
            switch(input){
                case 1:CreatePlaylist(); break;
                case 2:Add(); break;
                case 3:Edit(); break;
                case 4:Drop(); break;
                case 5:Display(); break;
                case 6:Search(); break;
                case 7:FilterGenre(); break;
                case 8:FilterArtist(); break;
                case 9:SortTitle(); break;
                case 10:SortDate(); break;
                case 11:break;
                default:throw new ArgumentOutOfRangeException("input", "Invalid selection."); break;
            }
        }

        public static void CreatePlaylist()
        {
            string name;
            string author;
            string creationDate;
            Console.Write("Enter a playlist title:");
            name = Console.ReadLine();
            Console.Write("Enter your name (or the name of the person who made it):");
            author = Console.ReadLine();
            Console.Write("Enter the date of creation (if today, just leave blank):");
            creationDate = Console.ReadLine();
            if(creationDate == string.Empty)
            {
                creationDate = DateTime.Now.ToString("MM/dd/yyyy");
            }
            mp3s = new Playlist(0, name, author, creationDate);
        }

        public static void Add()
        {
            mp3s.AddMP3(MP3Driver.makeNewFile());
        }

        public static void Edit()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the index of the MP3 you want to edit:");
            }
        }

        public static void Drop()
        {
            if (PlaylistCheck())
            {
                Console.Write("Enter the location to remove at:");
                mp3s.RemoveMP3(int.Parse(Console.ReadLine()));
            }
        }

        public static void Display()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine(mp3s);
            }
        }

        public static void Search()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the title to search for (case sensitive):");
                mp3s.SearchByTitle(Console.ReadLine());
            }
        }

        public static void FilterGenre()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the genre to filter by:");
                Genre genre = MP3Driver.parseStringToGenre(Console.ReadLine());
                Playlist filtered = new Playlist(mp3s.ListByGenre(genre), mp3s.name1 + " Filtered by genre: " + genre, mp3s.author1, mp3s.creationDate1);
                Console.WriteLine(filtered);
            }
        }

        public static void FilterArtist()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the author to filter by:");
                string author = Console.ReadLine();
                Playlist filtered = new Playlist(mp3s.ListByAuthor(author), mp3s.name1 + " Filtered by author: " + author, mp3s.author1, mp3s.creationDate1);
                Console.WriteLine(filtered);
            }
        }

        public static void SortTitle()
        {
            if (PlaylistCheck())
            {
                mp3s.SortByTitle();
            }
        }

        public static void SortDate()
        {
            if (PlaylistCheck())
            {
                mp3s.SortByDate();
            }
        }

        public static bool PlaylistCheck()
        {
            if(mp3s.playlist1.Capacity == 0)
            {
                throw new NoNullAllowedException(emptyPlaylistMessage);
            }
            return true;
        }
    }
}
