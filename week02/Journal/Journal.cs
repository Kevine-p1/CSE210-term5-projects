using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private Random _rand = new Random();

    public void AddEntry()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        Entry e = new Entry(prompt, response);
        _entries.Add(e);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }

        foreach (Entry e in _entries)
        {
            Console.WriteLine(e);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                writer.WriteLine(e.ToFileString());
            }
        }
        Console.WriteLine("Journal saved!");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry e = Entry.FromFileString(line);
            if (e != null)
                _entries.Add(e);
        }

        Console.WriteLine("Journal loaded!");
    }
    public void AutoBackup(string lastFilename = null)
{
    string backupFile;

    if (!string.IsNullOrEmpty(lastFilename))
    {
        string name = Path.GetFileNameWithoutExtension(lastFilename);
        string ext = Path.GetExtension(lastFilename);
        backupFile = name + "_backup" + ext;
    }
    else
    {
        backupFile = "journal_autobackup.txt";
    }

    using (StreamWriter writer = new StreamWriter(backupFile))
    {
        foreach (Entry e in _entries)
        {
            writer.WriteLine(e.ToFileString());
        }
    }
    Console.WriteLine($"Auto-backup saved to {backupFile}");
}

}
