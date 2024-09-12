namespace CSharpNow;

public class TernaryOperator
{
    public void Ternary()
    {
        var x = DateTime.Now.Second % 2 == 0 ? "Red" : "Blue";

        var x2 = DateTime.Now.Second % 2 == 0 
                    ? "Red" 
                    : "Blue";
    }

}
