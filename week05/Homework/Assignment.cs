public class Assignment
{
    private string _student;
    private string _topic;

    public Assignment(string student, string topic)
    {
        _student = student;

        _topic = topic;
    }


    public string GetStudentName()
    {
        return _student;
    }

    public string GetSummary()
    {
        return $"{_student} - {_topic}";
    }
}