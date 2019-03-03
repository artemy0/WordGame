using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Collections;
using System.Collections.Generic;
using PagedList;

namespace WordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello. This is a word game. press any key to start.");
            Console.ReadKey();
            Console.Clear();

            string Word;

            while (true)
            {
                Console.Write("Enter a word from 8 to 20 characters from which you will need to make other words: ");
                Word = Console.ReadLine();
                if (Word.Length >= 8 && Word.Length <= 20)
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have entered recent words. Try again.");
                    continue;
                }
            }

            PrintWord(Word);

            Console.Write("Enter a name for the first player: ");
            Player player1 = new Player(Console.ReadLine());

            Console.Write("Enter a name for the second player: ");
            Player player2 = new Player(Console.ReadLine());

            var players = new MoreCollections.CircularList<Player>(new Player[] { player1, player2 });
            int index = 0;
            try
            {
                do
                {
                    PrintWord(Word);

                    players[index++].Move(Word);

                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Thanks for playing.\n{player1.Name} has {player1.Points} points\n{player2.Name} has {player2.Points} points.");
            }

            Console.ReadKey();
        }

        public static void PrintWord(string word)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Source word is " + word.ToUpper());
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
