// Description: http://bgcoder.com/Contests/Practice/DownloadResource/942
namespace RefactoringTaskFive
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        private static byte minSongsNumber = byte.MaxValue;

        private static void Main()
        {
            byte numberOfCats = byte.Parse(Console.ReadLine().Split(' ')[0]);
            byte numberOfSongs = byte.Parse(Console.ReadLine().Split(' ')[0]);

            if (!byte.TryParse(Console.ReadLine().Split(' ')[0], out numberOfCats))
            {
                throw new ArgumentException("Invalid number of cats input.");
            }

            if (!byte.TryParse(Console.ReadLine().Split(' ')[0], out numberOfSongs))
            {
                throw new ArgumentException("Invalid number of songs input.");
            }

            var catsAndSongsTable = new bool[numberOfCats, numberOfSongs];

            string input;
            while ((input = Console.ReadLine()) != "Mew!")
            {
                var catSong = ReadCatSong(input);
                catsAndSongsTable[catSong[0] - 1, catSong[1] - 1] = true;
            }

            if (!EachCatKnowsSong(catsAndSongsTable))
            {
                Console.WriteLine("No concert!");
                return;
            }

            GetMinSongs(catsAndSongsTable);

            Console.WriteLine(minSongsNumber);
        }

        // returns [catNumber, songNumber];
        private static int[] ReadCatSong(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Cat's song input cannot be null or empty.");
            }

            var inputSplitBySpace = input.Split(' ');
            byte catNumber;
            byte songNumber;

            if (!byte.TryParse(inputSplitBySpace[1], out catNumber))
            {
                throw new ArgumentException("Unable to read car's number from input");
            }

            if (!byte.TryParse(inputSplitBySpace[4], out songNumber))
            {
                throw new ArgumentException("Unable to read song's number from input");
            }

            return new int[] { catNumber, songNumber };
        }

        private static void GetMinSongs(bool[,] catsAndSongs)
        {
            if (catsAndSongs == null)
            {
                throw new ArgumentException("Invalid cats and songs table.");
            }

            GetMinSongsRecursive(catsAndSongs, 0, 0, new HashSet<int>());
        }

        private static void GetMinSongsRecursive(bool[,] catsAndSongs, int curCat, int curSong, HashSet<int> sungSongs)
        {
            if (curCat == catsAndSongs.GetLength(0))
            {
                minSongsNumber = (byte)Math.Min(sungSongs.Count, minSongsNumber);
                return;
            }

            for (int song = curSong; song < catsAndSongs.GetLength(1); song++)
            {
                if (catsAndSongs[curCat, song] == true)
                {
                    var copyOfSungSongs = CopyHashSet(sungSongs);
                    copyOfSungSongs.Add(song);
                    if (copyOfSungSongs.Count >= minSongsNumber)
                    {
                        return;
                    }

                    GetMinSongsRecursive(catsAndSongs, curCat + 1, 0, copyOfSungSongs);
                }
            }
        }

        private static HashSet<int> CopyHashSet(HashSet<int> sungSongs)
        {
            var copyOfHashSet = new HashSet<int>();
            foreach (var song in sungSongs)
            {
                copyOfHashSet.Add(song);
            }

            return copyOfHashSet;
        }

        private static bool EachCatKnowsSong(bool[,] catsAndSongs)
        {
            for (int cat = 0; cat < catsAndSongs.GetLength(0); cat++)
            {
                var curCatKnowsSong = false;

                for (int song = 0; song < catsAndSongs.GetLength(1); song++)
                {
                    if (catsAndSongs[cat, song] == true)
                    {
                        curCatKnowsSong = true;
                        break;
                    }
                }

                if (!curCatKnowsSong)
                {
                    return false;
                }
            }

            return true;
        }
    }
}