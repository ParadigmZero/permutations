using System.Collections.Generic;
using System;
// Linq is needed for To List
using System.Linq;

public class Permuter
{
    public List<List<Value>> PermutationList = new List<List<Value>>();
    List<Value> permutation = new List<Value>();


    // build the array now
    public Permuter()
    {
        add();
        Console.WriteLine(PermutationList.Count);

        print();
    }

    public void print()
    {
        foreach (List<Value> p in PermutationList)
        {
            render(p);
        }
    }

    public void render(List<Value> p)
    {
        foreach (Value v in p)
        {
            switch (p)
            {
                case Value.Yod:

                    return;
            }
        }
    }





    public void add()
    {
        if (permutation.Count > 3)
        {
            Console.WriteLine("Add to list");
            // clone it into a new list so the original is never modified
            PermutationList.Add(permutation.ToList());
            // snip off the last element?
            permutation.RemoveAt(permutation.Count - 1);

            return;
        }

        permutation.Add(Value.Yod);
        add();
        permutation.Add(Value.He);
        add();
        permutation.Add(Value.Vau);
        add();
    }

}