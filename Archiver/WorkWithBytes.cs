using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiver
{
    public static class WorkWithBytes
    {
        /// <summary>
        /// ===============================
        /// use WorkWithFile.FillDictionary()
        /// ===============================
        /// </summary>
        /// <param name="allSybols"></param>
        /// <returns></returns>
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
