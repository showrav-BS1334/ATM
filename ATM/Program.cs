using System;
using System.Collections;
using System.ComponentModel.Design;

public class CardHolder 
{
    String cardNum;
    int pin;
    String firstName, lastName;
    double balance;

    // constructor
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // setter and getter
    public String getCardNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public double getBalance()
    {
        return balance;
    }
    public String getLastName()
    {
        return lastName;
    }
    public void setCardNum(String cardNum)
    {
        this.cardNum = cardNum;
    }

    public void setPin(int pin)
    { 
        this.pin = pin;
    }

    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }

    public void setLastName(String lastName)
    { 
        this.lastName = lastName;
    }

    public void setBalance(double balance)
    { 
        this.balance = balance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose an option from one of these: ");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much tk would you like to deposit?");
            double deposit = Convert.ToDouble(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thanks. Current Balance is: " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much do you want to withdraw?");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            if(currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Thanks!");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance is :" + currentUser.getBalance());
        }

        List<CardHolder> list = new List<CardHolder>();
        list.Add(new CardHolder("12345", 123, "A", "B", 100.50));
        list.Add(new CardHolder("12346", 124, "C", "D", 200));
        list.Add(new CardHolder("12347", 125, "E", "F", 300));
        list.Add(new CardHolder("12348", 126, "G", "H", 400.50));

        Console.WriteLine("Welcome to the simplest ATM. \n Please insert your debit card.");
        String debitCardNum;
        CardHolder currentUser;
        
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // checking the card number
                currentUser = list.FirstOrDefault(args=>args.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { 
                    Console.WriteLine("Card num is wrong, please try again!");
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                Console.WriteLine("Card num is wrong, please try again!");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = Convert.ToInt32(Console.ReadLine());
                if(currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Wrong pin, please try again!");
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                Console.WriteLine("Wrong pin, please try again!");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + "!");

        int option = 0;
        printOptions();
        do
        {
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if (option == 1) deposit(currentUser);
            else if (option == 2) withdraw(currentUser);
            else if (option == 3) balance(currentUser);
            else if (option == 4) break;
            else option = 0;
        } while (option != 4);
        Console.WriteLine("Thanks" +
            "Have a nice day");
    }
}