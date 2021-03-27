
const methods = (function() {
    const serializeForm = function(form) {
        const obj = {};
        const formData = new FormData(form);
        for (let key of formData.keys()) {
            obj[key] = formData.get(key);
        }
        return obj;
    };

    const publicObj = {
        getForm: serializeForm
    }

    return publicObj;
})();