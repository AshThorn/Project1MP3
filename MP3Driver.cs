using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Project1MP3
{
    public class MP3Driver
    {
        public static void Main(string[] args)
        {
            string username;
            int selection;
            MP3[] storage = new MP3[0];
            MP3 newMP3;
            welcomeMessage();//explanation of program's functionality
            username = usernameRequest();//get user's name
            do
            {
                selection = menu(storage.Length);
                if(selection == 1)
                {
                    newMP3 = makeNewFile();
                }
            } while (selection != 3);
            System.Console.WriteLine("Thank you for using my program, " + username + ".");
        }

        private static void welcomeMessage()
        {
            System.Console.WriteLine("Hello and welcome to MP3 Saver, developed shamefully by Ash North.\n" +
                "Here you can store fake MP3 headers, with a very limited number of genres because my teacher\n" +
                "needed an example for enums (I don't blame you I have no idea what would be an enum in MP3s.\n");
        }

        private static string usernameRequest()
        {
            string username;
            System.Console.Write("What's your name?");
            username = System.Console.ReadLine();
            if(username != null && username != "")
            {
                System.Console.WriteLine("You didn't say anything?");
                return usernameRequest();
            }
            return username;
        }

        private static int menu(int storageLength)
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
                "\tPlease enter your selection as a number:");
            input = System.Console.ReadLine();
            if (Int32.TryParse(input, out selection))
            {
                if ((selection == 2 && storageLength == 0) || selection < 0 || selection > 3)
                {
                    Console.WriteLine("This is not a valid entry.");
                    return menu(storageLength);
                }
                return selection;
            }
            Console.WriteLine("This is not a valid entry.");
            return menu(storageLength);
        }

        private static MP3 makeNewFile()
        {
            string title;
            string artist;
            string releaseDate;
            double playtime;
            Genre genre;
            decimal downloadCost;
            double fileSize;
            string path;

    }
}
}