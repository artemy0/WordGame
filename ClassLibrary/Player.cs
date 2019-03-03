using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player
    {
        private static int Count = 1;
        public string Name { get; private set; }
        public int Id { get; private set; }
        public int Points { get; private set; } = 0;

        public Player(string name)
        {
            Name = name;
            Id = Count++;
        }

        public void Move(string word)
        {
            Console.Write($"The move of the {Id} player named {Name}: ");
            string enteredWords = Console.ReadLine();

            string tempWord = word;

            foreach (char character in enteredWords)
            {
                int index = tempWord.IndexOf(character);
                if (index != -1)
                    tempWord = tempWord.Remove(index, 1);
                else
                {
                    Console.WriteLine("You have entered an invalid or non-existent word!");
                    throw new Exception($"The {Id} player named {Name} lost");
                }
            }

            Console.WriteLine("That's right. Press any button to move to the next player.");
        }
    }
}
