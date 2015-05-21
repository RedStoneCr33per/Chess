using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ATM
{
  class TextFileInputOutput
  {
    internal static void CreateStorage()
    {

      if (!Directory.Exists("C:\\ATM"))
      {
        Directory.CreateDirectory("C:\\ATM");
      }

      if (!File.Exists("C:\\ATM\\AccountDatabase.txt"))
      {
        File.Create("C:\\ATM\\AccountDatabase.txt");
      }
    }

    internal static void WriteNewAccountToFile(Account account)
    {
      using (StreamWriter streamwriter = new StreamWriter("C:\\ATM\\AccountDatabase.txt", true))
      {
        streamwriter.WriteLine("ACCOUNT NUMBER: {0} PIN: {1} BALANCE: {2} CURRENCY: {3}", account.AccoutNumber, account.PIN, account.Balance.ToString(), account.Currency);
      }
    }

    internal static void ReadAccountsFromFile(Dictionary<int, Account> list)
    {
      list.Clear();
      string line;
      using (StreamReader streamreader = new StreamReader("C:\\ATM\\AccountDatabase.txt"))
      {
        while (true)
        {
          line = streamreader.ReadLine();

          if (line == null)
          {
            break;
          }

          list.Add(Convert.ToInt32(line.Substring(16, 6)), new Account()
          {
            AccoutNumber = Convert.ToInt32(line.Substring(16, 6)),
            PIN = Convert.ToInt32(line.Substring(28, 4)),
            Balance = Convert.ToInt32(line.Substring(42, 5)),
            Currency = Convert.ToBoolean(line.Substring(58).ToLower())
          });
        }
      }
      Console.WriteLine("There are {0} accounts currently on file", list.Count);
    }

    internal static void UpdateTextFileBalance(Dictionary<int, Account> list, Account account, int oldaccountbalance)
    {
      string accountDatabaseString = File.ReadAllText("C:\\ATM\\AccountDatabase.txt");
      string oldAccountDetails = String.Format
        ("ACCOUNT NUMBER: {0} PIN: {1} BALANCE: {2} CURRENCY: {3}\r\n", account.AccoutNumber, account.PIN, oldaccountbalance, account.Currency);
      string updatedAccountDetails = 
        String.Format("ACCOUNT NUMBER: {0} PIN: {1} BALANCE: {2} CURRENCY: {3}\r\n", account.AccoutNumber, account.PIN, account.Balance, account.Currency);

      accountDatabaseString = accountDatabaseString.Replace(oldAccountDetails, updatedAccountDetails);

      using (StreamWriter sw = new StreamWriter("C:\\ATM\\AccountDatabase.txt"))
      {
        sw.Write(accountDatabaseString);
      }
      
      ReadAccountsFromFile(list);
    }


  }
}
