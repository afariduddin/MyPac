local.CandidateMentoringPageController = function (idPrefix) {
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
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var Title = "Coaching / Mentoring Detail";
    self.Title = Title;

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.CoachingStatusType
        });
        BuildSurfaceListing()
    }

    this.Activated = Activated;
    function Activated() {
        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_CandidateDashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Counselling & Coaching",
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

        self.ListControlller.AutoSearch = true;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
 
        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var Status = $(selSearchStatus).val();

            CandidateMentoringAjaxGateway.GetCoachingListing(Status, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Paper</td>");
            htr.append("<td >Description</td>");
            htr.append("<td >Date</td>");
            htr.append("<td >Status</td>");
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
                tr.append(("<td align=center>" + dr.CourseSubject_Code + " - " + dr.CourseSubject_Name + "</td>"));
                tr.append(("<td align=center>" + dr.Coaching_Description + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.Coaching_Date) + "</td>"));
                tr.append(("<td align=center>" + FlagNames.CoachingStatusType[dr.Coaching_Status] + "</td>"));
                tr.append(buileActionTd(dr));

                tbody.append(tr);
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");
                var lnkViewLog = $("<a href='javascript:void(0);'>Log</a>");
                lnkViewLog.click(function (event) {

                    buildSurfaceDataDialog(dr.Coaching_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "clipboard"), lnkViewLog);
                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog("New");
        }
        
        self.ListControlller.Initialize();
    }

    function buildSurfaceDataDialog(id) {

        var prop = $("<div title='Coaching / Mentoring Log'>");

        var divBtnLog = $("<div align='right'>");
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

        prop.append(divBtnLog, "</br>", divListLog);

        var htr = $("<tr></tr>");
        htr.append("<td >Date</td>");
        htr.append("<td >Description</td>");



        tblHeaderLog.empty();
        tblHeaderLog.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 800);
        prop.dialog('open');

        PopulateLogGrid(id);

        function PopulateLogGrid(id) {
            refreshItem(id);
        }
    }
    var tblBodyLog = $("<tbody>");
    function refreshItem(id) {
        CandidateMentoringAjaxGateway.GetCoachingItemListing(id, function (entity) {
            tblBodyLog.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entCoachingItem = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(entCoachingItem.CoachingItem_Date) + "</td>"));
                tr.append(("<td align=center>" + entCoachingItem.CoachingItem_Description + "</td>"));
                //dtr.append(buileEditTd(entCoachingItem));
                
                tblBodyLog.append(tr);
            }

            function buileEditTd(entCoachingItem) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildLogPropertySurfaceDataDialog(entCoachingItem.Coaching_ID, entCoachingItem.CoachingItem_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                return actionTd;
            }
        });
    }

    function buildLogPropertySurfaceDataDialog(Coaching_ID, CoachingItem_ID) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }

        if (CoachingItem_ID == null) {
            ctrl.LoadDelegate = function () {
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CandidateMentoringAjaxGateway.GetCoachingItem(CoachingItem_ID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
        };

        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Coaching / Mentoring Log";
            if (entity.CoachingItem_ID != GuidEmpty) title = "Editing Log Entry \"" + teq.Common.FormatDateTime(entity.CoachingItem_Date) + "\"";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Course Detail";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 500;
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Date and Time";
                    prop.Input = new teq.EntityDateTimeInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertydatetime");
                        element.Date.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                        element.Date.timeInput({
                            textboxWidth: "40px",
                            format: "12"
                        });
                        element.Time.timeInput({
                            textboxWidth: "40px",
                            format: "12"
                        });
                        element.Time.css('margin-left', 5);
                        teq.Common.SetDatePickerClearable($(element.Date));
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CoachingItem_Date;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Date = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Description";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CoachingItem_Description;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Description = val;
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
                        return entity.CoachingItem_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Remark = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }
}