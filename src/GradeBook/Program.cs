using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.addGrade(103.5);

            var grades = new List<double>() {79, 82, 0.4, 0.7, 1};
            grades.Add(0.3);

            var result = 0.0;
            foreach(var number in grades)
            {
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"The average grade is {result:N3}");
        }
    }
}
