using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football_project
{
    public class Player
    {
        // properties
        public string Name { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public string TeamName { get; set; }


        //constructor
        public Player(string name, string position, int shirtNumber, string teamName)
        {
            Name = name;
            Position = position;
            ShirtNumber = shirtNumber;
            TeamName = teamName;
        }


        //display text for lisstboxes
        public override string ToString()
        {
            return $"{Name} - {Position} - #{ShirtNumber}";
        }

    }
}
