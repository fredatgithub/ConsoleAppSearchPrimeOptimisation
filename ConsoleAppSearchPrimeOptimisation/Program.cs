using System;
using System.IO;
using System.Text;
using PrimeLibrary;

namespace ConsoleAppSearchPrimeOptimisation
{
  internal class Program
  {
    static void Main()
    {
      void Display(string message2) => Console.WriteLine(message2);
      Display("Optimisation de la recherche de nombres premiers");
      //const int max = 111;
      //for (int i = 0; i < max; i++)
      //{
      //  if (PrimeHelper.IsPrime(i))
      //  {
      //    //Display($"{i} est premier");
      //  }
      //}

      //Display($"Le temps d'exécution de la recherche de nombres premiers est de {PrimeHelper.ExecutionTimeForPrimeSearchUpTo(max)}");
      //string message = $"Pour calculer les nombres premiers de 2 à {max}, cela prends : {PrimeHelper.ExecutionTimeForPrimeSearchUpTo(max)}";
      //string filename = "PrimeExecutionTime.txt";
      //WriteToFile(filename, message);
      //Display($"Le temps d'exécution a été écrit dans le fichier {filename}");
      //Display(message);

      //Display($"Get divisors of 28: {PrimeHelper.GetDivisors(28)}");

      //Display($"Get prime divisors of 28: {PrimeHelper.GetPrimeDivisors(28)}");
      //Display($"Get non-prime divisors of 28: {PrimeHelper.GetNonPrimeDivisors(28)}");

      //Display($"Get all divisors of 109: {PrimeHelper.GetDivisorForPrimeCalculation(109)}");

      //for (int i = 11; i < 10_000; i += 2)
      //{
      //  Display($"Get all divisors of {i}: {PrimeHelper.GetDivisorForPrimeCalculation(i)}");
      //}

      const int max = 11_100;
      for (int i = 3; i < max; i += 2)
      {
        Display($"{i} est premier : {PrimeHelper.IsPrimeWithDivisors(i)}");
      }

      Display("Press any key to exit:");
      //Console.ReadKey();
    }

    private static void WriteToFile(string filename, string message, bool append = true)
    {
      try
      {
        using (StreamWriter sw = new StreamWriter(filename, append, Encoding.UTF8))
        {
          sw.WriteLine(message);
        }
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.ToString());
      }
    }
  }
}
