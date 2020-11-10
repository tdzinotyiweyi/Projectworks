using System;

public class TransferTransaction
{
    private Account _account;
    private Account _toAccount;
    private Account _fromAccount;
    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    private decimal _amount;
    
    private bool _executed = false;
    private bool _reversed = false;
    private bool _success = false;
    
    public bool Success
    {
        get
        {
            if (_theDeposit.Success && _theWithdraw.Success)
            {
                return true;
            } 
            else 
            {
                return false;
            }
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

    public TransferTransaction(Account account, Account user, decimal amount)
    {
        _fromAccount = account;
        _toAccount = user;
        _amount = amount;
    }
    public void Execute()
    {
        if ( _executed )
        {
            throw new Exception("Cannot execute this transaction");
        }

        _executed = true;
        _success = _account.Withdraw(_amount);
    }

    public void Rollback()
    {
        if (! _executed)
        {
            throw new Exception("No execution has takem place.");
        }

        if ( _reversed )
        {
            throw new Exception("You have successfully reversed the transaction. ");
        }

        _reversed = true;

        _account.Deposit(_amount);
        
    }

    public void Print()
    {
        if ( _success)
        {
            Console.WriteLine("Withdraw was successful. ");
            Console.WriteLine("Withdrawn amount is " + _amount.ToString());
        } 
        else if (_reversed) 
        {
            Console.WriteLine("Transactions successfully reversed. ");
        }
        
    }
    
}

