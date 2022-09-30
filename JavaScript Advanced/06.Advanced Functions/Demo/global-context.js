// Global context
function random() {
    console.log(this); // in browser it will be Window
    return Math.random();
}

random(); // global invocation

let math = {
    random: random
};

math.random() // method invocation

// Obejct context
let obj = {
    name: 'Peter',
    greed() {
        random() // global invocation
        console.log(`Helo! My name is ${this.name}`);
    }
};

obj.greed(); // method invocation
let greed = obj.greed; // copy function by reference
greed() // Global invocation

// DOM Element - must execute in browser
// element.addEventListener('click', function() {
//     console.log(this);
// });


// nested functions
function a() {
    let name1 = 'asdas'
    function b() {
        let name2 = 'asdas2'
        function c() {
            let name3 = 'asdas3'
            function d() {
                let name4 = 'asdas4'
                console.log(this);
            }
            d();
        }
        c();
    }
    b();
}

a();