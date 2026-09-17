using System;
using System.Diagnostics;
using System.Linq;

namespace PrimeLibrary
{
  public static class PrimeHelper
  {
    public static bool IsPrime(int number)
    {
      if (number <= 1) return false;
      if (number == 2) return true;
      if (number % 2 == 0) return false;
      for (int i = 3; i * i <= number; i += 2)
      {
        if (number % i == 0) return false;
      }

      return true;
    }

    public static string GetPrimeNumbersUpTo(int limit)
    {
      var primes = new System.Collections.Generic.List<int>();
      for (int i = 2; i <= limit; i++)
      {
        if (IsPrime(i))
        {
          primes.Add(i);
        }
      }
      return string.Join(", ", primes);
    }

    public static string GetPrimeNumbersInRange(int start, int end)
    {
      var primes = new System.Collections.Generic.List<int>();
      for (int i = start; i <= end; i++)
      {
        if (IsPrime(i))
        {
          primes.Add(i);
        }
      }
      return string.Join(", ", primes);
    }

    public static int CountPrimesUpTo(int limit)
    {
      int count = 0;
      for (int i = 2; i <= limit; i++)
      {
        if (IsPrime(i))
        {
          count++;
        }
      }
      return count;
    }

    public static int CountPrimesInRange(int start, int end)
    {
      int count = 0;
      for (int i = start; i <= end; i++)
      {
        if (IsPrime(i))
        {
          count++;
        }
      }
      return count;
    }

    public static int GetNthPrime(int n)
    {
      if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
      int count = 0;
      int number = 1;
      while (count < n)
      {
        number++;
        if (IsPrime(number))
        {
          count++;
        }
      }
      return number;
    }

    public static string GetFirstNPrimes(int n)
    {
      if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
      var primes = new System.Collections.Generic.List<int>();
      int count = 0;
      int number = 1;
      while (count < n)
      {
        number++;
        if (IsPrime(number))
        {
          primes.Add(number);
          count++;
        }
      }
      return string.Join(", ", primes);
    }

    public static string GetPrimeFactors(int number)
    {
      if (number < 2) throw new ArgumentOutOfRangeException(nameof(number), "number must be greater than 1.");
      var factors = new System.Collections.Generic.List<int>();
      for (int i = 2; i <= number; i++)
      {
        while (number % i == 0)
        {
          factors.Add(i);
          number /= i;
        }
      }
      return string.Join(", ", factors);
    }

