using System;

class Program
{
    static void Main(string[] args)
    {
       MathAssignment assignmentOne = new MathAssignment("7.3", " 8-19", "John Doe", "Fraction");
       Console.WriteLine( assignmentOne.GetSummary());
       Console.WriteLine(assignmentOne.GetHomeWorkList());

       WritingAssignment assignmentTwo = new WritingAssignment("The Causes of World War II by Mary Waters", "Mary Waters", "European History");
       Console.WriteLine(assignmentTwo.GetSummary());
       Console.WriteLine(assignmentTwo.GetWritingInfomation());
       
    }
}