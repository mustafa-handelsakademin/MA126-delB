using System;

class Program
{
    static void Main()
    {
        Course programming = new Course("Programmering", 2);
        Course mathematics = new Course("Matematik", 3);

        Student anna = new Student("Anna");
        Student bertil = new Student("Bertil");
        Student cecilia = new Student("Cecilia");

        Console.WriteLine("=== Anmälningar ===");

        // Anmälan via studentens Join-metod.
        anna.Join(programming);

        // Anmälan via kursens Enroll-metod.
        programming.Enroll(bertil);

        // Försök att anmäla en tredje student till en full kurs.
        cecilia.Join(programming);

        Console.WriteLine();
        Console.WriteLine("=== Dubbelanmälan ===");

        // Ska inte skapa en dubblett.
        anna.Join(programming);
        programming.Enroll(anna);

        Console.WriteLine();
        Console.WriteLine("=== Ytterligare kurs ===");

        anna.Join(mathematics);
        cecilia.Join(mathematics);

        Console.WriteLine();
        Console.WriteLine("=== Kurser ===");
        Console.WriteLine(programming);
        Console.WriteLine(mathematics);

        Console.WriteLine();
        Console.WriteLine("=== Närvaro ===");
        programming.RollCall();
        Console.WriteLine();
        mathematics.RollCall();

        Console.WriteLine();
        Console.WriteLine("=== Studentscheman ===");
        anna.Schedule();
        Console.WriteLine();
        bertil.Schedule();
        Console.WriteLine();
        cecilia.Schedule();

        Console.WriteLine();
        Console.WriteLine("=== Avanmälan ===");

        // Avanmälan via studentens Leave-metod.
        anna.Leave(programming);

        // Försök att ta bort samma student en gång till.
        anna.Leave(programming);

        // Ta bort en student via kursens Remove-metod.
        mathematics.Remove(cecilia);

        Console.WriteLine();
        Console.WriteLine("=== Resultat efter avanmälan ===");
        Console.WriteLine(programming);
        Console.WriteLine(mathematics);

        Console.WriteLine();
        programming.RollCall();
        Console.WriteLine();
        mathematics.RollCall();

        Console.WriteLine();
        anna.Schedule();
        Console.WriteLine();
        cecilia.Schedule();
    }
}