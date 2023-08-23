from Account import Account
class Customer:
    def __init__(self, username, password):
        self.username = username
        self.password = password
        self.accounts = []

    def get_accounts(self):
        return self.accounts

    def get_username(self):
        return self.username

    def add_account(self, account_number):
        acc = Account(account_number, 0)
        self.accounts.append(acc)

    def remove_account(self, account_number):
        account = self.get_account(account_number)
        if account:
            if account:
                self.accounts.remove(account)
                return True
        return False

    def get_account(self, account_number):
        for account in self.accounts:
            if account_number == account.account_number:
                return account
        return False

    def __str__(self):
        return f"{self.username}"

    def __repr__(self):
        return f"{self.username}"



