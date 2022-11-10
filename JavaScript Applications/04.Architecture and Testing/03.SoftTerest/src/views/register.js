let section = document.querySelector('#registerPage');
section.remove();

export function showRegister(context){
    context.showSection(section);
}