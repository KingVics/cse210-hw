public class Spinner
{
    private List<string> animationString = new List<string>();

    public Spinner()
    {
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");

    }

    public List<string> GetSpinner()
    {
        return animationString;
    }
}