function hightlight_row(rowId) {
    var table = document.getElementById('datatable');
    var cells = table.getElementsByTagName('td');

    var rowsNotSelected = table.getElementsByTagName('tr');
    for (var row = 0; row < rowsNotSelected.length; row++) {
        rowsNotSelected[row].style.backgroundColor = "";
        rowsNotSelected[row].classList.remove('selected');
    }
    if (rowId > 0) {
        var rowSelected = table.getElementsByTagName('tr')[rowId];
        rowSelected.style.backgroundColor = "yellow";
        rowSelected.className += " selected";
    }
}
