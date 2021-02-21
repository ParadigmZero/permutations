using System.Collections.Generic;
using System;
// Linq is needed for ToList()
using System.Linq;

using System.IO;
using System.Threading.Tasks;

public class Permuter
{


    public Value[] values;






    // could allow, can add duplicates
    bool uniquePermutations = false;


    public List<List<Value>> PermutationList = new List<List<Value>>();

    public string CSV;

    bool createFile = false;
    string fileName = "permutations";

    // build the array now
    public Permuter()
    {

        //         values = new Value[3] {
        //         Value.Yod,
        //         Value.He,
        //         Value.Vau
        // }; 
        // yields 81 permutations

        values = new Value[4] {
        Value.Fire,
        Value.Water,
        Value.Air,
        Value.Earth
}; // yields 256 permutations

        values = new Value[1]
        {
            Value.Fire
        };

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
        // Add(permutation.ToList(), Value.Yod);
        // Add(permutation.ToList(), Value.He);
        // Add(permutation.ToList(), Value.Vau);

        foreach (Value v in values)
        {
            Add(permutation.ToList(), v);
        }
    }

    public async void print()
    {

        foreach (List<Value> p in PermutationList)
        {
            CSV += $"{f(p[0])},{f(p[1])},{f(p[2])},{f(p[3])}\n";
        }

        Console.WriteLine(CSV);

        if (createFile)
        {
            await File.WriteAllTextAsync($"{fileName}.csv", CSV);
        }

        Console.WriteLine(PermutationList.Count);
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
        // returns error with any invalid
        //throw new Exception();

        return "ToDo";
    }
}