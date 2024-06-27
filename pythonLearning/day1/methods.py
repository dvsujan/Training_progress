def printHello():
    print("Hello World!");

def printTxtHello(txt):
    print(txt, "Hello") ; 

def addNums(a, b):
    return a + b; 

def isNumGreaterThan10(num):
    if num > 10:
        return True; 
    else:
        return False; 


printHello();
printTxtHello("Hi");
print(addNums(10, 20));
print(isNumGreaterThan10(5));
print(isNumGreaterThan10(15));
