
$.ajax({
    url: "/BasicSettings/RenderMenu",
    success: response => {
        addMenuToDom(response)
    },
    error: error => {
        console.log(error);
    }
});

function addMenuToDom(response) {
    const menuItems = document.getElementById("menu-items");
    const fragment = document.createDocumentFragment();
    response.forEach(menu => {
        fragment.append(createList(menu));
    });
    menuItems.appendChild(fragment);
}

function createList(item) {
    const li = document.createElement("li");
    li.className = "nav-item dropdown";
    li.innerHTML = `<a class="nav-link dropdown-toggle" id="${item.MenuId}" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">${item.MenuName}</a>
        <div class="dropdown-menu dropdown-default" aria-labelledby="${item.MenuId}">
            ${createSubList(item.SubMenus)}
        </div>`
    return li;
}

function createSubList(submenu) {
    let  html = "";
    submenu.forEach(sub => {
        html += `<a class="dropdown-item" href="#">${sub.SubMenuName}</a>`;
    });
    
    return html;
}