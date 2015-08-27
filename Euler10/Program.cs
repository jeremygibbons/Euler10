using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler10
{
    class Program
    {
        static LinkedList<long> primes;

        static void Main(string[] args)
        {
            primes = new LinkedList<long>();
            primes.AddLast(2);
            primes.AddLast(3);

            uint n;
            uint.TryParse(args[0], out n);
            
            Console.WriteLine(SumPrimesBelowLimit(n));
            Console.ReadLine();
        }

        static long SumPrimesBelowLimit(uint n)
        {
            long s = primes.Sum();
            while (true)
            {
                long p = FindNextPrime();
                if (p < n)
                    s += p;
                else
                    break;
            }
            return s;
        }

        static long FindNextPrime()
        {
            long p = primes.Last() + 2;
            while (isPrime(p) == false)
            {
                p += 2;
            }
            primes.AddLast(p);
            return p;
        }

        static bool isPrime(long p)
        {
            foreach (long n in primes)
            {
                if (p % n == 0)
                    return false;
                if (n > Math.Sqrt(p))
                    break;
            }
            return true;
        }
    }
}
