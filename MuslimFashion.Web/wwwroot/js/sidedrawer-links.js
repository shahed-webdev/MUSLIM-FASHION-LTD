
let linkData = [{
        "LinkCategoryID": 1,
        "SN": 1,
        "Category": "Settings",
        "IconClass": "fas fa-cog",
        "links": [{
            "LinkID": 1,
            "SN": 1,
            "Controller": "Settings",
            "Action": "ProjectStatus",
            "Title": "Project Status",
            "IconClass": null
        }, {
            "LinkID": 2,
            "SN": 2,
            "Controller": "Settings",
            "Action": "ProjectDonor",
            "Title": "Project Donor",
            "IconClass": null
        }, {
            "LinkID": 3,
            "SN": 3,
            "Controller": "Settings",
            "Action": "BeneficiaryType",
            "Title": "Project Beneficiary",
            "IconClass": null
        }, {
            "LinkID": 5,
            "SN": 5,
            "Controller": "Settings",
            "Action": "Country",
            "Title": "Country",
            "IconClass": null
        }, {
            "LinkID": 6,
            "SN": 6,
            "Controller": "Settings",
            "Action": "State",
            "Title": "State",
            "IconClass": null
        }, {
            "LinkID": 7,
            "SN": 7,
            "Controller": "Settings",
            "Action": "City",
            "Title": "City",
            "IconClass": null
        }]
    },
    {
        "LinkCategoryID": 1,
        "SN": 1,
        "Category": "Projects",
        "IconClass": "fas fa-list-ul",
        "links": [{
            "LinkID": 1,
            "SN": 1,
            "Controller": "Projects",
            "Action": "Features",
            "Title": "Features List",
            "IconClass": null
        }]
    }];

//selectors
const menuItem = document.getElementById("menuItem");

//active current url
function setNavigation() {
    const links = menuItem.querySelectorAll(".links")
    let path = window.location.pathname

    path = path.replace(/\/$/, "")
    path = decodeURIComponent(path)
   
    links.forEach(link => {
        const href = link.getAttribute('href')

        if (path === href) {
            if (link.parentElement.nodeName !== "STRONG") {
                const parentElement = link.parentElement.parentElement
                parentElement.previousElementSibling.classList.add("open")
                parentElement.classList.add("active")
            }

            link.classList.add('link-active')
        }
    })
}

//click on link
const linkCategoryClicked = function (evt) {
    const element = evt.target;
    if (element.nodeName === "STRONG") {
        if (element.nextElementSibling) {
            element.nextElementSibling.classList.toggle("active")
            element.classList.toggle("open")
        }
    }
}

//event listener
menuItem.addEventListener("click", linkCategoryClicked)

setNavigation();