using ReadifyServiceHost.ReadifyRedPillReference;
using System;
using System.Linq;

namespace ReadifyServiceHost
{
	public class ReadifyService : IRedPill
	{
		public Guid WhatIsYourToken()
		{
			return Guid.Parse("eeccd875-434f-40bd-95a1-7bcbaa47a3e7");
		}

		public long FibonacciNumber(long n)
		{
			var negative = n < 0;

			if (n == 0)
			{
				return 0;
			}

			if (n == 1 || n == -1)
			{
				return 1;
			}

			long fib = 0;
			long pre = 0;
			long next = 1;

			try
			{
				for (long i = 2; i <= Math.Abs(n); i++)
				{
					if (negative)
						fib = checked(pre - next);
					else
						fib = checked(pre + next);

					pre = next;
					next = fib;
				}
			}
			catch
			{
				throw;
			}

			return fib;
		}

		public TriangleType WhatShapeIsThis(int a, int b, int c)
		{
			//Check for negative values
			if (a <= 0 || b <= 0 || c <= 0)
				return TriangleType.Error;

			//Check if sides can create a triangle
			if (((double)(a) + (double)(b)) > c && ((double)(a) + (double)(c)) > b && ((double)(b) + (double)(c)) > a)
			{
				//Check for equilateral triangle 
				if (a == b && b == c)
					return TriangleType.Equilateral;

				//Check for Isosceles triangle 
				if (a == b || b == c || a == c)
					return TriangleType.Isosceles;

				return TriangleType.Scalene;
			}

			return TriangleType.Error;
		}

		public string ReverseWords(string s)
		{
			if (s == null)
				throw new ArgumentNullException();

			var result = "";

			var word = "";
			foreach (var c in s)
			{
				if (c != ' ')
					word += c;
				else
				{
					for (int j = word.Length - 1; j >= 0; j--)
						result += word[j];

					result += " ";
					word = "";
				}
			}

			for (int j = word.Length - 1; j >= 0; j--)
				result += word[j];

			return result;
		}
	}
}
