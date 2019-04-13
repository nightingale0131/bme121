// Matrix class for BME 121 Lab 4
// Updated: Oct 12, 2018

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
            // generate a random matrix and print it
            double[,] A = Matrix.Init(3,5);
			Matrix.Print(A);
			WriteLine();
			
			// generate a random matrix and print it
			double[,] B = Matrix.Init(10,3);
			Matrix.Print(B);
			WriteLine();
			
			// generate a random matrix and print it
			double[,] C = Matrix.Init(3,5);
			Matrix.Print(C);
			WriteLine();
			
			// check if sameDimensions is correct
			if(Matrix.SameDimensions(A,C) == true)
			{
				WriteLine("They are the same dimension.");
			}
			else
			{
				WriteLine("They are not the same dimension.");
			}
			WriteLine();
			
			// Add A and C together
			double[,] sum = Matrix.Add(A,C);
			Matrix.Print(C);
			
        }
        
    }
    
    static class Matrix
    {
        // method for generating a random matrix
        public static double[,] Init(int rows, int cols)
        {
			Random rGen = new Random();
			double[,] matrix = new double[rows,cols];
			
			for(int i = 0; i < rows; i++)
			{
				for(int j = 0; j < cols; j++)
				{
					// generate a random double from 1-10
					matrix[i,j] = rGen.NextDouble()*10;
				}
			}
			
			return matrix;
		}
        
        // method for nicely printing out matrix like:
		// 	a b c d
		//  e f g h
		//  i j k l
		public static void Print(double[,] matrix)
		{
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);
			
			for(int r = 0; r < rows; r++)
			{
				for(int c = 0; c < cols; c++)
				{
					// nicely format the display of each element
					// 4 - number of spaces to fill in
					// F1 - float, show exactly 1 digit after the decimal
					Write("{0,4:F1} ",matrix[r,c]);
				}
				
				WriteLine();
			}
		}
		
		// method for checking if matrices A and B have the same dimensions
		// i.e. number of rows and columns match
		public static bool SameDimensions(double[,] A, double[,] B)
		{
			int rowsA = A.GetLength(0);
			int colsA = A.GetLength(1);
			
			int rowsB = B.GetLength(0);
			int colsB = B.GetLength(1);
			
			if((rowsA == rowsB) && (colsA == colsB))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		// method for adding two matrices
		public static double[,] Add(double[,] A, double[,] B)
		{
			int rows = A.GetLength(0);
			int cols = A.GetLength(1);
			
			double[,] sum = new double [rows,cols];
			
			// Check if matrices A and B are the same dimension
			// If they are not return A
			
			if(SameDimensions(A,B) == true)
			{
				for(int r = 0; r < rows; r++)
				{
					for(int c = 0; c < cols; c++)
					{
						sum[r,c] = A[r,c] + B[r,c];
					}
				}
				
				return sum;
			}
			else
			{
				return A;
			}
			
		}
	}
}
