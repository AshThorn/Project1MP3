/*
 *  Project: Project 3
    File name: MP3DriverV2
    Description: IO for a playlist
    Course: CSCI 1260
    Author: Ash North
    Created: 2022-10-28
    Copyright: Ash North 2022
*/
using System;
using System.Data;

namespace MP3Project
{
    /// <summary>
    /// runs end user IO with a playlist
    /// </summary>
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
            "\t11)\tLoad from a file\n" +
            "\t12)\tSave to a file\n" +
            "\t0)\tExit";
        private static readonly string exitMessage = "Thank you for using my program.";
        private static readonly string emptyPlaylistMessage = "The playlist is still empty, put something in it before you try to do that.";
        private static string path = "mp3s.txt";

        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args">list of all arguments passed in order</param>
        public static void Main(string[] args)
        {
            int input = 0;
            mp3s = new Playlist();
            Console.WriteLine(welcomeMessage);
            do
            {
                try
                {
                    input = Menu();
                    if (input == 0)
                    {
                        break;
                    }
                    Select(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (input != 0);
            AskToSave();
            Console.WriteLine(exitMessage);
        }

        /// <summary>
        /// displays menu and gives the user's input
        /// </summary>
        /// <returns>user input (as an int)</returns>
        public static int Menu()
        {
            Console.WriteLine(menuMessage);
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// processes user input
        /// </summary>
        /// <param name="input">user input</param>
        /// <exception cref="ArgumentOutOfRangeException">thrown when user gives an input that does not exist</exception>
        public static void Select(int input)
        {
            switch(input){
                case 0:AskToSave(); break;
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
                case 11:LoadFromFile(); break;
                case 12: SaveToFile(); break;
                default:throw new ArgumentOutOfRangeException("input", "Invalid selection."); break;
            }
        }

        /// <summary>
        /// creates an empty playlist with properties that are supplied here
        /// </summary>
        public static void CreatePlaylist()
        {
            if(mp3s.playlist1.Count > 0)
            {
                AskToSave();
            }
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
            SaveToFile();
        }

        /// <summary>
        /// add a new MP3
        /// </summary>
        public static void Add()
        {
            mp3s.AddMP3(MP3Driver.makeNewFile());
        }

        /// <summary>
        /// edit an mp3
        /// </summary>
        public static void Edit()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the index of the MP3 you want to edit:");
            }
        }

        /// <summary>
        /// remove an mp3
        /// </summary>
        public static void Drop()
        {
            if (PlaylistCheck())
            {
                Console.Write("Enter the location to remove at:");
                mp3s.RemoveMP3(int.Parse(Console.ReadLine()));
            }
        }

        /// <summary>
        /// display the list
        /// </summary>
        public static void Display()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine(mp3s);
            }
        }

        /// <summary>
        /// s3earch by title
        /// </summary>
        public static void Search()
        {
            if (PlaylistCheck())
            {
                Console.WriteLine("Enter the title to search for (case sensitive):");
                mp3s.SearchByTitle(Console.ReadLine());
            }
        }

        /// <summary>
        /// filter by genre
        /// </summary>
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

        /// <summary>
        /// filter by artist
        /// </summary>
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

        /// <summary>
        /// sort by title
        /// </summary>
        public static void SortTitle()
        {
            if (PlaylistCheck())
            {
                mp3s.SortByTitle();
            }
        }
        
        /// <summary>
        /// sort by date
        /// </summary>
        public static void SortDate()
        {
            if (PlaylistCheck())
            {
                mp3s.SortByDate();
            }
        }

        /// <summary>
        /// checks if playlist contains mp3s
        /// </summary>
        /// <returns>validity check</returns>
        /// <exception cref="NoNullAllowedException">disallows the accessing of an object without initializing it</exception>
        public static bool PlaylistCheck()
        {
            if(mp3s.playlist1.Capacity == 0)
            {
                throw new NoNullAllowedException(emptyPlaylistMessage);
            }
            return true;
        }

        /// <summary>
        /// stores playlist to a file
        /// </summary>
        /// <exception cref="ArgumentNullException">invalid path entered</exception>
        public static void SaveToFile()
        {
            Console.Write("Where would you like to save? (Leave blank to continue using the previous file or the default): ");
            string toSave = Console.ReadLine();
            if (Playlist.ValidString(toSave))
            {
                path = toSave;
            }
            if(toSave == null)
            {
                throw new ArgumentNullException(toSave, "Path string is null.");
            }
            mp3s.SaveToFile(path);
        }

        /// <summary>
        /// pulls playlist from a file
        /// </summary>
        /// <exception cref="ArgumentNullException">invalid path entered</exception>
        public static void LoadFromFile()
        {
            Console.Write("Where would you like to load from? (Leave blank to continue using the previous file or the default): ");
            string toSave = Console.ReadLine();
            if (Playlist.ValidString(toSave))
            {
                path = toSave;
            }
            if (toSave == null)
            {
                throw new ArgumentNullException(toSave, "Path string is null.");
            }
            mp3s.FillFromFile(path);
        }

        /// <summary>
        /// asks the user if they would like to safe and then asks accordingly
        /// </summary>
        public static void AskToSave()
        {
            if (mp3s.SaveNeeded(path))
            {
                Console.WriteLine("Would you like to save before closing? (Y/N):");
                try
                {
                    string toSave = Console.ReadLine();
                    if(toSave.ToUpper() == "Y")
                    {
                        SaveToFile();
                    }
                    else if(toSave.ToUpper() == "N")
                    {
                        return;
                    }
                    else
                    {
                        throw new ArgumentException(toSave, "That is not an option.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    AskToSave();
                }
            }
        }
    }
}
