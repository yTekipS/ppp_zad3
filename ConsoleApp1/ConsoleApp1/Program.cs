// miesiac z najwiekszym zuzyciem wody 

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    List<string[]> FileLines = new List<string[]>();
    List<int> months = new List<int>();

    List<string[]> FillList()
    {
        if (File.Exists("wodociagi.txt"))
        {
            foreach (var line in File.ReadLines("wodociagi.txt"))
            {
                if (line != "")
                {
                    string[] x = line.Split(";");
                    FileLines.Add(x);
                    
                }           
            }
        }

        FileLines.RemoveAt(0);
        
        return FileLines;

    }

    void PrintList()
    {
        foreach (var line in FileLines)
        {
            Console.WriteLine("[{0}]", string.Join(", ", line));
        }
    }

    List<int>  CulcUse()
    {
        int counter = 0;
        FileLines.ForEach(line =>
        {
            for (int i = 1; i < line.Length; i++)
            {
               if(counter == 0)
                {
                    months.Add(int.Parse(line[i]));
                }
                if (counter == 1)
                {
                    months[i - 1] += int.Parse(line[i]);
                }
            }
            counter = 1;
        });
        return months;
    }
    int Check()
    {
        int position = 0;

        for (int month = 1; month < 12 ; month++)
        {
            if (months[month] >= months[position])
            {
                position = month;
            }       
        }
        return position;
    }

    public static void Main()
    {
        string[] mon = {"Styczen", "Luty", "Marzec", "Kwiecien",
                        "Maj", "Czerwiec", "Lipiec", "Sierpien",
                        "Wrzesien", "Pazdziernik", "Listopad", "Grudzien"};
        Program program = new Program();
        program.FillList();
        //program.PrintList();
        program.CulcUse();
        Console.WriteLine("[{0}]", string.Join(", ", program.months));
        Console.WriteLine("\n");
        Console.WriteLine("Miesiacem w ktory uzyto najwiecej wodu to miesiac {0}, uzyto w nim {1} kubikow wody", 
                            mon[program.Check()], program.months[program.Check()]);
    }
}