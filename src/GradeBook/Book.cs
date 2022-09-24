using System.Collections.Generic;
namespace GradeBook;

public class Book
{
    public Book(string name)
    {
        grades = new List<double>();
        this.Name = name;
    }
    public void AddGrade(double grade)
    {
        if (grade <= 100 && grade >= 0 )
        {
            grades.Add(grade);
        }
        else 
        {
            Console.WriteLine("Invalid value");
        }
    }
    public Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;

        var index = 0;
        do
        {
            result.High = Math.Max(grades[index], result.High);
            result.Low = Math.Min(grades[index], result.Low);
            result.Average += grades[index];
            index ++;
        } while(index < grades.Count );

        result.Average /= grades.Count;
        return result;
    }

    private List<double> grades;

    public string Name;
}
