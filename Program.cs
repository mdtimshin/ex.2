using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ex._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string secondLine = File.ReadLines("input.txt").Skip(1).First();
            string[] chisla = secondLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[chisla.Length];
            for(int count=0; count<chisla.Length; count++)
            {
                numbers[count] = int.Parse(chisla[count]);
            }
            List<int> cifri = new List<int>();
            int[] sort = new int[numbers.Length];
            numbers.CopyTo(sort, 0);
            Array.Sort(sort);
            int MAX = 0, CURRENT = 0, memory=numbers.Max();
            for(int i=0; i<sort.Length-1; i++)
            {
                if (sort[i] == sort[i + 1])
                {
                    CURRENT++;
                }
                else
                {
                    if ((CURRENT > MAX)&&(MAX!=0))
                    {
                        MAX = CURRENT;
                        memory = sort[i];
                    }
                    if((CURRENT > MAX) && (MAX == 0))
                    {
                        memory = sort[i];
                        MAX = CURRENT;
                    }
                    if ((CURRENT == MAX) && (CURRENT != 0) && (MAX != 0))
                    {
                        if (memory > sort[i])
                        {
                            memory = sort[i];
                        }
                    }
                    CURRENT = 0;
                }
            }
            if (MAX == 0)
            {
                
                for(int i = 0; i<numbers.Length; i++)
                {
                    if (numbers[i] != sort.Min())
                    {
                        cifri.Add(numbers[i]);
                    }
                }
                cifri.Add(sort.Min());
            }
            else
            {
                for(int i=0; i<numbers.Length; i++)
                {
                    if(numbers[i]!=memory)
                    cifri.Add(numbers[i]);
                }
                for (int a = 0; a <= MAX; a++)
                {
                    cifri.Add(memory);
                }
            }
            using(StreamWriter wr = new StreamWriter("output.txt"))
            {
                foreach(int n in cifri)
                {
                    wr.Write(n + " ");
                }
            }
        }
    }
}
