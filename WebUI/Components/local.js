local.InitAjaxPro = function ()
{
    var t = 1000;
    var barLoading = $("<div class='ui-state-highlight ui-corner-all' style='WIDTH:200px; PADDING:5px; position:fixed; display:none; text-align:center; z-index:9999999;'>Loading...</div>");
    var barTimeout = $("<div class='ui-state-error ui-corner-all' style='WIDTH:500px; PADDING:5px; position:fixed; display:none; text-align:center; z-index:9999999;'>Unable to connect to the server. Please try again.</div>");
    $("form:first").append(barLoading, barTimeout);

    var onLoading = function ()
    {
        barLoading.css("left", ($(document).width() - barLoading.width()) / 2);
        barLoading.css("top", t);
        barLoading.fadeIn(teq.Context.TransitionDuration);
    };
    var finishLoading = function ()
    {
        barLoading.fadeOut(teq.Context.TransitionDuration);
    };
    var showTimeout = function ()
    {
        barTimeout.css("left", ($(document).width() - barTimeout.width()) / 2);
        barTimeout.css("top", t);
        barTimeout.fadeIn(teq.Context.TransitionDuration);
    };
    var hideTimeout = function ()
    {
        barTimeout.fadeOut(teq.Context.TransitionDuration);
    };
    var onError = function (res)
    {
        var msg = "Something's went wrong:<br>" + res.Type + ": " + res.Message;
        if (res.Stack != null) msg += "<br>Stack: " + res.Stack;
        if (res.TargetSite != null) msg += "<br>TargetSite: " + res.TargetSite;
        if (res.Source != null) msg += "<br>Source: " + res.Source;
        teq.Context.Alert(msg);
    };
    teq.Context.ConfigureLoadingHandling(60000, 1000, onLoading, finishLoading, showTimeout, hideTimeout, onError);
}
local.BuildToolTipsProvider = function ()
{
    $(document).tooltip({
        position: {
            my: "left bottom",
            at: "left top",
            using: function (position, feedback)
            {
                $(this)
                .css(position)
                //.css("background", "InfoBackground")
                //.css("border", "solid 1px #000")
                .addClass("SystemToolTip")
                .removeClass("ui-corner-all")
                .removeClass("ui-widget")
                .removeClass("ui-widget-content");
            }
        }
    });
}
local.HidePreload = function ()
{
    setTimeout(function ()
    {
        $("#divcontainerpreloading_mask").remove();
        $("#divcontainerpreloading_content").fadeIn(teq.Context.TransitionDuration);
    }, teq.Context.TransitionDuration + 100);
}
local.GetTextOnlyCKConfig = function () {
    var cfg =
    {
        title: false,
        toolbarGroups: [
        //{ name: 'document', groups: ['mode', 'document', 'doctools'] },
        //{ name: 'forms' },
		    {name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
            { name: 'colors' },
            { name: 'paragraph', groups: ['list'] },
        //{name: 'links' },
        //{ name: 'insert' },
        //{name: 'styles', groups: ['Font', 'FontSize'] },
        {name: 'styles', groups: ['Font', 'FontSize'] },
           // { name: 'editing', groups: ['spellchecker'] },
            { name: 'editing' },
        //{ name: 'tools' },
        //{ name: 'others' },
        //{ name: 'about' }
	    ],
        //removeButtons : 'Anchor,Underline,Strike,Subscript,Superscript',
        forcePasteAsPlainText: true,
        removeDialogTabs: 'link:advanced',
        removePlugins: 'codemirror,uicolor,elementspath,scayt', //autogrow,
        uiColor: '#CCCCCC',
        //width: "600px",
        height: "100px",
        resize_enabled: false,
        enterMode: CKEDITOR.ENTER_BR,
        autoGrow_minHeight: 60,
        scayt_autoStartup: false
        //autoGrow_maxHeight: 400
    };

    CKEDITOR.config.fontSize_sizes = '8/8px;9/9px;10/10px;11/11px;12/12px;14/14px;16/16px;18/18px;20/20px;22/22px;24/24px';
    CKEDITOR.config.removeButtons += ",Styles,Format";
    CKEDITOR.config.font_names ="Arial/Arial, Helvetica, sans-serif;Courier New/Courier New, Courier, monospace;Georgia/Georgia, serif;Lucida Sans Unicode/Lucida Sans Unicode, Lucida Grande, sans-serif;Tahoma/Tahoma, Geneva, sans-serif;Times New Roman/Times New Roman, Times, serif;Trebuchet MS/Trebuchet MS, Helvetica, sans-serif;Verdana/Verdana, Geneva, sans-serif";
    
    return cfg;
}
local.ListingEmptyRecord = function (tbody, cols)
{
    var colSpan = cols;
    if (colSpan == null || colSpan == undefined) colSpan = tbody.prev().find("tr:first td").length;
    tbody.append("<tr><td style='height:50px;text-align:center;' valign='middle' colspan='" + colSpan + "'>No record found.</td></tr>");
}
local.ArrayToString = function (val, separator)
{
    if (separator.length == 0)
        separator = ",";

    var str = "";
    if (val instanceof Array)
    {
        for (var i = 0; i < val.length; i++)
        {
            str += val[i] + ",";
        }
        if (str.length > 0)
        {
            str = str.substr(0, str.length - 1);
        }
    }
    
    return str;
}
local.SiteDialog = function (onSaved)
{
    ContainerAjaxGateway.GetAvailableSites(function (sitesRes)
    {
        if (sitesRes.error != null) teq.Common.Alert(sitesRes.error);
        else
        {
            var dialogctrl = new teq.EntityPropertiesDialogController();
            dialogctrl.Modal = true;
            dialogctrl.DialogWidth = "400px";
            //dialogctrl.CanCancel = false;
            dialogctrl.LoadDelegate = function ()
            {
                ContainerAjaxGateway.GetLoggedInSite(function (res)
                {
                    if (res.error == null) dialogctrl.Populate(res.value);
                    else dialogctrl.Close();
                });
            };
            dialogctrl.SaveDelegate = function (entity, callback)
            {
                ContainerAjaxGateway.SaveLoggedInSite(entity, function (res)
                {
                    callback(res);
                    if (res.error == null && res.value.length == 0)
                    {
                        onSaved(entity.UserName, entity.SelectedSiteCode);
                        //self.ListControlller.RefreshList();
                    }
                });

                if (local.aspxContent_Dashboard1 != null) local.aspxContent_Dashboard1.RefreshBundle();
            };
            dialogctrl.GetTitleDelegate = function (entity)
            {
                var title = "Site Dialog";
                return title;
            };
            //#region Group: Site Dialog
            {
                var grp = new teq.EntityPropertiesGroup();
                grp.Name = "Site Dialog";
                dialogctrl.Groups.push(grp);
                //#region Section: Site Dialog
                {
                    var sec = new teq.EntityPropertiesFormSection();
                    sec.Description = "Please select your site today: ";
                    grp.Sections.push(sec);
                    //#region Field: Site Dropdown List 
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Site";
                        prop.Input = new teq.EntityDropdownSelectInput();
                        prop.Input.BuildElementDelegate = function (element)
                        {
                            var flags = [];
                            for (var i = 0; i < sitesRes.value.length; i++)
                            {
                                flags[sitesRes.value[i]] = Flags.Site[sitesRes.value[i]];
                            }
                            element.dropdownSelect(
                            {
                                //nullLabel: "- Please Select -",
                                //nullValue: "",
                                choices: flags //Flags.Site //["AABC", "CBC", "ACBC", "Wisma Penyayang"]
                            });
                        }
                        prop.GetValueDelegate = function (entity)
                        {
                            //alert(entity.SelectedSite);
                            return entity.SelectedSiteCode;
                        }
                        prop.SetValueDelegate = function (entity, val)
                        {
                            entity.SelectedSiteCode = val;
                        }
                        prop.AssociatedErrors = [ErrorCodes.LOGIN_SiteRequired];
                        prop.ValidationDelegate = function (val, callback)
                        {
                            ContainerAjaxGateway.VerifyLoggedInSite(val, callback);
                        }

                        sec.Properties.push(prop);
                    }
                    //#endregion
                }
                //#endregion
            }
            //#endregion

            dialogctrl.Initialize();
            //dialogctrl.Populate([]);
        }
    });
}
local.SecondsToTime = function (secs)
{
    var dt = new Date();
    dt.setHours(0);
    dt.setMinutes(0);
    dt.setSeconds(0);
    dt.setSeconds(secs);

    return dt;
}
local.TimeToSeconds = function (time)
{
    var dt = new Date(time);
    var hours = dt.getHours();
    var min = dt.getMinutes();
    var sec = dt.getSeconds();
    sec = (hours * 60 * 60) + (min * 60) + sec;

    return sec;
}
local.BuildAdvancedSearchDialogController=function (divHook, callback, callbackSave) {

    var mode = null;
    var module = "Road info";

    if (local.AdvancedSearchMode != null) mode = local.AdvancedSearchMode;
    if (local.AdvancedSearchModule != null) module = local.AdvancedSearchModule;
    var _callback = null;
    _callback = callback;
    if (_callback != null) {
        _callback();
    }

    var _callbacksave = null;
    _callbacksave = callbackSave;

    var ctrl = new teq.EntityPropertiesDialogController();
    ctrl.DialogWidth = 700;
    ctrl.DialogHeight= 500;
    ctrl.Modal = true;
    if (mode == null) ctrl.SaveButtonText = "Save";
    else ctrl.SaveButtonText = "Search";

    ctrl.ExtraButtons = [];
    ctrl.ExtraButtons.push({
        text: "Clear", click: function () {

        }
    });

    ctrl.ExtraButtons.push({
        text: "View Selected Road In GIS", click: function () {

        }
    });

    ctrl.LoadDelegate = function () {

        ctrl.Populate();
    }

    ctrl.SaveDelegate = function (entity, callback) {
        ctrl.Close();
        if (_callbacksave != null) {
            _callbacksave();
        }
    };
    ctrl.GetTitleDelegate = function (entity) {

        var title = "";

        if (mode != null) {

            title = "Road Info Search";
            
        }
        else
        {
            title = "My Preset Filter";

        }

       
        return title;
    };

    function Enums_GetLabel(key) {
        if (key == null) return '';
        else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
        else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
        else return '';
    }
    //#region Group: General
    {
        var inputWidth = "150px";
        var grp = new teq.EntityPropertiesGroup();
        grp.Name = "My Preset Filter";
        ctrl.Groups.push(grp);
        //#region Section: Generic
        {
            var sec = new teq.EntityPropertiesCustomSection();
             //sec.Name = "Custom Content";
            // sec.Description = "Build your own content.";
             grp.Sections.push(sec);

             sec.BuildContentDelegate = function (element) {

                 var mainTable = $("<table  align='center' cellspacing='0' cellpadding='4' border='0'>");
                 element.append(mainTable);

                 var spanKKRoadcount = $("<span style='font-size:9px;'>");
                 var spanPenRoadcount = $("<span style='font-size:9px;'>");
                 var spanTuaRoadcount = $("<span style='font-size:9px;'>");
                 var cbxRoadInput = [];
                 var cbDistrict = $("<input id='cbDistrictAll' type=checkbox>");
                 var cbRoad = $("<input id='cbRoadAll' type=checkbox>");
                 var cbxInput1 = $("<input type=checkbox checked=checked>");
                 var cbxInput2 = $("<input type=checkbox>");
                 var cbxInput3 = $("<input type=checkbox>");

                 function BuildDistrict(table) {

                     var divDistrictList = $("<div class='Wrap'>");
                     var tableDistrictList = $("<table class='List'>");
                     var tr1 = $("<tr >");
                     var tr2 = $("<tr>");
                     var tr3 = $("<tr>");
                     var td1 = $("<td style='cursor:pointer;'>");
                     var td2 = $("<td style='cursor:pointer;'>");
                     var td3 = $("<td style='cursor:pointer;'>");

                     var td1chk = $("<td >");
                     var td2chk = $("<td >");
                     var td3chk = $("<td >");


                     table.append(divDistrictList);

                     divDistrictList.append(tableDistrictList);
                     tableDistrictList.append(tr1);
                     tableDistrictList.append(tr2);
                     tableDistrictList.append(tr3);

                     //var cbxInput1 = $("<input type=checkbox>");
                     //var cbxInput2 = $("<input type=checkbox>");
                     //var cbxInput3 = $("<input type=checkbox>");

                     td1chk.append(cbxInput1);
                     td2chk.append(cbxInput2);
                     td3chk.append(cbxInput3);

                     tr1.append(td1chk);
                     tr2.append(td2chk);
                     tr3.append(td3chk);

                     tr1.append(td1);
                     tr2.append(td2);
                     tr3.append(td3);

                     spanKKRoadcount.append("(0 paper/s selected)")
                     spanTuaRoadcount.append("(0 paper/s selected)")
                     spanPenRoadcount.append("(0 paper/s selected)")

                     td1.append("ACCA");
                     td2.append("ICAEW ");
                     td3.append("CPA");

                     td1.append(spanKKRoadcount);
                     td2.append(spanPenRoadcount);
                     td3.append(spanTuaRoadcount);

                     td1.click(function () {
                         tr1.css("background-color", " rgb(250, 244, 180)")
                         tr2.css("background-color", "transparent")
                         tr3.css("background-color", "transparent")
                         RoadList = ["Paper Example 1", "Paper Example 2", "Paper Example 3", "Paper Example 4", "Paper Example 5", "Paper Example 6", "Paper Example 7",
                         ];
                         BuildRoad(tableRoad);
                         cbxInput1.prop('checked', !cbxInput1.is(':checked'));
                         cbDistrict.prop('checked', cbxInput1.is(':checked') && cbxInput2.is(':checked') && cbxInput3.is(':checked'));
                         teq.Common.StopPropagation;
                     });
                     td2.click(function () {
                         tr2.css("background-color", "rgb(250, 244, 180)")
                         tr1.css("background-color", "transparent")
                         tr3.css("background-color", "transparent")
                         RoadList = ["Paper Example 1", "Paper Example 2", "Paper Example 3", "Paper Example 4", "Paper Example 5", "Paper Example 6", "Paper Example 7",
                         ];
                    
                         BuildRoad(tableRoad);
                         cbxInput2.prop('checked', !cbxInput2.is(':checked'));
                         cbDistrict.prop('checked', cbxInput1.is(':checked') && cbxInput2.is(':checked') && cbxInput3.is(':checked'));
                         teq.Common.StopPropagation;
                     });
                     td3.click(function () {
                         tr3.css("background-color", "rgb(250, 244, 180)")
                         tr1.css("background-color", "transparent")
                         tr2.css("background-color", "transparent")
                         RoadList = ["Paper Example 1", "Paper Example 2", "Paper Example 3", "Paper Example 4", "Paper Example 5", "Paper Example 6", "Paper Example 7",
                         ];
                         BuildRoad(tableRoad);
                         cbxInput3.prop('checked', !cbxInput3.is(':checked'));
                         cbDistrict.prop('checked', cbxInput1.is(':checked') && cbxInput2.is(':checked') && cbxInput3.is(':checked'));
                         teq.Common.StopPropagation;
                     });
                     //table.append()
                 }

                 function BuildRoad(table) {
                     table.empty();
                     var divDistrictList = $("<div class='Wrap' style='overflow-y:auto; max-height:195px;'>");
                     var tableDistrictList = $("<table class='List'>");
                     divDistrictList.append(tableDistrictList);
                     table.append(divDistrictList);

                     for (i = 0; i < RoadList.length; i++) {
                         var tr = $("<tr >");
                         var td = $("<td style='width:200px;' >");
                         var tdchk = $("<td >");

                         var cbxInput = $("<input type=checkbox>");
                         cbxInput.click(function () {
                             var flag = true;
                             for (var i = 0; i < cbxRoadInput.length; i++) {
                                 flag = flag && cbxRoadInput[i].is(':checked');
                             }
                             cbRoad.prop('checked', flag);
                             teq.Common.StopPropagation;
                         });
                         if (RoadList[i] == "Jalan Aru") cbxInput.prop("checked", true);
                         cbxRoadInput.push(cbxInput);
                         tdchk.append(cbxInput);
                         td.append(RoadList[i]);
                         tr.append(tdchk);
                         tr.append(td);
                         tableDistrictList.append(tr);
                     }
                 }

                 var spanChangeDistrictRoadSetting = $("<span style='font-size:9px; '>");

                 //#Region field Road and Districts
                 {

                     var trDistrictRoadInfo = $("<tr>");
                     var tdDistrictRoadInfo = $("<td colspan='4'>");
                     trDistrictRoadInfo.append(tdDistrictRoadInfo);
                     mainTable.append(trDistrictRoadInfo);

                     var divDistrictRoadInfo = $("<div class='Wrap'>");
                     tdDistrictRoadInfo.append(divDistrictRoadInfo);
                     divDistrictRoadInfo.append("<table ><tbody><tr valign='top'><td align='left'><span style='white-space:nowrap;'> Selected Course </span></td><td>:</td><td align='left' ><span style=''>ACCA, ICAEW, CPA</span><span style=''> (3 courses selected)</span></td></tr><tr valign='top'><td align='left' ><span style='white-space:nowrap;'>Selected Paper</span></td><td>:</td><td align='left' ><span style=''>ACCA-F1, ACCA-F2, ACCA-F3, ACCA-F4, ACCA-F5, </span><span style=''>(5 paper/s selected)</span></td></tr></tbody></table>")
                     // tdDistrictRoadInfo.append("<br/>");
                     var divChangeDistrictRoadSetting = $("<div style='text-align:right; width:100%;'>");
                     tdDistrictRoadInfo.append(divChangeDistrictRoadSetting);
                     divChangeDistrictRoadSetting.append(spanChangeDistrictRoadSetting);
                     spanChangeDistrictRoadSetting.append("<a href='#'>Change</a>");

                     var RoadList = [];
                     //var trTitle = $("<tr>");
                     //mainTable.append(trTitle);
                     //var tdTitle1 = $("<td colspan=2 cellpadding='2'> ");
                     //var tdTitle2 = $("<td colspan=2  cellpadding='2'>");
                     //trTitle.append(tdTitle1);
                     //trTitle.append(tdTitle2);

                     var spanDistrictTitle = $("<span>");
                     spanDistrictTitle.append("Course :")
                     //tdTitle1.append(spanDistrictTitle);
                     var spanRoadTitle = $("<span>");
                     spanRoadTitle.append("Paper :");
                    // tdTitle2.append(spanRoadTitle);


                     var tr = $("<tr valign=top>");
                     mainTable.append(tr);
                     var td1 = $("<td colspan='2' style='Padding-right:30px;'>");
                     var td2 = $("<td colspan='2' >");

                     var tableRoadP = $("<table border=0>");
                     var trRoadTitle = $("<tr>");
                     var trRoadCBList = $("<tr>");
                     var tdRoadTitle = $("<td>");
                     var tdRoadChkAll = $("<td style='text-align:right; padding-right:5px;'>");
                     var tdRoadCBList = $("<td colspan=2>");

                     tableRoadP.append(trRoadTitle);
                     tableRoadP.append(trRoadCBList);
                     trRoadTitle.append(tdRoadTitle);
                     trRoadTitle.append(tdRoadChkAll);
                     trRoadCBList.append(tdRoadCBList);

                     var tableDistrictP = $("<table border=0>");
                     var trDistrictTitle = $("<tr>");
                     var trDistrictCBList = $("<tr>");
                     var tdDistrictTitle = $("<td>");
                     var tdDistrictChkAll = $("<td style='text-align:right; padding-right:5px;'>");
                     var tdDistrictCBList = $("<td colspan=2>");

                     tableDistrictP.append(trDistrictTitle);
                     tableDistrictP.append(trDistrictCBList);
                     trDistrictTitle.append(tdDistrictTitle);
                     trDistrictTitle.append(tdDistrictChkAll);
                     trDistrictCBList.append(tdDistrictCBList);


                     tr.append(td1);
                     tr.append(td2);
                     td2.append(tableRoadP);
                     td1.append(tableDistrictP);

                     //td1.append(spanDistrictTitle);
                    // td2.append(spanRoadTitle);
                    // td1.append("<br/>");
                     //td2.append("<br/>");
                    
                     //td2.append("&nbsp;&nbsp;", $("<input type=checkbox>"), "All");
                     //td1.append("&nbsp;&nbsp;", $("<input type=checkbox>"), "All");

                     //td1.append("<br/>");
                     //td2.append("<br/>");


                     var tableDistrict = $("<table>");
                     BuildDistrict(tableDistrict);
                     td1.append(tableDistrict);
                     var tableRoad = $("<table>");
                     //to ready road display
                     {
                         RoadList.push("F1 Accountant in Business");
                         RoadList = [];
                         RoadList.push("F2 Management Accounting");
                         RoadList.push("F3 Financial Accounting");
                         RoadList.push("F4 Corporate and Business Law");
                         RoadList.push("F5 Performance Management");
                         RoadList.push("F6 Taxation");
                         RoadList.push("F7 Financial Reporting");
                         RoadList.push("F8 Audit and Assurance");
                         RoadList.push("F9 Financial Management");

                         BuildRoad(tableRoad);
                     }
                     BuildRoad(tableRoad);
                     tdRoadCBList.append(tableRoad);
                     tdRoadTitle.append(spanRoadTitle);

                     //var cbRoad =  $("<input id='cbRoadAll' type=checkbox>");
                     var lblCbRoad = $("<label for='cbRoadAll'>")
                     lblCbRoad.append("All");                     
                     tdRoadChkAll.append(cbRoad, lblCbRoad);
                     cbRoad.click(function () {
                         for (var i = 0; i < cbxRoadInput.length; i++) {
                             cbxRoadInput[i].prop('checked', $(this).is(':checked'));
                         }
                     });

                     tdDistrictCBList.append(tableDistrict);
                     tdDistrictTitle.append(spanDistrictTitle)
                     //var cbDistrict = $("<input id='cbDistrictAll' type=checkbox>");
                     var lblCbDistrict = $("<label for='cbDistrictAll'>")
                     lblCbDistrict.append("All");
                     tdDistrictChkAll.append(cbDistrict, lblCbDistrict);
                     cbDistrict.click(function () {
                         cbxInput1.prop('checked', $(this).is(':checked'));
                         cbxInput2.prop('checked', $(this).is(':checked'));
                         cbxInput3.prop('checked', $(this).is(':checked'));
                     });

                     trDistrictRoadInfo.hide();
                     tr.hide();

                     if (mode != null)
                     {
                         tr.hide();
                         trDistrictRoadInfo.show();

                     }
                     else {
                         tr.show();
                         trDistrictRoadInfo.hide();

                     }
                    
                     spanChangeDistrictRoadSetting.click(function () {
                         trDistrictRoadInfo.hide();
                         tr.show();
                     })



                    
                     //#region Student ID
                     {
                         var trRoadMarrisID = $("<tr>");
                         mainTable.append(trRoadMarrisID);
                         var tdTitleRoadID = $("<td>");
                         trRoadMarrisID.append(tdTitleRoadID);
                         var tdRoadID = $("<td>");
                         trRoadMarrisID.append(tdRoadID);
                         tdTitleRoadID.append("Student ID : ");
                         var inputRoadID = $("<div>");
                         tdRoadID.append(inputRoadID);
                         var txtRoadID = $("<input type=text />");
                         inputRoadID.append(txtRoadID);



                         var tdTitleMarrisID = $("<td>");
                         trRoadMarrisID.append(tdTitleMarrisID);
                         var tdMarrisID = $("<td>");
                         trRoadMarrisID.append(tdMarrisID);
                         tdTitleMarrisID.append("Student Name : ");
                         var inputMarrisID = $("<div>");
                         tdMarrisID.append(inputMarrisID);
                         var txtMarrisID = $("<input type=text />");
                         inputMarrisID.append(txtMarrisID);
                     }
                     //#endregion

                     //#region Intake Year
                     {
                         var trRouteSectionID = $("<tr>");
                         mainTable.append(trRouteSectionID);
                         var tdTitleRouteID = $("<td>");
                         trRouteSectionID.append(tdTitleRouteID);
                         var tdRouteID = $("<td>");
                         trRouteSectionID.append(tdRouteID);
                         tdTitleRouteID.append("Intake Year : ");
                         var inputRouteID = $("<div>");
                         tdRouteID.append(inputRouteID);
                         var txtRouteID = $("<input type=text />");
                         inputRouteID.append(txtRouteID);

                         var tdTitleSectionID = $("<td>");
                         trRouteSectionID.append(tdTitleSectionID);
                         var tdSectionID = $("<td>");
                         trRouteSectionID.append(tdSectionID);
                         tdTitleSectionID.append("IC Number : ");
                         var inputSectionID = $("<div>");
                         tdSectionID.append(inputSectionID);
                         var txtSectionID = $("<input type=text />");
                         inputSectionID.append(txtSectionID);
                     }
                     //#endregion

                     //#region Criteria Row 3
                     {
                         var trRouteSectionID = $("<tr>");
                         mainTable.append(trRouteSectionID);
                         var tdTitleRouteID = $("<td>");
                         trRouteSectionID.append(tdTitleRouteID);
                         var tdRouteID = $("<td>");
                         trRouteSectionID.append(tdRouteID);
                         tdTitleRouteID.append("Gender : ");
                         var inputRouteID = $("<div>");
                         tdRouteID.append(inputRouteID);
                         var txtRouteID1 = $("<input type=radio name='gender' value=m />");
                         var txtRouteID2 = $("<input type=radio name='gender' value=f />");
                         inputRouteID.append(txtRouteID1);
                         inputRouteID.append("Male");
                         inputRouteID.append(txtRouteID2);
                         inputRouteID.append("Female");


                         var tdTitleSectionID = $("<td>");
                         trRouteSectionID.append(tdTitleSectionID);
                         var tdSectionID = $("<td>");
                         trRouteSectionID.append(tdSectionID);
                         tdTitleSectionID.append("Status : ");
                         var inputSectionID = $("<div>");
                         tdSectionID.append(inputSectionID);
                         var selStatus = $("<select />");
                         selStatus.append("<option>Open</option>");
                         selStatus.append("<option>Assessment</option>");
                         selStatus.append("<option>Assessment Review</option>");
                         selStatus.append("<option>Interview</option>");
                         selStatus.append("<option>Monitoring</option>");
                         selStatus.append("<option>Rejected</option>");
                         inputSectionID.append(selStatus);
                     }
                     //#endregion

                 }
                 //#endregion


             }

             sec.PopulateContentDelegate = function (entity) {

             }
             sec.CollectContentDelegate = function (entity) {

             }
             sec.ContentHasErrorDelegate = function () {
                 //return false;
             }
        }
        //#endregion
    }
    //#endregion

    if (mode != null & mode == 1) {
        //#region Group: Road Info
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = module;
            ctrl.Groups.push(grp);

            //#region Section: 1
            {

                var sec = new teq.EntityPropertiesGridSection();
                // sec.Name = "Shift information";
                sec.ConfigureGrids(4, 1);
                grp.Sections.push(sec);
                //#region Field: ROAD WIDTH
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Width";

                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {


                        element.append("From &nbsp <input type='text' style='width:30px;'> &nbsp To &nbsp <input type='text' style='width:30px;'>");
                    }
                    sec.Grids[0][0].Property = prop;
                    //sec.Grids[0][0].colSpan = 2;
                }
                //#endregion 

                //#region Field: ROAD CLASS
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Class";

                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {


                        element.append("From &nbsp <input type='text' style='width:30px;'> &nbsp To &nbsp <input type='text' style='width:30px;'>");
                    }
                    sec.Grids[1][0].Property = prop;
                    //sec.Grids[0][0].colSpan = 2;
                }
                //#endregion 

                ////#region Field: ROAD GRADE
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Grade";

                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        var Enums = [];
                        var Flags = Enums;
                        var FlagNames = Enums;
                        var FlagCodes = [];
                        FlagCodes.RoadGrade = [];
                        FlagNames.RoadGrade = [];
                        FlagNames.RoadGrade.Label = Enums_GetLabel;
                        FlagCodes.RoadGrade.a = "<5%";
                        FlagNames.RoadGrade["a"] = "<5%";
                        FlagCodes.RoadGrade.b = "5-10%";
                        FlagNames.RoadGrade["b"] = "5-10%";
                        FlagCodes.RoadGrade.c = ">10%";
                        FlagNames.RoadGrade["c"] = ">10%";

                        element.checkboxList({
                            choices: FlagCodes.RoadGrade,
                            columns: 3

                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return [];
                    }
                    sec.Grids[2][0].Property = prop;
                    //sec.Grids[0][1].RowSpan = 2;
                }
                //#endregion 

                //#region Field: DATE OF MARRIS UPDATE
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Date Of Marris Update";

                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        var datefrom = $("<input type='text' style='width:100px;'>");
                        var dateto = $("<input type='text' style='width:100px;'>");

                        datefrom.datepicker();
                        dateto.datepicker();
                        element.append("From ");
                        element.append(datefrom);
                        element.append(" To ");
                        element.append(dateto);
                    }
                    sec.Grids[3][0].Property = prop;
                    // sec.Grids[3][0].ColSpan = 2;
                }
                //#endregion 

            }
            //#endregion

        }
        //#endregion
    }
    ctrl.Initialize();

    var cbxShowEverytime = $("<input type='checkbox' />");
    ctrl.divContainer.parent().children('.ui-dialog-buttonpane').append(cbxShowEverytime, "<span style='font-size:8pt;'>Show this pop up everytime I login.</span>");

    local.AdvancedSearchModule = null;
}


