using System;

public class WithdrawTransaction 
{

    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public bool Success
    {
        get
        {
            return _success;
        }
    }

    public bool Executed
    {
        get
        {
            return _executed;
        }
    }

    public bool Reversed
    {
        get
        {
            return _reversed;
        }
    }

    public WithdrawTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if ( _executed )
        {
            throw new Exception("Cannot execute this transaction.");
        }

        _executed = true;
        _success = _account.Withdraw(_amount);
    }

    public void Rollback()
    {
        if (! _executed)
        {
            throw new Exception("No execution has taken place. ");
        }
        if (_reversed)
        {
            throw new Exception("You have successfully reversed the transaction. ");
        }

        _reversed = true;

        _account.Deposit(_amount);
    }

    public void Print()
    {
        if (_success)
        {
            Console.WriteLine("Withdraw was successful.");
            Console.WriteLine("Withdrawn amount is " + _amount.ToString());
        }
        else if (_reversed)
        {
            Console.WriteLine("Transaction successfully reversed. ");
        }
        
        }

}


