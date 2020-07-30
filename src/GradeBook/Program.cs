using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("David's Grade Book");
            book.addGrade(89.1);
            book.addGrade(90.5);
            book.addGrade(77.5);
            book.ShowStatistics();            
        }
    }
}
