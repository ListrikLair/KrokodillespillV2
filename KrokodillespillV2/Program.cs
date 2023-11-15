// See https://aka.ms/new-console-template for more information
namespace KrokodillespillV2
{
    class Program
    {
        private static void Main(string[] args)
        {
            Init();
        }

        static class GameState
        {
        public static int points = 0;
        }
        static void Init()
        {
            Console.WriteLine("Welcome to the Crocodile number comparison game!");
            Console.WriteLine("Choose between <, > and =");
            Run();
        }

        static int RandomizeNumber()
        {
            int number = new Random().Next(1, 11);
            return number;
        }

        static void Run()
        {
            int number1 = RandomizeNumber();
            int number2 = RandomizeNumber();
            Console.WriteLine($"{number1}_{number2}");
            var reply = Console.ReadLine();
            if (!VerifyReply(reply))
            {
                Environment.Exit(0);
            }
            if (CheckIfRight(number1, number2, reply))
            {
                GameState.points++;
                Console.WriteLine($"You're correct! You now have {GameState.points} point(s)");
            }
            else
            {
                GameState.points--;
                Console.WriteLine($"Oh no, that's wrong! You now have {GameState.points} point(s)");
            }
            Run();
        }

        static bool CheckIfRight(int number1, int number2, string reply)
        {
            char charReply = char.Parse(reply);
            if (number1 < number2 && charReply == '<')
            {
                return true;
            }
            else if (number1 > number2 && charReply == '>')
            {
                return true;

            }
            else if (number1 == number2 && charReply == '=')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool VerifyReply(string reply)
        {
            return reply switch
            {
                "<" => true,
                ">" => true,
                "=" => true,
                _ => false,
            };
        }
    }
}