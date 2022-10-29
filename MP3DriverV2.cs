using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;

namespace MP3Project
{
    public class MP3DriverV2
    {
        private static Playlist Mp3s;
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

        public static void Main(string[] args)
        {
            int input = 0;
            Mp3s = new Playlist();
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
                case 11:Console.WriteLine("How did you get here?"); break;
                default:throw new ArgumentOutOfRangeException("input", "Invalid selection."); break;
            }
        }

        public static void CreatePlaylist()
        {

        }

        public static void Add()
        {

        }

        public static void Edit()
        {

        }

        public static void Drop()
        {

        }

        public static void Display()
        {

        }

        public static void Search()
        {

        }

        public static void FilterGenre()
        {

        }

        public static void FilterArtist()
        {

        }

        public static void SortTitle()
        {

        }

        public static void SortDate()
        {

        }
    }
}
