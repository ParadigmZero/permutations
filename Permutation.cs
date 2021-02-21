public class Permutation
{
    int[] permutation = new int[4];

    char[] converted = new char[4];

    public Permutation()
    {

    }
    public void convert()
    {
        // for each value convert
        for (int i = 0; i < permutation.Length; i++)
        {
            switch (permutation[i])
            {
                case 1:
                    converted[i] = 'Y';
                    break;
                case 2:
                    converted[i] = 'H';
                    break;
                case 3:
                    converted[i] = 'V';
                    break;
            }
        }
    }

}