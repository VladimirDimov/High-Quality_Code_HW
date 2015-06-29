namespace RefactoringCode
{
    public class Person
    {        
        public Gender Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return this.Name + " " + " Age=" + this.Age + " Sex=" + this.Sex;
        }
    }    
}
