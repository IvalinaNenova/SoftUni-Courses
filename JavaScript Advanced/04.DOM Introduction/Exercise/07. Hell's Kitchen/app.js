function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {

      let input = JSON.parse(document.querySelector('#inputs textarea').value);
      let allRestaurants = {};
      let bestAverageSalary = 0;
      let bestRestaurantName = '';

      for (let i = 0; i < input.length; i++) {

         let [restaurantName, workers] = input[i].split(' - ');
         let individualWorkers = workers.split(', ');

         for (let worker of individualWorkers) {
            let [workerName, salary] = worker.split(' ');

            if (!allRestaurants.hasOwnProperty(restaurantName)) {
               allRestaurants[restaurantName] = {};
            }
            allRestaurants[restaurantName][workerName] = Number(salary);
         }

         let entries = Object.entries(allRestaurants);

         for (let [name, workers] of entries) {
            let salaries = Object.values(workers);
            let totalSalariesPaid = 0;

            for (const salary of salaries) {
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
      let workersFormatedArray = [];
      workersOrdered.reduce((result, worker) => {
         result.push(`Name: ${worker[0]} With Salary: ${worker[1]}`);
         return result;
      }, workersFormatedArray);

      document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRestaurantName} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${workersOrdered[0][1].toFixed(2)}`;
      document.querySelector('#workers p').textContent = workersFormatedArray.join(' ');
   }
}