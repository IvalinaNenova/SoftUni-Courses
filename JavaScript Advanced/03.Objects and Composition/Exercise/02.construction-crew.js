function solve(object) {

    let worker = object;

    if (worker.dizziness === true) {
        let waterReqired = 0.1 * worker.weight * worker.experience;
        worker.levelOfHydrated += waterReqired;
        worker.dizziness = false;
    }

    return worker;
}

console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));

console.log(solve({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));

console.log(solve({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
}
));