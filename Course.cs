using System;
using System.Collections.Generic;

public class Course
{
    public string Name { get; }
    public int MaxSeats { get; }
    public List<Student> Students { get; }

    public Course(string name, int maxSeats)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Kursen måste ha ett namn.");
        }

        if (maxSeats < 0)
        {
            throw new ArgumentException("MaxSeats kan inte vara negativt.");
        }

        Name = name;
        MaxSeats = maxSeats;
        Students = new List<Student>();
    }

    public void Enroll(Student student)
    {
        if (student == null)
        {
            Console.WriteLine("Studenten kan inte vara null.");
            return;
        }

        if (Students.Contains(student))
        {
            Console.WriteLine($"{student.Name} går redan kursen {Name}.");
            return;
        }

        if (Students.Count >= MaxSeats)
        {
            Console.WriteLine($"Kursen {Name} är full.");
            return;
        }

        Students.Add(student);

        if (!student.Courses.Contains(this))
        {
            student.Courses.Add(this);
        }

        Console.WriteLine($"{student.Name} har anmälts till {Name}.");
    }

    public void Remove(Student student)
    {
        if (student == null)
        {
            Console.WriteLine("Studenten kan inte vara null.");
            return;
        }

        if (!Students.Contains(student))
        {
            Console.WriteLine($"{student.Name} är inte anmäld till {Name}.");
            return;
        }

        Students.Remove(student);

        if (student.Courses.Contains(this))
        {
            student.Courses.Remove(this);
        }

        Console.WriteLine($"{student.Name} har tagits bort från {Name}.");
    }

    public void RollCall()
    {
        Console.WriteLine($"Närvaro: {Name}");

        if (Students.Count == 0)
        {
            Console.WriteLine("Inga studerande är anmälda.");
            return;
        }

        foreach (Student student in Students)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }

    public override string ToString()
    {
        return $"{Name} ({Students.Count}/{MaxSeats} platser)";
    }
}