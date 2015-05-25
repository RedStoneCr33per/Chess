using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ATM
{
  public class AccountCreation
  {
    #region variables

    public const string errorMessage = "Input not valid. Please retry.";
    public static bool checkInput = false;
    public static string currencyString;
    public static CultureInfo uk = new CultureInfo("en-GB");
    public static CultureInfo us = new CultureInfo("en-US");
    public static string balanceString;
    public static int i;
    enum currency
    {
      GBP,
      USD
    };

    #endregion

    public static Account CreateNewAccount(Dictionary<int, Account> list)
    {
      string message = "";
      Account account = new Account();
      i = list.Keys.Max() + 1;
      int accountNumber = i;

      if (LoginLogout.checkDatabase(list, accountNumber))
      {
        Console.WriteLine("Account already exists");
      }
          
      else
      {
        account.AccoutNumber = accountNumber;
        account.PIN = PINNumber();
        account.userLogin = false;

        list.Add(account.AccoutNumber, account);


        account.Currency = CreateCurrency(list, account.AccoutNumber);
        account.Balance = CreateBalance(list, account.AccoutNumber);
        
        string balanceCurrencyOutput = FormatBalanceCurrency(list[accountNumber]);

        if (checkInput)
        {
          TextFileInputOutput.WriteNewAccountToFile(account);
          message = String.Format("Account successfully created: Account Number: {0}", accountNumber + balanceCurrencyOutput);
          TextFileInputOutput.ReadAccountsFromFile(list);

        }

        else
        {
          message = errorMessage;
          list.Remove(account.AccoutNumber);
        }
        Console.WriteLine(message);

      }
      i++;
      Console.ReadLine();
      return account;
    }
    
    private static int PINNumber()
    {
      Console.WriteLine("Please enter your PIN number: ");
      string pinInput = Console.ReadLine();
      int pin = 0;
      string message = "";

      if (!int.TryParse(pinInput, out pin))
      {
        message = errorMessage;
        checkInput = false;
      }
      
      else if (pinInput.Length == 4)
      {
        pin = Convert.ToInt32(pinInput);

        if (pin == 1234)
        {
          message = "PIN stored, but 1234 is not a safe PIN - please log in and change it immediately";
        }

        else
        {
          message = "PIN stored";
        }
        checkInput = true;
      }

      else
      {
        message = errorMessage;
        checkInput = false;
      }

      Console.WriteLine(message);

      return pin;
    }
    
    private static bool CreateCurrency(Dictionary<int, Account> list, int accountnumber)
    {
      Console.WriteLine("Enter your currency preference (GBP or USD): ");
      string currencyInput = Console.ReadLine().ToUpper();

      if (currencyInput == "GBP")
      {
        list[accountnumber].Currency = false;
        checkInput = true;
        Console.WriteLine("Currency successfully set to GBP");
        balanceString = list[accountnumber].Balance.ToString("c", uk);
        return false;
      }

      else if (currencyInput == "USD")
      {
        list[accountnumber].Currency = true;
        checkInput = true;
        Console.WriteLine("Currency successfully set to USD");
        balanceString = list[accountnumber].Balance.ToString("c", us);
        return true;
      }

      else
      {
        Console.WriteLine(errorMessage);
        checkInput = false;
        return false;
      }

    }

    private static int CreateBalance(Dictionary<int, Account> list, int accountnumber)
    {
      int balance;
      string message = "";
      Console.WriteLine("Please enter your starting balance");
      string outputstring = Console.ReadLine();
      if (!int.TryParse(outputstring, out balance))
      {
        message = errorMessage;
        checkInput = false;
      }
      else
      {
        balance = Convert.ToInt32(outputstring);
        checkInput = true;

        if (!list[accountnumber].Currency)
        {
          message = "Currency successfully set to GBP";
        }

        else
        {
          message = "Currency successfully set to USD";
        }

      }

      Console.WriteLine(message);
      return balance;

    }

    public static string FormatBalanceCurrency(Dictionary<int, Account> list, int accountnumber)
    {
      string currencyFormattedString = "";
    
      if (!list[accountnumber].Currency)
      {
        currencyFormattedString = String.Format(" Account balance: {0}", list[accountnumber].Balance.ToString("c", uk));
      }

      else
      {
        currencyFormattedString = String.Format(" Account balance: {0}", list[accountnumber].Balance.ToString("c", us));
      }

      return currencyFormattedString;

    }

    public static string FormatBalanceCurrency(Account account)
    {
      string currencyFormattedString = "";

      if (!account.Currency)
      {
        currencyFormattedString = String.Format(" Account balance: {0}", account.Balance.ToString("c", uk));
      }

      else
      {
        currencyFormattedString = String.Format(" Account balance: {0}", account.Balance.ToString("c", us));
      }

      return currencyFormattedString;

    }

    private static bool checkAccountDatabase(Dictionary<int, Account> list, int dictionarykey)
    {
      if (list.ContainsKey(dictionarykey))
      {
        checkInput = false;
        return true;
      }
      else
      {
        checkInput = true;
        return false;
      }
    }
  }
}
