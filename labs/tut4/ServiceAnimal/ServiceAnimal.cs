// ServiceAnimal class for BME 121 Tut 4
// Updated: Oct 3, 2018
using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
            WriteLine("How many service animals are you registering?");
            int animalCnt = Int32.Parse(ReadLine());
            
            WriteLine("Registering {0} animals \n",animalCnt);
            
            // initializing array of ServiceAnimal objects
            ServiceAnimal[] database = new ServiceAnimal[animalCnt];
            
            // filling in information
            for(int i = 0; i < animalCnt; i++)
				database[i] = new ServiceAnimal();
				
			// displaying information
			WriteLine("These are the animals you registered: ");
			for(int i = 0; i < database.Length; i++)
				WriteLine(database[i]);
        }
    }
    
    class ServiceAnimal
	{
		//FIELDS
		string gender;
		
		//METHODS
		// constructor
		public ServiceAnimal()
		{
			WriteLine("Begin registration of new animal");

			// use your method inside of your constructor to set fields
			SetGender();
			
			WriteLine(); // for aesthetic purposes
		}
		
		public ServiceAnimal(string gender)
		{
			this.gender = gender;
		}
		
		public void SetGender()
		{
			// ask user for input
			Write("Enter gender: ");
			string input = ReadLine();
			
			// continue asking if neither female or male are entered
			while(input != "female" && input != "male")
			{
				Write("Please enter female or male: ");
				input = ReadLine();
			}
			
			// set field after data has been validated
			gender = input;
		}
		
		public string GetGender()
		{
			return gender;
		}
		
		// specifying what to print out when I write the instance
		public override string ToString()
		{
			return $"{gender}";
		}
	}
}
