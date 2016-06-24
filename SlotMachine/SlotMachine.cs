using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        public int NumberOfSlots { get; set; }

        public int IconsPerSlot { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }


        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>




        public SlotMachine()
        {
            NumberOfSlots = 3;
            IconsPerSlot = 5;
            MinimumBet = 0;
            MaximumBet = 100;
        }


        private int[] icons;

        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            icons = new int[NumberOfSlots];

            Random random = new Random();


            for (int i = 0; i < NumberOfSlots; i++)
            {
                icons[i] = random.Next(IconsPerSlot) + 1;
            }
        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            // return the icon array
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()
        {
            // determine the payout
            bool matches = false;

            // first value to check against
            int tempMatchNumber = icons[0];


            // check the 2 - end of array against the first element of array
            // it will only turn true if all numbers match
            for (int i = 1; i < NumberOfSlots; i++)
            {
                if (icons[i] != tempMatchNumber)
                {
                    break;
                }

                if (i == NumberOfSlots-1)
                {
                    matches = true;
                }

            }

            if (matches)
            {
               
                return (CurrentBet * tempMatchNumber * NumberOfSlots * 1000);
            }
            else
            {
                return (0);
            }
        }



    }
}
