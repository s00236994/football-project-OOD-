using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace football_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> teams = new List<Team>();
        private Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();

            SetupTeams();
            LoadTeamsToListBox();
        }

        private void SetupTeams()
        {
            //setup teams and populate them
            Team t1 = new Team("Leeds United");
            t1.AddPlayer(new Player("Ethan Ampadu", "MID", 4, "Leeds United"));
            t1.AddPlayer(new Player("Dominic Calvert-Lewin", "ST", 9, "Leeds United"));
            t1.AddPlayer(new Player("Jaka Bijol", "DEF", 15, "Leeds United"));

            Team t2 = new Team("Chelsea");
            t2.AddPlayer(new Player("Enzo Fernandez", "MID", 8, "Chelsea"));
            t2.AddPlayer(new Player("Liam Delap", "ST", 9, "Chelsea"));
            t2.AddPlayer(new Player("Reece James", "DEF", 24, "Chelsea"));

            Team t3 = new Team("Manchester City");
            t3.AddPlayer(new Player("Erling Haaland", "ST", 9, "Manchester City"));
            t3.AddPlayer(new Player("Rayan Cherki", "MID", 10, "Manchester City"));
            t3.AddPlayer(new Player("Ruben Dias", "DEF", 3, "Manchester City"));

            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

        }

        //load teams to listbox
        private void LoadTeamsToListBox()
        {
            lbxTeams.Items.Clear();


            foreach (Team t in teams)
            {
                lbxTeams.Items.Add(t);
            }
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team selectedTeam = lbxTeams.SelectedItem as Team;


            if (selectedTeam == null)
            {
                return;

            }

            lbxPlayers.Items.Clear();

            foreach (Player p in selectedTeam.Players)
            {
                lbxPlayers.Items.Add(p);
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player p = lbxPlayers.SelectedItem as Player;
            if (p == null)
            {
                MessageBox.Show("Please select a player first.");
                return;
            }

             if (PlayerAlreadySelected(p))
              {
                  MessageBox.Show("That player is already selected.");
                  return;
              }

              lbxSelectedPlayers.Items.Add(p);
            
        }

        private void btnAddRandomPlayer_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam = lbxTeams.SelectedItem as Team;
            if (selectedTeam == null)
            {
                MessageBox.Show("Please select a team first.");
                return;
            }

            if (selectedTeam.Players.Count == 0)
            {
                MessageBox.Show("The selected team has no players.");
                return;
            }

            int playerIndex = rand.Next(selectedTeam.Players.Count);
            Player randomPlayer = selectedTeam.Players[playerIndex];

            if (PlayerAlreadySelected(randomPlayer))
            {
                MessageBox.Show("That player is already selected.");
                return;
            }

            lbxSelectedPlayers.Items.Add(randomPlayer);
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player p = lbxSelectedPlayers.SelectedItem as Player;
            if (p == null)
            {
                MessageBox.Show("Select a player to remove.");
                return;
            }

            lbxSelectedPlayers.Items.Remove(p);
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            if (lbxSelectedPlayers.Items.Count == 0)
            {
                MessageBox.Show("Add at least 1 player to compare.");
                return;
            }

            string output = "";

            foreach (Player p in lbxSelectedPlayers.Items)
            {
                output += p.ToString() + Environment.NewLine;
            }

            MessageBox.Show("Selected Players:\n\n" + output);
        }

        private bool PlayerAlreadySelected(Player p)
        {
            foreach (Player existing in lbxSelectedPlayers.Items)
            {
                if (existing.Name == p.Name && existing.TeamName == p.TeamName)
                {
                    return true;
                }
            }
            return false;
        }



    }
}


