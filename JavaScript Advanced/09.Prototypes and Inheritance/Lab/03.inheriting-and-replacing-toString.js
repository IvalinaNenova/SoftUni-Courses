function toStringExtension() {
    class Person{
        constructor(name, email){
            this.name = name;
            this.email = email;
        }
        toString() {
            let info = [];
            for (let [key, value] of Object.entries(this)) {
                info.push(`${key}: ${value}`);
            }
            return `${Object.getPrototypeOf(this).constructor.name} (${info.join(', ')})`;
        }
    }
    class Teacher extends Person{
        constructor(name, email, subject){
            super(name, email)
            this.subject = subject;
        }
        
    }
    class Student extends Person{
        constructor(name, email, course){
            super(name, email)
            this.course = course;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

toStringExtension()

