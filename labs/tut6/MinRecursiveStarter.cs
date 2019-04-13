using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
            Random rGen = new Random();
            int size = 10;
            
            // generate a random int array with numbers between 0 and 100
            int[] x = new int[ size ];
            for (int i = 0; i < size; i++)
				x[i] = rGen.Next(101);
			
			// print array
			foreach (int num in x)
				Write($"{num} ");
			WriteLine();
				
			// test method
			WriteLine($"The minimum of the array is { GetMin(  ) }.");
			
        }
        
        // recursive method to return minimum value of an array
        static int GetMin( ) // You'll need to decide what arguments are needed
        {	
			// Think of base case (the smallest sub-problem)
			
			// How would you solve the problem if you had the answer
			// 	to a smaller problem?
		}
    }
}
