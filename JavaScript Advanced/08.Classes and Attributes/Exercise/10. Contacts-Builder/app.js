class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
        this.el = document.createElement('article');
    }

    getContent() {
        return `<div class="title">${this.firstName} ${this.lastName}<button>\u2139 </button></div>
                <div class="info" style="display: none;">
                    <span>\u260E ${this.phone}</span>
                    <span>\u2709 ${this.email}</span>
                </div>`
    }

    render(id) {
        let parent = document.getElementById(id);
        this.el.innerHTML = this.getContent();
        let title = this.el.querySelector('.title');
        this.title = title;
        if (this.online) {
            this.title.classList.add('online');
        }
        parent.appendChild(this.el);

        let button = this.el.querySelector('button');
        let info = this.el.querySelector('.info');

        button.addEventListener('click', (e) => {
            info.style.display = info.style.display == 'none'? 'block' : 'none';
        });

    }
    set online(value) {
        this._online = value;
        if (this.title) {
            if (value === true) {
                this.title.classList.add('online');
            } else {
                this.title.classList.remove('online');
            }
        }
    }

    get online() {
        return this._online;
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
