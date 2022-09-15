function extract(content) {
    let contentElement = document.getElementById(content);
        
   
    let pattern = /\(([^(]+)\)/g;
    let matches = contentElement.textContent.matchAll(pattern);

    let matchesArray = [];
    for (const match of matches) {
        matchesArray.push(match[1]);
    }
    
    return matchesArray.join('; ');
}