using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class Deposit
  {
    internal static void DepositFunds(Dictionary<int, Account> list, Account account)
    {
      if (!account.userLogin)
      {
        Console.WriteLine("Please login");
      }

      else
      {
        if (!accountValidation(list))
        {
          Console.WriteLine(AccountCreation.errorMessage);
        }

        else
        {
          depositValidation(list, account.AccoutNumber, list[account.AccoutNumber]);
        }
      }
    
    }

    private static bool accountValidation(Dictionary<int, Account> list)
    {
      Console.WriteLine("Enter the account you wish to deposit into: ");

      string accountInput = Console.ReadLine();
      int accountnumber;


      if (!Int32.TryParse(accountInput, out accountnumber))
      {
        return false;
      }

      else
      {
        accountnumber = Convert.ToInt32(accountInput);
        return true;
      }
    }

    private static void depositValidation(Dictionary<int, Account> list, int accountnumber, Account account)
    {
      
      if (!list.ContainsKey(accountnumber))
      {
        Console.WriteLine("Account number not in database");
      }

      else
      {
        Console.WriteLine("Enter the amount you wish to deposit into account {0}: ", accountnumber);
        string depositInput = Console.ReadLine();
        int depositAmount;

        if (!Int32.TryParse(depositInput, out depositAmount))
        {
          Console.WriteLine(AccountCreation.errorMessage);
        }

        else
        {
          depositAmount = completeDeposit(list, accountnumber, account, depositInput, depositAmount);

        }
      }
    }

    private static int completeDeposit(Dictionary<int, Account> list, int accountnumber, Account account, string depositInput, int depositAmount)
    {
      depositAmount = Convert.ToInt32(depositInput);
      if (depositAmount <= 0)
      {
        Console.WriteLine("Input must be greater than 0");
      }

      else
      {
        int oldBalance = account.Balance;
        list[accountnumber].Balance += depositAmount;
        account.Balance = list[accountnumber].Balance;

        TextFileInputOutput.UpdateTextFileBalance(list, account, oldBalance);
        formatAmountInCorrectCurrency(list, accountnumber, depositAmount);

        LoginLogout.Logout(list[account.AccoutNumber], list);
        account.userLogin = false;
      }
      return depositAmount;
    }

    private static void formatAmountInCorrectCurrency(Dictionary<int, Account> list, int accountNumber, int depositAmount)
    {
      if (list[accountNumber].Currency)
      {
        Console.WriteLine("Successfully deposited {0} into account number {1}", depositAmount.ToString("c", AccountCreation.us), accountNumber);
      }

      else
      {
        Console.WriteLine("Successfully deposited {0} into account number {1}", depositAmount.ToString("c", AccountCreation.uk), accountNumber);
      }
    }
  }

}