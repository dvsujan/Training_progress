import datetime 
from reportlab.lib.pagesizes import letter, A4
from reportlab.pdfgen import canvas
from pandas import DataFrame
import pandas as pd

class Employee: 
    def __init__(self, name:str, dob:datetime, phone:str, email:str):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
        self.age = datetime.date.today().year - dob.year
    
    def __str__(self):
        return f"Name: {self.name}, DOB: {self.dob}, Phone: {self.phone}, Email: {self.email}, Age: {self.age}"
    
    def save_to_txtfile(self):
        if file_format == "text":
            with open("employee.txt", "a") as f:
                f.write(str(self) + "\n")
    
    def save_to_excel(self):
        df = DataFrame({"Name": [self.name], "DOB": [self.dob], "Phone": [self.phone], "Email": [self.email], "Age": [self.age]})
        df.to_excel(f"employee_{self.name}.xlsx", index=False)
    
    def save_to_pdf(self):
        c = canvas.Canvas(f"employee_{self.name}.pdf", pagesize=A4)
        c.drawString(50, 750, f"Name: {self.name}")
        c.drawString(50, 700, f"DOB: {self.dob}")
        c.drawString(50, 650, f"Phone: {self.phone}")
        c.drawString(50, 600, f"Email: {self.email}")
        c.drawString(50, 550, f"Age: {self.age}")
        c.save()
        
class EmployeeManager:
    def __init__(self):
        self.employees = []
    
    def bulk_load_employees(self, filename):
        df = pd.read_excel(filename)
        for index, row in df.iterrows():
            employee = Employee(row["Name"], row["DOB"], row["Phone"], row["Email"])
            self.employees.append(employee)
        
    def print_employees(self):
        for employee in self.employees:
            print(employee)

def validate_details(employee):
    if not employee.name or not employee.dob or not employee.phone or not employee.email:
        return False
    elif employee.age < 18:
        return False
    elif not "@" in employee.email:
        return False
    elif not employee.phone.isdigit() or len(employee.phone) != 10:
        return False ; 
    elif employee.dob >= datetime.date.today():
        return False ; 
    else:
        return True ;   

if __name__ == "__main__":
    try:
        print("1. save employee to file")
        print("2. bulk load employees from excel file");
        choice = int(input("Enter your choice: "))
        if (choice == 2): 
            
            em = EmployeeManager()
            filename = input("Enter filename: ")
            em.bulk_load_employees(filename)
            print("Employees loaded successfully")
            em.print_employees(); 
            exit(1); 
        
        print("Enter employee details: ")
        name = input("Enter employee name: ")
        dob = datetime.datetime.strptime(input("Enter employee date of birth (YYYY-MM-DD): "), "%Y-%m-%d").date()
        phone = input("Enter employee phone number: ")
        email = input("Enter employee email: ")
        employee = Employee(name, dob, phone, email)
        if validate_details(employee):
            file_format = input("Enter file format to save (text, excel, or pdf): ")
            if file_format == "text":
                employee.save_to_txtfile()
            elif file_format == "excel":
                employee.save_to_excel()
            elif file_format == "pdf":
                employee.save_to_pdf()
            else:
                print("Invalid file format")
        else:
            print("Invalid employee details")
    except  ValueError as e:
        print(e)
        exit(1)