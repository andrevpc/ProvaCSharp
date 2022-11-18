using System;
using System.Linq;

double[] array = new double[]
{
    6.6, 7.2, 7.2, 8.4, 8.6, 8.4, 9.4, 9.8, 10.0
};
Console.WriteLine(mediaEspecial(array));

double mediaEspecial(double[] array)
{
    Array.Sort(array);
    int metade = (array.Count()/2)-1;
    return (array[metade] + array[metade+1] + array[metade+2]) / 3;
}