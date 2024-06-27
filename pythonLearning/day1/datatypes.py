# different type of data types in python
#1. int
num = 0 ; 
# 2. float
f = 0.0; 
# 3. complex
c = 0j ; 
# 4. bool
flag = True ; 
# 5. str
str = "hello world!"; 
# 6. list
lst = [1, 2, 3, 4] # mutable
# add t list 
lst.append(5)
# remove from list
lst.remove(2)

# 7. tuple
tp = (1 , 2, 3, 4) # immutable
# 8. set

st = {1, 2, 3, 4} 

# 9. dict
dic = {1: 'one', 2: 'two', 3: 'three'}

dicKeys = dic.keys(); 
dicValues = dic.values() ; 

dic[4] = 'four';

# 10. frozenset
fs = frozenset({1, 2, 3, 4})
# 11. bytes
b = bytes(10)
# 12. bytearray
ba = bytearray(10)
print(num , f , c , flag , str , lst , tp , st , dic , fs , b , ba); 


