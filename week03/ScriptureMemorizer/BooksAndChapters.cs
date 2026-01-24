public class BooksAndChapters
{
    // Returns a list of tuples containing Reference objects and their corresponding scripture texts
    public static List<(Reference, string)> GetVerses()
    {
        return new List<(Reference, string)>
        {
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            (new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."),
            (new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
            (new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            (new Reference("Genesis", 1, 1), "In the beginning God created the heavens and the earth."),
            (new Reference("Exodus", 20, 12), "Honor your father and your mother, so that you may live long in the land the Lord your God is giving you."),
            (new Reference("Matthew", 5, 9), "Blessed are the peacemakers, for they will be called children of God."),
            (new Reference("Hebrews", 11, 1), "Now faith is confidence in what we hope for and assurance about what we do not see."),
            (new Reference("Isaiah", 40, 31), "But those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.")
        };
    }
    

    


}