using System;
using PrimeLibrary;

namespace ConsoleAppSearchPrimeOptimisation
{
  internal class Program
  {
    static void Main()
    {
      void Display(string message) => Console.WriteLine(message);
      Display("Optimisation de la recherche de nombres premiers");
      const int max = 100;
      for (int i = 0; i < max; i++)
      {
        if (PrimeHelper.IsPrime(i))
        {
          Display($"{i} est premier");
        }
      }

      Display($"Le temps d'exécution de la recherche de nombres premiers est de {PrimeHelper.TimeSearchForPrimeUpTo(max)}");

      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
