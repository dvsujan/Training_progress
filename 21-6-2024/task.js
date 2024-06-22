class Person{
    #name;
    constructor(name){
        this.#name = name;
    }
    introduceSelf(){
        console.log(`Hello, my name is ${this.#name}`);
    }
}

class Student extends Person{
    #year;
    constructor(name, year){
        super(name);
        this.#year = year;
    }
    introduceSelf (){
        super.introduceSelf();
        console.log(`I am a student in year ${this.year}`);
    }
    canStudyArchery(){
        return this.year >= 2;
    }
}





