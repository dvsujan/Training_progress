# inheritance in python 

class Person: 
    def __init__(self, name, age):
        self._name = name
        self._age = age
    
    def get_name(self):
        return self._name
    def set_name(self, name):
        self._name = name
    
    def get_age(self):
        return self._age
    
    def set_age(self, age):
        self._age = age
    
    def greet(self):
        print(f"Hello, my name is {self._name}")
    
    def __str__(self):
        return f"Name: {self._name}, Age: {self._age}"




class Student(Person):
    def __init__(self, name, age, st_class):
        super().__init__(name, age)
        self._st_class = st_class
  
    def __str__(self):
        return f"{super().__str__()}, Class: {self._st_class}"
    
    def get_class(self):
        return self._st_class
    
    def set_class(self, st_class):
        self._st_class = st_class
    def greet(self):
        print(f"Hello, my name is {self._name} and I am a student")
        

class Teacher(Person):
    def __init__(self, name, age, subject):
        super().__init__(name, age)
        self._subject = subject
    def __str__(self):
        return f"{super().__str__()}, Subject: {self._subject}"

    def get_subject(self):
        return self._subject

    def set_subject(self, subject):
        self._subject = subject
    
    def greet(self):
        print(f"Hello, my name is {self._name} and I am a teacher")

if __name__ == "__main__":
    s = Student("ramu", 20, "A"); 
    t = Teacher("somu", 30, "Math"); 
    print(s); 
    print(t); 
    s.greet(); 
    t.greet(); 
