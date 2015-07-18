using System;

public class CSharpExam : Exam
{
    private const int ExamScoreMinValue = 0;
    private const int ExamScoreMaxValue = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Exam score cannot be negative.");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.Score < 0 || this.Score > 100)
        {
            throw new InvalidOperationException(
                string.Format(
                "Exam score must be between {0} and {1}",
                ExamScoreMinValue,
                ExamScoreMaxValue));
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}