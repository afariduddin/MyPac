/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.UserAccountManagementPageController = function (idPrefix) {


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
    var txtSearchName = "#" + idPrefix + "_txtSearchName";
    var txtSearchUserID = "#" + idPrefix + "_txtSearchUserID";
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
        if (!local.ValidatePermission(FlagCodes.PermissionType.UserManagement)) {
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
            Name: "User Account Management",
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
            var name = $(txtSearchName).val();
            var userid = $(txtSearchUserID).val();
            UserAccountManagementAjaxGateway.GetUserAccountList(name,userid, order.Columns, order.Directions, pg, function (res) {
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
            htr.append("<td >Full Name</td>");
            htr.append("<td >User ID</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Contact Number</td>");
            htr.append("<td >Created Date</td>");
            htr.append("<td >Created By</td>");
            htr.append("<td >User Group</td>");
            htr.append("<td >View</td>");
            htr.append("<td >Action</td>");

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
                tr.append(("<td align=center>" + dr.UserAccount_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.UserAccount_UserID + "</td>"));
                tr.append(("<td align=center>" + dr.UserAccount_Email + "</td>"));
                tr.append(("<td align=center>" + dr.UserAccount_Contact + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.UserAccount_CreatedDate) + "</td>"));
                tr.append(("<td align=center>" + dr.UserAccount_CreatedBy + "</td>"));
                tr.append(("<td align=center>" + dr.UserGroup_Name + "</td>"));

                if (local.CurrentUser == dr.UserAccount_UserID) {
                    tr.append("<td><td>");
                    tr.append("<td><td>");
                }
                else {

                    tr.append(buileEditTd(dr));
                    tr.append(buileActionTd(dr));
                }
                tbody.append(tr);
            }
            //if (tbl.Rows.length == 0) {
            //    local.ListingEmptyRecord(tbody);
            //}



            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.UserAccount_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.UserAccount_ID, dr.UserAccount_FullName);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk2 = $("<a href='javascript:void(0);'>Reset Password</a><br>");
                editLnk2.click(function (event) {
                    //teq.Context.ShowPage(local.aspxContent_GIS1);
                    //CheckGISFirstLoad();
                    event.stopPropagation();
                    self.ResetPassword(dr.UserAccount_ID, dr.UserAccount_FullName);
                });
                //actionTd.append(teq.Common.ThemeIcon("active", "check"), editLnk2);
                actionTd.append(teq.Common.ThemeIcon("active", "refresh"), editLnk2);

                //var editLnk3 = $("<a href='javascript:void(0);'>Reject</a>");
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), editLnk3);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        //#endregion

        self.ListControlller.Initialize();
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "User Account Management";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;
        // ctrl.DialogHeight= 600;

        //ctrl.LoadDelegate = function () {

        //    ctrl.Populate();
        //}

        var jqUserGroup = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value.Entity == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    jqUserGroup.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.UserGroup));
                    ctrl.Populate(res.value.Entity);
                }
            }
            else ctrl.Close();
        }
        if (id == null) {
            ctrl.LoadDelegate = function () {
                UserAccountManagementAjaxGateway.NewUserAccount(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                UserAccountManagementAjaxGateway.GetUserAccount(id, populateDel);
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            //ctrl.Close();
            //if (edit == "Edit") teq.Context.ToastTape("Record save successfully.");
            //else teq.Context.ToastTape("Record create Successfully.");
            UserAccountManagementAjaxGateway.SaveUserAccount(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create User Account";
            //alert(entity.UserGroup_ID);
            if (entity.UserAccount_ID != GuidEmpty) title = "Editing \"" + entity.UserAccount_FullName + "\"";
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
            grp.Name = "Personal Detail ";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);

                //#region Field: Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_FullName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_FullName = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        UserAccountManagementAjaxGateway.VerifyName(val, callback);
                    }
                    sec.Properties.push(prop);

                }
                //#endregion

                //#region Field: User ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "User ID";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_UserID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_UserID = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        UserAccountManagementAjaxGateway.VerifyUserID(val,id, callback);
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Email
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_Email = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Contact Number
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_Contact;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_Contact = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Gender
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "User Group";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: GuidEmpty
                        });
              
                        jqUserGroup = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserGroup_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserGroup_ID = val;
                    }
                    //sec.Grids[2][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: BumiStatus

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Enable";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.radioButtonList({
                            choices: Enums.YesNoType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {

                        if (entity.UserAccount_IsEnabled)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {

                        if (val == FlagCodes.YesNoType.Yes)
                            entity.UserAccount_IsEnabled = true;
                        else
                            entity.UserAccount_IsEnabled = false;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion
                
                //#region Field: Remarks
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_Remark = val;
                    }
                    //sec.Grids[6][0].Property = prop;
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
            UserAccountManagementAjaxGateway.DeleteUserAccount(id, function (res) {
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
    this.ResetPassword = function (id, name) {
        var msg = "Reset password for Record:<br><br>\"" + name + "\"<br><br>Resetted password will be same as the User ID. Are you sure?";
        teq.Context.Confirm(msg, function () {
            // teq.Context.ToastTape("Record deleted successfully.");
            UserAccountManagementAjaxGateway.ResetPassword(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Password resetted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
    }
    //#endregion


}