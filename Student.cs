using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; }
    public List<Course> Courses { get; }

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Studenten måste ha ett namn.");
        }

        Name = name;
        Courses = new List<Course>();
    }

    public void Join(Course course)
    {
        if (course == null)
        {
            Console.WriteLine("Kursen kan inte vara null.");
            return;
        }

        course.Enroll(this);
    }

    public void Leave(Course course)
    {
        if (course == null)
        {
            Console.WriteLine("Kursen kan inte vara null.");
            return;
        }

        course.Remove(this);
    }

    public void Schedule()
    {
        Console.WriteLine($"Kurser för {Name}");

        if (Courses.Count == 0)
        {
            Console.WriteLine("Studenten går inga kurser.");
            return;
        }

        foreach (Course course in Courses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }

    public override string ToString()
    {
        return Name;
    }
}