namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 30;

        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public Student(string firstName, string lastName, IList<Exam> exams)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("First name cannot be null or empty");
                }

                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new InvalidStringLengthException("First name", NameMinLength, NameMaxLength);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Last name cannotbe null or empty");
                }

                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new InvalidStringLengthException("Last name", NameMinLength, NameMaxLength);
                }

                this.lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get
            {
                return this.exams;
            }

            private set
            {
                if (this.Exams == null)
                {
                    throw new NullReferenceException("Student exams list cannot be null.");
                }

                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams.Count == 0)
            {
                throw new ArgumentException("Student exams list is empty.");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null)
            {
                throw new NullReferenceException("Cannot calculate average on missing exams");
            }

            if (this.Exams.Count == 0)
            {
                // No exams --> return -1;
                return -1;
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}