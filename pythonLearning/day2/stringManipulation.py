# string manipulation in python 
st = input("Enter a string: "); 
print(st); # print the string normally
print(st.capitalize()); # capitalizing the string
print(st.upper()); # convert the string to uppercase
print(st.lower()); # convert the string to lowercase
print(st.casefold()); # convert the string to lowercase
print(st.title()); # convert the string to title case
print(st.swapcase()); # changes the upper character to lower and lower to upper
print(st.strip()); # removes the leading and trailing whitespaces
print(st.lstrip()); # removes the leading whitespaces
print(st.rstrip()); # removes the trailing whitespaces
print(st.replace(" " , "")) # replaces the spaces with empty string
lst = (st.split(" ")); # splits the string into a list of words based on the seperating character
print(lst); 
print(''.join(lst)); # joins the list of words back into a string using an empty string as the seperator
print('-'.join(lst)); # joins the list of words back into a string using a hyphen as the seperator
print( st.find('a') ); # finds the index of the first occurrence of the substring 'a'
print( st.rfind('a') ); # finds the last index of the substring 'a'
