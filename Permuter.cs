public class Permuter
{
    // easier way to do permutations is to make unqiue values from
    // 1 to 4
    public Permuter()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            permute(0, "");
        }

    }

    public string permute(int i, string s)
    {
        // returns at the end
        if (s.Length < 4)
        {

        }

        return s;
    }

}