using System;
using System.Collections.Generic;

public class TicTacToe
{
    private char[,] board;
    private char currentPlayer;
    private readonly Dictionary<int, (int, int)> positionMap;
    private readonly Random random;

    public TicTacToe()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        random = new Random();

        positionMap = new Dictionary<int, (int, int)>
        {
            {7, (0, 0)}, {8, (0, 1)}, {9, (0, 2)},
            {4, (1, 0)}, {5, (1, 1)}, {6, (1, 2)},
            {1, (2, 0)}, {2, (2, 1)}, {3, (2, 2)}
        };

        InitializeBoard();
    }

    public void StartGame()
    {
        Console.WriteLine("Добрый день!");
        Console.WriteLine("Вы Человек, вы начинаете первым, сейчас вы X");
        PrintControls();
        Console.WriteLine("Игра НАЧАЛАСЬ!!!");

        while (true)
        {
            PrintBoard();

            if (currentPlayer == 'X')
            {
                HumanMove();
            }
            else
            {
                ComputerMove();
            }

            if (CheckWin())
            {
                PrintBoard();
                Console.WriteLine($"ПОБЕДИТЕЛЬ: {currentPlayer}");
                Console.WriteLine("КОНЕЦ!");
                return;
            }

            if (!HasEmptyCells())
            {
                PrintBoard();
                Console.WriteLine("НИЧЬЯ!");
                Console.WriteLine("КОНЕЦ!");
                return;
            }

            SwitchPlayer();
        }
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '-';
            }
        }
    }

    private void PrintControls()
    {
        Console.WriteLine($"Управление: {Environment.NewLine}7 8 9{Environment.NewLine}4 5 6{Environment.NewLine}1 2 3");
    }

    private void PrintBoard()
    {
        Console.WriteLine();
        Console.WriteLine($"{board[0, 0]} {board[0, 1]} {board[0, 2]}");
        Console.WriteLine($"{board[1, 0]} {board[1, 1]} {board[1, 2]}");
        Console.WriteLine($"{board[2, 0]} {board[2, 1]} {board[2, 2]}");
        Console.WriteLine();
    }

    private void HumanMove()
    {
        while (true)
        {
            Console.WriteLine("Ваш ход (1-9):");
            int move = ReadPlayerInput();

            if (IsValidMove(move))
            {
                MakeMove(move);
                return;
            }

            Console.WriteLine("Некорректный ход. Попробуйте снова.");
        }
    }

    private void ComputerMove()
    {
        Console.WriteLine("Ход компьютера...");

        while (true)
        {
            int move = random.Next(1, 10);

            if (IsValidMove(move))
            {
                MakeMove(move);
                return;
            }
        }
    }

    private int ReadPlayerInput()
    {
        while (true)
        {
            char input = Console.ReadKey(true).KeyChar;
            if (char.IsDigit(input))
            {
                Console.WriteLine(input);
                return (int)char.GetNumericValue(input);
            }
        }
    }

    private bool IsValidMove(int position)
    {
        if (!positionMap.TryGetValue(position, out var coordinates))
            return false;

        return board[coordinates.Item1, coordinates.Item2] == '-';
    }

    private void MakeMove(int position)
    {
        var (row, col) = positionMap[position];
        board[row, col] = currentPlayer;
    }

    private bool CheckWin()
    {
        // Проверка горизонталей
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
        }

        // Проверка вертикалей
        for (int j = 0; j < 3; j++)
        {
            if (board[0, j] != '-' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                return true;
        }

        // Проверка диагоналей
        if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;

        if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }

    private bool HasEmptyCells()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                    return true;
            }
        }
        return false;
    }

    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }

    public static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        game.StartGame();
    }
}