name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your date of birth: ")
phone = input("Enter your phone number: ")
     
def printDetails(name, age, dob, phone):
    print("Name: " + name); 
    print("Age: " + age);
    print("Date of Birth: " + dob);
    print("Phone: " + phone);
    
def validateDetails(name, age, dob, phone):
    if name.isalpha() and age.isdigit() and dob.isdigit() and phone.isdigit():
        printDetails(name, age, dob, phone)
    else:
        print("Please enter valid details")
        
