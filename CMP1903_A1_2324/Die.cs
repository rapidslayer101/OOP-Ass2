using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    // Die class
    internal class Die
    {
        // Die value Property
        private int _dieValue;

        // Roll dice method
        public int Roll(Random random)
        {
            _dieValue = random.Next(1, 7);
            return _dieValue;
        }

    }
    
    // DieRoller class inherits from Die class
    class DieRoller : Die
    {
        // Roll multiple dice method
        public List<int> RollMultiple(Random random, int numberOfRolls)
        {
            // roll NumberOfRolls dice and add to list
            var rollList = new List<int>();
            for (var i = 0; i < numberOfRolls; i++)
            {
                rollList.Add(Roll(random));
            }
            return rollList;
        }
    }
}
