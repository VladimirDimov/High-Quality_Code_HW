using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndCourses
{
    public class School
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 100;

        private IList<Course> courses;
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("School name cabnnot be empty.");
                }

                if (value == null)
                {
                    throw new ArgumentNullException("School name value cannot be null.");
                }

                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException(string.Format("Schhol name must have between {0} and {1} characters", NameMinLength, NameMaxLength));
                }

                this.name = value;
            }
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public void RemoveCourse(string name)
        {
            RemoveItemInIList<Course>(this.courses, x => x.Name == name );
        }

        public IList<Course> GetCourses()
        {
            return this.courses;
        }

        private void RemoveItemInIList<T>(IList<T> collection, Predicate<T> condition)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (condition(collection[i]))
                {
                    collection.RemoveAt(i);
                    return;
                }
            }

            throw new ArgumentException("Cannot remove missing item from the collection.");
        }        
    }
}
