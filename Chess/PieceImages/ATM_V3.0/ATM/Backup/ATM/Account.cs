using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
  public class Account
  { 
    public int AccoutNumber { get; set; }
    public int PIN { get; set; }
    public int Balance { get; set; }
    public bool Currency { get; set; }
    public bool userLogin { get; set; }
    public DateTime LoginTime { get; set; }
  }
}
