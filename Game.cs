using System;


namespace RockScissorsPaper
{
    public static class Game
    {
        public enum Gestures
        {
            Rock = 0,
            Scissors = 1,
            Paper = 2
        }

        private static readonly Random Random = new Random();
        public static Gestures RandGesture => GetRandomEnum<Gestures>();

        private static T GetRandomEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            T randomEnumType = (T) values.GetValue(Random.Next(values.Length));
            return randomEnumType;
        }

        public static byte ChooseWinner(Gestures firstGesture, Gestures secondGesture)
        {
            if ((firstGesture == Gestures.Rock && secondGesture == Gestures.Scissors) ||
                (firstGesture == Gestures.Scissors && secondGesture == Gestures.Paper) ||
                (firstGesture == Gestures.Paper && secondGesture == Gestures.Rock))
            {
                return 1;
            }

            if ((secondGesture == Gestures.Rock && firstGesture == Gestures.Scissors) ||
                (secondGesture == Gestures.Scissors && firstGesture == Gestures.Paper) ||
                (secondGesture == Gestures.Paper && firstGesture == Gestures.Rock))
            {
                return 2;
            }

            return 0;
        }
    }
}