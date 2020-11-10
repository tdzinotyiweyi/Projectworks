using System;
using SplashKitSDK;

public enum MenuOption
{
    NewAccount,
    Withdraw,
    Deposit,
    Transfer,
    Print,
    Quit,
}

public class Program
{
    private static MenuOption Readuseroption()
    {
        int option;

        Console.WriteLine(" 1 - NewAccount ");
        Console.WriteLine(" 2 - Withdraw ");
        Console.WriteLine(" 3 - Deposit ");
        Console.WriteLine(" 4 - Transfer ");
        Console.WriteLine(" 5 - Print ");
        Console.WriteLine(" 6 - Quit ");
          
        do
        {
            try
            {
                Console.WriteLine("Choose an Option [1-6]: ");
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch 
            {
                option = -1;
            }

        }   while (option < 1 || option > 6);
        
        return (MenuOption)(option-1);
    }

    private static Account NewAccount()
    {
        Console.WriteLine("Enter Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Starting Balance");
        string input = Console.ReadLine();
        
        decimal startingBalance = Convert.ToDecimal(input);
        
        Account newAccount = new Account(name, startingBalance);
        
        return newAccount;
    }

    private static void DoDeposit(Bank toBank)
    {
        Decimal DepositAmount;
        
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;
        
        try
        {           
            Console.WriteLine("How much would you like to Deposit? ");
            //Read in the amount
            DepositAmount = Convert.ToDecimal(Console.ReadLine());
        }
        catch 
        {
            DepositAmount = 0;
        }
        //create the deposit transaction
        DepositTransaction deposittransac = new DepositTransaction(toAccount, DepositAmount);
        
        //tell toBank to run the transaction
        toBank.ExecuteTransaction(deposittransac);
        //Ask the transaction to Print.
        deposittransac.Print();
    }
    
    private static void DoWithdraw(Bank toBank)
    {
        Decimal WithdrawAmount;
        
        
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;
        
        try
        {
            Console.WriteLine("How much would you like to Withdraw? ");
            WithdrawAmount = Convert.ToDecimal(Console.ReadLine());
        }
        catch
        {
            WithdrawAmount = 0;
        }
        
        WithdrawTransaction withdrawtransac = new WithdrawTransaction(toAccount, WithdrawAmount);
        
        toBank.ExecuteTransaction(withdrawtransac);
        withdrawtransac.Print();
    }

    private static void DoTransfer(Bank toBank)
    {
        Account toAccount = FindAccount(toBank);
        if (toAccount == null) return;

        Account fromAccount = FindAccount(toBank);
        if (fromAccount == null) return;
        
        Console.WriteLine("Enter amount to transfer: ");
        string input = Console.ReadLine();
        decimal amount = Convert.ToDecimal(input);

        TransferTransaction transfertransac = new TransferTransaction(fromAccount, toAccount, amount);

        toBank.ExecuteTransaction(transfertransac);

        transfertransac.Print();
    }

    private static void Doprint(Account user)
    {
        user.Print();
    }

    private static Account FindAccount(Bank fromBank)
    {
        Console.Write("Enter account name: ");
        String name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if ( result == null )
        {
            Console.WriteLine($"No account found with name {name}");
        }

        return result;
    }

    public static void Main()
    {
        Bank NewBank = new Bank();
        
        MenuOption userselection;

        Account account = new Account("Jakes Account", 200000);
        Account user = new Account("Takunda Dzinotyiweyi", 50000);

        do
        {
            userselection = Readuseroption();
            switch(userselection)
            {
                case MenuOption.NewAccount:
                NewBank.AddAccount(NewAccount());
                break;
                case MenuOption.Deposit:
                DoDeposit(NewBank);
                break;
                case MenuOption.Withdraw:
                DoWithdraw(NewBank);
                break;
                case MenuOption.Transfer:
                DoTransfer(NewBank);
                break;
                case MenuOption.Print:
                Doprint(FindAccount(NewBank));
                break;
                case MenuOption.Quit:
                Console.WriteLine("Quit");
                break;
            }
        } while (userselection != MenuOption.Quit);

    }
}

