using System;
using System.IO;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        // method to check if statistics file exists and create it if it doesn't with default values
        private void CheckFileExists()
        {
            // check if statistics file exists
            if (!File.Exists("statistics.txt"))
            {
                // populate statistics file with default values
                File.WriteAllText("statistics.txt", "0,0,0,0,0,0,0,0,0");
            }
        }
        
        // open file and read statistics data
        internal string[] ReadStatistics()
        {
            // call method to make sure statistics file exists to prevent errors
            CheckFileExists();
            
            // read statistics data from file called statistics.txt
            var data = File.ReadAllText("statistics.txt");
            
            // split string into array of 12 strings
            return data.Split(',');
        }
        
        // write statistics data to file, called at the end of each game
        private void WriteStatistics(int statNumber, string statData)
        {
            var stats = ReadStatistics();
            // write statistics data to file called statistics.txt
            stats[statNumber] = statData;
            File.WriteAllText("statistics.txt", string.Join(",", stats));
        }
        
        // method to increment a statistic by 1
        private void IncrementStat(int statNumber)
        {
            // get current value of statistic
            var stats = ReadStatistics();
            var stat = int.Parse(stats[statNumber]);
            
            // increment statistic
            stat++;
            
            // write new statistic number to file
            WriteStatistics(statNumber, stat.ToString());
        }
        
        // increment number of sevens out games played
        internal void SevensOutStatNumberOfGamesPlayed()
        {
            IncrementStat(0);
        }
        
        // increment number of sevens out games won by player1
        internal void SevensOutStatPlayer1Wins()
        {
            IncrementStat(1);
        }
        
        // increment number of sevens out games won by player2
        internal void SevensOutStatPlayer2Wins()
        {
            IncrementStat(2);
        }
        
        // increment number of sevens out games won by computer
        internal void SevensOutStatComputerWins()
        {
            IncrementStat(3);
        }
        
        // update sevens out high score
        internal void SevensOutStatHighScore(int score)
        {
            var stats = ReadStatistics();
            var highScore = int.Parse(stats[4]);
            
            // check if score is higher than current high score and update if necessary
            if (score > highScore)
            {
                WriteStatistics(4, score.ToString());
            }
        }

        
        // increment number of three or more games played
        internal void ThreeOrMoreStatNumberOfGamesPlayed()
        {
            IncrementStat(5);
        }
        
        // increment number of three or more games won by player1
        internal void ThreeOrMoreStatPlayer1Wins()
        {
            IncrementStat(6);
        }
        
        // increment number of three or more games won by player2
        internal void ThreeOrMoreStatPlayer2Wins()
        {
            IncrementStat(7);
        }
        
        // increment number of three or more games won by computer
        internal void ThreeOrMoreStatComputerWins()
        {
            IncrementStat(8);
        }
    }
}