let section = document.querySelector('#loginPage');
section.remove();

export function showLogin(context){
    context.showSection(section);
}