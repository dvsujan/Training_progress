# python functions 

# simple function 
def printHelloWorld(): 
    print("Hello World"); 

# function with parameters
def printHello(name):
    print("Hello " + name); 

# function with return value
def sum(a , b):
    return a + b;

# function with default parameter
def printName(name = "John"):
    print("Hello " + name); 

# function with variable number of parameters
def printAll(*names):
    for name in names:
        print("Hello " + name);

# recursion of fib function
def fib (n):
    if n <= 1:
        return n; 
    else:
        return fib(n-1) + fib(n-2); 
    

    

