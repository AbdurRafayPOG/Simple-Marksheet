using System;

class Marksheet
{
    public int math, oop, eng, sci, urdu, hist;
    public double per;
    public int totalMarks;

    public void Input()
    {
        math = GetValidMarks("Math");
        oop = GetValidMarks("OOP");
        eng = GetValidMarks("English");
        sci = GetValidMarks("Science");
        urdu = GetValidMarks("Urdu");
        hist = GetValidMarks("History");
    }

    private int GetValidMarks(string subject)
    {
        int marks;
        while (true)
        {
            Console.Write($"Enter marks in {subject} (out of 100): ");
            marks = Convert.ToInt32(Console.ReadLine());
            if (marks >= 0 && marks <= 100)
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter marks between 0 and 100.");
        }
        return marks;
    }

    public class Subject : Marksheet
    {
        public double CalculatePercentage()
        {
            totalMarks = math + oop + eng + sci + urdu + hist;
            per = (totalMarks * 100) / 600.0;
            return per;
        }

        public string GetGrade(int marks)
        {
            if (marks >= 90) return "A+";
            else if (marks >= 80) return "A";
            else if (marks >= 70) return "B";
            else if (marks >= 60) return "C";
            else if (marks >= 50) return "D";
            else return "F";
        }

        public bool IsPassed()
        {
            return math >= 50 && oop >= 50 && eng >= 50 && sci >= 50 && urdu >= 50 && hist >= 50;
        }
    }

    public class Display : Subject
    {
        public void ShowMarksheet()
        {
            Console.WriteLine("\n//-----Mark Sheet-----//\n");
            Console.WriteLine("Subject      Marks   Grade");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Math:        " + math + "    " + GetGrade(math));
            Console.WriteLine("OOP:         " + oop + "    " + GetGrade(oop));
            Console.WriteLine("English:     " + eng + "    " + GetGrade(eng));
            Console.WriteLine("Science:     " + sci + "    " + GetGrade(sci));
            Console.WriteLine("Urdu:        " + urdu + "    " + GetGrade(urdu));
            Console.WriteLine("History:     " + hist + "    " + GetGrade(hist));
            Console.WriteLine("\nTotal Marks: " + totalMarks + "/600");
            Console.WriteLine("Percentage:  " + per + "%");
            Console.WriteLine("Overall Grade: " + GetGrade((int)per));
            Console.WriteLine(IsPassed() ? "Status: Passed" : "Status: Failed");
        }
    }
}

class Bingo
{
    static void Main(string[] args)
    {
        Console.WriteLine("// ABDUR RAFAY //\n");
        Marksheet.Display i = new Marksheet.Display();
        i.Input();
        i.CalculatePercentage();
        i.ShowMarksheet();
        Console.Read();
    }
}
