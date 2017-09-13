local.PartTimerCandidatePageController = function (idPrefix) {
    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnImport = "#" + idPrefix + "_btnImport";
    var btnImportCDP = "#" + idPrefix + "_btnImportCDP";
    var btnImportInterview = "#" + idPrefix + "_btnImportInterview";
    var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";
    var btnAssign = "#" + idPrefix + "_btnAssign";
    var btnExport = "#" + idPrefix + "_btnExport";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    //var btnNew = "#" + idPrefix + "_btnNew";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";
    var tbody;

    var searchShown = true;
    var SettingType;

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var txtSearchScore = "#" + idPrefix + "_txtSearchScore";
    var selSearchLocation = "#" + idPrefix + "_selSearchLocation";
    var txtSearchAssessmentDateFrom = "#" + idPrefix + "_txtSearchAssessmentDateFrom";
    var txtSearchAssessmentDateTo = "#" + idPrefix + "_txtSearchAssessmentDateTo";
    var txtSearchEnrollmentDateFrom = "#" + idPrefix + "_txtSearchEnrollmentDateFrom";
    var txtSearchEnrollmentDateTo = "#" + idPrefix + "_txtSearchEnrollmentDateTo";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchSubjectType = "#" + idPrefix + "_selSearchSubjectType";
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";

    this.Initialize = Initialize;
    function Initialize() {

        $(btnImport).button();
        $(btnImportCDP).button();
        $(btnImportInterview).button();
        $(btnDownloadImport).button();
        //$(btnExport).button();
        $(btnAssign).button();

        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
        });
        $(btnImportCDP).click(function (event) {
            event.stopPropagation();
            buildImportCDPDialog();
        });
        $(btnImportInterview).click(function (event) {
            event.stopPropagation();
            buildImportInterviewDialog();
        });

        $(btnAssign).click(function (event) {
            arrItem = [];

            tbody.find('tr').each(function () {
                var row = $(this);
                //                arrItem.push(row.find('input[type="checkbox"]:checked').attr('id'));
                var chkBox = row.find('input[type="checkbox"]');
                if (typeof chkBox[0] != 'undefined' && chkBox[0].checked) {
                    arrItem.push(chkBox[0].id);
                }
            });
            buildBulkSessionPropertySurfaceDataDialog(arrItem);
        });

        $(txtSearchAssessmentDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchAssessmentDateFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchAssessmentDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchAssessmentDateTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));

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
        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.PartTimerAssessmentStatusType
        });
        $(selSearchSubjectType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.PartTimerAssessmentSubjectType
        });
        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

        $(selSearchLocation).dropdownSelect({
            nullValue: "",
            nullLabel: "- Select All -"
        });
        AssessmentResultAjaxGateway.GetPreferredLocation(function (resCourse) {
            $(selSearchLocation).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resCourse.value));
        });


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

        //$(chkSearchSponsorshipType).checkboxList(
        //    {
        //        columnSpacing: 20,
        //        valuesChanged: null,
        //        choices: Enums.SponsorType, //Flags.TradeType,
        //        //showLinks: true,
        //        columns: 1
        //    });
        //$(chkSearchSponsorshipType).checkboxList("setValues", ["1", "2"]);

        BuildSurfaceListing();

        if (!local.ValidatePermission(FlagCodes.PermissionType.PartTimerAssessmentSessionListEdit)) {
            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
            $(btnImportCDP).prop('disabled', true)
                    .addClass("ui-state-disabled");
            $(btnImportInterview).prop('disabled', true)
                    .addClass("ui-state-disabled");
            $(btnAssign).prop('disabled', true)
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
            var IC = $(txtSearchIC).val();
            var State = $(txtSearchState).val();
            var Score = $(txtSearchScore).val();
            var Location = $(selSearchLocation).val();
            var AssessmentDateFrom = $(txtSearchAssessmentDateFrom).val() == "" ? null : $(txtSearchAssessmentDateFrom).val();
            var AssessmentDateTo = $(txtSearchAssessmentDateTo).val() == "" ? null : $(txtSearchAssessmentDateTo).val();
            var EnrollmentDateFrom = $(txtSearchEnrollmentDateFrom).val() == "" ? null : $(txtSearchEnrollmentDateFrom).val();
            var EnrollmentDateTo = $(txtSearchEnrollmentDateTo).val() == "" ? null : $(txtSearchEnrollmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var SubjectType = $(selSearchSubjectType).val();
            var Status = $(selSearchStatus).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");

            if ((AssessmentDateFrom == null || AssessmentDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (AssessmentDateFrom == null || AssessmentDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) {
                teq.Context.Alert("<b>Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            PartTimerAssessmentResultAjaxGateway.GetResult(FullName, Gender, Email, IC, State, Score, Location, AssessmentDateFrom, AssessmentDateTo, ContractType, SubjectType, Status, sponsorshipType, EnrollmentDateFrom, EnrollmentDateTo, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptPartTimerAssessmentResultMasterList");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.PartTimerAssessmentSessionListView)) {
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
            Name: "Part-Timer Assessment Result List",
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

            var FullName = $(txtSearchFullName).val();
            var Gender = $(selSearchGender).val();
            var Email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var State = $(txtSearchState).val();
            var Score = $(txtSearchScore).val();
            var Location = $(selSearchLocation).val();
            var AssessmentDateFrom = $(txtSearchAssessmentDateFrom).val() == "" ? null : $(txtSearchAssessmentDateFrom).val();
            var AssessmentDateTo = $(txtSearchAssessmentDateTo).val() == "" ? null : $(txtSearchAssessmentDateTo).val();
            var EnrollmentDateFrom = $(txtSearchEnrollmentDateFrom).val() == "" ? null : $(txtSearchEnrollmentDateFrom).val();
            var EnrollmentDateTo = $(txtSearchEnrollmentDateTo).val() == "" ? null : $(txtSearchEnrollmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var SubjectType = $(selSearchSubjectType).val();
            var Status = $(selSearchStatus).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");

            if ((AssessmentDateFrom == null || AssessmentDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (AssessmentDateFrom == null || AssessmentDateTo == null || EnrollmentDateFrom == null || EnrollmentDateTo == null) {
                teq.Context.Alert("<b>Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            PartTimerAssessmentResultAjaxGateway.GetPartTimerAssessmentResultListing(FullName, Gender, Email, IC, State, Score, Location, AssessmentDateFrom, AssessmentDateTo, ContractType, SubjectType, Status, sponsorshipType, EnrollmentDateFrom, EnrollmentDateTo, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });


        }

        tbody = $(tbdList);
        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr1 = $("<tr></tr>");
            htr1.append("<td>No. </td>");
            htr1.append("<td>Full Name</td>");
            htr1.append("<td >IC Number</td>");
            htr1.append("<td>Technical Assessment</td>");
            htr1.append("<td>English Assessment</td>");
            htr1.append("<td>Assessment 3</td>");
            htr1.append("<td>CDP</td>");
            htr1.append("<td>Interview</td>");
            htr1.append("<td>Status</td>");
            htr1.append("<td>View</td>");

            varCheckBox = $("<input type='checkbox' />");
            varTD = $("<td ></td>");

            varTD.append(varCheckBox);

            htr1.append(varTD);
            htr1.append("<td >Action</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr1);

            varCheckBox.change(function () {
                if (this.checked) {
                    tbody.find('tr').each(function () {
                        var row = $(this);
                        row.find('input[type="checkbox"]').prop("checked", true);
                    });
                }
                else {
                    tbody.find('tr').each(function () {
                        var row = $(this);
                        row.find('input[type="checkbox"]').prop("checked", false);
                    });
                }
            });
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            //var tbody = $(tbdList);
            tbody.empty();
            var HasPermission = local.ValidatePermission(FlagCodes.PermissionType.PartTimerAssessmentSessionListEdit);
            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.PartTimerAssessmentResult_Assessment1 + "</td>"));
                tr.append(("<td align=center>" + dr.PartTimerAssessmentResult_Assessment2 + "</td>"));
                tr.append(("<td align=center>" + dr.PartTimerAssessmentResult_Assessment3 + "</td>"));
                tr.append(("<td align=center>" + dr.PartTimerAssessmentResult_Attendance + "</td>"));
                tr.append(("<td align=center>" + FlagNames.PartTimerInterviewType[dr.PartTimerAssessmentResult_InterviewResult] + "</td>"));
                tr.append(("<td align=center>" + FlagNames.PartTimerAssessmentStatusType[dr.PartTimerAssessmentResult_Status] + "</td>"));
                tr.append(buileEditTd(dr));

                if (dr.PartTimerAssessmentResult_Status == FlagCodes.PartTimerAssessmentStatusType.Complete || !HasPermission)
                {
                    tr.append(("<td align=center></td>"));
                    tr.append("<td align=center></td>");
                }
                else
                {
                    tr.append("<td align=center><input type='checkbox' id='" + dr.Application_ID + "' /></td>");
                    tr.append(buileActionTd(dr));
                }
              
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.PartTimerAssessmentResult_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //if (dr.PartTimerAssessmentResult_Status != FlagCodes.PartTimerAssessmentStatusType.Complete) {
                //    var delLnk = $("<a href='javascript:void(0);'>Reject</a>");
                //    delLnk.click(function (event) {
                //        event.stopPropagation();
                //        //self.DeleteRecord("", "&lt;Name&gt;");
                //    });
                //    actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);
                //}
                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                var editSessionLnk = $("<a href='javascript:void(0);'>Set Assessment Session</a>");
                editSessionLnk.click(function (event) {
                    buildSessionPropertySurfaceDataDialog(dr.Application_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "calendar"), editSessionLnk);

                return actionTd;
            }
        }
        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }
        self.ListControlller.Initialize();
    }

    var Title = "Part-Timer Assessment Candidate Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                PartTimerAssessmentResultAjaxGateway.NewPartTimerAssessmentResultDetail(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                PartTimerAssessmentResultAjaxGateway.GetPartTimerAssessmentResultDetail(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            ctrl.Populate(res.value);

                            //if (res.value.PartTimerAssessmentResult_Status == FlagCodes.PartTimerAssessmentStatusType.Complete || typeof FlagNames.PermissionType.PartTimerAssessmentSessionListEdit == 'undefined')
                            //{
                            //    $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            //}
                            if (res.value.PartTimerAssessmentResult_Status == FlagCodes.PartTimerAssessmentStatusType.Complete || (!local.ValidatePermission(FlagCodes.PermissionType.PartTimerAssessmentSessionListEdit))) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }
                        }
                    }
                    else ctrl.Close();
                });
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            PartTimerAssessmentResultAjaxGateway.SavePartTimerAssessment(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Assessment Result";
            if (entity.AssessmentResult_ID != GuidEmpty) title = "Editing \"" + entity.Application_FullName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        //#region Application Property
        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Applicant Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
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
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Email;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Part Timer Assessment Information";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Technical Assessment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_Assessment1;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Assessment1 = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "English Assessment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_Assessment2;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Assessment2 = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Assessment 3";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_Assessment3;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Assessment3 = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "CDP";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_Attendance;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Attendance = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Interview";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            choices: Enums.PartTimerInterviewType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_InterviewResult;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_InterviewResult = val;
                    };

                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Location";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_InterviewLocation;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_InterviewLocation = val;
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            choices: Enums.PartTimerAssessmentStatusType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentResult_Status;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Status = val;
                    };

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
                        return entity.PartTimerAssessmentResult_Remark;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentResult_Remark = val;
                    };
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }

    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            PartTimerAssessmentResultAjaxGateway.NewImport(function (res) {
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
            PartTimerAssessmentResultAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Part Timer Assessment Result List";
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

    function buildImportCDPDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            PartTimerAssessmentResultAjaxGateway.NewImport(function (res) {
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
            PartTimerAssessmentResultAjaxGateway.ImportCDP(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Part Timer CDP Result List";
            return title;
        };

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

    function buildImportInterviewDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            PartTimerAssessmentResultAjaxGateway.NewImport(function (res) {
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
            PartTimerAssessmentResultAjaxGateway.ImportInterview(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Part Timer Interview Result List";
            return title;
        };

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

    function buildSessionPropertySurfaceDataDialog(StudentID) {

        var jq = null;
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var populateDel = function (entity) {
            ctrl.Populate(entity.value);
        }

        if (StudentID == null) {
            //ctrl.LoadDelegate = function () {
            //    CourseManagementAjaxGateway.NewCourseSubject(CourseID, populateDel);
            //}
        }
        else {
            ctrl.LoadDelegate = function () {

                PartTimerAssessmentResultAjaxGateway.GetSession(function (resSession) {
                    jq.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resSession.value));
                });

                PartTimerAssessmentResultAjaxGateway.GetAssignedSession(StudentID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            PartTimerAssessmentResultAjaxGateway.SaveSession(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Assign Assessment Session";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 500;
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Available Session";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        element.addClass("property");
                        jq = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.PartTimerAssessmentSession_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentSession_ID = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }

    function buildBulkSessionPropertySurfaceDataDialog(StudentIDs) {

        var jq = null;
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var populateDel = function (entity) {
            entity.value.ApplicationIDs = StudentIDs;
            ctrl.Populate(entity.value);
        }

        if (StudentIDs == null || StudentIDs.length == 0) {
            ctrl.Close();
        }
        else {
            ctrl.LoadDelegate = function () {

                PartTimerAssessmentResultAjaxGateway.GetSession(function (resSession) {
                    jq.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resSession.value));
                });

                PartTimerAssessmentResultAjaxGateway.GetBulkAssignedSession(populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            PartTimerAssessmentResultAjaxGateway.SaveBulkSession(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Assign Assessment Session";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 500;
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Selected Students";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return StudentIDs.length;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Available Session";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        element.addClass("property");
                        jq = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PartTimerAssessmentSessionID = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }
}