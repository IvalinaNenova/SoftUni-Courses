let section = document.querySelector('#homePage');
section.remove();

export function showHome(context){
    context.showSection(section);
}
