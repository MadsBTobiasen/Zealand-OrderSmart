// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Af Mads
//Method that takes an id of a given div, and increments the value-property by one.
function incrementAmount(maxAmount, idDiv) {

    var div = getDiv(idDiv)

    if (div.value >= maxAmount) {
        div.value = maxAmount;
    } else {
        div.value = (parseInt(div.value) + 1);
    }

}

//Af Mads
//Method that takes an id of a given div, and decrements the value-property by one.
function decrementAmount(minAmount, idDiv) {

    var div = getDiv(idDiv)

    if (div.value <= minAmount) {
        div.value = minAmount;
    } else {
        div.value = (parseInt(div.value) - 1);
    }

}

//Af Mads
//Method that takes an id of a given div, and checks if the value-property is bigger than maxAmount,
//If true, the value is not incremented.
function checkMax(maxAmount, idDiv) {

    var div = getDiv(idDiv);

    if (div.value > maxAmount) {
        div.value = maxAmount;
    }

}

//Af Mads
//Method that takes an id of a given div, and gets the HTML element of the div.
function getDiv(idDiv) {

    var selector = "new_amount_div_" + idDiv;
    return document.getElementById(selector);

}

//Af Martin
//JavaScript that updates the site automatically every 15 seconds.
function timedRefresh(timeoutPeriod) {
    setTimeout("location.reload(true);", timeoutPeriod);
}