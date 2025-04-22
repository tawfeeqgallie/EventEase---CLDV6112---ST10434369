using System;

public static class ConsoleUI
{
    // Set up console look and feel
    public static void InitializeConsole()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear(); // Apply background
        Console.Title = "Cybersecurity Awareness Chatbot";
    }

    // Display the ASCII art banner
    public static void ShowBanner()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintBorder(" WELCOME TO ");
        Console.WriteLine(@"
 ██████  ███    ██ ██████  ███████ ███    ███  █████  ███    ██ ██████  
██    ██ ████   ██ ██   ██ ██      ████  ████ ██   ██ ████   ██ ██   ██ 
██    ██ ██ ██  ██ ██   ██ █████   ██ ████ ██ ███████ ██ ██  ██ ██   ██ 
██    ██ ██  ██ ██ ██   ██ ██      ██  ██  ██ ██   ██ ██  ██ ██ ██   ██ 
 ██████  ██   ████ ██████  ███████ ██      ██ ██   ██ ██   ████ ██████  

                 ██████ ██    ██ ██████  ███████ ██████                 
                ██       ██  ██  ██   ██ ██      ██   ██                
                ██        ████   ██████  █████   ██████                 
                ██         ██    ██   ██ ██      ██   ██                
                 ██████    ██    ██████  ███████ ██   ██    
");
        PrintBorder(" CYBERSECURITY CHATBOT ");
        Console.ResetColor();
    }

    // Welcome message in cyan
    public static void ShowWelcome()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║  Welcome to the Cybersecurity Awareness Bot  ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    // Ask for the user's name
    public static void AskForName()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n▶ Please enter your name: ");
        Console.ResetColor();
    }

    // Greet the user
    public static void GreetUser(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nNice to meet you, {userName}!");
        Console.ResetColor();
    }

    // Show chat prompt
    public static void ShowChatPrompt(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\n💬 {userName}, ask a question (type 'exit' to quit): ");
        Console.ResetColor();
    }

    // Show info or warning message
    public static void ShowInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"[INFO] {message}");
        Console.ResetColor();
    }

    // Helper method to draw a boxed section header
    private static void PrintBorder(string title)
    {
        string border = new string('═', title.Length + 4);
        Console.WriteLine($"╔{border}╗");
        Console.WriteLine($"║  {title}  ║");
        Console.WriteLine($"╚{border}╝");
    }
}