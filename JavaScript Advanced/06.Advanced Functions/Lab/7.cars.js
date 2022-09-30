// function solve(array) {
//     let cars = {};
//     let creator = {
//         create: (name1) => cars[name1] = {},
//        // inherit: (name1, name2) => create.bind(cars[name1]),
//         set: (name1, prop, value) => cars[name1][prop] = value,
//         print: () => console.log(cars),
//     }

//     for (const line of array) {
//         let info = line.split(' ');
//         let [cmd, name1, prop, value] = info;

//         if (info.length == 4 && info[0] == 'create') {
//             cmd = 'inherit';
//             creator[cmd](name1, value);
//         } else {
//             creator[cmd](name1, prop, value);
//         }

//         console.log(cmd, name1, prop, value);
//         console.log(cars);
//     }
// }

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);