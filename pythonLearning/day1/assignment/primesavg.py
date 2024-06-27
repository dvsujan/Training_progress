lst = []
for i in range(10):
    n = int(input("Enter a number: "))
    lst.append(n)

def isPrime (n):
    if n > 1:
        for i in range(2, n):
            if n % i == 0:
                return False
        else:
            return True
    else:
        return False

primeList = []
for i in lst:
    if isPrime(i):
        primeList.append(i)

if len(primeList) > 0:
    print("Average of prime numbers: ", sum(primeList)/len(primeList))
else:
    print ("No prime numbers in the given list")    