from Customer import Customer
from Account import Account

class Bank:
    def __init__(self):
        self.loggedin_customer = None
        self.customers = []

    def get_customers(self):
        return self.customers

    def add_customer(self, username, password):
        self.customers.append(Customer(username, password))

    def get_customer(self, username):
        for customer in self.customers:
            if customer.username ==username:
                return customer
        return False
    
    def change_customer_password(self, username, new_password):
        customer = self.get_customer(username)
        if customer:
            customer.password = new_password
            return True
        False

    def remove_customer(self, username):
        customer = self.get_customer(username)
        if customer:
            if customer:
                self.customers.remove(customer)
                return True
        return False

    def login(self, username, password):
        customer = self.get_customer(username)
        if customer:
            if customer.password == password:
                self.loggedin_customer = customer
                return True
        return False

    def logout(self):
        self.loggedin_customer = None

    def get_accounts(self):
        return self.loggedin_customer.get_accounts()

    def add_account(self, new_account_number):
        self.loggedin_customer.add_account(new_account_number)

    def remove_account(self, account_number):
        return self.loggedin_customer.remove_account(account_number)

    def get_account(self, account_number):
        return self.loggedin_customer.get_account(account_number)

    def deposit(self, account_number, amount):
        account = self.get_account(account_number)
        if account:
            account.set_balance(account.get_balance() + amount)
            return True
        return False

    def withdraw(self, account_number, amount):
        account = self.get_account(account_number)
        if account:
            if (account.get_balance()-amount) > 0:
                account.set_balance(account.get_balance() - amount)
                return True
        return False

    def __str__(self):
        return f"{self.customers}"

    