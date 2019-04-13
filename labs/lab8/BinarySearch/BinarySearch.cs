// solution for Practice 2 & 3
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

			// Find an integer in a range specified by CompareTarget
			WriteLine("Target is at index: {0}", BinarySearch( x ));

			WriteLine("Using recursive: {0}", RecursiveBinarySearch(x, 0, x.Length-1));
        }
		
		// Binary Search method
		static int? BinarySearch( int[] array )
		{
			if( array == null ) return null;
			
			// specify initial search range (entire array)
			int first = 0;
			int last = array.Length - 1;
			
			while( first <= last )
			{
				int middle = ( first + last )/2;
				
				int result = CompareTarget( array[ middle ] );
				
				if( result > 0 )
					last = middle - 1; // search left
				else if( result < 0 )
					first = middle + 1; // search right
				else
					return middle;
			}
			
			return null;
		}
		
		// specify what counts as the target
		static int CompareTarget( int item )
		{
			// specify range
			int min = 20;
			int max = 30;
			
			if( item < min ) return -1;
			else if (item > max ) return 1;
			else return 0;
		}
		
		static int? RecursiveBinarySearch( int[] array, int first, int last)
		{
			
			if( array == null ) return null;
		
			// calculate results
			int middle = (first + last)/2;
			int result = CompareTarget( array[ middle ] );
			
			// base cases
			if( result == 0 ) return middle;
			else if ( last <= first ) return null;
			
			// recursive cases
			if( result < 0 ) return RecursiveBinarySearch( array, middle + 1, last);
			else // result > 0
				return RecursiveBinarySearch( array, first, middle - 1);
					
		}
    }
}
