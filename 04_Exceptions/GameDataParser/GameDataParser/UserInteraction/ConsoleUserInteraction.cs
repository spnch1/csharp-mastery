namespace GameDataParser.UserInteraction;

public class ConsoleUserInteraction : IUserInteraction
{
    public void ShowMessage(string message) => Console.WriteLine(message);

    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        ShowMessage(message);
        Console.ResetColor();
    }

    public void PromptFileName() => ShowMessage("Enter the name of the file you want to read:");

    public string ParseFileName()
    {
        bool shallStop = false;
        string? input;
        
        do
        {
            PromptFileName();
            input = Console.ReadLine();
            if (input is null)
            {
                Console.WriteLine("File name cannot be null.");
                continue;
            }
            if (input is "")
            {
                Console.WriteLine("File name cannot be empty.");
                continue;
            }
            if (!File.Exists(input))
            {
                Console.WriteLine("File not found.");
                continue;
            }
            shallStop = true;
        } while (!shallStop);

        return input!;
    }
}