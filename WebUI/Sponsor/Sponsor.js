/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.SponsorPageController = function (idPrefix) {


    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnNew = "#" + idPrefix + "_btnNew";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var txtSearchCode = "#" + idPrefix + "_txtSearchCode";
    var txtSearchLabel = "#" + idPrefix + "_txtSearchLabel";
    //var btnNew = "#" + idPrefix + "_btnNew";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {
        //buildButton();
        BuildSurfaceListing()

    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.SponsorManagement)) {
            teq.Context.Alert("You do not have sufficient permission to the page you are trying to access.<br />Please contact your system administrator for further information.");
            teq.Context.ShowPage(local.aspxContent_Dashboard1);
        }

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Sponsor Management",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;


    }
    //#endregion

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }



    //#region BuildCandidateListing 

    function BuildSurfaceListing() {

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        self.ListControlller.btnNew = $(btnNew);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
        //#endregion

        //#region Delegates       
        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var code = $(txtSearchCode).val();
            var label = $(txtSearchLabel).val();
            SponsorAjaxGateway.GetSponsorList(code, label, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }


        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            //teq.Common.BuildColumnIndexes(tbl);

            var ctd = $("<td align=center/>");
            //ctd.append(this.MultiSelector.BuildSelectorControl());

            var htr = $("<tr></tr>");
            //htr.append(ctd);
            //htr.append("<td >No.</td>");
            htr.append("<td >No. </td>");
            htr.append("<td >Code</td>");
            htr.append("<td >Label</td>");
            htr.append("<td >Created Date</td>");
            htr.append("<td >Created By</td>");
            htr.append("<td >View</td>");
            //htr.append("<td >Action</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

            function headerCol(colName) {
                var td = $("<td/>");
                var a = $("<a href='javascript:void(0);'>" + colName + "</a>");
                td.append(a);
                return td;
            }
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();
 

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Code + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Label + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.Sponsor_Created) + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_CreatedBy + "</td>"));
                tr.append(buileEditTd(dr));
                //tr.append(buileActionTd(dr));
                tbody.append(tr);
            }
            //if (tbl.Rows.length == 0) {
            //    local.ListingEmptyRecord(tbody);
            //}



            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Sponsor_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.Sponsor_ID, dr.Sponsor_Code);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }

            //function buileActionTd(dr) {
            //    var actionTd = $("<td align=center/>");

            //    var editLnk2 = $("<a href='javascript:void(0);'>Reset Password</a><br>");
            //    editLnk2.click(function (event) {
            //        //teq.Context.ShowPage(local.aspxContent_GIS1);
            //        //CheckGISFirstLoad();
            //        event.stopPropagation();
            //        self.ResetPassword(dr.UserAccount_ID, dr.UserAccount_FullName);
            //    });
            //    //actionTd.append(teq.Common.ThemeIcon("active", "check"), editLnk2);
            //    actionTd.append(teq.Common.ThemeIcon("active", "refresh"), editLnk2);

            //    //var editLnk3 = $("<a href='javascript:void(0);'>Reject</a>");
            //    //actionTd.append(teq.Common.ThemeIcon("active", "close"), editLnk3);

            //    return actionTd;
            //}
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        //#endregion

        self.ListControlller.Initialize();
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "Sponsor Management";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;
        // ctrl.DialogHeight= 600;

        //ctrl.LoadDelegate = function () {

        //    ctrl.Populate();
        //}

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }
        if (id == null) {
            ctrl.LoadDelegate = function () {
                SponsorAjaxGateway.NewSponsor(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                SponsorAjaxGateway.GetSponsor(id, populateDel);
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            //ctrl.Close();
            //if (edit == "Edit") teq.Context.ToastTape("Record save successfully.");
            //else teq.Context.ToastTape("Record create Successfully.");
            SponsorAjaxGateway.SaveSponsor(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Sponsor";
            //alert(entity.UserGroup_ID);
            if (entity.Sponsor_ID != GuidEmpty) title = "Editing \"" + entity.Sponsor_Code + "\"";
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
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Sponsor Detail ";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);

                //#region Field: Code
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Code";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Sponsor_Code;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Sponsor_Code = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        SponsorAjaxGateway.VerifyCode(val, id, callback);
                    }
                    sec.Properties.push(prop);

                }
                //#endregion

                //#region Field: Label
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Label";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Sponsor_Label;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Sponsor_Label = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        SponsorAjaxGateway.VerifyLabel(val, callback);
                    }
                    sec.Properties.push(prop);
                }
                //#endregion
            }
            //#endregion
        }
        //#endregion
        ctrl.Initialize();
    }


    this.DeleteRecord = function (id, name) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {
            // teq.Context.ToastTape("Record deleted successfully.");
            SponsorAjaxGateway.DeleteSponsor(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Record deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
    }
    //#endregion


}