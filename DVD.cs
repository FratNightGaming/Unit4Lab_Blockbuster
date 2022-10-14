using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Blockbuster.Movie;

namespace Blockbuster
{
    public class DVD : Movie
    {
        public int index { get; set; }
        public DVD(string title, MovieGenre genre, int runTime, List<string> movieScenes) : base(title, genre, runTime, movieScenes)
        {
            this.Title = title;
            this.Category = genre;
            this.RunTime = runTime;
            //this.Scenes = scenes;
        }

        public override void Play()
        {

            while (true)
            {
                Console.WriteLine("\nWhat scene would you like to watch? Select index:");
                //PrintScenes(Scenes);

                while (true)
                {
                    try
                    {
                        index = int.Parse(Console.ReadLine());
                        /*if (index < 0 && index > Scenes.Count - 1)
                        {
                            throw new ArgumentOutOfRangeException($"{index} is an invalid index. Index must be within range. Try again.");
                        }*/
                        Console.WriteLine($"\nNow playing scene {index} - {Scenes[index]}");
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please enter a numeric value:");
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (ContinueWatching())
                {
                    continue;
                }

                else
                {
                    break;
                }
            }
            
            
            //(index >= 0 && index < Scenes.Count)
        }
    }
}

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
