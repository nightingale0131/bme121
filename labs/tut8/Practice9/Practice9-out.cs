using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			string line = "January,31,2017";
			
            // you can declare each out variable in the method
            ExtractDate(line, out string m, out int d, out int y);
            
            WriteLine($"Extracted date is: {y}-{m}-{d}"); 
		}
		
		static void ExtractDate( string date, out string month, out int day, out int year)
		{
			// break string into words
			string[] data = date.Split(',');
			
			// assign value to corresponding out argument
			month = data[0].Trim();
			day = Int32.Parse(data[1]);
			year = Int32.Parse(data[2]);
		}
    }
}
