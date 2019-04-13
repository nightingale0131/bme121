using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            // combine object sorting with insertion sort
            // Create list of animals randomly selected from file
            List<Animal> mammals = Animal.FileToArray("animals.txt");
            
            // print out the list of mammals
            foreach( Animal animal in mammals)
            {
				WriteLine($"{animal}");
			}
			
			// TODO:
			// sort animals by weight with insertion sort
			Animal.AnimalSort( mammals );
        }
    }
    
    class Animal
    {
		// FIELDS
		string species;
		double weight;
		
		// PROPERTIES
		public string Name => species;
		public double Weight => weight;
		
		// CONSTRUCTOR
		public Animal( string name, double weight )
		{
			this.species = name;
			this.weight = weight;
		}
		
		// CLASS METHODS
		public override string ToString( )
		{
			return $"{Name,-35} {Weight,8:F1}";
		}
		
		// this method isn't provided either
		public int CompareTo( Animal b )
		{
			if( weight == b.Weight ) return 0;
			else if (weight < b.Weight ) return -1;
			else return 1; // if weight > b.Weight
		}		
		
		// STATIC METHODS
		// method to parse through a pre-formatted file and generate
		//	a list of Animal objects
		public static List<Animal> FileToArray( string path )
		{
			// initialize list
			List<Animal> animals = new List<Animal>( );
			
			// constants for code simplicity
			const FileMode open = FileMode.Open;
			const FileAccess read = FileAccess.Read;
			
			// open file for reading
			using( FileStream file = new FileStream(path, open, read) )
			{
				using( StreamReader reader = new StreamReader(file) )
				{
					// Randomly select lines to store
					Random rGen = new Random( );
					while(! reader.EndOfStream)
					{
						string line = reader.ReadLine( );
						if( rGen.Next(50) < 1 )
						{
							animals.Add(ParseLine(line));
						}
					}
				}
			}
			return animals;
		}
		
		// method to parse through file
		public static Animal ParseLine( string line )
		{
			// split words by a tab
			string[] words = line.Split('\t');
			
			// extract name and weight
			return new Animal( words[0].Trim(), Double.Parse(words[1]) );			
		}
		
		// This method isn't provided
		public static void AnimalSort( List<Animal> animals )
		{
			// some basic input checks
			if( animals == null ) return;
			if( animals.Count < 1 ) return;
			
			// insertion sort
			for( int unsortedStart = 1; unsortedStart < animals.Count; unsortedStart++)
			{
				int hole = unsortedStart;
				Animal temp = animals[ hole ];
				
				// find where temp belongs
				while( hole > 0 && temp.CompareTo( animals[ hole - 1] ) < 0 )
				{
					animals[ hole ] = animals[ hole - 1 ];
					hole = hole - 1;
				}
				
				animals[ hole ] = temp;
				
				// Can see the progress of Insertion Sort
				WriteLine($"\nIteration {unsortedStart}");
				foreach( Animal animal in animals)
				{
					WriteLine($"{animal}");
				}
			}
		}
	}
}
