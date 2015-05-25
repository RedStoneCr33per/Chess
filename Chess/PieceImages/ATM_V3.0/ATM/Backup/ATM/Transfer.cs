using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class Transfer
  {
    internal static void TransferFunds(Dictionary<int, Account> list, Account account)
    {
      if (!account.userLogin)
      {
        Console.WriteLine("Please login");
      }

      else
      {
        Console.WriteLine("Please enter the account number you wish to transfer funds to: ");
        string transferInput = Console.ReadLine();
        int tranferAccount;

        if (!Int32.TryParse(transferInput, out tranferAccount) || transferInput.Length != 6)
        {
          Console.WriteLine(AccountCreation.errorMessage);
        }

        else
        {
          int recipientAccount = Convert.ToInt32(tranferAccount);
          Console.WriteLine("Enter the amount you with to transfer: ");
          string amountInput = Console.ReadLine();
          int transferAmount;
          if (!Int32.TryParse(amountInput, out transferAmount))
          {
            Console.WriteLine(AccountCreation.errorMessage);
          }
          else
            transferAmount = completeTransfer(list, account, recipientAccount, amountInput, transferAmount);
        }
      }
    }

    private static int completeTransfer(Dictionary<int, Account> list, Account account, int recipientAccount, string amountInput, int transferAmount)
    {
      transferAmount = Convert.ToInt32(amountInput);
      if (transferAmount <= 0 || transferAmount >= account.Balance)
      {
        Console.WriteLine("Amount must be greater than zero and less than your account balance");
      }

      else
      {
        int oldBalance = account.Balance;
        int oldRecipientBalance = list[recipientAccount].Balance;
        
        list[account.AccoutNumber].Balance -= transferAmount;
        Account recipientAccountObject = list[recipientAccount];
        recipientAccountObject.Balance = recipientAccountObject.Balance + transferAmount;

        TextFileInputOutput.UpdateTextFileBalance(list, list[account.AccoutNumber], oldBalance);
        TextFileInputOutput.UpdateTextFileBalance(list, recipientAccountObject, oldRecipientBalance);

        formatAmountInCorrectCurrency(list, recipientAccount, transferAmount);

        Balance.CheckBalance(list, list[account.AccoutNumber]);
        LoginLogout.Logout(list[account.AccoutNumber], list);

      }
      return transferAmount;
    }

    private static void formatAmountInCorrectCurrency(Dictionary<int, Account> list, int recipientAccount, int transferAmount)
    {
      if (list[recipientAccount].Currency)
      {
        Console.WriteLine("Successfully transfered {0} to account number {1}", transferAmount.ToString("c", AccountCreation.us), recipientAccount);
      }

      else
      {
        Console.WriteLine("Successfully transfered {0} to account number {1}", transferAmount.ToString("c", AccountCreation.uk), recipientAccount);
      }
    }
  }
}