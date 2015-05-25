using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class Program
  {
    
    static void Main(string[] args)
    {
      TextFileInputOutput.CreateStorage();
      programStart();
      
      #region variables
      
      bool programLoop = true;
      Account account = new Account();

      //INITIAL TEST ACCOUNT CREATION

      ////false = £GBP
      //Account testAccount1 = new Account { AccoutNumber = 100000, PIN = 1234, Balance = 10000, Currency = false };
      ////true = $USD
      //Account testAccount2 = new Account { AccoutNumber = 100001, PIN = 1234, Balance = 10000, Currency = true };
      //TextFileInputOutput.WriteAccountToFile(testAccount1);
      //TextFileInputOutput.WriteAccountToFile(testAccount2);
      
      //account = testAccount1;

      //Console.WriteLine("Added two test accounts to the database:");
      //Console.WriteLine("Account Number: 100000, PIN: 1234 & Account Number: 100000, PIN: 1234");

      Dictionary<int, Account> accountList = new Dictionary<int, Account>();

      //accountList.Add(testAccount1.AccoutNumber, testAccount1);
      //accountList.Add(testAccount2.AccoutNumber, testAccount2);

      TextFileInputOutput.ReadAccountsFromFile(accountList);

      Console.ReadLine();
      
      #endregion
      
      while (programLoop)
      {
        string userInput = initialMessage();

        switch (userInput)
        {
          case "CREATE": 
          case "C":
            account.userLogin = false;
            account = AccountCreation.CreateNewAccount(accountList);
            break;
          case "L":
            LoginLogout.ShortCutAdvice();
            break;
          case "LOGIN":
          case "LI":
            account = LoginLogout.Login(account, accountList);
            break;
          case "LOGOUT":
          case "LO":
            LoginLogout.Logout(account, accountList);
            break;
          case "BALANCE":
          case "B":
            Balance.CheckBalance(accountList, account);
            break;
          case "WITHDRAW":
          case "W":
            Withdraw.WithdrawFunds(accountList, account);
            break;
          case "DEPOSIT":
          case "D":
            Deposit.DepositFunds(accountList, account);
            break;
          case "TRANSFER":
          case "T":
            Transfer.TransferFunds(accountList, account);
            break;
          case "QUIT":
          case "Q":
            programLoop = exitProgram();
            break;
          default:
            Console.WriteLine("Input not understood, please re-enter");
            Console.ReadLine();
            break;
        }
      }
    }

    private static void programStart()
    {
      initialFormatting();
      displayLogo("start");
      Console.ReadLine();
    }

    private static void initialFormatting()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.SetWindowSize(200, 50);
      Console.Title = "Welcome to DST Banking";
      Console.CursorVisible = false;
    }

    private static void displayLogo(string option)
    {
      if (option == "start") 
      {
        Console.WriteLine("***************************** WELCOME TO DST BANKING ************************************");
        Console.WriteLine();
        Console.WriteLine();
      }

      else if (option == "quit")
        {
        Console.WriteLine("****************************** THANKYOU AND GOODBYE *************************************");
        Console.WriteLine();
        Console.WriteLine();
          }

      Console.WriteLine("d8888b. .d8888. d888888b      d8888b.  .d8b.  d8b   db db   dD d888888b d8b   db  d888b");
      Console.WriteLine("88  `8D 88'  YP `~~88~~'      88  `8D d8' `8b 888o  88 88 ,8P'   `88'   888o  88 88' Y8b");
      Console.WriteLine("88   88 `8bo.      88         88oooY' 88ooo88 88V8o 88 88,8P      88    88V8o 88 88");
      Console.WriteLine("88   88   `Y8b.    88         88~~~b. 88~~~88 88 V8o88 88`8b      88    88 V8o88 88  ooo");
      Console.WriteLine("88  .8D db   8D    88         88   8D 88   88 88  V888 88 `88.   .88.   88  V888 88. ~8~ ");
      Console.WriteLine("Y8888D' `8888Y'    YP         Y8888P' YP   YP VP   V8P YP   YD Y888888P VP   V8P  Y888P  ");
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Press enter to coninue");
      Console.WriteLine();
      Console.WriteLine();
    }

    private static void displayMessage()
    {
      Console.WriteLine();
      Console.WriteLine("Please keep your PIN safe.");
      Console.WriteLine("Press Return to continue");
      Console.WriteLine();
      Console.ReadLine();
    }

    private static string initialMessage()
    {
      Console.WriteLine("Enter command:");
      Console.WriteLine("You can enter 'create', 'login', 'logout',");
      Console.WriteLine("'balance', 'withdraw', 'deposit', 'transfer' or 'quit'");
      Console.ForegroundColor = ConsoleColor.White;
      string userInput = String.Format(Console.ReadLine().ToUpper());
      Console.ForegroundColor = ConsoleColor.Green;
      return userInput;
    }
    
    private static bool exitProgram()
    {
      displayLogo("quit");
      Console.ReadLine();
      return false;
    }
 }
}