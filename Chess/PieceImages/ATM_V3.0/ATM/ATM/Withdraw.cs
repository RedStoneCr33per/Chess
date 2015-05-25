using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class Withdraw
  {
    internal static void WithdrawFunds(Dictionary<int, Account> accountList, Account account)
    {
      if (!account.userLogin)
      {
        Console.WriteLine("Please login");
      }
      else
      {
        Console.WriteLine("Enter the amount you wish to withdraw: ");
        string withdrawalinput = Console.ReadLine();
        int withdrawal;
        if (!int.TryParse(withdrawalinput, out withdrawal))
        {
          Console.WriteLine(AccountCreation.errorMessage);
        }
        else
        {
          int oldBalance = account.Balance;
          withdrawal = withdrawalValidation(accountList,account, withdrawalinput, withdrawal);
          TextFileInputOutput.UpdateTextFileBalance(accountList, account, oldBalance);
        }
      }
    }

    private static bool checkDivisibility(int withdrawalAmount)
    {
      if ((withdrawalAmount % 10 == 0) || (withdrawalAmount % 20 == 0) || (withdrawalAmount % 50 == 0))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private static int withdrawalValidation(Dictionary<int, Account> accountList, Account account, string withdrawalinput, int withdrawal)
    {
      withdrawal = Convert.ToInt32(withdrawalinput);
      if (!checkDivisibility(withdrawal))
      {
        Console.WriteLine("Amount must be a denonimation of 10, 20 or 50");
      }
      else
      {

        if (withdrawal <= 0 || withdrawal >= accountList[account.AccoutNumber].Balance)
        {
          Console.WriteLine(AccountCreation.errorMessage);
        }

        else
        {
          accountList[account.AccoutNumber].Balance -= withdrawal;
          Balance.CheckBalance(accountList, accountList[account.AccoutNumber]);
          LoginLogout.Logout(accountList[account.AccoutNumber], accountList);
          account.userLogin = false;
        }
      }
      return withdrawal;
    }
  }
}