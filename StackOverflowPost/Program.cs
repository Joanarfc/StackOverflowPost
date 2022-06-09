using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowPost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post();

            DisplayMenu(post);
        }

        public static void DisplayMenu(Post post)
        {
            int convertedChoice;

            do
            {
                Console.Write("\n\n-------------Welcome to the StackOverflow------------\n");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1 - Write a post");
                Console.WriteLine("2 - Visualize a post");
                Console.WriteLine("9 - Quit");
                Console.Write("Insert your choice:");
                string choiceAsString = Console.ReadLine();

                bool parsedSuccess = int.TryParse(choiceAsString, out convertedChoice);

                if (parsedSuccess)
                {
                    switch (convertedChoice)
                    {
                        case 1:
                            Console.Write("Enter the post title:");
                            string title = Console.ReadLine();

                            Console.Write("Enter the post description:");
                            string description = Console.ReadLine();

                            post.Title = title;
                            post.Description = description;
                            Console.WriteLine(post.DisplayPost());
                            break;
                        case 2:
                            Console.WriteLine(post.DisplayPost());
                            DisplayVoteMenu(post);
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option!");

                }
            }
            while (convertedChoice != 9);
        }

        public static void DisplayVoteMenu(Post post)
        {
            int convertedChoice;

            do
            {
                Console.Write("\n\n-------------StackOverflow Post Vote------------\n");
                Console.WriteLine(post.DisplayPost());
                Console.WriteLine("Please choose an option to vote this post:");
                Console.WriteLine("1 - Up-vote a post");
                Console.WriteLine("2 - Down-vote a post");
                Console.WriteLine("3 - Return to the previous menu");
                Console.WriteLine("9 - Quit");
                Console.Write("Insert your choice:");
                string choiceAsString = Console.ReadLine();

                bool parsedSuccess = int.TryParse(choiceAsString, out convertedChoice);

                if (parsedSuccess)
                {
                    switch (convertedChoice)
                    {
                        case 1:
                            post.UpVote();
                            Console.WriteLine("Your vote is saved. Total votes: {0}", post.TotalVotes());
                            break;
                        case 2:
                            post.DownVote();
                            Console.WriteLine("Your vote is saved. Total votes: {0}", post.TotalVotes());
                            break;

                        case 3:
                            Console.Clear();
                            DisplayMenu(post);
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option!");

                }
            }
            while (convertedChoice != 9);
        }
    }
}
