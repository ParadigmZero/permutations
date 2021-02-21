using System;
using System.Collections.Generic;

namespace permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Permuter p = new Permuter();

            //char[] elements = new char[3] { 'Y', 'H', 'V' }; 

            //loopAttempt(); Console.WriteLine("Hello World!");
        }



        public static void loopAttempt()
        {
            char[] elements = new char[3] { 'Y', 'H', 'V' };

            // a simple list can be used since each value is both key and value
            List<string> permutations = new List<string>();

            // four levels of loop to build string

            string permutation;
            // first char
            for (int i = 0; i < elements.Length; i++)
            {
                permutation = "";
                permutation += elements[i];
                //second char
                for (int j = 0; j < elements.Length; j++)
                {
                    permutation += elements[j];
                    // third char
                    for (int k = 0; k < elements.Length; k++)
                    {
                        permutation += elements[k];
                        // fourth char
                        for (int l = 0; l < elements.Length; l++)
                        {
                            permutation += elements[l];
                            // if the permutation does not contain this element already
                            // put it in a list
                            if (!permutations.Contains(permutation))
                            {
                                // not sure whether it is OK to reference
                                // to so I do toString
                                permutations.Add(permutation);
                                // permutations.Add(permutation.ToString());
                            }
                        }
                    }
                }

            }

            foreach (string p in permutations)
            {
                Console.WriteLine(p);
            }

            // how many unique permutations?
            Console.WriteLine(permutations.Count);
        }
    }
}
