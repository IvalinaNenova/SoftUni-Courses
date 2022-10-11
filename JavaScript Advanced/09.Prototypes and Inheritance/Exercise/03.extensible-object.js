function extensibleObject() { 
    return {
        extend(template) {
            for (key in template) {
                if (typeof template[key] === 'function') {
                    Object.getPrototypeOf(this)[key] = template[key];
                } else {
                    this[key] = template[key];
                }
            }
        }
    }
} 
    const myObj = extensibleObject(); 
    const template = { 
        extensionMethod: function () {}, 
        extensionProperty: 'someString' 
      } 
      myObj.extend(template); 
          