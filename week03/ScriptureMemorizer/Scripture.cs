public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');

        Console.WriteLine(wordArray);
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }


    public void HideRandomWord(int numberToHide)
    {
        Random rand = new Random();

        List<Word> visibleWords = _words.Where(w => !w.isHidden()).ToList();

        int hideCount = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < hideCount; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); 
        }
    }
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return string.Join(" ", displayWords);
    }

    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
}