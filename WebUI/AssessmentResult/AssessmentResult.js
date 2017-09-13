local.AssessmentResultPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnAssign = "#" + idPrefix + "_btnAssign";
    var btnExport = "#" + idPrefix + "_btnExport";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnSendCLO = "#" + idPrefix + "_btnSendCLO";

    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

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
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchExamType = "#" + idPrefix + "_selSearchExamType";
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";

    var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";
    var btnImport = "#" + idPrefix + "_btnImport";
    var btnBulkAssign = "#" + idPrefix + "_btnBulkAssign";

    this.Initialize = Initialize;
    function Initialize() {
        $(btnSendCLO).button();
        $(btnAssign).button();
        $(btnDownloadImport).button();
        $(btnImport).button();
        $(btnBulkAssign).button();
        
        $(btnBulkAssign).click(function (event) {
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

        $(btnSendCLO).click(function (event) {
            arrItem = [];

            tbody.find('tr').each(function () {
                var row = $(this);
                var chkBox = row.find('input[type="checkbox"]');
                if (typeof chkBox[0] != 'undefined' && chkBox[0].checked) {
                    arrItem.push(chkBox[0].id);
                }
            });
            buildCLODataDialog(arrItem);
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

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ContractType
        });
        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.AssessmentStatusType
        });
        $(selSearchExamType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.AssessmentSubjectType
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
        ApplicationListingAjaxGateway.GetPreferredLocation(function (resLocation) {
            $(selSearchLocation).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resLocation.value));
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

        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
        });

        BuildSurfaceListing();

        if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentResultListEdit))
        {
            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
            $(btnSendCLO).prop('disabled', true)
                    .addClass("ui-state-disabled");
            $(btnBulkAssign).prop('disabled', true)
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
            //var DateFrom = $(txtSearchAssessmentDateFrom).val();
            //var DateTo = $(txtSearchAssessmentDateTo).val();
            var DateFrom = $(txtSearchAssessmentDateFrom).val() == "" ? null : $(txtSearchAssessmentDateFrom).val();
            var DateTo = $(txtSearchAssessmentDateTo).val() == "" ? null : $(txtSearchAssessmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var ExamType = $(selSearchExamType).val();
            var Status = $(selSearchStatus).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");

            if ((DateFrom == null || DateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Assessment Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (DateFrom == null || DateTo == null) {
                teq.Context.Alert("<b>Assessment Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            AssessmentResultAjaxGateway.GetResult(FullName, Gender, Email, IC, State, Score, Location, DateFrom, DateTo, ContractType, ExamType, Status, sponsorshipType, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptCandidateAssessmentResultMasterList");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentResultListView)) {
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
            Name: "Assessment Result",
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
            //var DateFrom = $(txtSearchAssessmentDateFrom).val();
            //var DateTo = $(txtSearchAssessmentDateTo).val();
            var DateFrom = $(txtSearchAssessmentDateFrom).val() == "" ? null : $(txtSearchAssessmentDateFrom).val();
            var DateTo = $(txtSearchAssessmentDateTo).val() == "" ? null : $(txtSearchAssessmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var ExamType = $(selSearchExamType).val();
            var Status = $(selSearchStatus).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");

            if ((DateFrom == null || DateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Assessment Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (DateFrom == null || DateTo == null) {
                teq.Context.Alert("<b>Assessment Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            AssessmentResultAjaxGateway.GetAssessmentResultListing(FullName, Gender, Email, IC, State, Score, Location, DateFrom, DateTo, ContractType, ExamType, Status, sponsorshipType, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });


        }

        tbody = $(tbdList);
        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr1 = $("<tr></tr>");
            htr1.append("<td rowspan=2>No. </td>");
            htr1.append("<td rowspan=2>Full Name</td>");
            htr1.append("<td rowspan=2>IC Number</td>");
            htr1.append("<td rowspan=2>Technical Assessment</td>");
            htr1.append("<td rowspan=2>English Foundation</td>");
            htr1.append("<td colspan=4>English Proficiency Test</td>");
            htr1.append("<td rowspan=2>Tiering</td>");
            htr1.append("<td rowspan=2>Status</td>");
            htr1.append("<td rowspan=2>Interview</td>");
            htr1.append("<td rowspan=2>Sponsor</td>");
            htr1.append("<td rowspan=2>View</td>");


            varCheckBox = $("<input type='checkbox' />");
            varTD = $("<td align=center rowspan=2></td>");

            varTD.append(varCheckBox);

            htr1.append(varTD);

            //htr1.append("<td rowspan=2 align=center><input type='checkbox' /></td>");
            

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

            var htr = $("<tr></tr>");
            htr.append("<td>Listening</td>");
            htr.append("<td>Writing</td>");
            htr.append("<td>Speaking</td>");
            htr.append("<td>Reading</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr1);
            thead.append(htr);

            function headerCol(colName) {
                var td = $("<td/>");
                var a = $("<a href='javascript:void(0);'>" + colName + "</a>");
                td.append(a);
                return td;
            }
        }
        self.ListControlller.PopulateDataDelegate = function (tbl) {
            //var tbody = $(tbdList);
            tbody.empty();
            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_TechnicalAssessment + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_EnglishFoundation + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_Listening + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_Writing + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_Speaking + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_Reading + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentResult_EPTSummary + "</td>"));
                tr.append(("<td align=center>" + FlagNames.AssessmentStatusType[dr.AssessmentResult_Status] + "</td>"));
                tr.append(("<td align=center>" + FlagNames.AssessmentInterviewStatus[dr.AssessmentResult_Interview] + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Label + "</td>"));
                tr.append(buileEditTd(dr));
                if (dr.AssessmentResult_Status != FlagCodes.AssessmentStatusType.Complete)
                {
                    tr.append("<td align=center><input type='checkbox' id='" + dr.AssessmentResult_ID + "' /></td>");
                } else
                {
                    tr.append("<td></td>");
                }
              
                
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.AssessmentResult_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);


                //if (dr.AssessmentResult_Status != FlagCodes.AssessmentStatusType.Complete) {
                //    var delLnk = $("<a href='javascript:void(0);'>Reject</a>");
                //    delLnk.click(function (event) {
                //        event.stopPropagation();
                //        self.DeleteRecord(dr.AssessmentResult_ID);
                //    });
                //    actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);
                //}
         

                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Assign to YPPB</a>");
                editLnk.click(function (event) {
                    //buildSurfaceDataDialog(dr.AssessmentResult_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "refresh"), editLnk);

                return actionTd;
            }
        }
        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Assessment Result Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 600;

        var jqSponsor = null;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                AssessmentResultAjaxGateway.NewAssessmentResultDetail(function (res) {
                    if (res.error == null) {

                        jqSponsor.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sponsor));

                        ctrl.Populate(res.value.Entity);
                    }
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                AssessmentResultAjaxGateway.GetAssessmentResultDetail(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            ctrl.Populate(res.value.Entity);

                            jqSponsor.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sponsor));
                            //alert(res.value.AssessmentResult_Status);
                            //if (res.value.AssessmentResult_Status == FlagCodes.AssessmentStatusType.Complete || typeof FlagNames.PermissionType.AssessmentResultListEdit == 'undefined')
                            //{
                            //    $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            //}
                            if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentResultListEdit) || res.value.AssessmentResult_Status == FlagCodes.AssessmentStatusType.Complete) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }
                        }
                    }
                    else ctrl.Close();
                });
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            AssessmentResultAjaxGateway.SaveAssessmentResult(entity, function (res) {
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
            grp.Name = "Assessment Information";
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
                        return entity.AssessmentResult_TechnicalAssessment;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_TechnicalAssessment = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "English Foundation";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_EnglishFoundation;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_EnglishFoundation = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "(EPT) Listening";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Listening;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Listening = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "(EPT) Writing";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Writing;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Writing = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "(EPT) Speaking";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Speaking;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Speaking = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "(EPT) Reading";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Reading;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Reading = parseFloat(val);
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Tiering";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_EPTSummary;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_EPTSummary = parseFloat(val);
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

                //{
                //    var prop = new teq.EntityProperty();
                //    prop.Label = "Sponsor";

                //    //prop.MarkCompulsary = true;
                //    prop.Input = new teq.EntityDropdownSelectInput();
                //    prop.Input.BuildElementDelegate = function (element) {
                //        element.addClass("property");
                //        element.dropdownSelect(
                //        {
                //            choices: Enums.SponsorType
                //        });
                //    };
                //    prop.GetValueDelegate = function (entity) {
                //        return entity.Application_Sponsor;
                //    };
                //    prop.SetValueDelegate = function (entity, val) {
                //        entity.Application_Sponsor = val;
                //    };

                //    sec.Properties.push(prop);
                //}
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            choices: Enums.AssessmentStatusType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Status;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Status = val;
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
                            choices: Enums.AssessmentInterviewStatus
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentResult_Interview;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Interview = val;
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
                        return entity.AssessmentResult_Remark;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentResult_Remark = val;
                    };
                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.Initialize();
    }
    function buildCLODataDialog(AssessmentIDs) {
        var msg = "Conditional Letter of Offer will be sent to all " + AssessmentIDs.length + " candidates. Please note that only candidates with Accepted status will receive the letter. Proceed?";
        teq.Context.Confirm(msg, function () {

            AssessmentResultAjaxGateway.SendCLO(AssessmentIDs, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Conditional Letter of Offers are successfully queued for sending.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
    }

    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            AssessmentResultAjaxGateway.NewImport(function (res) {
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
            AssessmentResultAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Assessment Result List";
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

    function buildBulkSessionPropertySurfaceDataDialog(AssessmentIDs) {

        var jq = null;
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var populateDel = function (entity) {
            entity.value.AssessmentIDs = AssessmentIDs;
            ctrl.Populate(entity.value);
        }

        if (AssessmentIDs == null || AssessmentIDs.length == 0) {
            ctrl.Close();
        }
        else {
            ctrl.LoadDelegate = function () {

                AssessmentResultAjaxGateway.GetSession(function (resSession) {
                    jq.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resSession.value));
                });

                AssessmentResultAjaxGateway.GetBulkAssignedSession(populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            AssessmentResultAjaxGateway.SaveBulkSession(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Assign Part Timer Assessment Session";
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
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return AssessmentIDs.length;
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
                        entity.SessionID = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }
}