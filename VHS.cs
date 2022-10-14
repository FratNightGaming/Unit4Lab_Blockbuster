using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockbuster
{
    public class VHS : Movie
    {
        public int CurrentScene { get; set; } = 0;

        public VHS(string title, MovieGenre genre, int runTime, List<string> movieScenes) : base(title, genre, runTime, movieScenes)//HELP?*/
        {
            this.Title = title;
            this.Category = genre;
            this.RunTime = runTime;
        }

        public override void Play()
        {
            bool goOn = true;

            Console.WriteLine("\nWould you like to start your movie? Y/N");

            string startMovieResponse = Console.ReadLine().ToUpper().Trim();

            if (startMovieResponse == "Y" || startMovieResponse == "YES")
            {
                
            }
            else
            {
                return;
            }

            while (goOn)
            {
                if (CurrentScene < Scenes.Count)
                {
                    Console.WriteLine($"\nScene {CurrentScene} - {Scenes[CurrentScene]}");//why is scenes possible null when i added a scene to constructor?
                    CurrentScene++;

                    Console.WriteLine("Would you like to watch the next scene? Y/N");
                    string nextSceneResponse = Console.ReadLine().ToUpper().Trim();

                    if (nextSceneResponse == "Y" || nextSceneResponse == "YES")
                    {
                        continue;
                    }
                    else
                    {
                        goOn = false;
                    }
                }

                else if (CurrentScene >= Scenes.Count)
                {
                    Console.WriteLine($"You have finished the movie. Please rewind to the opening scene.");
                    Console.WriteLine("Would you like to rewind? Y/N");
                    string rewindInput = Console.ReadLine().ToUpper().Trim();

                    if (rewindInput == "Y" || rewindInput == "YES")
                    {
                        Rewind();
                        continue;
                    }
                    else
                    {
                        goOn = false;
                    }
                }
            }
        }

        public void Rewind()
        {
            CurrentScene = 0;
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
