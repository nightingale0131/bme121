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
            
            // generate a random int array with numbers between 0 
            // and 100
            int[] x = new int[ size ];
            for (int i = 0; i < size; i++)
				x[i] = rGen.Next(101);
			
			// print array
			foreach (int num in x)
				Write($"{num} ");
			WriteLine();
				
			// test method
			WriteLine("The minimum of the array is {0}.",
						GetMin( x , size - 1 ) );
			
        }
        
        // recursive method to return minimum value of an array
        // i is the index of the last element in the array
        static int GetMin(int[] array, int i)
        {	
			// Think of base case (the smallest sub-problem)
			if ( i == 0)
			{
				return array[ 0 ];
			}
			else
			{
				// How would you solve the problem if you had the answer
				// 	to a smaller problem?
				return Min(array[ i ], GetMin(array, i - 1));
			}
		}
    }
}

// Slide 6 in the BME 121 Tut 6 has an explanation of how the GetMin method works
