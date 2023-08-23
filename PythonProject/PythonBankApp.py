from Account import Account
from Customer import Customer
from Bank import Bank
import json

bank = Bank()

def start():
    while(True):
        print("Enter 1 to log in")
        print("Enter 2 to create an account")
        print("Enter 3 to save and quit")
        choise = input()
        if choise == "1":
            login()
            break
        if choise == "2":
            create_user()
            continue
        if choise == "3":
            save()
            quit()
        print("invalid input")

def logout():
    bank.logout()
    start()

def create_user():
    print("Create account")
    print("Enter a username")
    username = input()
    print("Enter a password")
    password = input()
    bank.add_customer(username, password)
    print("done")
    start()

def login():
    print("your not loggedin")
    print("Enter your username")
    username = input()
    print("Enter your password")
    password = input()
    result = bank.login(username, password)
    if result:
        print("Success")
    else:
        print("Failed, try again")
        login()
    if bank.loggedin_customer.get_username() == "admin":
        admin()
    loggedin()

def admin():
    while(True):
        print("Enter 1 to see a list of all customers")
        print("Enter 2 to remove a customer")
        print("Enter 3 to log out")
        input1 = input()
        if input1 == "1":
            print(bank.get_customers())
        if input1 == "2":
            print("Enter the customers name")
            username = input()
            bank.remove_customer(username)
        if input1 == "3":
            logout()
            break

def dictlist_maker(customers):
    customerlist = []
    for customer in customers:
        accountlist = []
        accounts = customer.get_accounts()
        for account in accounts:
            accountdict = {
            "account_number":account.account_number,
            "account_balance":account.account_balance
            }
            accountlist.append(accountdict)
        customerdict = {
            "username":customer.username,
            "password":customer.password,
            "accounts":accountlist
        }
        customerlist.append(customerdict)
    return customerlist

def restore_saved_state(saveddictlist):
    for item in saveddictlist:
        bank.add_customer(item["username"], item["password"])
        customer = bank.get_customer(item["username"])
        for account in item["accounts"]:
            customer.add_account(account["account_number"])
            customer.get_account(account["account_number"]).set_balance(account["account_balance"])


def save():
    customers = dictlist_maker(bank.get_customers())

    jsonstring = json.dumps(customers, indent=2)
  
    file = open("savestate.json", "w")
    file.write(jsonstring)
    file.close()

def load():
    file = open("savestate.json", "r")
    savedstate = json.load(file)
    file.close()
    restore_saved_state(savedstate)

def loggedin():
    while(True):
        print("Enter 1 to view a list of your bankaccounts")
        print("Enter 2 to open a new bankaccount")
        print("Enter 3 to make a deposit")
        print("Enter 4 to withdraw funds")
        print("Enter 5 to change password")
        print("Enter 6 to remove a bankaccount")
        print("Enter 7 to log out")
        userinput = input()
        if userinput == "7":
            logout()
            break
        if userinput == "1":
            print(bank.get_accounts())
        if userinput == "2":
            print("Enter an new account number")
            accnbr = input()
            bank.add_account(accnbr)
        if userinput == "3":
            print("Enter your accountnumber")
            accnbr = input()
            print("Enter the amount you would like to deposit")
            depamo = input()
            bank.deposit(accnbr, int(depamo))
        if userinput == "4":
            print("Enter your accountnumber")
            accnbr = input()
            print("Enter the amount you would like to withdraw")
            witamo = input()
            bank.withdraw(accnbr, int(witamo))
        if userinput == "5":
            print("Enter a new password")
            new_pass = input()
            check = bank.change_customer_password(bank.loggedin_customer.get_username(), new_pass)
            if check:
                print("password canged")
            else:
                print("password change failed")
        if userinput == "6":
            print("Enter an account number")
            accnum = input()
            result = bank.remove_account(accnum)
            if result:
                print("Account closed")
            else:
                print("Account removal failed")
        
load()
start()

