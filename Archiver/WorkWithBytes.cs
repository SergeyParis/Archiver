using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public static class WorkWithBytes
    {
        public static int[] FillDictionary(byte[] allSybols)
        {
            int[] dictionary = new int[256];

            foreach (byte b in allSybols)
                dictionary[b]++;

            return dictionary;
        }
        public static void SortDictionary(ref Dictionary<byte, int> dictionary)
        {
            Dictionary<byte, int> newDictionary = new Dictionary<byte, int>();

            foreach (KeyValuePair<byte, int> pair in dictionary.OrderBy(pair => pair.Value))
                newDictionary.Add(pair.Key, pair.Value);

            dictionary = newDictionary;
        }
    }
}
