# dictionarys

#initilization

dict = {
    1:'one' , 
    2:'two' , 
    3:'three', 
    4:'four' ,
    5:'five',
    6:'six',
    7:'seven', 
    8:'eight' ,
    9:'nine' ,
}

# get the value of a key
print(dict[1]); 

#insert the value of a key
dict[0] = 'zero'; 

# get all keys 
print(dict.keys());

# get all values
print(dict.values());

# iteration 

for key in dict.keys():
    print(key , dict[key]); 

for value in dict.values():
    print(value);







