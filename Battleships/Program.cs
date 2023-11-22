using System;

class MainClass
{
    static void Main(string[] args)
    {
        //1 person battleship game
        //Creates 2 boards one for the player guesses and one for where the ships are randomly placed

        char[,] actualBoard = new char[6, 6];
        char[,] board = new char[6, 6];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int x = 0; x < board.GetLength(1); x++)
            {
                board[i, x] = '.';
                actualBoard[i, x] = '.';
            }
        }


        Random random = new Random();

        //Horizontal vs Vertical
        int dir = random.Next(0, 2);

        //Vertical ship
        if (dir == 0)
        {
            int x = random.Next(0, 3);
            int y = random.Next(0, 6);

            actualBoard[x, y] = 'X';
            actualBoard[x + 1, y] = 'X';
            actualBoard[x + 2, y] = 'X';

        }
        //Horizontal ship
        else if (dir == 1)
        {
            int x = random.Next(0, 6);
            int y = random.Next(0, 3);

            actualBoard[x, y] = 'X';
            actualBoard[x, y + 1] = 'X';
            actualBoard[x, y + 2] = 'X';
        }

        int shipPieces = 3;
        int shipHits = 0;
        int guesses = 0;

        while (true)
        {
            try
            {
                drawBoard(board);
                Console.Write("Enter a letter: ");
                string colLetter = Console.ReadLine();
                colLetter = colLetter.ToUpper();
                int row = 0;

                Console.Write("Enter a number: ");
                string rowInput = Console.ReadLine();
                int col = Int32.Parse(rowInput) - 1;

                if (colLetter == "A")
                {
                    row = 0;
                }
                else if (colLetter == "B")
                {
                    row = 1;
                }
                else if (colLetter == "C")
                {
                    row = 2;
                }
                else if (colLetter == "D")
                {
                    row = 3;
                }
                else if (colLetter == "E")
                {
                    row = 4;
                }
                else if (colLetter == "F")
                {
                    row = 5;
                }


                //if the row and col is the same as the ship or water
                if (board[row, col] == '.')
                {
                    guesses++;
                    if (actualBoard[row, col] == 'X')
                    {
                        board[row, col] = 'X';
                        Console.WriteLine("Hit!");
                        shipHits++;
                        if (shipHits == shipPieces)
                        {
                            break;
                        }
                    }
                    else
                    {
                        board[row, col] = 'O';
                        Console.WriteLine("Miss!");
                    }
                }
            }
            catch
            {
                //Could implement additional exceptions but this will do for now
                Console.WriteLine("Bad input.");
            }

        }

        drawBoard(board);
        Console.WriteLine($"You won with {guesses} guesses!");


    }

    public static void drawBoard(char[,] arr)
    {
        Console.Clear();

        //This int starts from the ASCII value of 65 which is 'A'.
        int asciiVal = 65;

        Console.Write(" \t");
        for (int i = 1; i < arr.GetLength(1) + 1; i++)
        {
            Console.Write($"{i}\t");
        }
        Console.WriteLine("\n");

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            
            Console.Write($"{(char)asciiVal}\t");
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                //Changes the color of hits, misses and water.
                if (arr[i, x] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (arr[i, x] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write($"{arr[i, x]}\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            asciiVal++;
        }
    }
}