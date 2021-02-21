using System.Collections.Generic;
using System;
// Linq is needed for ToList()
using System.Linq;

using System.IO;
using System.Threading.Tasks;

public class Permuter
{


    public Value[] Values;

    // could allow, can add duplicates
    bool Unique;

    public List<List<Value>> PermutationList = new List<List<Value>>();
    bool CreateFile;
    string FileName;




    int NumberOfElements;

    static void Main(string[] args)
    {
        Value[] yhvh = new Value[3] { Value.Yod, Value.He, Value.Vau };

        Permuter p = new Permuter(yhvh, 4, false, true, "allYHVH");
    }


    // build the array now
    public Permuter(Value[] values, int numberOfElements, bool unique = false,
    bool createFile = false, string fileName = "unnamed_permutation")
    {
        Values = values;
        NumberOfElements = numberOfElements;
        Unique = unique;
        CreateFile = createFile;
        FileName = fileName;

        if (numberOfElements < values.Length)
        {
            Console.WriteLine
            (
                @$"Cannot have only unique values in a permutation with {numberOfElements}
             elements in only { values.Length} spaces.");
            unique = false;
        }

        Add(new List<Value>(), Value.BLANK);
        print();
    }


    public void Add(List<Value> permutation, Value value)
    {
        // could use a dictionary.
        // if not duplicates check its not there already

        if (Unique)
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

        if (permutation.Count >= NumberOfElements)
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

        foreach (Value v in Values)
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

        if (CreateFile)
        {
            await File.WriteAllLinesAsync($"{FileName}.csv", perms);
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