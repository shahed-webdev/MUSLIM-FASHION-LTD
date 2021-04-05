
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
        for (let item in cart) {
            if (cart[item].ProductId === product.ProducId) {
                cart[item].Quantity = product.Quantity;
                saveCart();
                return;
            }
        }

        cart.push(product);
        saveCart();
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

            itemCopy.total = Number(item.UnitPrice * item.Quantity).toFixed(2);
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

function displayCart() {
    const cartArray = shoppingCart.listCart();
    var output = "";
    for (let i in cartArray) {
        output += `<tr>
                    <td class="d-flex align-items-center">
                      <img src="${cartArray[i].ProductUrl}" alt="${cartArray[i].Name}"/>
                      <div class="text-left">
                       <p class="mb-0">${cartArray[i].Name}</p>
                     
                      </div>
                    </td>
                    <td>৳${cartArray[i].UnitPrice}</td>
                    <td class="text-center">
                      <input class="item-quantity" data-id="${cartArray[i].ProductQuantitySetId}" value="${cartArray[i].Quantity}" min="1" type="number">
                    </td>
                    <td>৳${cartArray[i].total}</td>
                    <td class="text-right">
                      <button data-id="${cartArray[i].ProductQuantitySetId}" type="button" class="btn btn-sm grey darken-3 text-white delete-item" data-toggle="tooltip" data-placement="top" title="Remove item">X</button>
                    </td>
                </tr>`
    }

    $('.total-cart-count').html(shoppingCart.totalQuantityCount());
    //total amount
    $('.grand-total-amount').html(shoppingCart.totalAmountCart());
    $('#orderTotal').html(shoppingCart.totalAmountCart());

    if (!shoppingCart.totalQuantityCount()) {
        const emptyRow = `<tr><td colspan="5" class="alert alert-danger">No Product Added</td></tr>`;
        $('.show-cart tbody').html(emptyRow);

        $('.show-cart thead').hide();
        $('.modal-footer').hide();

        return;
    }

    $('.modal-footer').show();
    $('.show-cart tbody').html(output);
}


// Item quantity input
$('.show-cart').on("change", ".item-quantity",
    function(event) {
        const id = $(this).data('id');
        const quantity = Number($(this).val());

        if (quantity < 1) return;

        shoppingCart.inputQuantity(id, quantity);

        displayCart();
    });


// Delete item button
$('.show-cart').on("click", ".delete-item", function (event) {
    const id = $(this).data('id');

    shoppingCart.removeProduct(id);
    displayCart();
})


// -1
$('.show-cart').on("click", ".minus-item", function (event) {
    const id = $(this).data('id');
    shoppingCart.decreaseQuantity(id);

    displayCart();
})


// +1
$('.show-cart').on("click", ".plus-item", function (event) {
    const id = $(this).data('id');

    shoppingCart.increaseQuantity(id);
    displayCart();
})


displayCart();
