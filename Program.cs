using System.Diagnostics.Metrics;

namespace Blockbuster
{
    public class Program
    {
        public string input { get; set; } = string.Empty;
        //public Movie? currentMovie { get; set; } = null;
        static void Main(string[] args)
        {
            while (true)
            {
                Blockbuster blockbuster = new Blockbuster();
                Movie currentMovie;
                //blockbuster.Movies = new List<Movie>();// only needed if I dont instantiate list inside property in Blockbust class
                blockbuster.Movies.Add(new DVD("Inception", Movie.MovieGenre.Action, 153, new List<string> { "A Dream Within A Dream", "Back to Reality", "Mombasa", "Infiltration", "City Rampage", "Snow Metropolis", "Secret Revelation", "Time" }));
                blockbuster.Movies.Add(new DVD("Hereditary", Movie.MovieGenre.Horror, 127, new List<string> { "Charlie's Dream", "House Party", "Severed", "Mrs. Robinson", "Despair", "Daemon Reborn" }));
                blockbuster.Movies.Add(new DVD("Knocked Up", Movie.MovieGenre.Comedy, 118, new List<string> { "Just Do It Already", "Somebody Got Preggers", "Seth Rogen Attempts Comedy", "Fantasy Baseball", "Water Break" }));
                blockbuster.Movies.Add(new VHS("Home Alone", Movie.MovieGenre.Comedy, 101, new List<string> { "House Party", "I Made My Parents Disappear", "Home Adventures", "House Traps", "Burglars Break In", "Burglars Break In Jail" }));
                blockbuster.Movies.Add(new VHS("Forrest Gump", Movie.MovieGenre.Drama, 174, new List<string> { "A Boy Named Forrest", "Jenny", "Run Forrest Run!", "Vietnam", "Lieutenant Dan", "Bubba Gump Shrimp", "A Life Is A Box Of Chocolates", "Conclusion" }));
                blockbuster.Movies.Add(new VHS("Her", Movie.MovieGenre.Romance, 135, new List<string> { "Lonely Life", "Relationship with a Computer", "Work Life", "Misery", "AI Expansion" }));
                //Why can't I move above code within class Program? Hoping to access "buster" within all methods in program, not just through main.

                Introduction(blockbuster);

                currentMovie = blockbuster.CheckOut();

                currentMovie.Play();

                if (!blockbuster.ContinueShopping())
                {
                    break;
                }
            }
            /*blockbuster.Movies[0].PrintScenes(blockbuster.Movies[0].Scenes);
            Console.WriteLine();
            blockbuster.Movies[1].PrintScenes(blockbuster.Movies[1].Scenes);
            Console.WriteLine();
            blockbuster.Movies[2].PrintScenes(blockbuster.Movies[2].Scenes);
            Console.WriteLine();
            blockbuster.Movies[3].PrintScenes(blockbuster.Movies[3].Scenes);
            Console.WriteLine();
            blockbuster.Movies[4].PrintScenes(blockbuster.Movies[4].Scenes);
            Console.WriteLine();
            blockbuster.Movies[5].PrintScenes(blockbuster.Movies[5].Scenes);
            Console.WriteLine();*/

        }
        //I need to input Blockbuster parameter b/c I can't access blockbuster outside of main method.
        public static void Introduction(Blockbuster b)
        {
            Console.WriteLine("\nWelcome to Blockbuster. How may we assist you today?");

            b.PrintMovies();
        }
    }
}

/*
In your Main, create an instance of Blockbuster and manually populate its Movies list with at least 6 movies, 3 DVDs, 3 VHS all your choice.
*/

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
