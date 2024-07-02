from collections import Counter

num_shoes = int(input())
shoe_sizes = list(map(int, input().split()))
inventory = Counter(shoe_sizes)
num_customers = int(input())
total_earnings = 0

for x in range(num_customers):
    size, price = map(int, input().split())
    if inventory[size] > 0:
        total_earnings += price
        inventory[size] -= 1

print(total_earnings)