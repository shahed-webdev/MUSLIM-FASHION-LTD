
const shoppingCart = (function () {
    // Private methods
    let cart = [];

    // Save cart
    function saveCart() {
        localStorage.setItem('shoppingCart', JSON.stringify(cart));
    }

    // Load cart
    function loadCart() {
        cart = JSON.parse(localStorage.getItem('shoppingCart'));
    }

    if (localStorage.getItem("shoppingCart") != null) {
        loadCart();
    }


    // Public methods and properties
    const obj = {};

    // get cart
    obj.getCart = function () {
        return { shoppingList: cart, cartTotal: obj.totalCart() }
    }

    // Add to cart
    obj.addItemToCart = function (product) {
        const found = cart.some(el => el.ProductId === product.ProductId);
        
        if (!found) {
            cart.push(product);
            saveCart();
        }

        return found;
    }

    // input quantity
    obj.inputQuantity = function (id, quantity) {
        for (let item in cart) {
            if (cart[item].ProductId === id) {
                cart[item].Quantity = +quantity;
                break;
            }
        }
        saveCart();
    };

    // increase quantity
    obj.increaseQuantity = function (id) {
        for (let item in cart) {
            if (cart[item].ProductId === id) {
                cart[item].Quantity = +cart[item].Quantity+1;
                saveCart();
                return;
            }
        }
    }

    // decrease quantity
    obj.decreaseQuantity = function (id) {
        for (let item in cart) {
            if (cart[item].ProductId === id) {
                cart[item].Quantity--;
                if (cart[item].Quantity === 0) {
                    cart.splice(item, 1);
                }
                break;
            }
        }

        saveCart();
    }

    // Remove product from cart
    obj.removeProduct = function (id) {
        for (let item in cart) {
            if (cart[item].ProductId === id) {
                cart.splice(item, 1);
                break;
            }
        }
        saveCart();
    }

    // Clear cart
    obj.clearCart = function () {
        cart = [];
        saveCart();
    }

    //total quantity Count cart 
    obj.totalQuantityCount = function () {
        var totalCount = 0;
        for (let item in cart) {
            if (cart.hasOwnProperty(item)) {
                totalCount += +cart[item].Quantity;
            }
        }
        return totalCount;
    }

    // Total amount cart
    obj.totalAmountCart = function () {
        let totalCart = 0;
        for (let item in cart) {
            if (cart.hasOwnProperty(item)) {
                totalCart += cart[item].UnitPrice * cart[item].Quantity;
            }
        }
        return Number(totalCart.toFixed(2));
    }

    // List cart
    obj.listCart = function () {
        const cartCopy = [];
        for (let i in cart) {
            const item = cart[i];
            const itemCopy = {};
            for (let p in item) {
                itemCopy[p] = item[p];
            }

            itemCopy.LineTotal = Number(item.UnitPrice * item.Quantity).toFixed(2);
            cartCopy.push(itemCopy)
        }
        return cartCopy;
    }

    // get added product
    obj.getProduct = function (id) {
        for (let i in cart) {
            if (cart[i].ProductId === id) {
                return cart[i];
            }
        }
        return null;
    };

    return obj;
})();


// *****************************************
// Triggers / Events
// ***************************************** 

//show products table data
function displayCart() {
    const cartArray = shoppingCart.listCart();
    var output = "";
    for (let i in cartArray) {
        output += `<tr>
                    <td class="d-flex flex-wrap align-items-center">
                      <img src="${cartArray[i].ImageFileName}" alt="${cartArray[i].ProductName}"/>
                      <div class="text-left">
                       <p class="mb-0">${cartArray[i].ProductName}</p><strong>Size: ${cartArray[i].ProductSize}</strong>
                      </div>
                    </td>
                    <td>৳${cartArray[i].UnitPrice}</td>
                    <td class="text-center">
                      <input class="item-quantity form-control" id="${cartArray[i].ProductId}" value="${cartArray[i].Quantity}" min="1" max="50" type="number" required>
                    </td>
                    <td class="text-right">
                      <button id="${cartArray[i].ProductId}" type="button" class="btn btn-sm grey darken-3 text-white delete-item" title="Remove item">X</button>
                    </td>
                </tr>`
    }

    //cart quantity
    updateCartQuantity();

    //total amount
    setTotalAmountCart();

    $('.show-cart tbody').html(output);
}

//set total count product cart
function updateCartQuantity() {
    if (!shoppingCart.totalQuantityCount()) {
        $("#cartModal").modal("hide");
    }

    const totalCart = document.querySelector(".total-cart-count");
    totalCart.textContent = shoppingCart.totalQuantityCount();
}

//set grand total amount
function setTotalAmountCart() {
    const totalCart = document.querySelector(".grand-total-amount");
    totalCart.textContent = shoppingCart.totalAmountCart();
}

//remove item
const productTable = document.querySelector(".product-table");
productTable.addEventListener("click", function(evt) {
    const element = evt.target;
    const onRemove = element.classList.contains("delete-item");

    if (onRemove) {
        shoppingCart.removeProduct(element.id);
        element.parentElement.parentElement.remove();

        setTotalAmountCart();
        updateCartQuantity();
    }
});

// Item quantity input
productTable.addEventListener("change", function (evt) {
    const element = evt.target;
    const onInput = element.classList.contains("item-quantity");

    if (onInput) {
        const id = element.id;
        const quantity = +element.value;

        if (quantity < 1) return;

        shoppingCart.inputQuantity(id, quantity);

        setTotalAmountCart();
        updateCartQuantity();
    }
});


//on modal click
const cartCount = document.getElementById("cartCount");
cartCount.addEventListener("click", function (evt) {

    if (shoppingCart.totalQuantityCount()) {
        displayCart();
        $("#cartModal").modal("show");
    }
});


displayCart();
