function solve(input) {
    let processor = (function () {
        let result = [];

        return function processor(data) {
            let [command, value] = data.split(' ');

            let process = {
                add: () => result.push(value),
                remove: () =>{ 
                    let index = result.indexOf(value);
                    if (index !== -1) {
                    result.splice(result.indexOf(value), 1);                        
                    }
                },
                print: () => console.log(result.join(',')),
            }
            process[command].call(value);
        }
    })();

    for (let data of input) {
        processor(data);
    }
}


solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);