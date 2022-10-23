class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }
    newAdditions(footballPlayers) {
        //"{name}/{age}/{playerValue}"
        let uniquePlayers = [];

        footballPlayers.forEach(player => {
            let [name, age, value] = player.split('/');
            age = Number(age);
            value = Number(value);
            let currentPlayer = this.invitedPlayers.find(p => p.name === name);
            if (currentPlayer && value >= currentPlayer.playerValue) {
                currentPlayer.playerValue = value;
            } else {
                this.invitedPlayers.push({ name, age, playerValue: value });
                uniquePlayers.push(name);
            }
        });

        return `You successfully invite ${uniquePlayers.join(', ')}.`;
    }
    signContract(selectedPlayer) {
        //"{name}/{playerOffer}"
        let name = selectedPlayer.split('/')[0];
        let offer = Number(selectedPlayer.split('/')[1]);
        let existingPlayer = this.invitedPlayers.find(p => p.name === name);

        if (!existingPlayer) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (existingPlayer.playerValue > offer) {
            let difference = existingPlayer.playerValue - offer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${difference} million more are needed to sign the contract!`);
        }

        existingPlayer.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${existingPlayer.name} for ${offer} million dollars.`;
    }
    ageLimit(name, age) {
        let existingPlayer = this.invitedPlayers.find(p => p.name === name);

        if (!existingPlayer) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (existingPlayer.age >= age) {
            return `${existingPlayer.name} is above age limit!`;
        }
        
        let difference = age - existingPlayer.age;

        if (difference < 5) {
            return `${name} will sign a contract for ${difference} years with ${this.clubName} in ${this.country}!`;
        }else{
            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        }
    }
    transferWindowResult(){
        let output = ["Players list:"];
        this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))
        .forEach(p => output.push(`Player ${p.name}-${p.playerValue}`));
        
        return output.join('\n');
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
//let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Lionel Messi/60"));
console.log(fTeam.signContract("Kylian Mbappé/240"));
//console.log(fTeam.signContract("Barbukov/10"));
//let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.ageLimit("Lionel Messi", 33 ));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.ageLimit("Pau Torres", 26));
console.log(fTeam.signContract("Kylian Mbappé/240"));
//let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52", "Kylian Mbappé/23/160"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());

