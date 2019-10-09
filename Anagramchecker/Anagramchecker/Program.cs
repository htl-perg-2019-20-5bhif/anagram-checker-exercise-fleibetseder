using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagramchecker
{
    class Program
    {
        static void Main(string[] args)
        {

            //check();
            getKnown();
        }

        public static void check()
        {
            //Input
            string val1;
            Console.Write("Enter your Word 1: ");
            val1 = Console.ReadLine();
            Console.WriteLine("Your input: {0}", val1);

            string val2;
            Console.Write("Enter your Words: ");
            val2 = Console.ReadLine();
            Console.WriteLine("Your input: {0}", val2);

            string aa = String.Concat(val1.OrderBy(c => c));
            string bb = String.Concat(val2.OrderBy(c => c));
            
            ///Check if Anagram
            if (aa == bb)
            {
                //Console.WriteLine("The words {0}", val1+ " and the Word{1}",val2+"are anagrams!");
                Console.WriteLine("The words are anagrams!");

            }
            else
            {
                //Console.WriteLine("The word {0}", val1 + " and the Word{1}", val2 + "  are no anagrams!");
                Console.WriteLine("The words are no anagrams!");

            }
        }

        public static async void getKnown()
        {
            //Read File
            var dicContent = await System.IO.File.ReadAllTextAsync("dictionary.txt");
            List<WordPair> words = new List<WordPair>();
            string []a = dicContent.Split("\n");

            for (int i=0; i<a.Length; i++)
            {
                string[] b = a[i].Split(" = ");
                WordPair wp = new WordPair();
                wp.word1 = b[0];
                wp.word2 = b[1];
                words.Add(wp);

            }

            //Input
            string val1;
            Console.Write("Enter your Word 1: ");
            val1 = Console.ReadLine();
            Console.WriteLine("Your input: {0}", val1);

            /*for(int d=0; d < words.Count; d++)
            {
                Console.WriteLine("Word 1: {0}", words[d].word2);

            }*/

            Boolean isanagram = false;
            for (int x=0; x<words.Count; x++)
            {
                string toorder = words[x].word1;
                //Console.WriteLine("Word 1: {0}", toorder);

                string aa = String.Concat(val1.OrderBy(c => c));
                string bb = String.Concat(toorder.OrderBy(c => c));
                if (aa == bb&&isanagram==false)
                {
                    Console.WriteLine("The words are anagrams!");
                    isanagram = true;
                }
            }

            if (!isanagram)
            {
                Console.WriteLine("The words are no anagrams!");
            }
        }


        
    }
}
