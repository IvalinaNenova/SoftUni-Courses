async function loadCommits() {
    // Try it with Fetch API
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const list = document.getElementById('commits');
    try{
        const responce = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);

        if (responce.ok == false) {
            throw new Error(`Error: ${responce.status} (Not Found)`);
        }
        let data = await responce.json();
        for (const com of data) {
            let item = document.createElement('li');
            item.textContent = `${com.commit.author.name}: ${com.commit.message}`;
            list.appendChild(item);
        }
    }catch(err){
        console.log(err.message);
    }
    
}