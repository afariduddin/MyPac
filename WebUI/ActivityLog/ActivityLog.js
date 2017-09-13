local.ActivityLogPageController = function (idPrefix) {

    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var txtSearchFullName = "#" + idPrefix + "_txtSearchUsername";
    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {

        $(txtSearchDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchDateFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        teq.Common.SetDatePickerClearable($(txtSearchDateFrom));
        $(txtSearchDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchDateTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));
        BuildSurfaceListing()
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.AuditLog)) {
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
            Name: "Audit Log",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }

    this.Shown = function () {
    }
    function BuildSurfaceListing() {
        self.ListControlller = new teq.EntityListController();

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        self.ListControlller.btnPinSearch = $(btnPinSearch);

        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
      
        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var userid = $(txtSearchFullName).val();

            var startDate = $(txtSearchDateFrom).val() == "" ? null : $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val() == "" ? null : $(txtSearchDateTo).val();
            ActivityLogAjaxGateway.GetActivityLogListing(startDate, endDate, userid, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >User ID</td>");
            htr.append("<td >Date</td>");
            htr.append("<td >Description</td>");
            htr.append("<td >IP Address</td>");
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
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.ActivityLog_UserName + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.ActivityLog_DateTime) + "</td>"));
                tr.append(("<td align=center>" + dr.ActivityLog_Description + "</td>"));
                tr.append(("<td align=center>" + dr.ActivityLog_IPAddress + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>View Transaction</a>");
                editLnk.click(function (event) {
                    buildSurfaceTransactionDataDialog(dr.ActivityLog_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "script"), editLnk);
                return actionTd;
            }
        }

        self.ListControlller.Initialize();
    }

    var tblBodyLog = $("<tbody>");
    function refreshItem(id) {
        ActivityLogAjaxGateway.GetActivityLogTransaction(id, function (entity) {
            tblBodyLog.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var ent = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + ent.Description + "</td>"));
                tr.append(buileEditTd(ent));
                tblBodyLog.append(tr);
            }

            function buileEditTd(ent) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>View Column</a>");
                editLnk.click(function (event) {
                    buildLogColumnSurfaceDataDialog(ent.ActivityLogTransaction_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "clipboard"), editLnk);

                return actionTd;
            }
        });
    }

    function buildSurfaceTransactionDataDialog(id) {
        var prop = $("<div title='Audit Log Transaction'>");

        var divListLog = $("<div>");
        var divWrapLog = $("<div class='Wrap' style='width:99%;'>");
        var tblListLog = $("<table class='List'>");
        var tblHeaderLog = $("<thead>");
        var tblPagerLog = $("<table class='Pager'>");

        tblListLog.append(tblHeaderLog);
        tblListLog.append(tblBodyLog);
        divWrapLog.append(tblListLog);
        divWrapLog.append(tblPagerLog);
        divListLog.append(divWrapLog);

        var htr = $("<tr></tr>");
        htr.append("<td>Description</td>");
        htr.append("<td>View</td>");

        tblHeaderLog.empty();
        tblHeaderLog.append(htr);

        prop.append(divListLog);

        prop.dialog();
        prop.dialog("option", "width", 800);
        prop.dialog('open');

        PopulateLogGrid(id);

        function PopulateLogGrid(id) {
            refreshItem(id);
        }
    }

    var tblBodyLogColumn = $("<tbody>");
    function refreshColumnItem(id) {
        ActivityLogAjaxGateway.GetActivityLogColumn(id, function (entity) {
            tblBodyLogColumn.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var ent = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + ent.ActivityLogColumn_ColumnName + "</td>"));
                tr.append(("<td align=center>" + ent.ActivityLogColumn_OriginalValue + "</td>"));
                tr.append(("<td align=center>" + ent.ActivityLogColumn_NewValue + "</td>"));
                tblBodyLogColumn.append(tr);
            }
        });
    }

    function buildLogColumnSurfaceDataDialog(id) {
        var prop = $("<div title='Audit Log Transaction Column'>");

        var divListLog = $("<div>");
        var divWrapLog = $("<div class='Wrap' style='width:99%;'>");
        var tblListLog = $("<table class='List'>");
        var tblHeaderLog = $("<thead>");
        var tblPagerLog = $("<table class='Pager'>");

        tblListLog.append(tblHeaderLog);
        tblListLog.append(tblBodyLogColumn);
        divWrapLog.append(tblListLog);
        divWrapLog.append(tblPagerLog);
        divListLog.append(divWrapLog);

        var htr = $("<tr></tr>");
        htr.append("<td >Column</td>");
        htr.append("<td >Original Value</td>");
        htr.append("<td >New Value</td>");

        tblHeaderLog.empty();
        tblHeaderLog.append(htr);

        prop.append(divListLog);

        prop.dialog();
        prop.dialog("option", "width", 800);
        prop.dialog('open');

        PopulateLogColumnGrid(id);

        function PopulateLogColumnGrid(id) {
            refreshColumnItem(id);
        }
    }

}