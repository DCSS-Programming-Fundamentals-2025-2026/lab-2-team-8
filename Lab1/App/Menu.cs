using Lab1.Domain.Core;
using Lab1.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.App
{
    class Menu
    {
        public static void DemoMenu()
        {
            UserRepository userRepository = new UserRepository();
            WalletRepository walletRepository = new WalletRepository();
            SaleRepository saleRepository = new SaleRepository();
            EventRepository eventRepository = new EventRepository();
            DemoDataFactory demoDataFactory = new DemoDataFactory();

            bool isTrue = true;
            while (isTrue)
            {
                Console.WriteLine($"0 - exit\r\n1 - add user\r\n2 - add wallet\r\n3 - add event\r\n4 - buy ticket\r\n5 - print all users\r\n6 - print all events\r\n7 - return ticket\r\n8 - print check\r\n9 - summary for event\r\n10 - final summary");
                string stringInput = Console.ReadLine();
                bool isSuccess = int.TryParse(stringInput, out int input);
                if (isSuccess)
                {
                    if (input == 0)
                    {
                        isTrue = false;
                        Console.WriteLine("You exited the program.");
                        break;
                    }
                    else if (input == 1)
                    {
                        Console.WriteLine("Input number of users: ");
                        string numberOfUsersString = Console.ReadLine();
                        bool userSuccess = int.TryParse(numberOfUsersString, out int numberOfUsers);
                        if (userSuccess)
                        {
                            int userCount = userRepository.GetCount();
                            for( int i = userCount; i < numberOfUsers + userCount; i++)
                            {
                                User user = demoDataFactory.UserFactory(i);
                                if (!userRepository.AddUser(user))
                                {
                                    
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 2)
                    {

                    }
                    else if (input == 3)
                    {

                    }
                    else if (input == 4)
                    {

                    }
                    else if (input == 5)
                    {

                    }
                    else if (input == 6)
                    {

                    }
                    else if (input == 7)
                    {

                    }
                    else if (input == 8)
                    {

                    }
                    else if (input == 9)
                    {

                    }
                    else if (input == 10)
                    {

                    }
                    else
                    {
                        Console.WriteLine("The numer must be between 0 and 10.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
