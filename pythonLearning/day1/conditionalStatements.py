a = int(input("enter a "));  
b = int(input("enter b ")); 

if a > b:
    print("a is greater than b");
elif a < b:
    print("a is less than b");
else:
    print ("a is equal to b");
    
print("a is greater than b") if a > b else print("a is less than b") if a < b else print("a is equal to b"); 
    
    