public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;


    public MathAssignment(string textBookSection, string problems, string student, string topic) : base(student, topic)
    {
        _textBookSection = textBookSection;
        _problems = problems;   
    }


    public string GetHomeWorkList()
    {
        return $"Section {_textBookSection} {_problems}";
    }
}