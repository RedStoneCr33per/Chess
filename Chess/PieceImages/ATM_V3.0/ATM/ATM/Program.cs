using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

      Console.WriteLine("Added two test accounts to the database:");
      Console.WriteLine("Account Number: 100000, PIN: 1234 & Account Number: 100000, PIN: 1234");

      Dictionary<int, Account> accountList = new Dictionary<int, Account>();

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
        Console.WriteLine("***************************** WELCOME TO PDA BANKING ************************************");
        Console.WriteLine();
        Console.WriteLine();
      }

      else if (option == "quit")
        {
        Console.WriteLine("****************************** THANKYOU AND GOODBYE *************************************");
        Console.WriteLine();
        Console.WriteLine();
          }

Console.WriteLine(" ___    ___    _____     ___    _____  _   _  _   _  _  _   _  ___   ");
Console.WriteLine("(  _`\\ (  _`\\ (  _  )   (  _`\\ (  _  )( ) ( )( ) ( )(_)( ) ( )(  _`\\");
Console.WriteLine("| |_) )| | ) || (_) |   | (_) )| (_) || `\\| || |/'/'| || `\\| || ( (_)");
Console.WriteLine("| ,__/'| | | )|  _  |   |  _ <'|  _  || , ` || , <  | || , ` || |___");
Console.WriteLine("| |    | |_) || | | |   | (_) )| | | || |`\\ || |\\`\\ | || |`\\ || (_, )");
Console.WriteLine("(_)    (____/'(_) (_)   (____/'(_) (_)(_) (_)(_) (_)(_)(_) (_)(____/'");
                                                                     
                                                                     
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