let section = document.querySelector('#createPage');
section.remove();

export function showCreate(context){
    context.showSection(section);
}