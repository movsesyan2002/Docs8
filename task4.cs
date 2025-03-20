// Task 4:  Advanced Banking System with Transactions
// Task: Design a banking system where accounts support deposit, withdrawal, and balance transfer. 
// Implement static utilities for currency conversion. 
// Use ref parameters to modify balances and out parameters to return transaction details.

using System;

class Bankaccount {
    private string Accountnumber;
    private int Balance;

    public Bankaccount(string accountnumber, int balance) {
        this.Accountnumber = accountnumber;
        this.Balance = balance;
    }

    public void Deposit(int balance) {
        if (balance < 0) {
            throw new ArgumentException("Balacne is less than 0");
        }

        this.Balance += balance;
    }

    public void WithDrawal(int amount) {
        if (amount < 0) {
            throw new ArgumentException("Amount is less than 0");
        }

        else if (amount > Balance) {
            throw new ArgumentException("Amount is great than Balance");
        }

        else {
            this.Balance -= amount;
        }
    }

    public static void Transform( Bankaccount account, int amount,  Bankaccount other) {
        if (amount < 0 || amount > account.Balance) {
            throw new ArgumentException("Balance or Amount is'nt valid");
        }

        account.Balance -= amount;
        other.Balance += amount;
    }

    public void TransformUsd (out int res) {
        res = this.Balance / 400;
    }

    public void Display() {
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"Account number is {this.Accountnumber}\nAnd Balance is {this.Balance} Amd");
        Console.WriteLine("--------------------------------------------------------------------");
    }
}

class Program {
    static void Main() {
        Bankaccount bankaccount1 = new Bankaccount("12345",10000);
        Bankaccount bankaccount2 = new Bankaccount("12377",20000);

        int res;
        bankaccount1.TransformUsd(out res);
        Console.WriteLine($"{res}");

        Bankaccount.Transform( bankaccount1,5000, bankaccount2);
        bankaccount1.Display();
        bankaccount2.Display();
    }
}
