using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace DATN.API.Services
{
    public class LevenshteinService
    {
        string filePath = @"E:\DATN_BE\1-1000.txt";

        public int levenshteinDistanceDP(string token1, string token2)
        {
            int[,] distances = new int[(token1.Length + 1), (token2.Length + 1)];

            for (int t1 = 0; t1 < token1.Length + 1; t1++)
            {
                distances[t1, 0] = t1;
            }
            for (int t2 = 0; t2 < token2.Length + 1; t2++)
            {
                distances[0, t2] = t2;
            }
            int a = 0;
            int b = 0;
            int c = 0;
            for (int t1 = 1; t1 < token1.Length + 1; t1++)
            {
                for (int t2 = 1; t2 < token2.Length + 1; t2++)
                {
                    // = Min(a,b,c)
                    if (token1[t1 - 1] == token2[t2 - 1])
                    {
                        distances[t1, t2] = distances[(t1 - 1), (t2 - 1)];
                    }
                    else // = Min(a,b,c) + 1
                    {
                        a = distances[t1, t2 - 1];
                        b = distances[t1 - 1, t2];
                        c = distances[t1 - 1, t2 - 1];
                        if (a <= b && a <= c)
                        {
                            distances[t1, t2] = a + 1;
                        }
                        else
                        {
                            if (b <= a && b <= c)
                            {
                                distances[t1, t2] = b + 1;
                            }
                            else
                            {
                                distances[t1, t2] = c + 1;

                            }
                        }
                    }
                }              
            }
            return distances[token1.Length, token2.Length];
        }

        public List<string> calcDictDistance(string word, int numWords)
        {
            numWords = 1;
            List<string> dictWordDist = new List<string>();
                       
            int wordIdx = 0;
            List<string> closestWords = new List<string>();
            if (System.IO.File.Exists(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    int wordDistance = levenshteinDistanceDP(word, lines[i].Trim());
                    if (wordDistance >= 10) { wordDistance = 9; }
                    dictWordDist.Add(wordDistance.ToString() + "-" + lines[i].Trim());
                    wordIdx++;
                }

                //List<string> wordDetails = new List<string>();
                string[] wordDetails;
                string currWordDist = "";
                dictWordDist.Sort();
                for (int i=0; i< numWords; i++)
                {
                    currWordDist = dictWordDist[i];
                    //wordDetails = currWordDist.Split('-');
                    wordDetails = currWordDist.Split('-');
                    for (int tm=1;tm<wordDetails.Length;tm++)
                    {
                        closestWords.Add(wordDetails[tm]);
                    }
                }               

            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            return closestWords;
        }
    }
}
