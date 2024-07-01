# classes in python 

class CarFactory: 
    def __init__(self):
        self.cars = []

    def create_car(self, make, model, year):
        car = Car(make, model, year)
        self.cars.append(car)
        return car
    
    def add_car(self, car):
        self.cars.append(car)
    
    def remove_car(self, car):
        self.cars.remove(car)
    
    def get_cars(self):
        return self.cars
    
    def get_all_cars_info(self):
        for car in self.cars:
            print(car.get_info())
 
class Car:
    def __init__(self, make, model, year):
        self.__make = make
        self.__model = model
        self.__year = year
    
    def get_info(self):
        return f"Make: {self.__make}, Model: {self.__model}, Year: {self.__year}"
    
           
factory = CarFactory()
car1 = factory.create_car("Toyota", "Camry", 2020)
c = Car("Toyota", "Fortuner", 2023); 
factory.add_car(c)
factory.get_all_cars_info()
print("----------------------------")
factory.remove_car(car1)
factory.get_all_cars_info()
