using System;

namespace DobbleGenerator
{
    internal class Program
    {
        protected Program()
        {
        }

        static void Main()
        {
            Console.WriteLine("Generation of Dobble cards :");
            Console.WriteLine();
            Console.WriteLine(new DobbleGame(6));
        }
    }
}
