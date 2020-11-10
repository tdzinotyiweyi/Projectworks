using System;
using SplashKitSDK;


public class Account
{
    private decimal _balance;
    private string _name;

    public Account(string name, decimal startingBalance)
    {
        _name= name;
        _balance = startingBalance;
    }

    public bool Deposit( decimal amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _balance = _balance + amountToAdd;

            return true;
        }
        
        return false;
            
    }

    public bool Withdraw( decimal amountToDeduct)
    {
        if (amountToDeduct > 0)
        {
            _balance = _balance - amountToDeduct;
            return true;
        }
            return false; 
    }

    public String Name 
    {
        get 
        {
            return _name; 
        }

    }

    public decimal Balance
    {
        get 
        { 
            return _balance; 
        }

    }
    
    public void Print()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Balance);
    }

}


