function solve(input) {
    let data = [];
 
    let action = carsManipulator();
 
    for (const task of input) {
        let [cmd, name, key, value] = task.split(' ');
 
        if (key == 'inherit') {
            cmd += key;
            key = value;
        }
 
        action[cmd](name, key, value);
 
    }
 
    function carsManipulator() {
 
        let result = {
            create: (name) => {
                data[name] = {};
            },
 
            createinherit: (name, nameOfParent) => {
                let newObj = Object.create(data[nameOfParent]);
                data[name] = newObj;
            },
 
            set: (name, key, value) => {
              data[name][key] = value;
            },
 
            print: (name) => {
              let output = [];
              
              for (var prop in data[name]) {
                output.push(`${prop}:${data[name][prop]}`);
              }
                
                let s = output.join(',');
 
                console.log(s);
            }
        }
 
        return result;
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);