using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        // Initialize the console UI
        ConsoleUI.InitializeConsole();

        // Play the welcome audio if the file exists
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string audioPath = Path.Combine(basePath, "Assets", "ElevenLabs_Text_to_Speech_audio.wav");

        if (File.Exists(audioPath))
        {
            SoundPlayer player = new SoundPlayer(audioPath);
            player.Play();
        }
        else
        {
            ConsoleUI.ShowInfo("Audio file not found: " + audioPath);
        }

        // Display the visual banner and welcome message
        ConsoleUI.ShowBanner();
        ConsoleUI.ShowWelcome();

        // Ask for the user's name
        ConsoleUI.AskForName();
        string userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            ConsoleUI.ShowInfo("Please enter a valid name:");
            userName = Console.ReadLine();
        }

        // Greet the user and begin the chatbot
        ConsoleUI.GreetUser(userName);
        StartChat(userName);
    }

    private static void StartChat(string userName)
    {
        var responses = new Dictionary<string[], string>
        {
            { new[] { "how are you", "how do you feel" }, "I'm secure and fully patched, thanks for asking!" },
            { new[] { "purpose", "what do you do", "why are you here" }, "I'm here to teach you how to stay safe online and raise cybersecurity awareness." },
            { new[] { "what can i ask", "help", "options" }, "You can ask about passwords, phishing, safe browsing, malware, social engineering, or how to protect your devices." },
            { new[] { "password" }, "Use at least 12 characters with letters, numbers, and symbols. Avoid personal info like birthdays." },
            { new[] { "phishing", "scam", "fake email" }, "Phishing emails trick users into clicking bad links. Always verify the sender." },
            { new[] { "deez" }, "nuts!" },
            { new[] { "firewall" }, "A firewall filters your network traffic to block threats." },
            { new[] { "vpn" }, "A VPN encrypts your internet connection for secure browsing." },
            { new[] { "2fa", "two-factor" }, "2FA adds an extra verification step to secure your accounts." },
            { new[] { "ransomware" }, "Ransomware locks your files and demands payment. Backups are key!" },
            { new[] { "backup" }, "Back up your files regularly to protect against data loss." },
            { new[] { "email safety" }, "Don't click links or open attachments from unknown sources." },
            { new[] { "spam" }, "Spam emails may carry malware. Delete them immediately." },
            { new[] { "encryption" }, "Encryption protects your data by making it unreadable without a key." },
            { new[] { "identity theft" }, "Keep your personal info private to avoid identity theft." },
            { new[] { "public wifi" }, "Avoid sensitive activity on public Wi-Fi. Use a VPN if needed." },
            { new[] { "social media" }, "Limit what you share on social media to avoid oversharing." },
            { new[] { "antivirus" }, "Antivirus software helps detect and remove threats." },
            { new[] { "trojan" }, "A Trojan disguises itself as legitimate software to cause harm." },
            { new[] { "keylogger" }, "Keyloggers secretly record your keystrokes. Use antivirus to catch them." },
            { new[] { "browser extension" }, "Only install browser extensions from trusted sources." },
            { new[] { "cookies" }, "Cookies store user data. Clear them regularly for privacy." },
            { new[] { "ad blocker" }, "Ad blockers prevent malicious ads from loading." },
            { new[] { "cyber attack" }, "Cyber attacks aim to steal, damage, or disrupt data or systems." },
            { new[] { "zero-day" }, "A zero-day is an unpatched vulnerability hackers can exploit." },
            { new[] { "clickjacking" }, "Clickjacking tricks users into clicking something harmful." },
            { new[] { "fake website" }, "Always double-check URLs to avoid fake websites." },
            { new[] { "security question" }, "Choose difficult-to-guess security questions." },
            { new[] { "shoulder surfing" }, "Watch out for people looking over your shoulder in public." },
            { new[] { "banking security" }, "Use your bank’s mobile app and enable transaction alerts." },
            { new[] { "smishing" }, "Smishing is phishing via SMS. Never click suspicious text links." },
            { new[] { "cyberbullying" }, "Report and block cyberbullies. Don’t engage." },
            { new[] { "device encryption" }, "Encrypt your device to secure your data even if it's stolen." },
            { new[] { "cyber hygiene" }, "Cyber hygiene includes updating passwords, scanning devices, and backing up data." },
            { new[] { "botnet" }, "Botnets are networks of infected devices controlled remotely." },
            { new[] { "browsing", "http", "safe online" }, "Use HTTPS websites and avoid clicking on unknown popups." },
            { new[] { "malware", "virus" }, "Malware is software designed to damage or gain access to systems." },
            { new[] { "update", "patch" }, "Install updates—they fix vulnerabilities and enhance security." },
            { new[] { "social engineering", "trick" }, "Social engineering manipulates people into giving up confidential info." },
            { new[] { "mobile", "protect", "device" }, "Lock your devices, use antivirus, and avoid unknown Wi-Fi networks." }
        };
        while (true) // Start an infinite loop to keep the chatbot running until the user types "exit"
        {
            ConsoleUI.ShowChatPrompt(userName); // Show a styled message asking the user to input a question
            string input = Console.ReadLine().ToLower(); // Read user input and convert it to lowercase for easier keyword matching

            if (string.IsNullOrWhiteSpace(input)) // If the user input is empty or just spaces
            {
                ConsoleUI.ShowInfo("Please enter a valid question."); // Tell the user to type something valid
                continue; // Skip to the next iteration of the loop
            }

            if (input.Contains("exit"))
            {
                ConsoleUI.ShowInfo("Stay safe online! Goodbye!"); // Say goodbye
                break; // Exit the loop and end the chatbot
            }

            bool matched = false; // This flag keeps track of whether a keyword was matched

            // Loop through each keyword-response pair in the dictionary
            foreach (var pair in responses)
            {
                foreach (var keyword in pair.Key) // Loop through each keyword in the current pair
                {
                    if (input.Contains(keyword)) // If the user's input contains the keyword
                    {
                        Console.WriteLine(pair.Value); // Print the chatbot's corresponding response
                        matched = true; // Mark that a match was found
                        break; // Exit the keyword loop early
                    }
                }
                if (matched) break; // If a match has already been found, skip checking other pairs
            }

            if (!matched) // If no keywords were matched in the entire dictionary
            {
                ConsoleUI.ShowInfo("I didn’t quite catch that. Try asking about passwords, phishing, malware, or safe browsing.");
            }

            Thread.Sleep(300); // Add a small pause to make the chatbot feel more natural
        }
    }
}
