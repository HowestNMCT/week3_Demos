using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Demo1_ReadCsv.Models
{
    /// <summary>
    /// Beer class from demo week 2 - python to C#
    /// </summary>
    public class Beer
    {
        //1. PROPERTIES

        #region Properties

        public string Name { get; set; } //: Simple property "prop"

        //Simple property alternative "propfull":
        //private string _name;

        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        public string Brewery { get; private set; } //Readonly property

        public double Alcohol { get; set; } //required type double

        //Extra logic in set using "propfull"
        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                if (value != "")
                {
                    this._color = value;
                }
                else
                {
                    this._color = "unknown";
                }
            }
        }

        #endregion

        //2. CONSTRUCTORS

        #region Constructors
        //each parameter has an explicit type

        public Beer(string name, string brewery, double alcoholPerc, string color)
        {
            this.Name = name;
            this.Color = color;
            this.Alcohol = alcoholPerc;
            this.Brewery = brewery;
        }

        #endregion
                
        //3. METHODS

        //default ToString (Python: def __str__(self): )
        public override string ToString()
        {
            return Name + " (" + Brewery + ")";
        }

        /// <summary>
        /// get a list of beers that comes from a csv file
        /// </summary>
        /// <returns>the list of beers that are in the csv file</returns>
        public static List<Beer> GetBeersFromCsv()
        {
            //1. Add the csv file to the project as an embedded resource
            //2. Read the file:

            

            //a. Create an empty list to hold all beer items
            List<Beer> beers = new List<Beer>();

            //b. Get the csv file from resources
            //WRONG RESOURCE ID? => System.ArgumentNullException: 'Value cannot be null. Parameter name: stream'
            //      check namespace , make sure csv file is inside Assets FROM STEP 1 (do not move the file afterwards!!),
            //      make sure it's an embedded resource (properties)
            string resourceId = "Demo1_ReadCsv.Assets.beerlist.csv"; //project_namespace.Assets.filename.extension
            var assembly = typeof(Beer).GetTypeInfo().Assembly; //get assembly via reflection
            Stream stream = assembly.GetManifestResourceStream(resourceId);

            //c. read the file
            using (var reader = new System.IO.StreamReader(stream))
            {
                //read the first line and ignore it (= title line, no data)
                reader.ReadLine();

                //read the next line (= first data line):
                string line = reader.ReadLine();

                //loop through all lines
                while(line!=null) //as long as readline() returns a value, and thus finds a line
                {
                    //split the line into parts based on the ';' char
                    string[] parts = line.Split(';');

                    try
                    {
                        //Naam van het bier;Brouwerij;% alcohol;Kleur van het bier
                        //translate csv data line to an actual beer object:
                        Beer beer = new Beer(parts[0], parts[1], Convert.ToDouble( parts[2] ), parts[3]);
                        //add to array of results:
                        beers.Add(beer);
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("error processing line: " + line);
                    }

                    //!! DO NOT FORGET !! : Read the next line! (otherwise: endless loop):
                    line = reader.ReadLine();
                }

            } //closing the file

            //AFTER the while loop, return the filled list of beers
            return beers;
        }

        /// <summary>
        /// Get a hard coded list of beer objects
        /// </summary>
        /// <returns>the list of beer objects</returns>
        public static List<Beer> GetBeers()
        {
            return new List<Beer>
            {
                new Beer("Rodenbach Grand Cru", "Rodenbach", 6, "brown"),
                new Beer("Jupiler", "InBev", 5.2, "blond"),
                new Beer("Omer", "Bockor", 8, "blond"),
                new Beer("Duvel", "Duvel Moortgat", 8.5, "")
            };
        }

        /// <summary>
        /// Get the list of beers back filtered on alcohol percentage.
        /// </summary>
        /// <param name="beers">The full list of beers to be filtered.</param>
        /// <param name="min">The minimum alcohol percentage of the beer.</param>
        /// <param name="max">The maximum alcohol percentage of the beer.</param>
        /// <returns>The filtered list of beers.</returns>
        public static List<Beer> SearchByAlcohol(List<Beer> beers, double min, double max)
        {
            //create empty list to hold filtered beers 
            List<Beer> results = new List<Beer>();

            //loop through each beer in the beers list
            //  (Python: for beer in beers: )
            foreach (Beer beer in beers)
            {
                //check if alcohol percentage of the beer is between boundaries
                if (beer.Alcohol >= min && beer.Alcohol <= max)
                {
                    //if so, add the beer to the list of results
                    results.Add(beer);
                }
            }

            //return the list of results
            return results;
        }

        /// <summary>
        /// Get the list of beers back filtered on (part of the) name.
        /// </summary>
        /// <param name="beers">Full list of beers to be filtered.</param>
        /// <param name="searchTerm">(Part of) the name of the beer(s) to search for</param>
        /// <returns></returns>
        public static List<Beer> SearchByName(List<Beer> beers, string searchTerm)
        {
            //create empty list to hold filtered beers 
            List<Beer> results = new List<Beer>();

            //loop through each beer in the beers list
            //  (Python: for beer in beers: )
            foreach (Beer beer in beers)
            {
                //check if the name in lowercase contains the lowercase characters in searchterm 
                if (beer.Name.ToLower().Contains(searchTerm.ToLower()))
                {
                    //if so, add the beer to the list of results
                    results.Add(beer);
                }
            }

            //return the list of results
            return results;
        }
    }
}
