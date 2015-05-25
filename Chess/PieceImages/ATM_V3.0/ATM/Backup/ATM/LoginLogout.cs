using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class LoginLogout
  {

    internal static void ShortCutAdvice()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Did you mean 'login' (li) or 'logout' (lo)?");
      Console.ForegroundColor = ConsoleColor.Green;
    }

    internal static Account Login(Account account, Dictionary<int, Account> list)
    {
      int accountnumber = account.AccoutNumber;
      if (checkUserLogin(account))
      {
        Console.WriteLine("You are already logged on ");
        return account;
      }

      else
      {
        Console.WriteLine("Enter your account number:");
        string accountnumberinput = Console.ReadLine();
        
        if (!int.TryParse(accountnumberinput, out accountnumber))
        {
          Console.WriteLine(AccountCreation.errorMessage);
          return account;
        }
        
        else
          {
            accountnumber = Convert.ToInt32(accountnumberinput);
            return completeLogin(ref account, list, accountnumber);
          }
        
      }
    }

    internal static void Logout(Account account, Dictionary<int, Account> list)
    {
      if (!checkUserLogin(account))
      {
        Console.WriteLine("You have already logged out ");
      }
      else
      {
        account.userLogin = false;
        list[account.AccoutNumber].userLogin = false;
        
        Console.WriteLine("Successfully logged out...");
      }
    }

    private static bool checkUserLogin(Account account)
    {
      if (account.userLogin)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool checkDatabase(Dictionary<int, Account> accountlist, int accountnumber)
    {
      if (accountlist.ContainsKey(accountnumber))
      {
        if (checkForPIN(accountlist[accountnumber]))
        {
          return true;
        }
        else
        {
          return false;
        }
      }

      else
      {
        return false;
      }

    }

    public static bool checkDatabase(Dictionary<int, Account> accountlist, int accountnumber, Account account)
    {
      if (accountlist.ContainsKey(account.AccoutNumber))
      {
        if (checkForPIN(account))
        {
          return true;
        }
        else
        {
          return false;
        }
      }

      else
      {
        return false;
      }

    }

    public static bool checkDatabaseWithoutPinCheck(Account account, Dictionary<int, Account> accountlist)
    {
      if (accountlist.ContainsKey(account.AccoutNumber))
      {
        return true;
      }
      
      else
      {
        return false;
      }

    }

    private static bool checkForPIN(Account account)
    {
      int userPIN;
      Console.WriteLine("Enter your PIN: ");
      string userinput = Console.ReadLine();
      if (!int.TryParse(userinput, out userPIN))
      {
        return false;
      }

      else
      {
        userPIN = Convert.ToInt32(userinput);
        if (userPIN != account.PIN)
        {
          return false;
        }
        else
        {
          return true;
        }
      }
    }

    private static Account completeLogin(ref Account account, Dictionary<int, Account> list, int accountnumber)
    {
      if (!list.ContainsKey(accountnumber))
      {
        Console.WriteLine("Account not on file");
        return account;
      }

      else if (!checkDatabaseWithoutPinCheck(list[accountnumber], list))
      {
        Console.WriteLine("Account not on file");
        return account;
      }
      else
      {
        if (checkForPIN(list[accountnumber]))
        {
          account.userLogin = true;
          list[accountnumber].userLogin = true;
          list[accountnumber].LoginTime = DateTime.Now;
          account.LoginTime = list[accountnumber].LoginTime;

          Console.WriteLine("Successfully logged in...");
          account = list[accountnumber];
        }
        else
        {
          Console.WriteLine("Incorrect PIN");
        }
        return account;
      }
    }
  }
}
