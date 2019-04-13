using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
			// generate a randomly sized int array, filled with numbers
			// 	between 0 - 100
            Random rGen = new Random();
            int size = rGen.Next( 5, 20 );
            int[] x = new int[ size ];
            
            for( int i = 0; i < size; i++ )
				x[ i ] = rGen.Next( 101 );
			
			// sort array using a default method
			Array.Sort( x );
			
			// print array
			foreach( int num in x )
				Write( $"{num} " );
			WriteLine( );

			// Use your search method below to find the index
        }
    }
}
