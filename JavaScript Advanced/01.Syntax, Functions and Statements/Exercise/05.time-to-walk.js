function solve(steps, meters, speed) {
    
    let metersToWalk = steps * meters;
    let speedInMetersPerHour = speed * 1000;

    let secondsNeededToWalk = metersToWalk / speedInMetersPerHour * 3600;

    let restInSeconds = Math.floor(metersToWalk / 500) * 60;

    let totalSecondsToWalk = secondsNeededToWalk + restInSeconds;


    let hours = Math.floor(Math.ceil(totalSecondsToWalk) / 3600).toString();
    let minutes = Math.floor(totalSecondsToWalk/60).toString();
    let seconds = Math.ceil(totalSecondsToWalk % 60).toString();

    return `${hours.padStart(2, '0')}:${minutes.padStart(2, '0')}:${seconds.padStart(2, '0')}`;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));