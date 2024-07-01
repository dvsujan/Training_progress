from inheritanceandpolymorphism import * ; 

class FileHandler: 
    def __init__(self, file_path):
        self.file_path = file_path
    
    def save_obj(self , obj):
        with open(self.file_path, 'a') as f:
            f.write(str(obj))
    
    def load_obj(self, obj):
        with open(self.file_path, 'r') as f:
            for line in f:
                if str(obj) in line:
                    return line
        return None
    
    def del_obj(self, obj):
        with open(self.file_path, 'r') as f:
            lines = f.readlines()
        with open(self.file_path, 'w') as f:
            for line in lines:
                if str(obj) not in line:
                    f.write(line)
    
    def update_obj(self, obj, new_data):
        self.delobj(obj)
        self.saveobj(new_data)
    

def menu(): 
    print("1. Add student") 
    print("2. Remove student")
    print("3. Update student")
    print("4. Display all students")
    print("5. Exit")
    i = int(input("enter a choice")); 
    if (i<1 or i>5):
        print("Invalid choice");
        menu(); 
    return i ; 

if __name__ == "__main__": 
    choice = menu(); 
    file_handler = FileHandler("students.txt");
    if choice == 1:
        name = input("Enter student name: ");
        age = int(input("Enter student age: "));
        grade = input("Enter student grade: ");
        student = Student(name, age, grade);
        file_handler.save_obj(student); 
    
    elif choice == 2:
        name = input("Enter student name to remove: ");
        with open("students.txt", "r") as f:
            for line in f:
                if name in line:
                    file_handler.del_obj(line);
    elif choice == 3:
        name = input("Enter student name to update: ");
        student = Student(name, 0, "");
        new_grade = input("Enter new grade: ");
        new_student = Student(name, 0, new_grade);
        file_handler.update_obj(student, new_student);
    elif choice == 4:
        with open("students.txt", "r") as f:
            for line in f:
                print(line.strip());
                
    elif choice == 5:
        exit();
    else :
        print("Invalid choice");