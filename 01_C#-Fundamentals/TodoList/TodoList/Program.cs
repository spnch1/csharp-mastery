Console.WriteLine("Welcome to TodoList!");

string choice;
List<string> todos = [];

do
{
    Console.WriteLine("\n[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    choice = Console.ReadKey(true).KeyChar.ToString().ToUpper();

    switch (choice)
    {
        case "S":
            PrintChoice(choice);
            PrintNumeratedList(todos);
            break;
        case "A":
            PrintChoice(choice);
            AddTodoEntry(todos);
            break;
        case "R":
            PrintChoice(choice);
            RemoveTodoEntry(todos);
            break;
        case "E":
            PrintChoice(choice);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.\n");
            break;
    }
} while (choice != "E");

Console.WriteLine("See you next time!");
Console.ReadKey(true);
return;

void PrintChoice(in string choice)
{
    Console.WriteLine($"Chosen option: {choice}");
}

void PrintNumeratedList(List<string> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("No TODO entries found.");
        return;
    }
    for (var i = 0; i < list.Count; ++i)
    {
        Console.WriteLine($"{i + 1}. {list[i]}");
    }
}

void AddTodoEntry(List<string> list)
{
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        description = Console.ReadLine()!;
    } while (!IsValidDescription(description, list));
    
    list.Add(description!);
    Console.WriteLine($"TODO successfully added: {description}");
}

void RemoveTodoEntry(List<string> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("Nothing to remove!");
        return;
    }
    var isValidIdx = false;
    do
    {
        var todosAmount = list.Count;
        Console.WriteLine("Select the index of the TODO you want removed " +
                          "(or type 'back' to cancel):");
        PrintNumeratedList(list);

        var input = Console.ReadLine();
        if (IsValueNullOrWhiteSpace(input)) continue;
        
        if (input!.ToLower() == "back")
            break;
        
        if (int.TryParse(input, out var idx))
        {
            idx--;
            if (idx < 0 || idx >= todosAmount)
            {
                Console.WriteLine("No such TODO.");
            }
            else
            {
                Console.WriteLine($"Removed entry #{idx + 1}: {list[idx]}");
                list.RemoveAt(idx);
                isValidIdx = true;
            }
        }
        else
        {
            Console.WriteLine("Invalid index format: must be an integer. Try again.");
        }
    } while (!isValidIdx);
}

bool IsValueNullOrWhiteSpace(string? s)
{
    if (!string.IsNullOrWhiteSpace(s)) return false;
    Console.WriteLine("Input must be non-empty");
    return true;
}

bool IsValidDescription(string? s, List<string> list)
{
    if (IsValueNullOrWhiteSpace(s)) return false;

    if (!list.Contains(s!)) return true;
    Console.WriteLine($"Description must be unique " +
                      $"(entry already exists at index {list.IndexOf(s!)})");
    return false;
}
