using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }


        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        // public void override InMemoryBook(double grade)
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            // Looping options:
            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }
        private List<double> grades;

        const string category = "Science";
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            
            using(var writer = File.AppendText($"{Name}.txt"))
            {
            writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();


        using(var reader = File.OpenText($"{Name}.txt"))
        {
            var line = reader.ReadLine();
            while(line != null)
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
        }

            return result;
        }
        private List<double> grades;

        const string category = "Science";
    }
}