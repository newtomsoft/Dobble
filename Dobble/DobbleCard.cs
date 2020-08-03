using System;
using System.Collections.Generic;
using System.Text;

namespace DobbleGenerator
{
    public class DobbleCard
    {
        public List<int> Values { get; }


        public DobbleCard() => Values = new List<int>();
        public DobbleCard(int firstValue) => Values = new List<int> { firstValue };


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var value in Values)
                stringBuilder.Append(value + "-");

            return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
        }
    }
}