    public static string GetPrimeFactorsInRange(int start, int end)
    {
      if (start < 2 || end < 2) throw new ArgumentOutOfRangeException("start and end must be greater than 1.");
      var factors = new System.Collections.Generic.List<int>();
      for (int i = start; i <= end; i++)
      {
        factors.AddRange(GetPrimeFactors(i).Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
      }
      return string.Join(", ", factors);
    }

    public static string GetUniquePrimeFactors(int number)
    {
      if (number < 2) throw new ArgumentOutOfRangeException(nameof(number), "number must be greater than 1.");
      var factors = new System.Collections.Generic.HashSet<int>();
      for (int i = 2; i <= number; i++)
      {
        while (number % i == 0)
        {
          factors.Add(i);
          number /= i;
        }
      }
      return string.Join(", ", factors);
    }

    public static string GetUniquePrimeFactorsInRange(int start, int end)
    {
      if (start < 2 || end < 2) throw new ArgumentOutOfRangeException("start and end must be greater than 1.");
      var factors = new System.Collections.Generic.HashSet<int>();
      for (int i = start; i <= end; i++)
      {
        factors.UnionWith(GetUniquePrimeFactors(i).Split(new[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
      }
      return string.Join(", ", factors);
    }

    public static string GetPrimeNumbersUsingSieve(int limit)
    {
      if (limit < 2) return string.Empty;
      var isPrime = new bool[limit + 1];
      for (int i = 2; i <= limit; i++) isPrime[i] = true;
      for (int i = 2; i * i <= limit; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= limit; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      var primes = new System.Collections.Generic.List<int>();
      for (int i = 2; i <= limit; i++)
      {
        if (isPrime[i])
        {
          primes.Add(i);
        }
      }
      return string.Join(", ", primes);
    }

    public static string GetPrimeNumbersUsingSieveInRange(int start, int end)
    {
      if (start < 2 || end < 2) throw new ArgumentOutOfRangeException("start and end must be greater than 1.");
      var isPrime = new bool[end + 1];
      for (int i = 2; i <= end; i++) isPrime[i] = true;
      for (int i = 2; i * i <= end; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= end; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      var primes = new System.Collections.Generic.List<int>();
      for (int i = start; i <= end; i++)
      {
        if (isPrime[i])
        {
          primes.Add(i);
        }
      }
      return string.Join(", ", primes);
    }

    public static int CountPrimesUsingSieve(int limit)
    {
      if (limit < 2) return 0;
      var isPrime = new bool[limit + 1];
      for (int i = 2; i <= limit; i++) isPrime[i] = true;
      for (int i = 2; i * i <= limit; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= limit; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      int count = 0;
      for (int i = 2; i <= limit; i++)
      {
        if (isPrime[i])
        {
          count++;
        }
      }
      return count;
    }

    public static int CountPrimesUsingSieveInRange(int start, int end)
    {
      if (start < 2 || end < 2) throw new ArgumentOutOfRangeException("start and end must be greater than 1.");
      var isPrime = new bool[end + 1];
      for (int i = 2; i <= end; i++) isPrime[i] = true;
      for (int i = 2; i * i <= end; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= end; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      int count = 0;
      for (int i = start; i <= end; i++)
      {
        if (isPrime[i])
        {
          count++;
        }
      }
      return count;
    }

    public static int GetNthPrimeUsingSieve(int n)
    {
      if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
      int limit = n * (int)System.Math.Log(n) + n * (int)System.Math.Log(System.Math.Log(n)); // Approximation of the nth prime
      var isPrime = new bool[limit + 1];
      for (int i = 2; i <= limit; i++) isPrime[i] = true;
      for (int i = 2; i * i <= limit; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= limit; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      int count = 0;
      for (int i = 2; i <= limit; i++)
      {
        if (isPrime[i])
        {
          count++;
          if (count == n)
          {
            return i;
          }
        }
      }
      throw new Exception("Nth prime not found within the estimated limit.");
    }

    public static string GetFirstNPrimesUsingSieve(int n)
    {
      if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than 0.");
      int limit = n * (int)System.Math.Log(n) + n * (int)System.Math.Log(System.Math.Log(n)); // Approximation of the nth prime
      var isPrime = new bool[limit + 1];
      for (int i = 2; i <= limit; i++) isPrime[i] = true;
      for (int i = 2; i * i <= limit; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= limit; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      var primes = new System.Collections.Generic.List<int>();
      for (int i = 2; i <= limit && primes.Count < n; i++)
      {
        if (isPrime[i])
        {
          primes.Add(i);
        }
      }
      return string.Join(", ", primes);
    }

    public static string GetPrimeFactorsUsingSieve(int number)
    {
      if (number < 2) throw new ArgumentOutOfRangeException(nameof(number), "number must be greater than 1.");
      var isPrime = new bool[number + 1];
      for (int i = 2; i <= number; i++) isPrime[i] = true;
      for (int i = 2; i * i <= number; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= number; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      var factors = new System.Collections.Generic.List<int>();
      for (int i = 2; i <= number; i++)
      {
        if (isPrime[i] && number % i == 0)
        {
          factors.Add(i);
        }
      }
      return string.Join(", ", factors);
    }

    public static string GetUniquePrimeFactorsUsingSieve(int number)
    {
      if (number < 2) throw new ArgumentOutOfRangeException(nameof(number), "number must be greater than 1.");
      var isPrime = new bool[number + 1];
      for (int i = 2; i <= number; i++) isPrime[i] = true;
      for (int i = 2; i * i <= number; i++)
      {
        if (isPrime[i])
        {
          for (int j = i * i; j <= number; j += i)
          {
            isPrime[j] = false;
          }
        }
      }
      var factors = new System.Collections.Generic.HashSet<int>();
      for (int i = 2; i <= number; i++)
      {
        if (isPrime[i] && number % i == 0)
        {
          factors.Add(i);
        }
      }
      return string.Join(", ", factors);
    }

    public static TimeSpan TimeSearchForPrimeUpTo(int limit)
    {
      var stopwatch = Stopwatch.StartNew();
      GetPrimeNumbersUpTo(limit);
      stopwatch.Stop();
      return stopwatch.Elapsed;
    }
  }
}
