/*
 * Fonctions de grille
 */


function formatDate(d, offset) {
    if (d == null) {
        return "";
    }
    if (d.toString().indexOf("/Date(") == 0) {
        d = new Date(parseInt(d.substr(6)) + parseInt(offset));
    }
    else {
        d = new Date(d);
    }
    //var d = new Date(dateObject);
    var day = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    if (day < 10) {
        day = "0" + day;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var date = day + "/" + month + "/" + year;

    return date;
};

function calculSumColonne(grid, ColName) {
    var sum = 0;
    for (var i = 0; i < grid.igGrid('rows').length; i++) {
        var idRow = $(grid.igGrid('rows')[i]).data("id");
        sum = sum + ($.isNumeric(grid.igGrid("getCellValue", idRow, ColName)) ? grid.igGrid("getCellValue", idRow, ColName) : 0);
    }
    return sum == 100;

}
function getSommeSummury(grid, ColName, type) {
    for (var i in grid.igGridSummaries("summariesFor", ColName)) {
        if (grid.igGridSummaries("summariesFor", ColName)[i].type == type) {
            return grid.igGridSummaries("summariesFor", ColName)[i].result;
        }
    }
}
function changeDeviseTR(grid, newIdDeviseTR) {
    ////var totalCredit = 0, totalDebit = 0, debit, credit;

    ////var courChange=1;
    ////for(var i=0;i<listDevises.length;i++)
    ////{
    ////    if(listDevises[i].ID===newIdDeviseTR)
    ////    {
    ////        courChange=listDevises[i].COUR;
    ////    }
    ////}


    //for (var i = 0; i < grid.igGrid('rows').length; i++) {


    //    var idRow = $(grid.igGrid('rows')[i]).data("id");
    //    if (idRow > 0) {
    //        var debitTR = grid.igGrid("getCellValue", idRow, "DebitTR") ? grid.igGrid("getCellValue", idRow, "DebitTR") : 0;
    //        var creditTR = grid.igGrid("getCellValue", idRow, "CreditTR") ? grid.igGrid("getCellValue", idRow, "CreditTR") : 0;

    //        grid.igGridUpdating('updateRow', idRow, { 'IdDeviceTR': newIdDeviseTR, 'CreditTC': creditTR * courChange, 'DebitTC': debitTR * courChange });
    //    }
    //    else {
    //        console.log('Erreur changeDeviseTR');
    //    }

    //}
    var datasource = grid.data("igGrid").dataSource.data();
    var debitTR = 0;
    var creditTR = 0;

    for (var i in datasource) {
        //debitTR = grid.igGrid("getCellValue", idRow, "DebitTR") ? grid.igGrid("getCellValue", idRow, "DebitTR") : 0;
        //creditTR = datasource[i].CreditTR ? grid.igGrid("getCellValue", idRow, "CreditTR") : 0;
        var oldRow = grid.data("igGrid").dataSource.findRecordByKey(datasource[i].Id);
        oldRow.IdDeviceTR = newIdDeviseTR;
        oldRow.CreditTC = formatDouble((oldRow.CreditTR == null) ? null : oldRow.CreditTR * courChange);
        oldRow.DebitTC = formatDouble((oldRow.DebitTR == null) ? null : oldRow.DebitTR * courChange);

        if (oldRow.CPT_Echeances_grille != null && oldRow.CPT_Echeances_grille.Records != null) {
            for (var j in oldRow.CPT_Echeances_grille.Records) {
                oldRow.CPT_Echeances_grille.Records[j].MontantTC = formatDouble((oldRow.CPT_Echeances_grille.Records[j].MontantTR == null) ? null : oldRow.CPT_Echeances_grille.Records[j].MontantTR * courChange);
            }
        }

        grid.data("igGrid").dataSource.updateRow(datasource[i].Id, oldRow);
    }
    rebind(grid);


}

function formatDouble(montant) {
    return montant == null ? null : Math.round(montant * 100) / 100;
}


function calculeTRtoTC(grid, idRow) {
    var idTR = grid.igGrid("getCellValue", idRow, "IdDeviceTR");
    var debitTR = grid.igGrid("getCellValue", idRow, "DebitTR") ? grid.igGrid("getCellValue", idRow, "DebitTR") : null;
    var creditTR = grid.igGrid("getCellValue", idRow, "CreditTR") ? grid.igGrid("getCellValue", idRow, "CreditTR") : null;

    grid.igGridUpdating('updateRow', idRow, { 'CreditTC': creditTR == null ? null : formatDouble(creditTR * courChange), 'DebitTC': debitTR == null ? null : formatDouble(debitTR * courChange) });
    calculeTotaux(grid);
}

function calculeTRtoTCChild(grid, idRow) {
    var montantTR = grid.igGrid("getCellValue", idRow, "MontantTR") ? grid.igGrid("getCellValue", idRow, "MontantTR") : null;
    
    grid.igGridUpdating('updateRow', idRow, { 'MontantTC': montantTR == null ? null : formatDouble(montantTR * courChange)});
    calculeTotaux(grid);
}

function loadEditorID(grid, ColumnKey, idSpan) {



    var colSettings = grid.data("igGridUpdating").options.columnSettings;
    for (var colNumber = 0; colNumber < colSettings.length; colNumber++) {
        if (colSettings[colNumber].columnKey === ColumnKey && colSettings[colNumber].editorOptions) {
            colSettings[colNumber].editorOptions.id = idSpan;
            break;
        }

    }

    //alert('combobox chargé');
}

function setColumnDefaultValue(grid, ColumnKey, defaultValue) {
    var colSettings = grid.data("igGridUpdating").options.columnSettings;
    for (var colNumber = 0; colNumber < colSettings.length; colNumber++) {
        if (colSettings[colNumber].columnKey === ColumnKey) {
            colSettings[colNumber].defaultValue = defaultValue;
            //if (colSettings[colNumber].editorType && colSettings[colNumber].editorType === "combo") {
            //    if (JSON.stringify(colSettings[colNumber].editorOptions.dataSource) != JSON.stringify(listItems))
            //        colSettings[colNumber].editorOptions.dataSource = listItems;
            //}
            break;
        }

    }
}


function loadComboItems(grid, ColumnKey, listItems) {

    if (grid.igGridUpdating("isEditing")) {
        var editor = grid.igGridUpdating("editorForKey", ColumnKey);
        editor.igCombo("option", "dataSource", listItems);
        editor.igCombo("dataBind");
    }
    else {
        var colSettings = grid.data("igGridUpdating").options.columnSettings;
        for (var colNumber = 0; colNumber < colSettings.length; colNumber++) {
            if (colSettings[colNumber].columnKey === ColumnKey) {
                if (colSettings[colNumber].editorType && colSettings[colNumber].editorType === "combo") {
                    if (JSON.stringify(colSettings[colNumber].editorOptions.dataSource) != JSON.stringify(listItems))
                        colSettings[colNumber].editorOptions.dataSource = listItems;
                }
                break;
            }

        }
    }
    //alert('combobox chargé');
}


//var grid = $("#listGridComptesTVA");
function loadListCombo(grid, listLookup, ColumnKey) {
    var comboDataSource = {};
    var colSettings = grid.data("igGridUpdating").options.columnSettings;
    for (var colNumber = 0; colNumber < colSettings.length; colNumber++) {
        if (colSettings[colNumber].columnKey === ColumnKey) {
            if (colSettings[colNumber].editorType && colSettings[colNumber].editorType === "combo") {
                comboDataSource = colSettings[colNumber].editorOptions.dataSource;
                if (typeof (comboDataSource) != "undefined" && comboDataSource != null) {
                    for (var i = 0; i < comboDataSource.length; i++) {
                        listLookup[comboDataSource[i].ID] = comboDataSource[i];
                    }
                }

            }
            break;
        }

    }
}



function columnSettingIndex(grid, ColumnKey) {



    var colSettings = grid.data("igGridUpdating").options.columnSettings;
    for (var colNumber = 0; colNumber < colSettings.length; colNumber++) {
        if (colSettings[colNumber].columnKey === ColumnKey) {

            return colNumber;

        }

    }

    //alert('combobox chargé');
}



function calculeTotaux(grid) {

    var totalCreditTR = 0, totalDebitTR = 0, debitTR, creditTR;
    var totalCreditTC = 0, totalDebitTC = 0, debitTC, creditTC;
    var listDeletedRow = deletedRow(grid);

    for (var i = 0; i < grid.igGrid('rows').length; i++) {

        var id = $(grid.igGrid('rows')[i]).data("id");
        if (id > 0 && typeof (listDeletedRow[id]) == "undefined") {
            debitTR = grid.igGrid("getCellValue", id, "DebitTR");
            creditTR = grid.igGrid("getCellValue", id, "CreditTR");

            debitTC = grid.igGrid("getCellValue", id, "DebitTC");
            creditTC = grid.igGrid("getCellValue", id, "CreditTC");



            totalDebitTR = totalDebitTR + ($.isNumeric(debitTR) ? debitTR : 0);
            totalCreditTR = totalCreditTR + ($.isNumeric(creditTR) ? creditTR : 0);

            totalDebitTC = totalDebitTC + ($.isNumeric(debitTC) ? debitTC : 0);
            totalCreditTC = totalCreditTC + ($.isNumeric(creditTC) ? creditTC : 0);
        }
    }
    $.ig.regional.defaults.currencySymbol = '';
    $("#totalCreditTR").text($.ig.formatter(totalCreditTR, "number", "currency"));
    $("#totalDebitTR").text($.ig.formatter(totalDebitTR, "number", "currency"));


    $("#totalCreditTC").text($.ig.formatter(totalCreditTC, "number", "currency"));
    $("#totalDebitTC").text($.ig.formatter(totalDebitTC, "number", "currency"));


    $("#deviseTR").text(codeTR);
    $("#deviseTC").text(codeTC);


}

function updateAllRowsValue(grid, columnKey, value) {


    var listDeletedRow = deletedRow(grid);
    var object = {};
    var attr = new Array();
    object[columnKey] = value;
    attr.push(object);
    for (var i = 0; i < grid.igGrid('rows').length; i++) {

        var id = $(grid.igGrid('rows')[i]).data("id");
        if (id > 0 && typeof (listDeletedRow[id]) == "undefined") {
            grid.igGridUpdating('updateRow', id, attr[0]);
        }
    }



}


function permut(gridId, idRow, nbr) {
    var grid = $("#" + gridId);

    //alert(idRow);
    //$(gridEcritures.igGrid('rows')[0]).data('id')
    var idRowNbr = -1;

    for (var i = 0; i < grid.igGrid('rows').length; i++) {
        //lookup[i] = $(gridEcritures.igGrid('rows')[i]).data('id');
        if ($(grid.igGrid('rows')[i]).data('id') == idRow && typeof (grid.igGrid('rows')[i + nbr]) != "undefined") {
            idRowNbr = $(grid.igGrid('rows')[i + nbr]).data('id');
        }
    }
    //alert(idRow+' '+idRowNbr);
    if (idRowNbr > -1) {
        //var columns = grid.igGrid("option", "columns");
        //for (var colNumber = 0; colNumber < columns.length; colNumber++) {
        //    //if (columns[colNumber].key != "actionsColumn") {
        //        var cellValue = grid.igGrid("getCellValue", idRow, columns[colNumber].key);
        //        grid.igGridUpdating("setCellValue", idRow, columns[colNumber].key, grid.igGrid("getCellValue", idRowNbr, columns[colNumber].key));
        //        grid.igGridUpdating("setCellValue", idRowNbr, columns[colNumber].key, cellValue);
        //    //}
        //}
        var cellValue = grid.igGrid("getCellValue", idRow, "NumOrdre");

        grid.igGridUpdating('updateRow', idRow, { 'NumOrdre': grid.igGrid("getCellValue", idRowNbr, "NumOrdre") });
        grid.igGridUpdating('updateRow', idRowNbr, { 'NumOrdre': cellValue });

        //grid.igGridUpdating("setCellValue", idRow, "NumOrdre", grid.igGrid("getCellValue", idRowNbr, "NumOrdre"));
        //grid.igGridUpdating("setCellValue", idRowNbr, "NumOrdre", cellValue);

        grid.igGridSorting('sortColumn', 'NumOrdre', 'asc');

    }


    //showcolumn(grid, gridColumns[model + "Edit"]);
    //grid.igGridUpdating('option', 'editMode', 'dialog');
    //grid.igGridUpdating('startEdit', idRow);
}


function solder(gridId, idRow) {
    var grid = $("#" + gridId);


    if (!ecritureIsLettered(grid, idRow)) {
        //var dataSource = grid.igGrid("option", "dataSource");
        var totalCredit = 0, totalDebit = 0, debit, credit;
        //var listDeletedRow = deletedRow(grid);
        //$(".selector").igGrid("getCellValue", 3, "ShipDate");
        for (var i = 0; i < grid.igGrid('rows').length; i++) {

            var id = $(grid.igGrid('rows')[i]).data("id");
            //if (id > 0 && id != idRow && typeof (listDeletedRow[id]) == "undefined") {
            if (id > 0 && id != idRow) {
                debit = grid.igGrid("getCellValue", id, "DebitTR");
                credit = grid.igGrid("getCellValue", id, "CreditTR");

                totalDebit = totalDebit + ($.isNumeric(debit) ? debit : 0);
                totalCredit = totalCredit + ($.isNumeric(credit) ? credit : 0);
            }

        }
        grid.igGridUpdating('updateRow', idRow, { 'DebitTR': totalCredit - totalDebit > 0 ? formatDouble(totalCredit - totalDebit) : null, 'CreditTR': totalDebit - totalCredit > 0 ? formatDouble(totalDebit - totalCredit) : null });
        //grid.igGridUpdating("setCellValue", idRow, "DebitTR", totalCredit-totalDebit>0?totalCredit-totalDebit:null);
        //grid.igGridUpdating("setCellValue", idRow, "CreditTR", totalDebit-totalCredit>0?totalDebit-totalCredit:null);
        calculeTRtoTC(grid, idRow);
        updateEcheances(grid, idRow, gridEcritures.igGrid("getCellValue", idRow, "IdTypePaiement"), formatDouble(totalCredit - totalDebit), gridEcritures.igGrid("getCellValue", idRow, "isAdded") ? "True" : "False");
    }
    else {
        noty({ text: 'Veuillez délettré l\'échéance pour pouvoir la solder', layout: 'topRight', type: 'error' });
    }
}

function deletedRow(grid) {
    var transactions = grid.igGrid("allTransactions");
    var lisdeletedRow = [];
    for (var i = 0; i < transactions.length; i++) {
        if (transactions[i].type === "deleterow") {
            lisdeletedRow[transactions[i].rowId] = transactions[i].rowId;
        }

    }
    return lisdeletedRow;
}


function rebind(grid) {

    //var pendingTransactions = grid.data("igGrid").dataSource.pendingTransactions();

    //var allTransactions = grid.data("igGrid").dataSource.allTransactions();

    //grid.igGrid("commit");

    grid.igGrid("dataBind");

    //grid.data("igGrid").dataSource._transactionLog = pendingTransactions;

    //grid.data("igGrid").dataSource._accumulatedTransactionLog = allTransactions;

}


function showcolumn(grid, columnToShow) {
    var cols = grid.igGrid("option", "columns");
    for (c in cols) {
        if (('#' + columnToShow + '#').indexOf('#' + cols[c].key + '#') >= 0) {
            cols[c].hidden = false;
        }
        else {
            cols[c].hidden = true;
        }
    }
}

function replaceComma(value) {
    // Quick & Dirty replace ',' by '.' as decimal separators
    return value.replace(',', '.');
}
function enableUpdatecolumn(grid, columnToChange, enable) {
    var cols = grid.igGridUpdating("option", "columnSettings");
    for (c in cols) {
        if (('#' + columnToChange + '#').indexOf('#' + cols[c].columnKey + '#') >= 0) {
            cols[c].readOnly = enable;
        }
        //else {
        //    cols[c].hidden = true;
        //}
    }
    grid.igGridUpdating("option", "columnSettings", cols);
}

function replaceComboFilterEditor(idGrid, columnKey, dataSourceCombo) {
    $($('tr[data-role="filterrow"] td[aria-describedby="' + idGrid+'_'+columnKey + '"]')[0]).children().hide()
    $($('tr[data-role="filterrow"] td[aria-describedby="' + idGrid + '_' + columnKey + '"]')[0]).append('<div id="filter' + idGrid + '_' + columnKey + '" class="ui-igedit" ></div>');
    var grid=$('#'+idGrid);
    $("#filter" + idGrid + '_' + columnKey).igCombo({

        dataSource: dataSourceCombo,

        textKey: "VALUE",

        valueKey: "ID",

        //mode: "dropdown",

        width: "100%",

        autoSelectFirstMatch : false,

        autoComplete : true,

        selectionChanged:

        function (evt, ui) {

            var expressions = grid.data("igGrid").dataSource.settings.filtering.expressions;

            grid.data("igGrid").dataSource.settings.filtering.expressions = [];

            var newExpressions = [];

            if (expressions.length !== 0) {

                for (var i = 0; i < expressions.length; i++) {

                    if (expressions[i].fieldName !== columnKey) {

                        newExpressions.push({

                            fieldName: expressions[i].fieldName,

                            expr: expressions[i].expr,

                            cond: expressions[i].cond

                        });

                    }

                }

            }
            if ((ui.items !== null) && (ui.items.length === 1)) {

                newExpressions.push({

                    fieldName: columnKey,

                    expr: parseInt(ui.items[0].data.ID),

                    cond: "equals"

                });
            }
            setTimeout(function () {
                grid.igGridFiltering("filter", newExpressions);
            }, 100);
        }
    });
}

function redirectTo(link) {
    window.location.replace(link);
}

function form_to_json(selector) {
    var ary = $(selector).serializeArray();
    var obj = {};
    for (var a = 0; a < ary.length; a++) obj[ary[a].name] = ary[a].value;
    return obj;
    return ary;
}


$(document).ready(function () {
    //var defaults = $.fn.datepicker.defaults = {

    //    format: "dd/mm/yyyy",
    //    weekStart: 1,
    //    autoclose: true,
    //    language: "fr",
    //    todayBtn: true,
    //    keyboardNavigation: true,
    //    orientation: "auto",
    //    todayHighlight: true


    //    //autoclose: false,
    //    //beforeShowDay: $.noop,
    //    //calendarWeeks: false,
    //    //clearBtn: false,
    //    //daysOfWeekDisabled: [],
    //    //endDate: Infinity,
    //    //forceParse: true,
    //    //format: 'mm/dd/yyyy',

    //    //language: 'en',
    //    //minViewMode: 0,
    //    //multidate: false,
    //    //multidateSeparator: ',',

    //    //rtl: false,
    //    //startDate: -Infinity,
    //    //startView: 0,

    //    //todayHighlight: false,
    //    //weekStart: 0
    //};
    //$.fn.datepicker.defaults.format = "dd/mm/yyyy";
    //$.fn.datepicker.defaults.weekStart = 1;
    //$.fn.datepicker.defaults.autoclose = true;
    //$.fn.datepicker.defaults.language = "fr";

    if (typeof ($.validator) != "undefined") {
        $.validator.methods.range = function (value, element, param) {
            var globalizedValue = value.replace(",", ".");
            return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
        }

        $.validator.methods.number = function (value, element) {
            return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\,]\d{3})+)(?:[\,]\d+)?$/.test(value);
        }

        $.validator.methods.date = function (value, element) {
            var date_regex = /(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))/;
            //alert(date_regex.test(value));
            return this.optional(element) || date_regex.test(value);
        }
    }

    if (typeof ($.datepicker) != "undefined") {
        $.datepicker.setDefaults($.datepicker.regional['fr']);
    }

    $('.selectpicker').selectpicker();
});

$(document).ready(function () {
    $(".dropdown-toggle").dropdown();
});

function HideShowBoutton() {
    var $param = $('input[name=ChoixParam]:checked').val();
    if ($param == 2) {
        $('input[name=next]').show();
        $('input[name=finish]').hide();
    } else {
        $('input[name=next]').hide();
        $('input[name=finish]').show();
    }
}