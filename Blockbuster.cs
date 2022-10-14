using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockbuster
{
    public class Blockbuster
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public void PrintMovies()
        {
            for (int i = 0; i < Movies.Count; i++)
            {
                Console.WriteLine($"\nIndex -\t{i}:\t\t\tTitle -\t {Movies[i].Title}");
            }
        }

        public Movie CheckOut()
        {
            int TitleIndex;

            //PrintMovies();
            
            while(true)
            {
                try
                {
                    Console.WriteLine("\nWhich movie would you like to check out? Select by index:");
                    TitleIndex = int.Parse(Console.ReadLine());
                    if (TitleIndex < 0 && TitleIndex > Movies.Count - 1)
                        {
                            throw new ArgumentOutOfRangeException($"{TitleIndex} is an invalid index. Index must be within range. Try again.");//this is not being called; instead it prints generic argumentoutrangeexception message
                        }
                    else
                    {
                        Movies[TitleIndex].PrintInfo();

                        Movies[TitleIndex].PrintScenes(Movies[TitleIndex].Scenes);//isnt this super jank and long?
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            /*Movies[TitleIndex].PrintInfo();
            Movies[TitleIndex].PrintScenes(Movies[TitleIndex].Scenes);//isnt this super jank and long?*/
            return Movies[TitleIndex];// what is the point of returning the movie? how do I use this in program? cw (CheckOut).Title???
            //Id rather call CheckOutAgain() here.
        }

        public bool ContinueShopping()
        {
            Console.WriteLine("\nWould you like to check out another movie? Y/N");
            string input = Console.ReadLine().ToUpper().Trim();

            if (input == "Y" || input == "YES")
            {
                return true;
            }

            else if (input == "N" || input == "NO")
            {
                Console.WriteLine("\nExiting program. Goodbye!");
                return false;
            }

            else
            {
                Console.WriteLine($"\n\"{input}\" is an invalid command. Try again.");
                return ContinueShopping();
            }
        }
    }
}
/*Lastly, create a class named Blockbuster that contains the following code: 
Member variable called List<Movie> Movies
Method called PrintMovies() -this will print all the movie titles in the Movies list along with their indexes.
Method called CheckOut() -this will call PrintMovies() and ask the user which movie they’d like to check out, get an index from the user, select a movie from the list and PrintInfo() on that movie. The method should return the Movie object selected by the user.
In your Main, create an instance of Blockbuster and manually populate its Movies list with at least 6 movies, 3 DVDs, 3 VHS all your choice.*/



/*
What will the application do?
Create an abstract Movie class with the following: 
A property for Title that’s a string 
A property for Category that’s of Enum Genre - if we haven’t covered this yet, just use a string 
An int property for RunTime (in minutes) 
A list of strings called Scenes
A virtual method called PrintInfo() that prints all properties in the class to the console save for the scenes.
A method called PrintScenes() that prints all the scenes in the list along with their index. 
An abstract method with no return type called Play() (If we haven’t covered abstract yet, just make this method virtual instead) 

Next Create a child class of Movie called VHS and code the following:
A property called CurrentScene 
A method called Play() that plays the scene at the CurrentScene and then increments CurrentScene . 
A method called Rewind() that returns nothing and sets CurrentScene to 0. 

Create a child of Movie named DVD with the following code: 
A method called Play() that takes no parameters and is void that will ask the user what scene they’d like to watch, print all the available scenes, and allow the user to select a scene from the list and print it out.

Lastly, create a class named Blockbuster that contains the following code: 
Member variable called List<Movie> Movies
Method called PrintMovies() -this will print all the movie titles in the Movies list along with their indexes.
Method called CheckOut() -this will call PrintMovies() and ask the user which movie they’d like to check out, get an index from the user, select a movie from the list and PrintInfo() on that movie. The method should return the Movie object selected by the user.
In your Main, create an instance of Blockbuster and manually populate its Movies list with at least 6 movies, 3 DVDs, 3 VHS all your choice.

Extended Exercise: 
Create a PlayWholeMovie in both VHS and DVDs to play each scene from start to finish. */