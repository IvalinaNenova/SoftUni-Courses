export function validator(data){
    let [make, model, year, description, price, image, material] = data;

    let isValid = true;
    make.value.length >= 4 ? decorate(make, true) : decorate(make, false);
    model.value.length >= 4 ? decorate(model, true) : decorate(model, false);
    description.value.length > 10 ? decorate(description, true) : decorate(description, false);
    Number(year.value) > 1950 && Number(year.value) < 2050 ? decorate(year, true) : decorate(year, false);
    Number(price.value) > 0 ? decorate(price, true) : decorate(price, false);
    image.value != '' ? decorate(image, true) : decorate(image, false);

    function decorate(element, bool) {
        if (bool) {
            element.classList.add('is-valid');
            element.classList.remove('is-invalid');
        } else {
            isValid = false;
            element.classList.add('is-invalid');
            element.classList.remove('is-valid');
        }
    }

    let info = {
        make: make.value,
            model: model.value,
            description: description.value,
            year: year.value,
            price: price.value,
            img: image.value,
            material: material.value
    }

    return isValid? info: false;
}