local.StudentProgressSummaryPageController = function (idPrefix) {

    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnExport = "#" + idPrefix + "_btnExport";
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

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchContactNumber = "#" + idPrefix + "_txtSearchContactNumber";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchStudentStatus = "#" + idPrefix + "_selSearchStudentStatus";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";
    var txtSearchCreatedDateFrom = "#" + idPrefix + "_txtSearchCreatedDateFrom";
    var txtSearchCreatedDateTo = "#" + idPrefix + "_txtSearchCreatedDateTo";
    var txtSearchEnrollmentDateFrom = "#" + idPrefix + "_txtSearchEnrollmentDateFrom";
    var txtSearchEnrollmentDateTo = "#" + idPrefix + "_txtSearchEnrollmentDateTo";
    var chkSearchTSP = "#" + idPrefix + "_chkSearchTSP";
    
    var btnImport = "#" + idPrefix + "_btnImport";

    var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        $(btnImport).button();
        $(btnDownloadImport).button();
        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
        });


        $(txtSearchCreatedDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchCreatedDateFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchCreatedDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchCreatedDateTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));
        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

        $(txtSearchEnrollmentDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchEnrollmentDateFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchEnrollmentDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchEnrollmentDateTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ContractType
        });

        $(selSearchStudentStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.StudentStatusType
        });
        //$(selSearchSponsorshipType).dropdownSelect({
        //    nullValue: -1,
        //    nullLabel: "- Select All -",
        //    choices: Enums.SponsorType
        //});

        SponsorAjaxGateway.GetAllSponsor(function (res) {
            //teq.Common.Reveal(res);
            //alert(res.value.length)
            //val = res.value[0];
            //alert(val.Label);
            //alert(res.length);
            SponsorList = [];
            for (i = 0; i < res.value.length; i++) {
                val = res.value[i];
                SponsorList[val.Value] = val.Label;
            }
            $(chkSearchSponsorshipType).checkboxList(
            {
                columnSpacing: 20,
                valuesChanged: null,
                choices: SponsorList, //Flags.TradeType,
                showLinks: true,
                columns: 1
            }
            );
        });

        BuildSurfaceListing()

        if (!local.ValidatePermission(FlagCodes.PermissionType.StudentProgressSummaryEdit)) {
            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }
        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var FullName = $(txtSearchFullName).val();
            var Gender = $(selSearchGender).val();
            var Email = $(txtSearchEmail).val();
            var CreatedDateFrom = $(txtSearchCreatedDateFrom).val() == "" ? null : $(txtSearchCreatedDateFrom).val();
            var CreatedDateTo = $(txtSearchCreatedDateTo).val() == "" ? null : $(txtSearchCreatedDateTo).val();
            var EnrollmentDateFrom = $(txtSearchEnrollmentDateFrom).val() == "" ? null : $(txtSearchEnrollmentDateFrom).val();
            var EnrollmentDateTo = $(txtSearchEnrollmentDateTo).val() == "" ? null : $(txtSearchEnrollmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var Status = $(selSearchStudentStatus).val();
            var ContactNum = $(txtSearchContactNumber).val();
            //var Sponsorship = $(selSearchSponsorshipType).val();
            var IC = $(txtSearchIC).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var TSPType = $(chkSearchTSP).checkboxList("getValues");

            if ((CreatedDateFrom == null || CreatedDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (CreatedDateFrom == null || CreatedDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) {
                teq.Context.Alert("<b>Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }
            if (TSPType.length <= 0) {
                teq.Context.Alert("<b>TSP</b> cannot be blank.");
                return false;
            }

            StudentProgressSummaryAjaxGateway.GetResult(FullName, Gender, Email, ContactNum, CreatedDateFrom, CreatedDateTo, ContractType, Status, sponsorshipType, EnrollmentDateFrom, EnrollmentDateTo, false,IC, TSPType, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptStudentProgressSummaryMasterList");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.StudentProgressSummaryView)) {
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
            Name: "Student Progress List",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        TSPManagementAjaxGateway.GetAllTSP(function (res) {
            //teq.Common.Reveal(res);
            //alert(res.value.length)
            //val = res.value[0];
            //alert(val.Label);

            TSPList = [];
            for (i = 0; i < res.value.length; i++) {
                val = res.value[i];
                TSPList[val.Value] = val.Label;
            }

            $(chkSearchTSP).checkboxList(
            {
                columnSpacing: 20,
                valuesChanged: null,
                choices: TSPList, //Flags.TradeType,
                showLinks: true,
                columns: 1
            }
            );
        });
        local.AdvancedSearchMode = null;

     
    }

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
        //self.ListControlller.btnNew = $(btnNew);
        // self.ListControlller.btnToggleSearch = $(btnShowSearch);
        //self.ListControlller.btnNew = $(btnNew);
        //self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        //#endregion
        //#region Settings
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

            var FullName = $(txtSearchFullName).val();
            var Gender = $(selSearchGender).val();
            var Email = $(txtSearchEmail).val();
            var CreatedDateFrom = $(txtSearchCreatedDateFrom).val() == "" ? null : $(txtSearchCreatedDateFrom).val();
            var CreatedDateTo = $(txtSearchCreatedDateTo).val() == "" ? null : $(txtSearchCreatedDateTo).val();
            var EnrollmentDateFrom = $(txtSearchEnrollmentDateFrom).val() == "" ? null : $(txtSearchEnrollmentDateFrom).val();
            var EnrollmentDateTo = $(txtSearchEnrollmentDateTo).val() == "" ? null : $(txtSearchEnrollmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var Status = $(selSearchStudentStatus).val();
            var ContactNum = $(txtSearchContactNumber).val();
            var IC = $(txtSearchIC).val();
            //var Sponsorship = $(selSearchSponsorshipType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var TSPType = $(chkSearchTSP).checkboxList("getValues");

            if ((CreatedDateFrom == null || CreatedDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (CreatedDateFrom == null || CreatedDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) {
                teq.Context.Alert("<b>Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }
            if (TSPType.length <= 0) {
                teq.Context.Alert("<b>TSP</b> cannot be blank.");
                return false;
            }
 
            StudentProgressSummaryAjaxGateway.GetAssessmentResultListing(FullName, Gender, Email, ContactNum, CreatedDateFrom, CreatedDateTo, ContractType, Status, sponsorshipType, EnrollmentDateFrom, EnrollmentDateTo,IC, TSPType, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });

   
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >Sponsor</td>");
            htr.append("<td >Institute</td>");
            htr.append("<td >Contact Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Completed Subject</td>");
            htr.append("<td >Current Subject</td>");
            htr.append("<td >Remaining Subject</td>");
            htr.append("<td >Warning Letter Count</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");
            //htr.append("<td align=center><input type='checkbox' /></td>");
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
            var HasPermission = local.ValidatePermission(FlagCodes.PermissionType.StudentProgressSummaryEdit);
            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Code + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_CampusName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_PhonePrefix + " - " + dr.Application_PhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + dr.CompletedSubject + "</td>"));
                tr.append(("<td align=center>" + dr.CurrentSubject + "</td>"));
                tr.append(("<td align=center>" + dr.RemainingSubject + "</td>"));
                tr.append(("<td align=center>" + dr.WarningLetterCount + "</td>"));
                tr.append(("<td align=center>" + FlagNames.StudentStatusType[dr.Student_Status] + "</td>"));
                tr.append(buileEditTd(dr));

                if (dr.Student_Status != FlagCodes.StudentStatusType.Active || !HasPermission) {
                    //tr.append("<td align=center></td>");
                    tr.append("<td align=center></td>");
                }
                else
                {
                    //tr.append("<td align=center><input type='checkbox' /></td>");
                    tr.append(buileActionTd(dr));
                }
         
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Student_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);


                var viewWarningLnk = $("<a href='javascript:void(0);'>Issued Warning Letter List</a>");
                viewWarningLnk.click(function (event) {
                    buildWarningLetterSurfaceDataDialog(dr.Student_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), viewWarningLnk);
                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                //var editLnk = $("<a href='javascript:void(0);'>Terminate</a>");
                //editLnk.click(function (event) {
                //    event.stopPropagation();
                //    //self.TerminateRecord(dr.Student_ID);
                //    self.TerminateRecord(dr.Student_ID, dr.Application_FullName);
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), editLnk);

                var warningLetterLnk = $("<a href='javascript:void(0);'>Issue Warning</a>");
                warningLetterLnk.click(function (event) {
                    buildStudentIssueWarningDialog(dr.Student_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "flag"), warningLetterLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();

        {
            $(btnShowSearch_SpanIcon).append(SearchImageicon);
            $(btnShowSearch_SpanIcon).css("padding-right", "10px")
            $(btnShowSearch_SpanArrowIcon).append(ArrowImageicon);
        }
    }

    var Title = "Student Progress Detail";
    self.Title = Title;
    var tblBodySubject = $("<tbody>");
    function buildWarningLetterSurfaceDataDialog(id) {
        var prop = $("<div title='Warning Letter List'>");

        //var divBtnSubject = $("<div align='right'>");
       // var btnAddSubject = $("<button></button>");

        var divListSubject = $("<div>");
        var divWrapSubject = $("<div class='Wrap' style='width:99%;'>");
        var tblListSubject = $("<table class='List'>");
        var tblHeaderSubject = $("<thead>");
        var tblPagerSubject = $("<table class='Pager'>");

       // divBtnSubject.append(btnAddSubject);

        tblListSubject.append(tblHeaderSubject);
        tblListSubject.append(tblBodySubject);
        divWrapSubject.append(tblListSubject);
        divWrapSubject.append(tblPagerSubject);
        divListSubject.append(divWrapSubject);

        prop.append( divListSubject);

       // $(btnAddSubject).button();

        var htr = $("<tr></tr>");
        htr.append("<td >Subject</td>");
        htr.append("<td >Date</td>");

        htr.append("<td>Action</td>");

        tblHeaderSubject.empty();
        tblHeaderSubject.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 650);
        prop.dialog("option", "height", 450);
        prop.dialog('open');

        PopulateLetterGrid(id);

        function PopulateLetterGrid(id) {
            //btnAddSubject.click(function (event) {
            //    buildSubjectSurfaceDataDialog(id, null);
            //})
            refreshItem(id);
        }
    }

    function refreshItem(id) {
        StudentProgressSummaryAjaxGateway.GetWarningLetterList(id, function (entity) {

            tblBodySubject.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entSubject = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + entSubject.EmailNotification_Subject + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(entSubject.StudentWarningLetter_CreatedDate) + "</td>"));
                tr.append(buileEditTd(entSubject));
                tblBodySubject.append(tr);
            }

            function buileEditTd(entSubject) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>View</a>");
                editLnk.click(function (event) {
                    window.open("PopupEmailNotification.aspx?id=" + entSubject.EmailNotification_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                return actionTd;
            }
        });
    }

    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;
        var jqSponsor = null;
        if (id == null) {
            ctrl.LoadDelegate = function () {
                StudentProgressSummaryAjaxGateway.NewStudentProgressSummaryDetail(function (res) {
                    if (res.error == null) ctrl.Populate(res.value.Entity);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                StudentProgressSummaryAjaxGateway.GetStudentProgressSummaryDetail(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            jqSponsor.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sponsor));
                            ctrl.Populate(res.value.Entity);

                            if (res.value.Entity.Student_Status == FlagCodes.StudentStatusType.Complete || !local.ValidatePermission(FlagCodes.PermissionType.StudentProgressSummaryEdit)) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }
                        }
                    }
                    else ctrl.Close();
                });
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressSummaryAjaxGateway.SaveStudentProgressSummary(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Student Progress Summary";
            if (entity.AssessmentResult_ID != GuidEmpty) title = "Editing \"" + entity.Application_FullName + "\"";
            return title;
        };


        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }
        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Student Progress Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_FullName;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "D.O.B.";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return teq.Common.FormatDate(entity.Application_DOB);
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Gender";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return FlagNames.GenderType[entity.Application_Gender];
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Nationality";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return FlagNames.NationalityType[entity.Application_Nationality];
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_IdentificationNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_PhonePrefix + " " + entity.Application_PhoneNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_MobilePhonePrefix + " " + entity.Application_MobilePhoneNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Email;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "Active";
                    vals[1] = "Completed";
                    vals[2] = "Suspended";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            choices: Enums.StudentStatusType
                        });
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                         return entity.Student_Status;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Student_Status = val;
                    };

                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Student_Remark;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Student_Remark = val;
                    };
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Sponsor";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                        });
                        //element.change(function () {
                        //    //AssessmentResultAjaxGateway.GetSponsorList($(this).val(), function (res) {
                        //    //    if (res.error == null) {
                        //    //        //jqSubject.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value));
                        //    //        //jqSubject.checkboxList("setValues", []); //clear checkboxlist upon changing field
                        //    //    }
                        //    //});
                        //});
                        jqSponsor = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Sponsor_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Sponsor_ID = val;
                    }
                    sec.Properties.push(prop);
                }
            }         
        }
        ctrl.Initialize();
    }

    function buildStudentIssueWarningDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var jqWarningLetter = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value.Entity == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    //teq.Context.Alert(res.value.WarningLetterTemplate);
                    jqWarningLetter.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.WarningLetterTemplate));
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }


        if (id == null) {
            ctrl.LoadDelegate = function () {
                StudentProgressSummaryAjaxGateway.NewStudentWarningLetter(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                StudentProgressSummaryAjaxGateway.GetStudentWarningLetter(id, populateDel);
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressSummaryAjaxGateway.SaveStudentWarningLetter(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                }
            });
        };

        //ctrl.SaveDelegate = function (entity, callback) {
        //    var msg = "Saving the selected the template.<br><br>Are you sure?";
        //    teq.Context.Confirm(msg, function () {
        //        StudentProgressSummaryAjaxGateway.SaveStudentWarningLetter(entity, function (res) {
        //            if (res.error == null && res.value.length == 0) {
        //                self.ListControlller.RefreshList();
        //            }
        //        });
        //    });
        //};

        ctrl.GetTitleDelegate = function (entity) {
            //var title = self.Title + " - " + edit;
            var title = "Create Warning Letter";
            if (entity.Entity.Student_ID != GuidEmpty) title = "Issue Warning Letter To \"" + entity.Entity.Application_FullName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Warning letter Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "Note: Once a template is selected and saved, <br>a warning letter will be sent to the corresponding recipient.";

                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Template List";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Select None -",
                            nullValue: GuidEmpty
                        });
                        element.addClass("property");
                        jqWarningLetter = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedWarningLetter;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SelectedWarningLetter = val;
                    };
                    sec.Properties.push(prop);
                }
            }

        }
        ctrl.Initialize();
    }

    //function buildStudentProgressDialog(edit) {
    //    {
    //        var ctrl = new teq.EntityPropertiesDialogController();
    //        var inputWidth = "150px";
    //        var grp = new teq.EntityPropertiesGroup();
    //        grp.Name = "Lots";
    //        ctrl.Groups.push(grp);
    //        {
    //        }
    //        ctrl.LoadDelegate = function () {
    //            ctrl.Populate(null);
    //        }
    //        ctrl.GetTitleDelegate = function (entity) {
    //            var title = "Course Code - " + edit;
    //            return title;
    //        };
    //        ctrl.Initialize();
    //    }
    //}

    this.TerminateRecord = function (id, fullname) {
        StudentProgressSummaryAjaxGateway.VerifyTerminatedStudent(id, function (res) {
            if (res.error == null) {
                if (res.value.Code == teq.Context.SuccessErrorCode) {
                    var msg = "Terminate Student:<br><br>\"" + fullname  + "\"<br><br>Are you sure?";
                    teq.Context.Confirm(msg, function () {
                        StudentProgressSummaryAjaxGateway.TerminateStudent(id, function (res) {
                            if (res.error == null) {
                                if (res.value.Code == teq.Context.SuccessErrorCode) {
                                    self.ListControlller.RefreshList();
                                    teq.Context.ToastTape("Student is terminated.");
                                }
                                else teq.Context.Alert(res.value.Name);
                            }
                        });
                    });
                }
                else teq.Context.Alert(res.value.Name);
            }
        });
    }

    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            StudentProgressSummaryAjaxGateway.NewImport(function (res) {
                if (res.error == null) {
                    if (res.value == null) {
                        teq.Context.Alert("Selected record no longer exists.");
                        ctrl.Close();
                    }
                    else {
                        ctrl.Populate(res.value);
                    }
                }
            });
        }
        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressSummaryAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Student";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var inputWidth = "250px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = " ";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "File";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["xlsx"], null);
                        jqUploadFile = element;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadFile = val;
                    }
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }

}