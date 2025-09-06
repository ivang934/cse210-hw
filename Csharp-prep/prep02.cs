using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        
        int gradePercentage = int.Parse(userInput);

        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";

        int lastDigit = gradePercentage % 10;

        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time!");
        }
    }
}
