def is_valid_number(input_str):
    return input_str.isdigit()

def checkValidity(input_str): 
    if input_str is None or len(input_str) != 16 or not is_valid_number(input_str):
        print("Invalid input. Please enter a 16-digit number.")
        return False; 
    return True ;  
    
def main():
    input_str = input("Enter a 16-digit number: ")
    
    if not checkValidity(input_str):
        return
    
    reversed_str = input_str[::-1]
    
    sum_digits = 0
    
    for i, char in enumerate(reversed_str):
        digit = int(char)
        
        if (i + 1) % 2 == 0:
            digit *= 2
            if digit > 9:
                digit = (digit % 10) + (digit // 10)
        
        sum_digits += digit
    
    is_valid = sum_digits % 10 == 0
    if is_valid:
        print("Given Number is a valid Card")
    else:
        print("Given number is not a valid card Number")
