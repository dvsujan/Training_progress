def isPrime(num): 
    if num == 1:
        return False
    else:
        for i in range(2, int(num**0.5)+1):
            if num % i == 0:
                return False
        return True

n = int(input("Enter a number: ")); 
for x in range(1, n+1):
    if isPrime(x):
        print(x, end=" "); 
    

    