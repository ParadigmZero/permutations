using System.Collections.Generic;
using System;
// Linq is needed for To List
using System.Linq;

public class Permuter
{
    public List<List<Value>> PermutationList = new List<List<Value>>();



    // build the array now
    public Permuter()
    {

        Add(new List<Value>(), Value.BLANK);

        Console.WriteLine(PermutationList.Count);

        print();
    }


    public void Add(List<Value> permutation, Value value)
    {

        if (value != Value.BLANK)
        {
            permutation.Add(value);
        }

        if (permutation.Count > 3)
        {


            if (PermutationList.Contains(permutation))
            {
                Environment.Exit(1337);
            }
            // clone it into a new list so the original is never modified
            PermutationList.Add(permutation.ToList());
            return;
        }

        // recursive calls if the permutation is not yet length of 4
        // to build it up
        Add(permutation.ToList(), Value.Yod);
        Add(permutation.ToList(), Value.He);
        Add(permutation.ToList(), Value.Vau);
    }

    public void print()
    {
        foreach (List<Value> p in PermutationList)
        {
            Console.WriteLine(
                $"[{f(p[0])},{f(p[1])},{f(p[2])},{f(p[3])}]"
            );
        }
    }



    public string f(Value value)
    {
        switch (value)
        {
            case Value.Yod:
                return "Y";
            case Value.He:
                return "H";
            case Value.Vau:
                return "V";

        }
        throw new Exception();
        //return "ERROR";
    }
}