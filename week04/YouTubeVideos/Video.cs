public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds;

    List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
    }


    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // return list of comments
    public List<Comment> GetComments()
    {
        return _comments;
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}