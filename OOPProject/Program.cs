using ConsoleThemes;
using OOPProject.Helpers;
using OOPProject.Models;
using OOPProject.Service;

namespace OOPProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LibirayBranch branch = DataSeeding.Seed();
            DisplayService display = new();
            LibirayService libirayService= new LibirayService(branch,display);
            bool running = true;
            while (running)
            {
                try
                {
                    ConsoleHelper.ShowMenu();
                    string? choice= Console.ReadLine()?.Trim();
                    switch (choice)
                    {
                        case "1":
                            display.ShowBranchInfo(branch);
                            break;
                            case "2":
                            display.ShowAllUsers(branch);
                            break;
                            case "3":
                            display.ShowAvailableCopies(branch);
                            break;
                            case "4":
                            display.ShowALLCopies(branch);
                            break;
                            case "5":
                            libirayService.HandleBorrow();
                            break;
                            case "6":
                            libirayService.HandleReturn();
                            break;
                        case "7":
                            libirayService.HandleHistory();
                            break;
                        case "8":
                            libirayService.HandleRegisteration();
                            break;
                        case "0":
                            running=false;
							Console.WriteLine("bye");
                            break;
                        default:
							Console.WriteLine("Invalid operation");
                            break;
                    }

                }
                catch
                {
                    running = false;

                }
				Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
