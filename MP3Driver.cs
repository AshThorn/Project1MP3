/*
    Project: Projecct 1
    File name: Project1MP3Driver
    Description: makes and displays mp3 headers
    Course: CSCI 1260
    Author: Ash North
    Created: 2022-09-14
    Copyright: Ash North 2022
 */

using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;

namespace MP3Project
{
    /// <summary>
    /// driver for mp3s
    /// </summary>
    public class MP3Driver
    {
         /// <summary>
         /// it's a main method it does what the program does
         /// </summary>
         /// <param name="args">default param</param>
        /*public static void Main(string[] args)
        {
            string username;
            int selection;
            MP3 storage = new MP3();
            bool hasStoredMP3 = false;

            welcomeMessage();//explanation of program's functionality
            username = usernameRequest();//get user's name
            do
            {
                selection = menu(hasStoredMP3);
                if(selection == 1)
                {
                    storage = makeNewFile();
                    hasStoredMP3 = true;//tell the program it has an mp3 stored
                }
                else if(selection == 2)
                {
                    System.Console.WriteLine(storage.toString());
                }
            } while (selection != 3);//continue running until user requests exit
            System.Console.WriteLine("Thank you for using my program, " + username + ".");
        }*/

        /// <summary>
        /// displays a wellcome message
        /// </summary>
        private static void welcomeMessage()
        {
            System.Console.WriteLine("Hello and welcome to MP3 Saver, developed shamefully by Ash North.\n" +
                "Here you can store fake MP3 headers, with a very limited number of genres because my teacher\n" +
                "needed an example for enums (I don't blame you I have no idea what would be an enum in MP3s.\n");
        }

        /// <summary>
        /// requests username
        /// </summary>
        /// <returns>the input that actually got accepted</returns>
        private static string usernameRequest()
        {
            string username;
            System.Console.Write("What's your name?");
            username = System.Console.ReadLine();//getting username
            if(username != null && username != "")
            {

                return username;//successful input, proceed
            }
            System.Console.WriteLine("You didn't say anything?");//error handling
            return usernameRequest();
        }

        /// <summary>
        /// runs a menu
        /// </summary>
        /// <param name="hasStoredMP3">tells whether there is an mp3 stored</param>
        /// <returns>the input</returns>
        private static int menu(bool hasStoredMP3)
        {
            int selection;
            string input;
            System.Console.Write(
                "\t  Menu\n" +
                "\t--------\n" +
                "\n" +
                "\t1.\tCreate a new MP3 file\n" +
                "\t2.\tDisplay an MP3 file\n" +
                "\t3.\tClose the program\n" +
                "\n" +
                "\tPlease enter your selection as a number:");//print the menu
            input = System.Console.ReadLine();//recieve input
            if (Int32.TryParse(input, out selection))//check validity of input
            {
                if ((selection == 2 && !hasStoredMP3) || selection < 0 || selection > 3)//if input invalid,
                {
                    Console.WriteLine("This is not a valid entry.");
                    return menu(hasStoredMP3);//try again
                }
                return selection;//if valid, then return
            }
            Console.WriteLine("This is not a valid entry.");
            return menu(hasStoredMP3);//invalid input handling part 2
        }

        /// <summary>
        /// make a new mp3
        /// </summary>
        /// <returns>an mp3</returns>
        public static MP3 makeNewFile()
        {
            string title;
            string artist;
            string releaseDate;
            double playtime;
            Genre genre;
            decimal downloadCost;
            double fileSize;
            string path;

            Console.WriteLine("Right, making a new MP3.");

            //get the values for the MP3
            //I know these lack error handling but I'm running out of time
            //update: we have (some) error handling now
            System.Console.Write("Enter the title:");
            do
            {

                title = System.Console.ReadLine();
            } while (!Playlist.ValidString(title));
            Console.Write("Enter the artist:");
            do
            {
                artist = System.Console.ReadLine();
            } while (!Playlist.ValidString(artist));
            Console.Write("Enter the release date:");
            do
            {
                releaseDate = System.Console.ReadLine();
            } while (!Playlist.ValidDate(releaseDate));
            Console.Write("Enter the playtime:");
            playtime = Double.Parse(Console.ReadLine());
            Console.Write("Enter the genre:");
            genre = parseStringToGenre(Console.ReadLine());
            Console.Write("Enter the cost of the download:");
            downloadCost = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the size of the file in MB:");
            fileSize = Double.Parse(Console.ReadLine());
            Console.Write("Enter the path to the album cover:");
            do
            {
                path = System.Console.ReadLine();
            } while (!Playlist.ValidString(path));

            return new MP3(title, artist, releaseDate, playtime, genre, downloadCost, fileSize, path);
        }

        /// <summary>
        /// parses string input to Genre enum
        /// </summary>
        /// <param name="str">the input</param>
        /// <returns>the enum value</returns>
        public static Genre parseStringToGenre(string str)
        {
            while (true)
            {
                switch (str)
                {
                    case "Rock": return Genre.Rock; break;
                    case "Pop": return Genre.Pop; break;
                    case "Jazz": return Genre.Jazz; break;
                    case "Country": return Genre.Country; break;
                    case "Classical": return Genre.Classical; break;
                    default: return Genre.Other; break;//yes I know this will turn any typo into other but I have no time
                    //I swear I know what I'm doing
                }
            }
        }
    }
}