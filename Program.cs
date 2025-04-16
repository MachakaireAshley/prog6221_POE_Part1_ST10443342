namespace ProgAssi
{

    using System;
    using System.Media;
    using System.Threading;
    using System.Text;

    class Program
    {
        static void Main()
        {
            // Play welcome audio
            PlayWelcomeMessage();

            // Display animated ASCII art
            DisplayAnimatedAsciiArt();

            // Get user name with validation
            string userName = GetUserName();

            // Main interaction loop
            bool continueChat = true;
            while (continueChat)
            {
                // Show main menu
                DisplayMainMenu(userName);
                string input = Console.ReadLine()?.ToLower().Trim();

                // Process main menu selection
                switch (input)
                {
                    case "1":
                    case "how are you?":
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypeLine($"\nI am good and functioning optimally, {userName}!", ConsoleColor.Green);
                        TypeLine("Ready to help with cybersecurity questions.", ConsoleColor.Green);
                        Console.ResetColor();
                        WaitForUser();
                        break;

                    case "2":
                    case "what is your purpose?":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeLine($"\n{userName}, Ashley's Cybersecurity Bot is here to:", ConsoleColor.DarkGreen);
                        TypeLine("- Educate about cybersecurity threats", ConsoleColor.Green);
                        TypeLine("- Provide practical safety tips for everyday users", ConsoleColor.Green);
                        TypeLine("- Help recognize common online scams", ConsoleColor.Green);
                        TypeLine("- Promote safe digital practices for all ages", ConsoleColor.Green);
                        TypeLine("- Empower you to take control of your online security", ConsoleColor.Green);
                        Console.ResetColor();
                        WaitForUser();
                        break;

                    case "3":
                    case "what can i ask you about?":
                        bool stayInCybersecurityMenu = true;
                        while (stayInCybersecurityMenu)
                        {
                            ShowCybersecurityMenu(userName);
                            int choice = GetValidatedMenuChoice();

                            if (choice == 6) 
                            {
                                stayInCybersecurityMenu = false;
                                continue;
                            }

                            ProcessUserChoice(choice, userName);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\n{userName}, continue with cybersecurity questions? (yes/no): ");
                            Console.ResetColor();
                            string response = Console.ReadLine()?.ToLower();

                            if (response != "yes")
                            {
                                stayInCybersecurityMenu = false;
                            }
                        }

                        break;

                    case "4":
                    case "exit":
                        continueChat = false;
                        break;

                    default:
                        Console.WriteLine("\nI didn't understand that. Please choose 1-4.");
                        break;
                }
            }
            DisplayGoodbyeMessage(userName);
            Console.ReadKey();
        }

        static void WaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress enter to continue");
            Console.ResetColor();
            Console.ReadKey();
        }
        
        static void PlayWelcomeMessage()
        {
            try
            {
                Console.WriteLine("\nInitializing cybersecurity assistant...\n");
                using (SoundPlayer player = new SoundPlayer("C:\\Users\\lab_services_student\\source\\repos\\ProgAssi\\Audio\\Welcome.wav"))
                {
                    player.Play();
                    Thread.Sleep(3000); // Allow audio to play
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio note: " + ex.Message);
            }
        }

        
        //I decided to use the switch method to create an illusion where when you begin the art changes colour before settling on the final colour
        //
        static void DisplayAnimatedAsciiArt()
        {
            string[] colors = { "Red", "Green", "Blue", "Yellow", "Cyan", "Magenta" };
            int colorIndex = 0;

            Console.WriteLine("\nLoading cybersecurity protocols...\n");

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(
                    typeof(ConsoleColor), colors[colorIndex % colors.Length]);

                switch (i % 4)
                {
                    case 0:
                        Console.WriteLine(@"
  ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗    ██║   ██████ ║███████╗██║  ██║
  ╚═════╝    ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
            ");
                        break;
                    case 1:
                        Console.WriteLine(@"
  ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗    ██║   ██████ ║███████╗██║  ██║
  ╚═════╝    ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
 ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
 ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
 ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
 ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
 ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
 ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   
            ");
                        break;
                    case 2:
                        Console.WriteLine(@"
  ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗    ██║   ██████ ║███████╗██║  ██║
  ╚═════╝    ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
 ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
 ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
 ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
 ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
 ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
 ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   
  ██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗
  ╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝
            ");
                        break;
                    case 3:
                        Console.WriteLine(@"
  ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗    ██║   ██████ ║███████╗██║  ██║
  ╚═════╝    ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
 ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
 ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
 ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
 ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
 ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
 ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   
 ██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗
 ╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝
 !!!CYBERSECURITY!!!CYBERSECURITY!!!CYBERSECURITY!!!
            ");
                        break;
                }

                Thread.Sleep(300);
                Console.Clear();
                colorIndex++;
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"
   ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗    ██║   ██████ ║███████╗██║  ██║
  ╚═════╝    ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
 ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
 ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
 ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
 ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
 ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
 ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   
 ██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗██╗
 ╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝╚═╝
 !!!CYBERSECURITY!!!CYBERSECURITY!!!CYBERSECURITY!!!
");
        }

        
        static void TypeWrite(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.ResetColor();
        }

        static void TypeLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            TypeWrite(text, color);
            Console.WriteLine();
        }


        static void ShowCybersecurityMenu(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{userName}, what cybersecurity topic would you like to learn about?");
            Console.WriteLine("┌───────────────────────────────────────────────┐");
            Console.WriteLine("│ 1. Password safety                            │");
            Console.WriteLine("│ 2. Phishing scams                             │");
            Console.WriteLine("│ 3. Safe browsing practices                    │");
            Console.WriteLine("│ 4. Social engineering                         │");
            Console.WriteLine("│ 5. Two-factor authentication                  │");
            Console.WriteLine("| 6. Back to main menu                          |");
            Console.WriteLine("└───────────────────────────────────────────────┘");
            Console.Write("\nEnter your choice (1-6): ");
            Console.ResetColor();
        }

        static void DisplayGoodbyeMessage(string userName)
        {
            
            TypeLine($"\nThank you for using Ashley's Cybersecurity Bot, {userName}!", ConsoleColor.Blue);
            TypeLine("Remember to stay vigilant online and protect your digital life.", ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("GoodBye!!");
            Console.ResetColor();
        }
        

        
        static string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("║  Welcome to Ashley's Cybersecurity Bot ║");
            Console.WriteLine("║                                        ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nTo personalize your experience, please tell me your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  Name cannot be empty. Let's try that again.");
                Console.ResetColor();
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNice to meet you, {name}! I'm here to help you stay safe online.");
            Console.ResetColor();

            return name;
        }

        static int GetValidatedMenuChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a value. Try again:");
                    Console.ResetColor();
                    continue;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 6)
                {
                    return choice;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 1-6:");
                Console.ResetColor();
            }
        }



        static void DisplayMainMenu(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n╔═══════════════════════════════════════╗");
            Console.WriteLine($"║ {userName}, how can I help you today?     ║");
            Console.WriteLine($"╠═══════════════════════════════════════╣");
            Console.WriteLine($"║ 1. How are you?                       ║");
            Console.WriteLine($"║ 2. What is your purpose?              ║");
            Console.WriteLine($"║ 3. What can I ask you about?          ║");
            Console.WriteLine($"║ 4. Exit                               ║");
            Console.WriteLine($"╚═══════════════════════════════════════╝");
            Console.Write("Enter your choice (1-4): ");
            Console.ResetColor();
        }

        static void ProcessUserChoice(int choice, string userName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n───────────────────────────────────────────────");

            switch (choice)
            {
                case 1:
                    TypeLine("\n Strong Password Guidelines:", ConsoleColor.Magenta);
                    TypeLine("- Use at least 12 characters", ConsoleColor.Magenta);
                    TypeLine("- Combine uppercase, lowercase, numbers & symbols", ConsoleColor.Magenta);
                    TypeLine("- Avoid personal information (names, birthdays)", ConsoleColor.Magenta);
                    TypeLine("- Use a unique password for each account", ConsoleColor.Magenta);
                    TypeLine("\n Pro Tip: Use passphrases like 'Coffee@RainyCapeTown2023!'", ConsoleColor.Magenta);
                    break;

                case 2:
                    TypeLine("\n How to Spot Phishing Attempts:", ConsoleColor.Magenta);
                    TypeLine("- Check sender email addresses carefully", ConsoleColor.Magenta);
                    TypeLine("- Hover over links to see actual URLs before clicking", ConsoleColor.Magenta);
                    TypeLine("- Look for poor grammar/spelling", ConsoleColor.Magenta);
                    TypeLine("- Be wary of urgent requests for personal information", ConsoleColor.Magenta);
                    TypeLine("- Verify unexpected attachments with the sender", ConsoleColor.Magenta);
                    TypeLine("- REMEMBER banks will NEVER ask for your PIN via email/SMS", ConsoleColor.Magenta);
                    break;

                case 3:
                    TypeLine("\n Safe Browsing Practices:", ConsoleColor.Magenta);
                    TypeLine("- Always look for HTTPS in website URLs", ConsoleColor.Magenta);
                    TypeLine("- Keep your browser and plugins updated", ConsoleColor.Magenta);
                    TypeLine("- Use a reputable antivirus program", ConsoleColor.Magenta);
                    TypeLine("- Avoid public Wi-Fi for sensitive transactions", ConsoleColor.Magenta);
                    TypeLine("- Clear browser cache and cookies regularly", ConsoleColor.Magenta);
                    break;

                case 4:
                    TypeLine("\n Social Engineering Awareness:", ConsoleColor.Magenta);
                    TypeLine("- Never share sensitive information over the phone", ConsoleColor.Magenta);
                    TypeLine("- Verify identities before granting access", ConsoleColor.Magenta);
                    TypeLine("- Be cautious of 'too good to be true' offers", ConsoleColor.Magenta);
                    TypeLine("- Don't plug in unknown USB devices", ConsoleColor.Magenta);
                    TypeLine("- Report suspicious requests to your IT department", ConsoleColor.Magenta);
                    break;

                case 5:
                    TypeLine("\n Two-Factor Authentication (2FA):", ConsoleColor.Magenta);
                    TypeLine("- Always enable 2FA where available", ConsoleColor.Magenta);
                    TypeLine("- Use authenticator apps instead of SMS when possible", ConsoleColor.Magenta);
                    TypeLine("- Keep backup codes in a secure place", ConsoleColor.Magenta);
                    TypeLine("- Consider hardware security keys for high-value accounts", ConsoleColor.Magenta);
                    TypeLine("- Review authorized devices regularly", ConsoleColor.Magenta);
                    break;



            }

            Console.WriteLine("───────────────────────────────────────────────");
            Console.ResetColor();
        }
        
    }
}
