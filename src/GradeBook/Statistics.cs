using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var x when x >= 90.0:
                        return 'A';

                    case var x when x >= 80.0:
                        return 'B';

                    case var x when x >= 70.0:
                        return 'C';
                    case var x when x >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}