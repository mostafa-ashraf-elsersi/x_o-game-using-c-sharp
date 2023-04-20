namespace X_O_Game
{
    internal class X_O_Game
    {
        // Fields
        private string[] grid;
        private int counter;
        private string[] input;
        private string lastInput;
        private int firstInputAsInt;
        private string playerOrder;
        private string response;


        // Class Constructor
        public X_O_Game()
        {
            Console.Title = "X_O Game";
            grid = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            counter = 1;
            lastInput = "";
            FiringGame();
        }


        // Methods
        internal void DrawingGrid()
        {
            Console.WriteLine();
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine($"             {grid[0]}             |          {grid[1]}          |          {grid[2]}          ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("     ______________________|_____________________|_____________________");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine($"             {grid[3]}             |          {grid[4]}          |          {grid[5]}          ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("     ______________________|_____________________|_____________________");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine($"             {grid[6]}             |          {grid[7]}          |          {grid[8]}          ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
            Console.WriteLine("                           |                     |                     ");
        }

        internal void GetAndSetInput()
        {
            playerOrder = (counter % 2 != 0) ? "First" : "Second";
            DrawingGrid();

            do
            {
                Console.Write($"\n {playerOrder} Player (Pos, Val): ");
                try
                {
                    input = Console.ReadLine().Trim().Split(", ");
                    input = input.ToArray();
                    input[1] = input[1].ToUpper();
                    firstInputAsInt = int.Parse(input[0]);
                }
                catch
                {
                    Console.WriteLine("\n Invalid writing way!");
                    continue;
                }

                if (!(firstInputAsInt >= 0 && firstInputAsInt <= 8))
                {
                    Console.WriteLine("\n Invalid position number!");
                    continue;
                }
                if (input[1] != "X" && input[1] != "O")
                {
                    Console.WriteLine("\n Invalid symbol! Only 'X' or 'O' are valid!");
                    continue;
                }
                if (input[1] == lastInput)
                {
                    Console.WriteLine("\n Enter the other symbol this time!");
                    continue;
                }
                if (grid[firstInputAsInt] == "X" || grid[firstInputAsInt] == "O")
                {
                    Console.WriteLine("\n Invalid overwriting! occupy empty cells!");
                    continue;
                }

                lastInput = input[1];
                grid[Array.IndexOf(grid, input[0])] = input[1];
                break;
            } while (true);

            Console.Clear();
        }

        internal bool CheckingIfThereWinner()
        {
            if ((grid[0] == grid[1] && grid[1] == grid[2]) ||
                (grid[3] == grid[4] && grid[4] == grid[5]) ||
                (grid[6] == grid[7] && grid[7] == grid[8]) ||
                (grid[0] == grid[3] && grid[3] == grid[6]) ||
                (grid[1] == grid[4] && grid[4] == grid[7]) ||
                (grid[2] == grid[5] && grid[5] == grid[8]) ||
                (grid[0] == grid[4] && grid[4] == grid[8]) ||
                (grid[2] == grid[4] && grid[4] == grid[6]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void FiringGame()
        {
            grid = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            Console.WriteLine("\n WELCOME IN THE X_O GAME:");

            while (true)
            {
                if (counter == 10)
                {
                    Console.Write("\n The game is locked! Do you want to start over (y/n)? ");
                    response = Console.ReadLine().Trim().ToLower();

                    if (response == "y")
                    {
                        counter = 1;
                        lastInput = "";
                        FiringGame();
                        break;
                    }
                    else if (response == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n Invalid input! Try again!");
                        continue;
                    }
                }
                else
                {
                    GetAndSetInput();

                    if (CheckingIfThereWinner())
                    {
                        Console.Write($"\n The winner is the {playerOrder} player! Do you want to start over (y/n)? ");
                        response = Console.ReadLine().Trim().ToLower();

                        if (response == "y")
                        {
                            counter = 1;
                            lastInput = "";
                            Console.Clear();
                            FiringGame();
                        }
                        else if (response == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n Invalid input! Try again!");
                            continue;
                        }
                        break;
                    }

                    counter += 1;
                }
            }
        }
    }
}

