function getDimensions(element) {
    var rect = $("#" + element)[0].getBoundingClientRect();
    return JSON.stringify(rect);
}
function setDimensions(element, height) {
    $("#" + element).css('height', height + 'px');
}

