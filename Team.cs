using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football_project
{
    public class Team
    {
        // properties
        public string Name { get; set; }
        public List<Player> Players { get; set; }


        //constructor
        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public void AddPlayer(Player p)
        {
            Players.Add(p);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
