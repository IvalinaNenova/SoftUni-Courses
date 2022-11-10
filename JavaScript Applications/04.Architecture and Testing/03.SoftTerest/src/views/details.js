let section = document.querySelector('#detailsPage');
section.remove();

export function showDetails(context){
    context.showSection(section);
}
