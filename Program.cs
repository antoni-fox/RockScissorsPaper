﻿using System;
using static System.Byte;

namespace RockScissorsPaper
{
    internal class Program
    {
        enum GameOtions
        {
            GamerWithComputer = 1,
            TwoGamers = 2,
            TwoComupters = 3,
            Quit = 4
        }

        public static void Main(string[] args)
        {
            byte optionNumber = 0;
            while (optionNumber != 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Выберите действие:\n" +
                                  "1. Игрок против компьютера\n" +
                                  "2. Игрок против игрока\n" +
                                  "3. Компьютера против компьютеа\n" +
                                  "4. Выход");
                Console.ForegroundColor = ConsoleColor.Green;
                String consoleKeyInfo = Console.ReadLine();

                try
                {
                    if (consoleKeyInfo != null)
                    {
                        optionNumber = Parse(consoleKeyInfo);
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: Неверный формат\n", consoleKeyInfo);
                    continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: Слишком большое число\n", consoleKeyInfo);
                    continue;
                }

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch ((GameOtions) optionNumber)
                {
                    case GameOtions.GamerWithComputer:
                        GameWithComputer();
                        break;
                    case GameOtions.TwoGamers:
                        break;
                    case GameOtions.TwoComupters:
                        GameWithTwoComputers();
                        break;
                    case GameOtions.Quit:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный номер\n");
                        break;
                }
                Console.WriteLine("");
            }
        }

        public static void GameWithComputer()
        {
            Console.WriteLine("Выберите: 1. {0}; 2. {1}; 3. {2}",
                Game.Gestures.Rock.ToString(),
                Game.Gestures.Scissors.ToString(),
                Game.Gestures.Paper.ToString());

            var consoleKeyInfo = Console.ReadLine();
            byte gestureNumber = 0;
            try
            {
                if (consoleKeyInfo != null)
                {
                    gestureNumber = Parse(consoleKeyInfo);
                }
                else
                {
                    Console.WriteLine("Неверное значение");
                    return;
                }
            }
            catch (Exception e)
            {
                if (!(e is FormatException) && !(e is OverflowException)) throw;
                Console.WriteLine("Неверное значение");
                return;
            }

            if (Enum.IsDefined(typeof(Game.Gestures), (int)gestureNumber))
            {
                var firstGesture = (Game.Gestures) gestureNumber;
                var secondGesture = Game.RandGesture;
                CheckGameWinner(firstGesture, secondGesture);
                return;
            }
            
            Console.WriteLine("Неверное значение");
            
        }

        public static void GameWithTwoGamers()
        {
        }

        public static void GameWithTwoComputers()
        {
            var firstGesture = Game.RandGesture;
            var secondGesture = Game.RandGesture;
            CheckGameWinner(firstGesture, secondGesture);
        }


        public static void CheckGameWinner(Game.Gestures firstGesture, Game.Gestures secondGesture)
        {
            Console.WriteLine("Игрок 1 выбрал: {0} \nИгрок 2 выбрал: {1}", firstGesture.ToString(),
                secondGesture.ToString());
            var resultOfGame = Game.ChooseWinner(firstGesture, secondGesture);
            Console.WriteLine(((resultOfGame == 1) || (resultOfGame == 2))
                ? ("Выиграл игрок " + resultOfGame)
                : ("Ничья"));
        }
    }
}