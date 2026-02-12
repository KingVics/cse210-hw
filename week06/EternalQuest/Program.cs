class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements:
        // 1) Added a level + title system based on points (Seeker -> Eternal Champion).
        // 2) Added milestone bonuses (+250 every 5 recorded events) for extra gamification.
        // 3) Added a new goal type: NegativeGoal, which deducts points for bad habits.
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
