#Tuples
# Tuples are immutable 

t = ( 1, 2 , 3 , 4 , 5,1) ; 
print(t); 

# t[2] = 10; # throws error cuz it is immutable

print(t.count(1)); # gives the count of 1
print(t.index(5)); # gives the index of 5

lst = [1 , 2, 3 , 4 , 5] ; 
print(tuple(lst)); # converts the list into tuple

#string tuple 
tt = ("hello", "wold"); 
print (tt); 


