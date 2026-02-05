public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string title, string student, string topic) : base(student, topic)
    {
        _title = title;
    }

    public string GetWritingInfomation()
    {
        return _title;
    }
}