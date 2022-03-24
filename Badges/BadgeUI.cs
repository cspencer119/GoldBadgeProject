using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgeUI
    {
        BadgeRepo badgeRepo = new BadgeRepo();
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Select an Option:\n" +
                     "1.\tDisplay Badges\n" +
                     "2.\tCreate New Badges\n" +
                     "3.\tUpdate Badges\n" +
                     "4.\tExit");
                char response = Console.ReadKey().KeyChar;
                switch (response)
                {
                    case '1':
                        DisplayBadges();
                        PressToContinue();
                        break;
                    case '2':
                        AddBadges();
                        break;
                    case '3':
                        UpdateBadges();
                        break;
                    case '4':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Response");
                        PressToContinue();
                        break;
                }
            }
        }

        private bool AddBadges()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            Console.WriteLine("Badge ID: (q to quit)");
            newBadge.ID = GetIntResponse("q", "Badge ID: (q to quit)");
            if (newBadge.ID == -1)
            {
                return false;
            }
            AddDoors(newBadge);
            badgeRepo.AddNewBadge(newBadge);
            return true;
        }

        private bool UpdateBadges()
        {
            Badge badge = UserSelectBadge();
            if (badge != null)
            {
                Console.Clear();
                DisplayBadge(badge);
                Badge newBadge = new Badge();
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine($"Badge {badge.ID} has access to these doors:");
                    DisplayDoors(badge);
                    Console.WriteLine("What would you like to do?\n" +
                        "1.\tAdd Doors\n" +
                        "2.\tRemove Doors\n" +
                        "3.\tExit");
                    char response = Console.ReadKey().KeyChar;
                    switch (response)
                    {
                        case '1':
                            AddDoors(badge);
                            break;
                        case '2':
                            RemoveDoors(badge);
                            break;
                        case '3':
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Response.");
                            PressToContinue();
                            break;
                    }
                }
                return true;
            }
            return false;
        }

        private void RemoveDoors(Badge badge, bool display = false)
        {
            if (display)
            {
                Console.WriteLine($"Badge {badge.ID} has access to these doors:");
                DisplayDoors(badge);
            }
            Console.WriteLine("Which door will be removed? (q to quit)");
            string response = GetResponse("q", "Which door will be removed? (q to quit)");
            foreach (string door in badge.DoorNames)
            {
                List<string> removingDoors = new List<string>();
                if (door == response)
                {
                    removingDoors.Add(door);
                    badge.DoorNames.Remove(door);
                    badgeRepo.UpdateExistingBadge(badge.ID, badge);
                    Console.WriteLine("Door removed.");
                    Console.WriteLine("Would you like to keep removing doors? (y/n)");
                    if (GetYesNoResponse("y", "n"))
                    {
                        Console.Clear();
                        RemoveDoors(badge, true);
                    }
                    break;
                }
            }
        }

        private void AddDoors(Badge newBadge, bool display = false)
        {
            if (display)
            {
                Console.WriteLine($"Badge {newBadge.ID} has access to these doors:");
                DisplayDoors(newBadge);
            }
            Console.WriteLine("Add Door: (q to quit, f to finish)");
            string response = GetResponse("q");
            if (response.ToLower() != "q")
            {
                if (response.ToLower() != "f")
                {
                    newBadge.DoorNames.Add(response);
                    badgeRepo.UpdateExistingBadge(newBadge.ID, newBadge);
                    AddDoors(newBadge);
                }
            }
        }

        private void DisplayBadges()
        {
            Console.WriteLine();
            foreach (KeyValuePair<int, List<string>> badge in badgeRepo.GetBadges())
            {
                DisplayBadge(new Badge() { ID = badge.Key, DoorNames = badge.Value });
            }
        }

        private void DisplayBadge(Badge badge)
        {
            Console.WriteLine($"Badge ID: {badge.ID}");
            Console.WriteLine($"Accessible Doors:");
            DisplayDoors(badge);
        }

        private void DisplayDoors(Badge badge)
        {
            foreach (string door in badge.DoorNames)
            {
                Console.WriteLine($"{door}");
            }
        }

        private Badge UserSelectBadge()
        {
            DisplayBadges();
            Console.WriteLine("Badge id: (q to quit)");
            int response = GetIntResponse("q", "Badge id: (q to quit)");
            if (response != -1)
            {
                Badge badge = badgeRepo.FindBadgeById(response);
                if (badge != null)
                {
                    return badge;
                }
                Console.WriteLine("Invalid Response.");
                PressToContinue();
                return UserSelectBadge();
            }
            return null;
        }

        private string GetResponse(string quitCharacter, string prompt = "")
        {
            string response = Console.ReadLine();
            if (response.ToLower() == quitCharacter.ToLower())
            {
                return null;
            }
            return response;
        }

        private bool GetYesNoResponse(string affirmative, string negative)
        {
            string response = Console.ReadLine().ToLower();
            if (response == affirmative.ToLower())
            {
                return true;
            }
            if (response == negative.ToLower())
            {
                return false;
            }
            return false;
        }

        private int GetIntResponse(string quitCharacter, string prompt = "")
        {
            string response = Console.ReadLine();
            if (response.ToLower() == quitCharacter.ToLower())
            {
                return -1;
            }
            try
            {
                int intResponse = int.Parse(response);
                return intResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Response");
                PressToContinue();
                Console.WriteLine($"{prompt}");
                return GetIntResponse(quitCharacter, prompt);
            }
        }

        private void PressToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
