let section = document.querySelector('#dashboard-holder');
section.remove();

export function showCatalog(context){
    context.showSection(section);
}