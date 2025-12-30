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
            var isValidDescription = false;
            do
            {
                Console.WriteLine("Enter the TODO description:");
                var description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Description must be non-empty");
                }
                else if (todos.Contains(description))
                {
                    Console.WriteLine($"Description must be unique " +
                                      $"(entry already exists at index {todos.IndexOf(description)})");
                }
                else
                {
                    todos.Add(description);
                    Console.WriteLine($"TODO successfully added: {description}");
                    isValidDescription = true;
                }
            } while (!isValidDescription);
            break;
        case "R":
            PrintChoice(choice);
            if (todos.Count == 0)
            {
                Console.WriteLine("Nothing to remove!");
                break;
            }
            var isValidIdx = false;
            do
            {
                var todosAmount = todos.Count;
                Console.WriteLine("Select the index of the TODO you want removed " +
                                  "(or type 'back' to cancel):");
                PrintNumeratedList(todos);

                string input = Console.ReadLine() ?? "";
                if (input.ToLower() == "back")
                    break;
                
                if (int.TryParse(input, out int idx))
                {
                    idx--;
                    if (idx < 0 || idx >= todosAmount)
                    {
                        Console.WriteLine("No such TODO.");
                    }
                    else
                    {
                        Console.WriteLine($"Removed entry #{idx + 1}: {todos[idx]}");
                        todos.RemoveAt(idx);
                        isValidIdx = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index format: must be an integer. Try again.");
                }
            } while (!isValidIdx);
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

void PrintChoice(in string choice)
{
    Console.WriteLine($"Chosen option: {choice}");
}

void PrintNumeratedList(List<string> items)
{
    if (items.Count == 0)
    {
        Console.WriteLine("No TODO entries found.");
        return;
    }
    for (int i = 0; i < items.Count; ++i)
    {
        Console.WriteLine($"{i + 1}. {items[i]}");
    }
}
