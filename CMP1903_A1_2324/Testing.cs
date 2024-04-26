using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        // Test method
        internal void TestGame()
        {
            // create a sevens out game object
            var sevensOut = new SevensOut();
            
            // run the sevens out DiceRoll test method
            var sumToCheck1 = sevensOut.TestRollDice(0);
            
            // use debug.assert on the sumToCheck variable to check if the total is 7
            Debug.Assert(sumToCheck1 == 7, "Game Error: Total is not 7");
            
            
            // create a three or more game object
            var threeOrMore = new ThreeOrMore();
            
            // run the three or more DiceRoll test method
            var sumToCheck2 = threeOrMore.TestRollDice(0);
            
            // use debug.assert on the sumToCheck variable to check if the total is 12
            Debug.Assert(sumToCheck2 == 12, "Game Error: Total is not 12");
            
            
            // write to log file if tests pass or fail
            if (sumToCheck1 == 7 && sumToCheck2 == 12)
            {
                File.WriteAllText("testLog.txt", "All tests passed");
            }
            else
            {
                if (sumToCheck1 != 7)
                {
                    File.WriteAllText("testLog.txt", "Sevens Out test failed");
                }
                else
                {
                    File.WriteAllText("testLog.txt", "Sevens Out test passed");
                }
                
                if (sumToCheck2 != 12)
                {
                    File.WriteAllText("testLog.txt", "Three Or More test failed");
                }
                else
                {
                    File.WriteAllText("testLog.txt", "Three Or More test passed");
                }
            }
            
        }
    }
}
