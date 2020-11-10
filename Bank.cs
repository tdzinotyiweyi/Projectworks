using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Bank
{
    private List<Account> _accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

//For my GetAccount method, I was struggling to get my function to work, so I researched and found how to do the method on StackOverflow. 
    public Account GetAccount(string name)
    {
        for (int i = 0; i < _accounts.Count; i++)
        {
            if (name == _accounts[i].Name)
            {
                return _accounts[i];
            }
        }
        
        return null;
    }

    public void ExecuteTransaction(WithdrawTransaction transaction)
    {
        transaction.Execute();
    }

    public void ExecuteTransaction(DepositTransaction transaction)
    {
        transaction.Execute();
    }

    public void ExecuteTransaction(TransferTransaction transaction)
    {
        transaction.Execute();
    }
}

