function solve(array) {
    let info = {};

    for (const item of array) {
        let[cityName, population] = item.split(' <-> ');

        if (!info[cityName]) {
            info[cityName] = 0;
        }

        info[cityName] += Number(population);
    }

    for (let city in info) {
        console.log(`${city} : ${info[city]}`);
    }
}

solve(['Sofia <-> 1200000',
                   'Montana <-> 20000',
                   'New York <-> 10000000',
                   'Washington <-> 2345000',                  
                   'Las Vegas <-> 1000000']
                   );

solve(['Istanbul <-> 100000',
                    'Honk Kong <-> 2100004',
                    'Jerusalem <-> 2352344',
                    'Mexico City <-> 23401925',
                    'Istanbul <-> 1000']
                    );