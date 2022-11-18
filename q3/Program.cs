using System.Collections.Generic;

App.Run();

public class BluerControl
{   
    public void ApplyBlur(byte[] data)
    {
        // for(int i=0; i<data.Length; i++)
        // {
        //     data[i] = 0;
        // }

        int[] temporario = new int[data.Length];

        for(int i=20; i<temporario.Length-20; i++)
        {
            for(int j=i-20; j<i+20; j++)
            {
                temporario[i] += data[j];
            }
            temporario[i] /= 41;
        }
        for(int i = 0; i<data.Length; i++)
        {
            data[i] = (byte)(temporario[i]);
        }
    }
}