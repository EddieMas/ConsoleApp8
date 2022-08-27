using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

Dictionary<string, string> slovnic = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json"));

short vibor = 0;
do
{
    do
    {
        Console.WriteLine("\nEsli hotite dobavit slovo - vvedite 1");
        Console.WriteLine("Esli hotite udalit slovo - vvedite 2");
        Console.WriteLine("Esli hotite naiti slovo - vvedite 3");
        Console.WriteLine("Esli hotite sortirovat slovo - vvedite 4");
        Console.WriteLine("Esli hotite zakonchit programu - vvedite 5: ");
        vibor = short.Parse(Console.ReadLine());
    } while (vibor < 1 || vibor > 5);
    if (vibor == 1)
    {
        Console.Write("\nVvedite angliskoe slovo: ");
        string slovo = Console.ReadLine();
        Console.Write("Vvedite perevod etogo slova: ");
        string perevod = Console.ReadLine();
        ((Dictionary<string, string>)JsonSerializer.Deserialize<Dictionary<string, string>>((string)File.ReadAllText((string)"jsonSlovnic.json"))).Add(slovo, perevod);
        Console.WriteLine("Slovo dobavilos");
    }
    else if (vibor == 2)
    {
        Console.Write("\nEnter the word to delete: ");
        string udalit = Console.ReadLine();
        foreach (var slovo_1 in JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")))
        {
            if (slovo_1.Key.ToLower().Equals(udalit.ToLower()) || slovo_1.Value.ToLower().Equals(udalit.ToLower()))
            {
                ((Dictionary<string, string>)JsonSerializer.Deserialize<Dictionary<string, string>>((string)File.ReadAllText((string)"jsonSlovnic.json"))).Remove(udalit);
                Console.WriteLine("Slovo udaleno");
                break;
            }
            if (slovo_1.Equals(JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")).Last()))
                Console.WriteLine("Nelza udalit togo chego net");
        }
    }
    else if (vibor == 3)
    {
        Console.Write("\nVvedite slovo kotoroe ichite: ");
        string poisk = Console.ReadLine();
        foreach (var slovo_2 in JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")))
        {
            if (slovo_2.Key.ToLower().Equals(poisk.ToLower()) || slovo_2.Value.ToLower().Equals(poisk.ToLower()))
            {
                Console.WriteLine($"{slovo_2.Key} - {slovo_2.Value}");
                break;
            }
            if (slovo_2.Equals(JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")).Last()))
                Console.WriteLine("Takogo slova net v slovnike");
        }
    }
    else if (vibor == 4)
    {
        short sortirovka = 0;
        do
        {
            Console.WriteLine("\nVvedite esli hotite otsortirovat angliskie slova - 1");
            Console.Write("Vvedite esli hotite otsortirovat po perevodu slova - 2");
            sortirovka = short.Parse(Console.ReadLine());
        } while (sortirovka != 1 && sortirovka != 2);

        if (sortirovka == 1)
            slovnic = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        else
            slovnic = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json")).OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Console.WriteLine("Sorting completed successfully!");
    }
} while (vibor != 5);
File.WriteAllText("jsonSlovnic.json", JsonSerializer.Serialize<Dictionary<string, string>>(JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("jsonSlovnic.json"))));