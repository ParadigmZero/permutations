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
    bool unique;


    public List<List<Value>> PermutationList = new List<List<Value>>();

    public string CSV;

    bool createFile;
    string fileName;




    int numberOfElements;

    // build the array now
    public Permuter()
    {
        unique = false;



        createFile = true;

        numberOfElements = 6;

        fileName = "IChing";

        // values = new Value[3] {
        //         Value.Yod,
        //         Value.He,
        //         Value.Vau
        // }; // yields 81 permutations

        // values = new Value[4] {
        //         Value.Yod,
        //         Value.He,
        //         Value.Vau,
        //         Value.HeEarth
        // }; // yields 81 permutations

        // values = new Value[4] {
        //         Value.Fire,
        //         Value.Water,
        //         Value.Air,
        //         Value.Earth
        // };

        values = new Value[2] {
                Value.Yin,
                Value.Yang
        };

        // values = new Value[1]
        // {
        //     Value.Fire
        // }; // yields one permutation as expected

        if (numberOfElements < values.Length)
        {
            Console.WriteLine
            ($"Cannot have only unique values in each permutation with {numberOfElements} in only {values.Length} spaces");
            unique = false;
        }

        Add(new List<Value>(), Value.BLANK);
        print();
    }


    public void Add(List<Value> permutation, Value value)
    {
        // could use a dictionary.
        // if not duplicates check its not there already

        if (unique)
        {
            if (permutation.Contains(value))
            {
                return;
            }
        }


        if (value != Value.BLANK)
        {
            permutation.Add(value);
        }

        if (permutation.Count >= numberOfElements)
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

    // Print further refines the list
    // for instance, in YHVH there are two Hehs,
    // however depending on how they are displayed
    // we further reduce the permutations
    public async void print()
    {

        List<string> perms = new List<string>();
        string aux = "";

        foreach (List<Value> p in PermutationList)
        {

            for (int i = 0; i < p.Count; i++)
            {
                aux += $"{f(p[i])},";
            }
            aux.Trim(',');

            // if the value is not there already add it.
            if (!perms.Contains(aux))
            {
                perms.Add(aux);
            }

            aux = "";
        }

        if (createFile)
        {
            await File.WriteAllLinesAsync($"{fileName}.csv", perms);
        }

        foreach (string s in perms)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine($"{perms.Count} permutations");
    }


    // essentially a Dictionary could just use that
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
            case Value.HeEarth:
                return "H";
            case Value.Earth:
                return "Earth";
            case Value.Water:
                return "Water";
            case Value.Air:
                return "Air";
            case Value.Fire:
                return "Fire";
            case Value.Yin:
                return "Yin";
            case Value.Yang:
                return "Yang";
        }
        // returns error with any invalid
        throw new Exception();

        //return "ToDo";
    }
}