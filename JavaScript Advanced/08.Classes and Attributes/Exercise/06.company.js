class Company {
    constructor() {
        this.departments = {};
    }
    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || Number(salary) < 0) throw new Error('Invalid input!')

        let employee = { name, salary, position };
        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }
        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    bestDepartment() {
        let company = Object.entries(this.departments);
        let bestAverageSalary = 0;
        let bestDepartment = '';

        for (const [department, employees] of company) {
            let totalSalariesPaid = 0
            for (const employee of employees) {
                totalSalariesPaid += Number(employee.salary);
            }
            let averageSalary = totalSalariesPaid / employees.length;

            if (averageSalary > bestAverageSalary) {
                bestAverageSalary = averageSalary;
                bestDepartment = department;
            }
        }

        let sortedEmployees = this.departments[bestDepartment]
            .sort((a, b) => { return b.salary - a.salary == 0 ? a.name.localeCompare(b.name) : b.salary - a.salary })
            .map(x => `${x.name} ${x.salary} ${x.position}`)
            .join('\n');

        return `Best Department is: ${bestDepartment}\nAverage salary: ${bestAverageSalary.toFixed(2)}\n${sortedEmployees}`;
    }
}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
let bestDepartment = c.bestDepartment();
console.log(bestDepartment);
