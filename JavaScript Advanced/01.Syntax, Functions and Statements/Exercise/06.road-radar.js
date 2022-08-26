function solve(speed, area) {

    let areaSpeedLimit;
    switch (area){
        case 'motorway': areaSpeedLimit = 130;
        break;
        case 'interstate': areaSpeedLimit = 90;
        break;
        case 'city': areaSpeedLimit = 50;
        break;
        case 'residential': areaSpeedLimit = 20;
        break;
    }

    let driverSpeed = Number(speed);

    if (driverSpeed <= areaSpeedLimit) {
        return `Driving ${driverSpeed} km/h in a ${areaSpeedLimit} zone`;
    }else{

        let difference = driverSpeed - areaSpeedLimit;

        let status;

        if (difference <= 20) {
            status = 'speeding';
        }else if(difference <=40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }

        return `The speed is ${difference} km/h faster than the allowed speed of ${areaSpeedLimit} - ${status}`;
    }
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));