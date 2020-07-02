using System.Collections.Generic;

namespace GradeBook
{
    class Book 
    {
        public Book()
        {
            grades = new List<double>();
        }
        public void addGrade(double grade) {
             grades.Add(grade);
        }

        List<double> grades;
    }
}