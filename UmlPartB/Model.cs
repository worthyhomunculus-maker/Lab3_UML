
using System;
using System.Collections.Generic;

public class Librarian
{
    public string Name { get; }

    public Librarian(string name)
    {
        Name = name;
    }
}

public class Library
{
    private readonly List<Librarian> members = new();

    public void Add(Librarian p)
    {
        if (!members.Contains(p))
            members.Add(p);
    }
}

public class LoanRecord
{
    public Librarian Person { get; }
    public int Value { get; }

    public LoanRecord(Librarian p, int value)
    {
        Person = p;
        Value = value;
    }
}

public class LoanBook
{
    private readonly List<LoanRecord> records = new();

    public void Add(Librarian p, int value)
    {
        records.Add(new LoanRecord(p, value));
    }

    public int Result()
    {
        int total = 0;

        foreach (var r in records)
            if (r.Value >= 5)
                total++;

        return total;
    }
}
