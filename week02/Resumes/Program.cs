using System;

class Program
{
    static void Main(string[] args)
    {
         Job job1 =  new Job();
         job1._jobTitle = "Software Engineer";
         job1._company = "Microsoft";
         job1._startYear = 2020;
         job1._endYear = 2026;

         Job job2 = new Job();
         job2._jobTitle = "Data Analyst";
         job2._company = "Facebook";
         job2._startYear = 2023;
         job2._endYear = 2026;

        // job1.Display();
        // job2.Display();


        Resume myResume = new Resume();

        myResume._name = "Victor Resume";
        myResume._job.Add(job1);
        myResume._job.Add(job2);

        myResume.Display();
       
    }
}