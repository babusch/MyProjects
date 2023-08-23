class Account:
    def __init__(self, account_number, account_balance):
        self.account_number = account_number
        self.account_balance = account_balance

    def get_balance(self):
        return self.account_balance 

    def set_balance(self, new_balance):
        self.account_balance = new_balance

    def __str__(self):
        return f"account number = {self.account_number}, account balance = {self.account_balance} kr"

    def __repr__(self):
        return f"account number = {self.account_number}, account balance = {self.account_balance} kr"