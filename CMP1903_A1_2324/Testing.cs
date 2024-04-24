using System;
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
        public void TestGame()
        {   
            // Create a random object
            var random = new Random();
            
            // Create game object
            var game = new Game();
            
            // Die rolls are between 1 and 6 (inclusive)
            var die = new Die();
            Debug.Assert(die.Roll(random) >= 1 && die.Roll(random) <= 6, "Die roll is not between 1 and 6");
            
            // The total of the three dice rolls is between 3 and 18 (inclusive)
            var total = game; }
    }
}
