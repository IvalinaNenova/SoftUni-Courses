function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {

      let input = JSON.parse(document.querySelector('#inputs textarea').value);
      let allRestaurants = {};
      let bestAverageSalary = 0;
      let bestRestaurantName = '';

      for (let line of input) {

         let [restaurantName, workers] = line.split(' - ');
         let individualWorkers = workers.split(', ');

         for (let worker of individualWorkers) {
            let [workerName, salary] = worker.split(' ');

            if (!allRestaurants.hasOwnProperty(restaurantName)) {
               allRestaurants[restaurantName] = {};
            }
            allRestaurants[restaurantName][workerName] = Number(salary);
            console.log(allRestaurants);
         }

         let entries = Object.entries(allRestaurants);

         for (let [name, workers] of entries) {
            let salaries = Object.values(workers);
            let totalSalariesPaid = 0;

            for (let salary of salaries) {
               totalSalariesPaid += salary;
            }

            let averageSalary = totalSalariesPaid / salaries.length;

            if (averageSalary > bestAverageSalary) {
               bestAverageSalary = averageSalary;
               bestRestaurantName = name;
            }
         }
      }

      let workersOrdered = Object.entries(allRestaurants[bestRestaurantName]).sort((a, b) => b[1] - a[1]);
      let workersAsString = '';
      workersOrdered.forEach(w => workersAsString += `Name: ${w[0]} With Salary: ${w[1]} `);

      document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRestaurantName} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${workersOrdered[0][1].toFixed(2)}`;
      document.querySelector('#workers p').textContent = workersAsString;
   }
}