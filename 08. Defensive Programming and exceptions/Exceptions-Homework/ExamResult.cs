using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private string comments;
    private int maxGrade;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade must be greater than the minimal grade. Minimal grade value: " + minGrade);
        }

        if (grade < minGrade || grade > maxGrade)
        {
            throw new ArgumentException(string.Format("Grade must be between {0} and {1}", minGrade, maxGrade));
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Minimal grade cannot be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade 
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Maximal grade cannot be negative.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments 
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("Comments cannot be null or empty.");
            }

            this.comments = value;
        } 
    }
}