using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Blockbuster
{
    
    public abstract class Movie
    {
        public string Title { get; set; }
        public MovieGenre Category { get; set; }
        public int RunTime { get; set; }
        public List <string> Scenes { get; set; } = new List<string>();

        public int indexGetType;

        public enum MovieGenre
        {
            Drama,
            Comedy,
            Horror,
            Romance,
            Action
        }

        public Movie(string title, MovieGenre genre, int runTime, List<string> movieScenes)
        {
            this.Title = title;
            this.Category = genre;
            this.RunTime = runTime;
            Scenes.Add("Opening Credits");//adding an opening credits scene to make sure lists are never null
            //Scenes = movieScenes;
            Scenes.AddRange(movieScenes);
        }
        
        public virtual void PrintInfo()
        {
            /*string movieType = GetType().Name;
            indexGetType = movieType.LastIndexOf(".");
            string finalMovieType = movieType.Substring(indexGetType);*/

            Console.WriteLine($"\nMovie Title: {Title} - {GetType().Name}\nCategory: {Category}\nRunTime: {RunTime} minutes\n");
        }

        public virtual void PrintScenes(List<string> sceneList)
        {
            Console.WriteLine($"List of Scenes in {Title}\n");

            for (int i = 0; i < sceneList.Count; i++)
            {
                Console.WriteLine($"Scene {i}:\t{sceneList[i]}");
            }
        }

        public abstract void Play();
        
        public bool ContinueWatching()
        {
            /*string movieType = GetType().Name;
            indexGetType = movieType.IndexOf(".");
            string finalMovieType = movieType.Substring(indexGetType);*/

            Console.WriteLine("\nWould you like to continue watching? Y/N");
            string input = Console.ReadLine().ToUpper().Trim();

            if (input == "Y" || input == "YES")
            {
                return true;
            }

            else if (input == "N" || input == "NO")
            {
                Console.WriteLine($"\nEjecting movie from {GetType().Name} player");
                return false;
            }

            else
            {
                Console.WriteLine($"\n\"{input}\" is an invalid command. Try again.");
                return ContinueWatching();
            }
        }
    }
}
/*Task: Create your own blockbuster video. Movies will come in 2 different formats: VHS and DVD. The user should be able to rent a movie from a list of movies and watch it.

What will the application do?
Create an abstract Movie class with the following: 
A property for Title that’s a string 
A property for Category that’s of Enum Genre - if we haven’t covered this yet, just use a string 
An int property for RunTime (in minutes) 
A list of strings called Scenes
A virtual method called PrintInfo() that prints all properties in the class to the console save for the scenes.
A method called PrintScenes() that prints all the scenes in the list along with their index. 
An abstract method with no return type called Play() (If we haven’t covered abstract yet, just make this method virtual instead) 


Create an Enum named Genre with the following values (for the sake of simplicity assume each movie will only have one Genre) (Also if haven’t learned enums yet just use strings) : 
Drama
Comedy 
Horror
Romance 
Action
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
