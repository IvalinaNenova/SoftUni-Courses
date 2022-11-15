import page from './node_modules/page/page.mjs'
import { loginView } from './views/login.js';
import { catalogView} from './views/catalog.js';

page('/login', loginView);
page('/catalog', catalogView);

updateNav();

export function updateNav(){
    if (sessionStorage.getItem('token') != null) {
        document.querySelector('#user').style.display = 'inline';
        document.querySelector('#guest').style.display = 'none';
    }else{
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'inline';
    }
}
page.start()
