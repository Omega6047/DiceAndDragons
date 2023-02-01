using System;

namespace DiceAndDragons.Model
{
    class M_Dice : VM
    {

        private string _rollResult;
        public string rollResult { get => _rollResult; set => SetField(ref _rollResult, value, () => rollResult); }

        Random seed = new Random();

        public void rollDice(int min, int max)
        {
            rollResult = seed.Next(min, max+1).ToString();
        }

        public int rollStats(int min, int max)
        {
            return seed.Next(min, max + 1);
        }

    }
}
