﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCG = System.Collections.Generic;
using Motvin.Collections;

namespace HashSetBench
{
    public static class BenchUtil
    {
        public const int MaxCacheSizeInInts = 5_000_000;

        private static int[] _clearCacheArray;
        private static int[] _indicesIntoCacheArray;

        private static int _sum;

        public static void ClearCpuCaches()
        {
            if (_clearCacheArray == null)
            {
                _clearCacheArray = new int[MaxCacheSizeInInts * 2];

                // populate the array
                for (int i = 0; i < _clearCacheArray.Length; i++)
                {
                    _clearCacheArray[i] = 1;
                }

                // populate an array of indices into this array and mix up their order
                int indicesIntoCacheArraySize = _clearCacheArray.Length / 16; // assume that a cache line is at least 16 bytes long
                _indicesIntoCacheArray = new int[indicesIntoCacheArraySize];
                Random rand = new Random(89);
                int maxIdx = _indicesIntoCacheArray.Length - 1;
                for (int i = 0; i < indicesIntoCacheArraySize; i++)
                {
                    int idx = rand.Next(1, maxIdx); // don't allow 0 index because this will be the not-an-index value

                    int j = idx;
                    for (; j < indicesIntoCacheArraySize; j++)
                    {
                        if (_indicesIntoCacheArray[i] == 0)
                        {
                            _indicesIntoCacheArray[i] = idx;
                            break;
                        }
                    }

                    if (j == indicesIntoCacheArraySize)
                    {
                        // try to find a free spot going backwards
                        j = idx - 1;
                        for (; j >= 0; j--)
                        {
                            if (_indicesIntoCacheArray[i] == 0)
                            {
                                _indicesIntoCacheArray[i] = idx;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < _indicesIntoCacheArray.Length; i++)
            {
                _sum += _clearCacheArray[_indicesIntoCacheArray[i]];
            }
        }

        // make sure the minInt/maxInt range is large enough for the length of the array so that the random #'s aren't mostly already taken
        public static void PopulateIntArray(int[] dest, Random rand, int minInt, int maxInt, double uniqueValuePercent = 0)
        {
            if (uniqueValuePercent > 0)
            {
                int uniqueValuesCount = (int)(uniqueValuePercent * dest.Length);
                if (uniqueValuesCount <= 0)
                {
                    uniqueValuesCount = 1; // there must be at least one of these unique values
                }

                // first get all unique values in the uniqueValuesArray
                HashSet<int> h = new HashSet<int>();

                int cnt = 0;
                if (dest.Length == uniqueValuesCount)
                {
                    while (cnt < uniqueValuesCount)
                    {
                        int val = rand.Next(minInt, maxInt);
                        if (h.Add(val))
                        {
                            dest[cnt] = val;
                            cnt++;
                        }
                    }
                }
                else
                {
                    int[] uniqueValuesArray = new int[uniqueValuesCount];
                    while (cnt < uniqueValuesCount)
                    {
                        int val = rand.Next(minInt, maxInt);
                        if (h.Add(val))
                        {
                            uniqueValuesArray[cnt] = val;
                            cnt++;
                        }
                    }

                    PopulateIntArrayFromUniqueArray(dest, rand, uniqueValuesArray, uniqueValuesCount);
                }
            }
            else
            {
                for (int i = 0; i < dest.Length; i++)
                {
                    dest[i] = rand.Next(minInt, maxInt);
                }
            }
        }

        // put numberOfRandomValues in dest at random places (indices)
        // the random values are from minInt to maxInt
        public static void PopulateIntArrayAtRandomIndices(int[] dest, Random rand, int minInt, int maxInt, int numberOfRandomValues)
        {
            for (int i = 0; i < numberOfRandomValues; i++)
            {
                int val = rand.Next(minInt, maxInt);
                int idx = rand.Next(0, dest.Length - 1);
                dest[idx] = val;
            }
        }

        public static void PopulateIntArrayFromUniqueArray(int[] dest, Random rand, int[] uniqueValuesArray, int uniqueValuesCount)
        {
            // randomly pick an index for each value and indicate that this index is used
            bool[] isUsed = new bool[dest.Length];

            int maxIdx = dest.Length - 1;
            int cnt = 0;
            while (cnt < uniqueValuesCount)
            {
                int idx = rand.Next(0, maxIdx); // get a random dest index and place each unique value in these dest index slots
                if (!isUsed[idx])
                {
                    dest[idx] = uniqueValuesArray[cnt];
                    isUsed[idx] = true;
                    cnt++;
                }
            }

            // now loop through dest and randomly pick a value from uniqueValuesArray - these will be duplicates
            maxIdx = uniqueValuesCount - 1;
            for (int i = 0; i < dest.Length; i++)
            {
                if (isUsed[i] == false)
                {
                    int idx = rand.Next(0, maxIdx);
                    dest[i] = uniqueValuesArray[idx];
                }
            }
        }

        public static void PopulateCollections25_25_50PctUnique(int maxN, out int[] uniqueArray, out int[] mixedArray,
            SCG.HashSet<int> h, FastHashSet<int> f = null, C5.HashSet<int> c5 = null, SCG.SortedSet<int> sortedSet = null, SCG.List<int> lst = null)
        {
            uniqueArray = new int[maxN];
            mixedArray = new int[maxN];

            Random rand = new Random(89);
            BenchUtil.PopulateIntArray(uniqueArray, rand, int.MinValue, int.MaxValue, 1.0); // a array should have 100% unique values

            int uniqueValuesCount = maxN / 2; // this should produce a c array that has 50% unique values (the other 50% are duplicates), but all are actually in the uniqueArray, so 1, 1, 2, 2 would be an example of this
            if (uniqueValuesCount == 0)
            {
                uniqueValuesCount = 1;
            }
            BenchUtil.PopulateIntArrayFromUniqueArray(mixedArray, rand, uniqueArray, uniqueValuesCount);
            BenchUtil.PopulateIntArrayAtRandomIndices(mixedArray, rand, int.MinValue, int.MaxValue, maxN - uniqueValuesCount);

            if (h != null)
            {
                for (int i = 0; i < maxN; i++)
                {
                    h.Add(uniqueArray[i]);
                }
            }

            if (f != null)
            {
                for (int i = 0; i < maxN; i++)
                {
                    f.Add(uniqueArray[i]);
                }
            }

            if (c5 != null)
            {
                for (int i = 0; i < maxN; i++)
                {
                    c5.Add(uniqueArray[i]);
                }
            }

            if (sortedSet != null)
            {
                for (int i = 0; i < maxN; i++)
                {
                    sortedSet.Add(uniqueArray[i]);
                }
            }

            if (lst != null)
            {
                for (int i = 0; i < maxN; i++)
                {
                    lst.Add(uniqueArray[i]);
                }
                lst.Sort();
            }
        }
    }

    public static class StringRandUtil
    {
        public const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Space = " ";
        public const string Digits = "1234567890";
        public const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        public const string Symbols = "!@#$%^&*()_+-=[]{};':\",./<>?\\";

        public static string CreateRandomString(Random rand, int minLen, int maxLen, string[] freqArray)
        {
            int len = rand.Next(minLen, maxLen);

            StringBuilder sb = new StringBuilder(new string(' ', len));

            int maxFreq = freqArray.Length - 1;
            string s;
            for (int i = 0; i < len; i++)
            {
                if (maxFreq == 0)
                {
                    s = freqArray[0];
                }
                else
                {
                    int freq = rand.Next(0, maxFreq);
                    s = freqArray[freq];
                }
                int n = rand.Next(0, s.Length - 1);

                sb[i] = s[n];
            }

            return sb.ToString();
        }
    }
}
