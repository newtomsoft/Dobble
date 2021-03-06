﻿using System.Collections.Generic;
using System.Text;

namespace DobbleGenerator
{
    public class DobbleGame
    {
        private int ValuesInCardNumber { get; }
        public List<DobbleCard> DobbleCards { get; }

        public DobbleGame(int valuesInCardNumber)
        {
            ValuesInCardNumber = valuesInCardNumber;
            DobbleCards = GenerateAllCards(valuesInCardNumber);
        }

        private List<DobbleCard> GenerateAllCards(int valuesNumber) => GenerateCardsWithSameFirstValue(valuesNumber, valuesNumber - 1);

        private List<DobbleCard> GenerateCardsWithSameFirstValue(int valuesNumber, int firstValue)
        {
            var dobbleCards = new List<DobbleCard>();
            if (valuesNumber <= 0) return dobbleCards;

            if (firstValue == 0)
            {
                for (int i = 0; i < valuesNumber; i++)
                    dobbleCards.Add(new DobbleCard(0));

                int iValue = 0;
                for (int iCard = 0; iCard < valuesNumber; iCard++)
                {
                    for (int i = 1; i < valuesNumber; i++)
                    {
                        iValue++;
                        dobbleCards[iCard].Values.Add(iValue);
                    }
                }
                return dobbleCards;
            }

            List<DobbleCard> referenceCards;
            if (firstValue == 1)
            {
                referenceCards = GenerateCardsWithSameFirstValue(valuesNumber, firstValue - 1);
                for (int i = 0; i < valuesNumber - 1; i++)
                    dobbleCards.Add(new DobbleCard(firstValue));

                for (int iCard = 0; iCard < valuesNumber - 1; iCard++)
                    for (int iValue = 0; iValue < valuesNumber - 1; iValue++)
                        dobbleCards[iCard].Values.Add(referenceCards[iValue + 1].Values[iCard + 1]);

                dobbleCards.AddRange(referenceCards);
                return dobbleCards;
            }

            referenceCards = GenerateCardsWithSameFirstValue(valuesNumber, firstValue - 1);
            for (int i = 0; i < valuesNumber - 1; i++)
                dobbleCards.Add(new DobbleCard(firstValue));

            for (int iCard = 0; iCard < valuesNumber - 1; iCard++)
                for (int iValue = 0; iValue < valuesNumber - 1; iValue++)
                    dobbleCards[iCard].Values.Add(referenceCards[(iCard + iValue) % (valuesNumber - 1)].Values[iValue + 1]);

            dobbleCards.AddRange(referenceCards);
            return dobbleCards;
        }

        public override string ToString()
        {
            const string separator = "   ";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < DobbleCards.Count - ValuesInCardNumber; i++)
            {
                stringBuilder.Append(DobbleCards[i].ToString());
                if ((i + 1) % (ValuesInCardNumber - 1) == 0)
                    stringBuilder.Append("\n");
                else
                    stringBuilder.Append(separator);
            }
            stringBuilder.Remove(stringBuilder.Length - "\n".Length, "\n".Length);
            stringBuilder.Append("\n");
            for (int i = DobbleCards.Count - ValuesInCardNumber; i < DobbleCards.Count; i++)
            {
                stringBuilder.Append(DobbleCards[i].ToString());
                stringBuilder.Append(separator);
            }
            return stringBuilder.ToString();
        }
    }
}
