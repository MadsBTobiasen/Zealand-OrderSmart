// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function incrementAmount(maxAmount, idDiv) {

    var div = getDiv(idDiv)

    if (div.value >= maxAmount) {
        div.value = maxAmount;
    } else {
        div.value = (parseInt(div.value) + 1);
    }

}

function decrementAmount(minAmount, idDiv) {

    var div = getDiv(idDiv)

    if (div.value <= minAmount) {
        div.value = minAmount;
    } else {
        div.value = (parseInt(div.value) - 1);
    }

}

function checkMax(maxAmount, idDiv) {

    var div = getDiv(idDiv);

    if (div.value > maxAmount) {
        div.value = maxAmount;
    }

}

function getDiv(idDiv) {

    var selector = "new_amount_div_" + idDiv;
    return document.getElementById(selector);

}