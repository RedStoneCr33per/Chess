using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  class Balance
  {
    internal static void CheckBalance(Dictionary<int, Account> list, Account account)
    {
      if (!account.userLogin)
      {
        Console.WriteLine("Please login");
      }
      else
      {
        DateTime currentDateTime = DateTime.Now;
        TimeSpan timeLoggedIn = currentDateTime - account.LoginTime;
        Console.WriteLine("Correct as of {0} {1}", currentDateTime.ToLongDateString(), currentDateTime.ToLongTimeString());
        Console.WriteLine(AccountCreation.FormatBalanceCurrency(list, account.AccoutNumber));
        Console.WriteLine("Total time logged in: {0:0} minutes and {1} seconds", timeLoggedIn.TotalMinutes, timeLoggedIn.Seconds);
        LoginLogout.Logout(account, list);
        }
    }
  }
}
