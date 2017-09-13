local.ApplicationListingPageController = function (idPrefix) {

    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnImport = "#" + idPrefix + "_btnImport";
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
    var btnReject = "#" + idPrefix + "_btnReject";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";
    var tbody;

    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";
    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchLocation = "#" + idPrefix + "_selSearchLocation";
    var selSearchApplicationStatusType = "#" + idPrefix + "_selSearchApplicationStatusType";

    var txtSearchCGPA = "#" + idPrefix + "_txtSearchCGPA";
    var selSearchCourse = "#" + idPrefix + "_selSearchCourse";
    var txtSearchAgeFrom = "#" + idPrefix + "_txtSearchAgeFrom";
    var txtSearchAgeTo = "#" + idPrefix + "_txtSearchAgeTo";

    var searchShown = true;
    var SettingType;

    var selTSP = $("<select style=\"width:266px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selYear = $("<select style=\"width:266px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selMonth = $("<select style=\"width:266px; padding: 3px 6px; margin-bottom:3px;\" />");

    var PendingCount = "#" + idPrefix + "_PendingCount";
    var TerminatedCount = "#" + idPrefix + "_TerminatedCount";
    var CompletedCount = "#" + idPrefix + "_CompletedCount";

    var arrItem;
    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {
        $(btnAssign).button();
        $(btnReject).button();
        $(btnImport).button();
        $(btnDownloadImport).button();

        selTSP.change(function () {
            ApplicationListingAjaxGateway.GetMonth(selTSP.val(), selYear.val(), populateMonth);
        });


        $(btnReject).click(function (event) {
            arrItem = [];

            tbody.find('tr').each(function () {
                var row = $(this);
                var chkBox = row.find('input[type="checkbox"]');
                if (typeof chkBox[0] != 'undefined' && chkBox[0].checked) {
                    arrItem.push(chkBox[0].id);
                }
            });
            bulkReject(arrItem);
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

        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ContractType
        });

        $(selSearchLocation).dropdownSelect({
            nullValue: GuidEmpty,
            nullLabel: "- Select All -"
        });
        ApplicationListingAjaxGateway.GetPreferredLocation(function (resLocation) {
            $(selSearchLocation).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resLocation.value));
        });

        $(selSearchApplicationStatusType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ApplicationStatus
        });

        $(selSearchCourse).dropdownSelect({
            nullValue: GuidEmpty,
            nullLabel: "- Select All -"
        });
        ApplicationListingAjaxGateway.GetCourseName(function (res) {
            $(selSearchCourse).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });

        BuildSurfaceListing()

        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
        });

        if (!local.ValidatePermission(FlagCodes.PermissionType.ApplicationListEdit)) {
            $(btnAssign).prop('disabled', true)
                    .addClass("ui-state-disabled");

            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }
        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var startDate = $(txtSearchDateFrom).val() == "" ? null : $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val() == "" ? null : $(txtSearchDateTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var state = $(txtSearchState).val();
            var contractType = $(selSearchContractType).val();
            var location = $(selSearchLocation).val();
            var ApplicationStatus = $(selSearchApplicationStatusType).val();
            var CGPA = $(txtSearchCGPA).val();
            var Course = $(selSearchCourse).val();
            var AgeFrom = $(txtSearchAgeFrom).val();
            var AgeTo = $(txtSearchAgeTo).val();

            if (startDate == null || endDate == null) {
                teq.Context.Alert("<b>Application Date Range</b> cannot be blank.");
                return false;
            }

            ApplicationListingAjaxGateway.GetResult(startDate, endDate, fullname, gender, email, IC, state, contractType, location, ApplicationStatus, CGPA, Course, AgeFrom, AgeTo, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptCandidateApplicationMasterList");
                }
            });
        });

    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.ApplicationListView)) {
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
            Name: "Application List",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

   
    }

    var populateMonth = function (res) {
        selMonth.empty();
        selMonth.dropdownSelect({
            nullValue: "",
            nullLabel: "- Select One -",
            choices: teq.Common.DictionaryToArray(res.value)
        });
    };

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }

    function BuildSurfaceListing() {
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
        teq.Common.SetDatePickerClearable($(txtSearchDateTo));

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

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
            var startDate = $(txtSearchDateFrom).val() == "" ? null : $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val() == "" ? null : $(txtSearchDateTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var state = $(txtSearchState).val();
            var contractType = $(selSearchContractType).val();
            var location = $(selSearchLocation).val();
            var ApplicationStatus = $(selSearchApplicationStatusType).val();


            var CGPA = $(txtSearchCGPA).val();
            var Course = $(selSearchCourse).val();
            var AgeFrom = $(txtSearchAgeFrom).val();
            var AgeTo = $(txtSearchAgeTo).val();

            if (startDate == null || endDate == null) {
                teq.Context.Alert("<b>Application Date Range</b> cannot be blank.");
                return false;
            }

            ApplicationListingAjaxGateway.GetApplicationListing(startDate, endDate, fullname, gender, email, IC, state, contractType, location, ApplicationStatus,CGPA,Course,AgeFrom,AgeTo, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                    ApplicationListingAjaxGateway.GetApplicationStatus(function (res) {
                        if (res.error == null) {
                            $(PendingCount).text(res.value.Pending);
                            $(TerminatedCount).text(res.value.Terminated);
                            $(CompletedCount).text(res.value.Completed);
                        }
                    });
                }
            });


        }

        tbody = $(tbdList);
        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >IC Number</td>");
            htr.append("<td >State</td>");
            htr.append("<td >Mobile Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Application Date</td>");
            htr.append("<td >Contract Type</td>");
            htr.append("<td >Preferred Location</td>");
            htr.append("<td >Session Accepted</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");

            varCheckBox = $("<input type='checkbox' />");
            varTD = $("<td ></td>");

            varTD.append(varCheckBox);

            htr.append(varTD);
            htr.append("<td >Action</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

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
            tbody.empty();

            var Populate = true;
            if (!local.ValidatePermission(FlagCodes.PermissionType.ApplicationListEdit)) {
                Populate = false;
            }

            for (var i = 0; i < tbl.Rows.length; i++) {

                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");

                var IsAssessmentSessionAccepted = "No";
                if (dr.Application_IsAssessmentSessionAccepted)
                {
                    IsAssessmentSessionAccepted = "Yes";
                }
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_State + "</td>"));
                tr.append(("<td align=center>" + dr.Application_MobilePhonePrefix + " - " + dr.Application_MobilePhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.Application_Date) + "</td>"));
                tr.append(("<td align=center>" + FlagNames.ContractType[dr.Application_ContractType] + "</td>"));
                tr.append(("<td align=center>" + dr.Application_CampusName + ", " + dr.Application_CampusCity + "</td>"));
                tr.append(("<td align=center>" + IsAssessmentSessionAccepted + "</td>"));
                tr.append(("<td align=center>" + FlagNames.ApplicationStatus[dr.Application_Status] + "</td>"));
             

                var isComplete = false;
                if (FlagCodes.ApplicationStatus.Complete == dr.Application_Status) {
                    isComplete = true;
                }
                if (!Populate || isComplete)
                {
                    tr.append(buileEditTd(dr));
                    tr.append("<td align=center></td>");
                    tr.append("<td align=center></td>");
                }
                else {
                    tr.append(buileEditTd(dr));
                    tr.append("<td align=center><input type='checkbox' id='" + dr.Application_ID + "' /></td>");
                    tr.append(buileActionTd(dr));
                }


                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Application_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //var delLnk = $("<a href='javascript:void(0);'>Reject</a>");
                //delLnk.click(function (event) {
                //    event.stopPropagation();
                //    //self.DeleteRecord("", "&lt;Name&gt;");
                //    self.RejectRecord(dr.Application_ID, dr.Application_FullName);
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Set Assessment Session</a>");
                editLnk.click(function (event) {
                    buildSessionPropertySurfaceDataDialog(dr.Application_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "calendar"), editLnk);

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

    var Title = "Application Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;

        var jqCourse = null;
        var jqSubject = null;
        var jqLocation = null;
        var jqYear = null;
        var jqMonth = null;
        var jqUploadDocument = null;
        var jqCountry = null;
        var jqPQ = null;
        var jqStatus = null;
        var jqSector = null;
        var jqPosition = null;

        var sectorRow = null;

        var companyAddressRow = null;
        var companyContactRow = null;
        var companyNameRow = null;
        var departmentRow = null;
        var positionRow = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value.Entity == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    
                    selTSP.dropdownSelect({
                        choices: teq.Common.DictionaryToArray(res.value.Location)
                    });
                    selYear.dropdownSelect({
                        choices: teq.Common.DictionaryToArray(res.value.YearList)
                    });
                    selMonth.dropdownSelect({
                        nullValue: "",
                        nullLabel: "- Select One -",
                        choices: teq.Common.DictionaryToArray(res.value.MonthList)
                    });

                    //$(selTSP).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Location));
                    //$(selYear).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.YearList));
                    //$(selMonth).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.MonthList));

                    jqCourse.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Course));
                    jqSubject.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value.Subject));
                    jqCountry.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Country));
                    jqPQ.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.PQ));
                    jqSector.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sector));
                    jqPosition.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Position));
                    //jqStatus.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Status));
                    //jqYear.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.YearList));
                    //jqMonth.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.MonthList));

                    //if (res.value.Entity.Application_Status == FlagCodes.ApplicationStatus.Complete || typeof FlagNames.PermissionType.ApplicationListEdit == 'undefined')
                    //{
                    //    $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                    //}

                    var canEdit = true;
                    //if (res.value.Entity.Application_Status == FlagCodes.ApplicationStatus.Complete) { //Samuel Chen
                    //    canEdit = false;
                    //}
                    if (!local.ValidatePermission(FlagCodes.PermissionType.ApplicationListEdit)) {
                        canEdit = false;
                    }

                    if (!canEdit)
                    {
                        $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true)
                                                              .addClass("ui-state-disabled");
                    }
        
                    ctrl.Populate(res.value);
                    if (res.value.Entity.Application_CurrentlyEmployed == FlagCodes.YesNoType.Yes) {
                        sectorRow.Show();
                        companyAddressRow.Show();
                        companyContactRow.Show();
                        companyNameRow.Show();
                        departmentRow.Show();
                        positionRow.Show();
                    } else {
                        sectorRow.Hide();
                        companyAddressRow.Hide();
                        companyContactRow.Hide();
                        companyNameRow.Hide();
                        departmentRow.Hide();
                        positionRow.Hide();
                    }
            
                }
            }
            else ctrl.Close();
        }

        if (id == null) {
            ctrl.LoadDelegate = function () {
                ApplicationListingAjaxGateway.NewApplication(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                ApplicationListingAjaxGateway.GetApplication(id, populateDel);
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            ApplicationListingAjaxGateway.SaveApplication(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                    jqUploadDocument.Reset();
                }
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Application";
            if (entity.Entity.Application_ID != GuidEmpty) title = "Editing \"" + entity.Entity.Application_FullName + "\"";
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
            grp.Name = "Applicant Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_FullName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_FullName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Date of Birth";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_DOB;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_DOB = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "IC Number";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_IdentificationNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_IdentificationNumber = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Nationality";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect({
                            choices: Enums.NationalityType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Nationality;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Nationality = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Gender";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect({
                            choices: Enums.GenderType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Gender;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Gender = val;
                    }
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Currently Employed";
                    prop.Class = "property";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.MarkCompulsary = true;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.radioButtonList({
                            choices: Enums.YesNoType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });

                        element.change(function () {
                            
                            var result = element.find('input:checked').val();
                            if (result == FlagCodes.YesNoType.Yes)
                            {
                                sectorRow.Show();
                                companyAddressRow.Show();
                                companyContactRow.Show();
                                companyNameRow.Show();
                                departmentRow.Show();
                                positionRow.Show();
                            } else
                            {
                                sectorRow.Hide();
                                companyAddressRow.Hide();
                                companyContactRow.Hide();
                                companyNameRow.Hide();
                                departmentRow.Hide();
                                positionRow.Hide();
                            }
                           // alert(element.find('input:checked').val());
                           
                           
                           
                        });
                    }
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        if (entity.Entity.Application_CurrentlyEmployed) return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == 1)
                        { entity.Entity.Application_CurrentlyEmployed = true; }
                        else
                        { entity.Entity.Application_CurrentlyEmployed = false; }
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    sectorRow = prop;
                    prop.Label = "Sector";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        element.addClass("property");
                        jqSector = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanySector;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanySector = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    positionRow = prop;
                    prop.Label = "Position";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        element.addClass("property ");
                        jqPosition = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanyPosition;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanyPosition = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    departmentRow = prop;
                    prop.Label = "Department ";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanyDepartment;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanyDepartment = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    companyNameRow = prop;
                    prop.Label = "Company Name ";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanyName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanyName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    companyContactRow = prop;
                    prop.Label = "Company Contact ";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanyContact;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanyContact = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    companyAddressRow = prop;
                    prop.Label = "Company Address ";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CompanyAddress;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CompanyAddress = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.MarkCompulsary = true;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_FatherName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_FatherName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.MarkCompulsary = true;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_FatherIdentification;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_FatherIdentification = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.MarkCompulsary = true;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_MotherName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_MotherName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's IC Number";
                    //prop.MarkCompulsary = true;
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_MotherIdentification;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_MotherIdentification = val;
                    }
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Combined Household Income";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CombinedHouseholdIncome;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CombinedHouseholdIncome = parseFloat(val);
                    }
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Contact Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address 1";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Address1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Address1 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address 2";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Address2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Address2 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Postcode";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Postcode;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Postcode = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "City";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_City;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_City = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "State";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.attr('list', 'dtState');
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_State;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        // element.addClass("property");
                        entity.Entity.Application_State = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Country";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.dropdownSelect(
                        {
                        });
                        jqCountry = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Country_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Country_ID = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var txtPhonePrefix = $("<input type='text' style=\"width:40px; padding: 3px 6px; margin-bottom:3px;\" />");
                    var txtPhone = $("<input type='text' style=\"width:191px; padding: 3px 6px; margin-bottom:3px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPhonePrefix, "&nbsp;", txtPhone);
                    }
                    prop.GetValueDelegate = function (entity) {
                        txtPhonePrefix.val(entity.Entity.Application_PhonePrefix);
                        txtPhone.val(entity.Entity.Application_PhoneNumber);
                        return entity.Entity.Application_PhonePrefix, entity.Entity.Application_PhoneNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_PhonePrefix = txtPhonePrefix.val();
                        entity.Entity.Application_PhoneNumber = txtPhone.val();
                    }
                    sec.Properties.push(prop);
                }
                {
                    var txtPrefix = $("<input type='text' style=\"width:40px; padding: 3px 6px; margin-bottom:3px;\" />");
                    var txtMobile = $("<input type='text' style=\"width:191px; padding: 3px 6px; margin-bottom:3px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Number";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPrefix, "&nbsp;", txtMobile);
                    };
                    prop.GetValueDelegate = function (entity) {
                        txtPrefix.val(entity.Entity.Application_MobilePhonePrefix);
                        txtMobile.val(entity.Entity.Application_MobilePhoneNumber);
                        return entity.Entity.Application_MobilePhonePrefix, entity.Entity.Application_MobilePhoneNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_MobilePhonePrefix = txtPrefix.val();
                        entity.Entity.Application_MobilePhoneNumber = txtMobile.val();
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Email = val;
                    }
                    sec.Properties.push(prop);
                }
            }
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Academic & PQ Information";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Current Field of Study";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CurrentFieldOfStudy;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CurrentFieldOfStudy = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "University / Institution";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_University;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_University = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Current / Final CGPA";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_CGPA;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_CGPA = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Registration No.";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_PGRegistrationNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_PGRegistrationNumber = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Start Date";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_PQStartDate;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_PQStartDate = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Deadline";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_PQDeadline;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_PQDeadline = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Level PQ Started";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                        });
                        jqPQ = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_PQLevelStart;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_PQLevelStart = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Registered Next Exam Sitting";
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
                    prop.GetValueDelegate = function (entity) {
                        if (entity.Entity.Application_RegisteredNextExam) return FlagCodes.YesNoType.Yes; //Refer Enumeration.js at runtime
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == 1)
                        { entity.Entity.Application_RegisteredNextExam = true; }
                        else
                        { entity.Entity.Application_RegisteredNextExam = false; }
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Next Exam Session";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_NextExamSession;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_NextExamSession = val;
                    }
                    sec.Properties.push(prop);
                }
            }
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Application Detail";
            ctrl.Groups.push(grp);
            {
                var propCourse;
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Course";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                        });
                        element.change(function () {
                            ApplicationListingAjaxGateway.GetSubjectList($(this).val(), function (res) {
                                if (res.error == null) {
                                    jqSubject.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value));
                                    jqSubject.checkboxList("setValues", []); //clear checkboxlist upon changing field
                                }
                            });
                        });
                        jqCourse = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Course_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Course_ID = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contract Type";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.radioButtonList({
                            choices: Enums.ContractType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_ContractType;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_ContractType = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Outstanding Papers";
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.checkboxList({
                            columns: 1,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                        jqSubject = element;
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedSubject;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SelectedSubject = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Prefered Study Location";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selTSP);
                    }

                    prop.GetValueDelegate = function (entity) {
                        selTSP.val(entity.Entity.TSP_ID);
                        return entity.Entity.TSP_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.TSP_ID = selTSP.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                //{
                //    var prop = new teq.EntityProperty();
                //    prop.Label = "Study Location";
                //    //prop.MarkCompulsary = true;
                //    prop.Input = new teq.EntityDropdownSelectInput();
                //    prop.Input.BuildElementDelegate = function (element) {
                //        element.addClass("property");
                //        element.dropdownSelect(
                //        {
                //        });
                //        jqLocation = element;
                //    };
                //    prop.GetValueDelegate = function (entity) {
                //        return entity.Entity.TSP_ID;
                //    }
                //    prop.SetValueDelegate = function (entity, val) {
                //        entity.Entity.TSP_ID = val;
                //    }
                //    sec.Properties.push(prop);
                //}

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Intake Year";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selYear);
                    }

                    prop.GetValueDelegate = function (entity) {
                        selYear.val(entity.Entity.Application_IntakeYear);
                        return entity.Entity.Application_IntakeYear;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_IntakeYear = selYear.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Intake Month";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selMonth);
                    }

                    prop.GetValueDelegate = function (entity) {
                        selMonth.val(entity.Entity.Application_IntakeMonth);
                        return entity.Entity.Application_IntakeMonth;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_IntakeMonth = selMonth.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: -1,
                            choices: Enums.ApplicationStatus
                        });
                        jqStatus = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Application_Status;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Application_Status = val;
                    }
                    sec.Properties.push(prop);
                }
                //{
                //    var prop = new teq.EntityProperty();
                //    prop.Label = "Intake Year";
                //    //prop.MarkCompulsary = true;
                //    prop.Input = new teq.EntityDropdownSelectInput();
                //    prop.Input.BuildElementDelegate = function (element) {
                //        element.addClass("property");
                //        element.dropdownSelect(
                //        {
                //        });
                //        jqYear = element;
                //    };
                //    prop.GetValueDelegate = function (entity) {
                //        return entity.Entity.Application_IntakeYear;
                //    }
                //    prop.SetValueDelegate = function (entity, val) {
                //        entity.Entity.Application_IntakeYear = val;
                //    }
                //    sec.Properties.push(prop);
                //}
                //{
                //    var prop = new teq.EntityProperty();
                //    prop.Label = "Intake Month";
                //    //prop.MarkCompulsary = true;
                //    prop.Input = new teq.EntityDropdownSelectInput();
                //    prop.Input.BuildElementDelegate = function (element) {
                //        element.addClass("property");
                //        element.dropdownSelect(
                //        {
                //        });
                //        jqMonth = element;
                //    };
                //    prop.GetValueDelegate = function (entity) {
                //        return entity.Entity.Application_IntakeMonth;
                //    }
                //    prop.SetValueDelegate = function (entity, val) {
                //        entity.Entity.Application_IntakeMonth = val;
                //    }
                //    sec.Properties.push(prop);
                //}
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Attachment";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);
                {
                    var downloadLnk1 = $("<a download='' href=''>Download</a>");//$("<a download='' href=''><img src='Resource/download_s.png' /><br /><br /></a>");

                    var prop = new teq.EntityProperty();
                    prop.Label = "IC";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk1);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], null);
                        jqUploadDocument = element;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                    }
                    prop.GetValueDelegate = function (entity) {
                        downloadLnk1.text(entity.Entity.Application_IdentificationImage);
                        downloadLnk1.attr("href", "UserFiles/UploadedAttachments/" + entity.Entity.Application_ID + "/" + entity.Entity.Application_IdentificationFile);
                        downloadLnk1.attr("download", entity.Entity.Application_IdentificationImage);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadIC = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var downloadLnk2 = $("<a download='' href=''>Download</a>");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Birth Certificate";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk2);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], null);

                        jqUploadDocument = element;
                    }
                    //prop.AssociatedErrors = [ErrorCodes.GCM_SunYatSungPls, ErrorCodes.GCM_FileRequired];
                    prop.ValidationDelegate = function (val, callback) {
                        //  GiftCategoryMngAjaxGateway.VerifyUploadedFile(val, callback);
                    }
                    prop.GetValueDelegate = function (entity) {
                        downloadLnk2.text(entity.Entity.Application_BirthCertificateImage);
                        downloadLnk2.attr("href", "UserFiles/UploadedAttachments/" + entity.Entity.Application_ID + "/" + entity.Entity.Application_BirthCertificateFile);
                        downloadLnk2.attr("download", entity.Entity.Application_BirthCertificateImage);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadBOC = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var downloadLnk3 = $("<a download='' href=''>Download</a>");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Academic Transcript";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk3);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], null);
                        jqUploadDocument = element;
                    }
                    //prop.AssociatedErrors = [ErrorCodes.GCM_SunYatSungPls, ErrorCodes.GCM_FileRequired];
                    prop.ValidationDelegate = function (val, callback) {
                        //  GiftCategoryMngAjaxGateway.VerifyUploadedFile(val, callback);
                    }
                    prop.GetValueDelegate = function (entity) {
                        downloadLnk3.text(entity.Entity.Application_AcademicTranscriptImage);
                        downloadLnk3.attr("href", "UserFiles/UploadedAttachments/" + entity.Entity.Application_ID + "/" + entity.Entity.Application_AcademicTranscriptFile);
                        downloadLnk3.attr("download", entity.Entity.Application_AcademicTranscriptImage);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadAC = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var downloadLnk4 = $("<a download='' href=''>Download</a>");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Passport Size Photo";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk4);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], null);
                        jqUploadDocument = element;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        //  GiftCategoryMngAjaxGateway.VerifyUploadedFile(val, callback);
                    }
                    prop.GetValueDelegate = function (entity) {
                        downloadLnk4.text(entity.Entity.Application_PassportSizeImage);
                        downloadLnk4.attr("href", "UserFiles/UploadedAttachments/" + entity.Entity.Application_ID + "/" + entity.Entity.Application_PassportSizeFile);
                        downloadLnk4.attr("download", entity.Entity.Application_PassportSizeImage);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadPhoto = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var downloadLnk5 = $("<a download='' href=''>Download</a>");

                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Acceptance Letter";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk5);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], null);
                        jqUploadDocument = element;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        //  GiftCategoryMngAjaxGateway.VerifyUploadedFile(val, callback);
                    }
                    prop.GetValueDelegate = function (entity) {
                        downloadLnk5.text(entity.Entity.Application_PQAcceptanceImage);
                        downloadLnk5.attr("href", "UserFiles/UploadedAttachments/" + entity.Entity.Application_ID + "/" + entity.Entity.Application_PQAcceptanceFile);
                        downloadLnk5.attr("download", entity.Entity.Application_PQAcceptanceImage);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadPQ = val;
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

                ApplicationListingAjaxGateway.GetSession(function (resSession) {
                    jq.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resSession.value));
                });

                ApplicationListingAjaxGateway.GetAssignedSession(StudentID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            ApplicationListingAjaxGateway.SaveSession(entity, function (res) {
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
                        return entity.AssessmentSession_ID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentSession_ID = val;
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
            entity.value.StudentIDs = StudentIDs;
            ctrl.Populate(entity.value);
        }

        if (StudentIDs == null || StudentIDs.length == 0) {
            ctrl.Close();
        }
        else {
            ctrl.LoadDelegate = function () {

                ApplicationListingAjaxGateway.GetSession(function (resSession) {
                    jq.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resSession.value));
                });

                ApplicationListingAjaxGateway.GetBulkAssignedSession(populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            ApplicationListingAjaxGateway.SaveBulkSession(entity, function (res) {
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
                        //return "";
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SessionID = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }

    function bulkReject(ApplicationIDs) {
        var msg = "Select applications will be rejected. Proceed?";
        teq.Context.Confirm(msg, function () {

            ApplicationListingAjaxGateway.Reject(ApplicationIDs, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Selected Applications are rejected.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
    }

    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 400;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            ApplicationListingAjaxGateway.NewImport(function (res) {
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
            ApplicationListingAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Application List";
            return title;
        };

        {
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
                        teq.Common.BuildSingleFileUploadInput(element, "250px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["xlsx"], null);
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