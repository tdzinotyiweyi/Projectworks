class Account:
  
  def __init__(self, name, startingBalance):
    self.name = name
    self.balance = startingBalance

  # to print the account
  
  def print_account (self):
    print("%s $%.2f" % (self.name, self.balance))

  # subtracts balance by the withdrawal amount

  def withdrawal(self, amount):
    self.balance -= amount
    return amount

  # adds the deposited amount to the balance 

  def deposit(self, amount):
    self.balance += amount
    return amount

from Account import Account

test = Account("Jake", 10.0)
another_account = Account("Fred", 1000.0)

print("Balances:")
test.print_account()
another_account.print_account()

# The Menu option

print("1 Print")
print("2 Deposit")
print("3 Withdraw")
print("4 Quit")
line = input("Select option: ")
num = int(line)
if num == 4:
  quit
elif num == 1 :
  another_account.print_account()
elif num == 2:
  deposit_input = input("Amount To Deposit: ")
  another_account.deposit(float(deposit_input))
  print("New balance:")
  another_account.print_account()
elif num == 2:
  withdraw_input = input("Amount To Withdraw: ")
  another_account.deposit(float(withdraw_input))
  print("New balance:")
  another_account.print_account()
else :
  print("Error occured try Again or enter 4 to quit")
  line = input("Select an option: ")
