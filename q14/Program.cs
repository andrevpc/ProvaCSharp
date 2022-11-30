App.Run();

public class Controller
{
    public long GetNext(long current, int move)
    {
        switch (move)
        {
            //Vi que tem que manipular o long diferente do que fiz, como não tem tempo não mudarei, mas o raciocinio está ai
            case 1:
                if(current % 8 != 0)
                    return current - 1;
                else
                    return current;
            case 2:
                if(!(0 <= current && current <= 7))
                    return current - 8;
                else
                    return current;
            case 3:
                if((current+1) % 8 != 0)
                    return current + 1;
                else
                    return current;
            case 4:
                if(!(56 <= current && current <= 64))
                    return current + 8;
                else
                    return current;
            default:
                return current;
        }
    }
}