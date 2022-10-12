class SmartHike {

    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak, altitude) {
        if (this.goals[peak]) {
            return `${peak} has already been added to your goals`
        } else {
            this.goals[peak] = Number(altitude);
            return `You have successfully added a new goal - ${peak}`
        }
    }

    hike(peak, time, difficultyLevel) {
        if (!this.goals[peak]) {
            throw new Error(`${peak} is not in your current goals`)
        } else {
            if (this.resources == 0) {
                throw new Error("You don't have enough resources to start the hike");
            } else {
                if (this.resources - time * 10 < 0) {
                    return "You don't have enough resources to complete the hike";
                } else {
                    this.resources -= time * 10;
                    this.listOfHikes.push({ peak, time, difficultyLevel });
                    return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`
                }
            }
        }
    }

    rest(time) {
        this.resources += time * 10;
        if (this.resources > 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`
        } else {
            return `You have rested for ${time} hours and gained ${time * 10}% resources`
        }
    }

    showRecord(criteria) {
        if (this.listOfHikes.length == 0) {
            return `${this.username} has not done any hiking yet`
        }

        if (criteria != 'all') {
            let fiteredHikes = this.listOfHikes.filter(h => h.difficultyLevel == criteria);

            if (fiteredHikes.length == 0) {
                return `${this.username} has not done any ${criteria} hiking yet`
            }else{
                let bestHike = fiteredHikes.sort((a, b) => a.time - b.time)[0];
                return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`
            }
        }else{
            let output = ["All hiking records:"];
            this.listOfHikes.forEach(h => output.push(`${this.username} hiked ${h.peak} for ${h.time} hours`));
            return output.join("\n").trim();
        }
    }
}

// const user = new SmartHike('Vili');
// console.log(user.addGoal('Musala', 2925));
// console.log(user.addGoal('Rui', 1706));
// console.log(user.addGoal('Musala', 2925));


//const user = new SmartHike('Vili');
//console.log(user.addGoal('Musala', 2925));  //You have successfully added a new goal - Musala
//console.log(user.addGoal('Rui', 1706));     //You have successfully added a new goal - Rui
//console.log(user.hike('Musala', 8, 'hard'));     //You hiked Musala peak for 8 hours and you have 20% resources left 
//console.log(user.hike('Rui', 3, 'easy'));        //You don't have enough resources to complete the hike
//console.log(user.hike('Everest', 12, 'hard')); //Uncaught Error: Everest is not in your current goals

//const user = new SmartHike('Vili');
//console.log(user.addGoal('Musala', 2925));    //You have successfully added a new goal - Musala
//console.log(user.hike('Musala', 8, 'hard'));   //You hiked Musala peak for 8 hours and you have 20% resources left 
//console.log(user.rest(4));                    //You have rested for 4 hours and gained 40% resources 
//console.log(user.rest(5));                    //Your resources are fully recharged. Time for hiking!


const user = new SmartHike('Vili');
console.log(user.showRecord('all'));

user.addGoal('Musala', 2925);
user.addGoal('Botev', 1706);
user.hike('Botev', 8, 'hard');
user.rest(10);
user.hike('Musala', 8, 'hard');
user.rest(10);
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
user.rest(10);
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));



