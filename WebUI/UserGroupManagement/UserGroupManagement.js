
local.UserGroupManagementPageController = function (idPrefix) {

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
        if (!local.ValidatePermission(FlagCodes.PermissionType.UserGroupManagement)) {
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
            Name: "User Group Management",
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
            //var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 100, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            //self.ListControlller.Populate(res.value);
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var name = $(txtSearchName).val();
            UserGroupManagementAjaxGateway.GetUserGroupList(name, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {

            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Group Name</td>");
            htr.append("<td >Created Date</td>");
            htr.append("<td >Created By</td>");
            htr.append("<td >View</td>");

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
                //var dr = tbl.Rows[i];
                //var tr = $("<tr></tr>");

                //var handle = $("<td align=center>" + dr.RowNum + "</td>");
                //local.BuildTrashBinHandler(handle, dr.CardNumber, "[" + dr.CardNumber + "] " + dr.FullName, self.DeleteMember);

                //var std = $("<td align=center/>");
                //std.append(this.MultiSelector.BuildRowSelector(dr.CardNumber, tr));

                //tr.append(std);
                //tr.append(handle);
                //tr.append("<td>" + dr.CardNumber + "</td>");
                //tr.append("<td align=center>" + Enums.CardType.Label(dr.CardType) + "</td>");
                //tr.append("<td>" + dr.FullName + "</td>");
                //tr.append("<td>" + teq.Common.FormatString(dr.NewICNumber) + "</td>");
                //tr.append("<td align=center>" + teq.Common.FormatDate(dr.DateOfBirth) + "</td>");
                //tr.append("<td>" + teq.Common.FormatString(dr.EmailAddress) + "</td>");
                //tr.append("<td align=center>" + Enums.Gender.Label(dr.Gender) + "</td>");
                //tr.append("<td align=center>" + Enums.MemberPreferedLanguage.Label(dr.MemberPreferedLanguage) + "</td>");
                //tr.append("<td align=center>" + Enums.Race.Label(dr.Race) + "</td>");
                //tr.append("<td align=center>" + Enums.MaritalStatus.Label(dr.MaritalStatus) + "</td>");
                //tr.append("<td align=center>" + Enums.Occupation.Label(dr.Occupation) + "</td>");
                //tr.append(buileActionTd(dr));
                //tbody.append(tr);


                    var dr = tbl.Rows[i];
                    var tr = $("<tr></tr>");
                    tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                    tr.append(("<td align=center>" + dr.UserGroup_Name + "</td>"));
                    tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.UserGroup_CreatedDate) + "</td>"));
                    tr.append(("<td align=center>" + dr.UserGroup_CreatedBy + "</td>"));
                    tr.append(buileEditTd(dr));
                    tbody.append(tr);
            }
            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.UserGroup_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.UserGroup_ID, dr.UserGroup_Name);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

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
    var Title = "User Group Management";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;
        
        if (id == null) {
            ctrl.LoadDelegate = function () {
                UserGroupManagementAjaxGateway.NewUserGroup(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                UserGroupManagementAjaxGateway.GetUserGroup(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else ctrl.Populate(res.value);
                    }
                    else ctrl.Close();
                });
            }
        }


        ctrl.SaveDelegate = function (entity, callback) {
            UserGroupManagementAjaxGateway.SaveUserGroup(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {

            var title = "Create User Group";
            if (entity.Entity.UserGroup_ID != GuidEmpty) title = "Editing \"" + entity.Entity.UserGroup_Name + "\"";
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
            grp.Name = "User Group Detail";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Group Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.UserGroup_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.UserGroup_Name = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        UserGroupManagementAjaxGateway.VerifyName(val, callback);
                    }
                    sec.Properties.push(prop);

                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Permission";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.checkboxList({
                            choices: Enums.PermissionType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedGroup;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SelectedGroup = val;
                    }

                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.UserGroup_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.UserGroup_Remark = val;
                    }
                    sec.Properties.push(prop);
                }

            }           

        }
        ctrl.Initialize();
    }
    this.DeleteRecord = function (id, name) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {
           // teq.Context.ToastTape("Record deleted successfully.");
            UserGroupManagementAjaxGateway.DeleteUserGroup(id, function (res) {
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
}