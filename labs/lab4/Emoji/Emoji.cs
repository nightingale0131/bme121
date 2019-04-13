// Emoji class for BME 121 Lab 4
// Updated: Oct 12, 2018

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			// Write face in the Emoji class
            WriteLine(Emoji.Show());
            WriteLine();
            
            Emoji.Change(@"\(>0<)/");
            WriteLine(Emoji.Show());
            
            Write(Emoji.face);
        }
        
    }
    
    static class Emoji
    {
		public static string face = "~(o.o)~";
		
		// Write method to return the emoji string
		// Note that face doesn't need to be passed in as an argument
		public static string Show()
		{
			return face;
		}
		
		// Write method to change the face field
		public static void Change(string newFace)
		{
			face = newFace;
		}
	}
}
