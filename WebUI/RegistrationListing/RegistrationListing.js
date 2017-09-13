local.RegistrationListingPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnImport = "#" + idPrefix + "_btnImport";
    var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var btnExport = "#" + idPrefix + "_btnDownloadExcel";
    
    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var selSearchCourse = "#" + idPrefix + "_selSearchCourse";
    var selSearchEmployed = "#" + idPrefix + "_selSearchEmployed";
    var dtpSearchRegisterFrom = "#" + idPrefix + "_dtpSearchRegisterFrom";
    var dtpSearchRegisterTo = "#" + idPrefix + "_dtpSearchRegisterTo";
    
    var searchShown = true;
    var SettingType;

    var selLevel1 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selField1 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");

    var selLevel2 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selField2 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");

    var selLevel3 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selField3 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");

    var selLevel4 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selField4 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");

    var selLevel5 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selField5 = $("<select style=\"width:203px; padding: 3px 6px; margin-bottom:3px;\" />");


    this.Initialize = Initialize;
    function Initialize() {
        RegistrationListingAjaxGateway.GetGlobalSetting(FlagCodes.GlobalSettingType.FieldOfStudy, function (resField) {
            selField1.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });

            selField2.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });

            selField3.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });

            selField4.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });

            selField5.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });
        });

        RegistrationListingAjaxGateway.GetGlobalSetting(FlagCodes.GlobalSettingType.EducationLevel, function (resLevel) {
            selLevel1.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resLevel.value)
            });

            selLevel2.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resLevel.value)
            });

            selLevel3.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resLevel.value)
            });

            selLevel4.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resLevel.value)
            });

            selLevel5.dropdownSelect({
                nullValue: "",
                nullLabel: "- None -",
                choices: teq.Common.DictionaryToArray(resLevel.value)
            });
        });

        $(btnImport).button();
        //$(btnExport).button();
        $(btnDownloadImport).button();

        BuildSurfaceListing();

        $(dtpSearchRegisterFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(dtpSearchRegisterFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(dtpSearchRegisterTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(dtpSearchRegisterTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));
        $(selSearchCourse).dropdownSelect({
            nullValue: "",
            nullLabel: "- Select All -"
        });

        RegistrationListingAjaxGateway.GetCourse(function (resCourse) {
            $(selSearchCourse).dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resCourse.value));
        });

        $(selSearchEmployed).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.YesNoType
        });
        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
            //
        });

        if (!local.ValidatePermission(FlagCodes.PermissionType.RegistrationListEdit))
        {
            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }

        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);


        $(btnExport).attr('disabled', false).unbind().click(function () {

            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var state = $(txtSearchState).val();
            var course = $(selSearchCourse).val();
            var employed = $(selSearchEmployed).val();
            var dtregisterfrom = $(dtpSearchRegisterFrom).val() == "" ? null : $(dtpSearchRegisterFrom).val();
            var dtregisterto = $(dtpSearchRegisterTo).val() == "" ? null : $(dtpSearchRegisterTo).val();


            if (dtregisterfrom == null || dtregisterto == null) {
                teq.Context.Alert("<b>Registration Date Range</b> cannot be blank.");
                return false;
            }

            RegistrationListingAjaxGateway.GetResult(fullname, gender, email, IC, state, course, employed, dtregisterfrom, dtregisterto, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptCandidateRegistrationMasterList");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {
            if (!local.ValidatePermission(FlagCodes.PermissionType.RegistrationListView))
            {
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
            Name: "Registration List",
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

            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var state= $(txtSearchState).val();
            var course= $(selSearchCourse).val();
            var employed = $(selSearchEmployed).val();
            //var dtregisterfrom = $(dtpSearchRegisterFrom).val();
            //var dtregisterto = $(dtpSearchRegisterTo).val();
            var dtregisterfrom = $(dtpSearchRegisterFrom).val() == "" ? null : $(dtpSearchRegisterFrom).val();
            var dtregisterto = $(dtpSearchRegisterTo).val() == "" ? null : $(dtpSearchRegisterTo).val();

            if (dtregisterfrom == null || dtregisterto == null) {
                teq.Context.Alert("<b>Registration Date Range</b> cannot be blank.");
                return false;
            }

            RegistrationListingAjaxGateway.GetCandidateListing(fullname, gender, email, IC, state, course, employed, dtregisterfrom, dtregisterto, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });

        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >IC Number</td>");
            htr.append("<td >State</td>");
            htr.append("<td >Contact Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Reg. Date</td>");
            htr.append("<td >Currently Employed</td>");
            
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

                var EmployedStatus = dr.Candidate_CurrentlyEmployed;
                if (dr.Candidate_CurrentlyEmployed) {
                    EmployedStatus = "Yes";//Employed
                }
                else {
                    EmployedStatus = "No";//Unemployed
                }

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Candidate_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Candidate_ICNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Candidate_State + "</td>"));
                tr.append(("<td align=center>" + dr.Candidate_PhonePrefix + "-" + dr.Candidate_PhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Candidate_Email + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.Candidate_CreatedDate) + "</td>"));
                tr.append(("<td align=center>" + EmployedStatus + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Candidate_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                //delLnk.click(function (event) {
                //    event.stopPropagation();
                //    self.DeleteRecord(dr.Candidate_ID, dr.Candidate_FullName);
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Personal Information";
    self.Title = Title;

    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;

        var jqQualification = null;
        var jqCountry = null;
        var jqSector = null;
        var jqPosition = null;
        if (id == null) {
            ctrl.LoadDelegate = function () {
                RegistrationListingAjaxGateway.NewCandidate(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                RegistrationListingAjaxGateway.GetCandidate(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {

                            
                            if (!local.ValidatePermission(FlagCodes.PermissionType.RegistrationListEdit))
                                {
                                    $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                                }

                            jqQualification.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value.Course));
                            jqCountry.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Country));
                            jqSector.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sector));
                            jqPosition.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Position));
                            ctrl.Populate(res.value);
                        }
                    }
                    else ctrl.Close();
                });
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            RegistrationListingAjaxGateway.SaveCandidate(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Candidate";
            if (entity.Entity.TSP_ID != GuidEmpty) title = "Editing \"" + entity.Entity.Candidate_FullName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Personal Information";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 910;
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";

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
                        return entity.Entity.Candidate_FullName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FullName = val;
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
                        element.prop("readonly", true);
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_DOB;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_DOB = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "IC Number";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_ICNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_ICNumber = val;
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
                        element.dropdownSelect(
                        {
                            choices: Enums.NationalityType
                        });
                    };
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_Nationality;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Nationality = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Gender";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.radioButtonList({
                            choices: Enums.GenderType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_Gender;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Gender = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Bumiputra";
                    prop.MarkCompulsary = true;
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
                        //return entity.Entity.Candidate_IsBumiputra;

                        if (entity.Entity.Candidate_IsBumiputra) return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        //entity.Entity.Candidate_IsBumiputra = val;

                        if (val == 1)
                        { entity.Entity.Candidate_IsBumiputra = true; }
                        else
                        { entity.Entity.Candidate_IsBumiputra = false; }
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Ethnicity";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_OtherEthnicity;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_OtherEthnicity = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Currently Employed";
                    prop.Class = "property";
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
                        if (entity.Entity.Candidate_CurrentlyEmployed) return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == 1)
                        { entity.Entity.Candidate_CurrentlyEmployed = true; }
                        else
                        { entity.Entity.Candidate_CurrentlyEmployed = false; }
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
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
                        return entity.Entity.Candidate_Sector;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Sector = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Position";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        element.addClass("property propertyseperator");
                        jqPosition = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_Position;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Position = val;
                    }
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
                        return entity.Entity.Candidate_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Remark = val;
                    }
                    sec.Properties.push(prop);
                }
            } 

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Contact Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
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
                        return entity.Entity.Candidate_Address1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Address1 = val;
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
                        return entity.Entity.Candidate_Address2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Address2 = val;
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
                        return entity.Entity.Candidate_Postcode;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Postcode = val;
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
                        return entity.Entity.Candidate_City;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_City = val;
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
                        return entity.Entity.Candidate_State;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_State = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Country";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.MarkCompulsary = true;
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
                        element.append(txtPhonePrefix, "&nbsp;",txtPhone);
                    }

                    prop.GetValueDelegate = function (entity) {
                        txtPhonePrefix.val(entity.Entity.Candidate_PhonePrefix);
                        txtPhone.val(entity.Entity.Candidate_PhoneNumber);
                        return [entity.Entity.Candidate_PhonePrefix, entity.Entity.Candidate_PhoneNumber];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_PhonePrefix = txtPhonePrefix.val();
                        entity.Entity.Candidate_PhoneNumber = txtPhone.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
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
                    }

                    prop.GetValueDelegate = function (entity) {
                        txtPrefix.val(entity.Entity.Candidate_MobilePhonePrefix);
                        txtMobile.val(entity.Entity.Candidate_MobilePhoneNumber);
                        return [entity.Entity.Candidate_MobilePhonePrefix, entity.Entity.Candidate_MobilePhoneNumber];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_PhonePrefix = txtPrefix.val();
                        entity.Entity.Candidate_MobilePhoneNumber = txtMobile.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
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
                        return entity.Entity.Candidate_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Email = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Academic Information";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Preferred Qualification";
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.checkboxList({
                            columns: 1,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                        jqQualification = element;
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedCourse;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SelectedCourse = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Education History";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selLevel1, "&nbsp;&nbsp;&nbsp;", selField1);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selLevel1.val(entity.Entity.Candidate_EducationLevel1);
                        selField1.val(entity.Entity.Candidate_FieldOfStudy1);
                        
                        return [entity.Entity.Candidate_EducationLevel1, entity.Entity.Candidate_FieldOfStudy1];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EducationLevel1 = selLevel1.val();
                        entity.Entity.Candidate_FieldOfStudy1 = selField1.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selLevel2, "&nbsp;&nbsp;&nbsp;", selField2);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selLevel2.val(entity.Entity.Candidate_EducationLevel2);
                        selField2.val(entity.Entity.Candidate_FieldOfStudy2);

                        return [entity.Entity.Candidate_EducationLevel2, entity.Entity.Candidate_FieldOfStudy2];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EducationLevel2 = selLevel2.val();
                        entity.Entity.Candidate_FieldOfStudy2 = selField2.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selLevel3, "&nbsp;&nbsp;&nbsp;", selField3);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selLevel3.val(entity.Entity.Candidate_EducationLevel3);
                        selField3.val(entity.Entity.Candidate_FieldOfStudy3);

                        return [entity.Entity.Candidate_EducationLevel3, entity.Entity.Candidate_FieldOfStudy3];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EducationLevel3 = selLevel3.val();
                        entity.Entity.Candidate_FieldOfStudy3 = selField3.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selLevel4, "&nbsp;&nbsp;&nbsp;", selField4);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selLevel4.val(entity.Entity.Candidate_EducationLevel4);
                        selField4.val(entity.Entity.Candidate_FieldOfStudy4);

                        return [entity.Entity.Candidate_EducationLevel4, entity.Entity.Candidate_FieldOfStudy4];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EducationLevel4 = selLevel4.val();
                        entity.Entity.Candidate_FieldOfStudy4 = selField4.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyseperator");
                        element.append(selLevel5, "&nbsp;&nbsp;&nbsp;", selField5);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selLevel5.val(entity.Entity.Candidate_EducationLevel5);
                        selField5.val(entity.Entity.Candidate_FieldOfStudy5);

                        return [entity.Entity.Candidate_EducationLevel5, entity.Entity.Candidate_FieldOfStudy5];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EducationLevel5 = selLevel5.val();
                        entity.Entity.Candidate_FieldOfStudy5 = selField5.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Pursuing Highest Level of Education";
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
                        //return entity.Entity.Candidate_CurrentlyPursuingHighestLevel;
                        if (entity.Entity.Candidate_CurrentlyPursuingHighestLevel) return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        
                        if (val == 1)
                        { entity.Entity.Candidate_CurrentlyPursuingHighestLevel = true; }
                        else
                        { entity.Entity.Candidate_CurrentlyPursuingHighestLevel = false; }
                    }
                    sec.Properties.push(prop);
                }
                {
                    var newOptions = {
                        "Australia": "Australia",
                        "Malaysia": "Malaysia",
                        "New Zealand": "New Zealand",
                        "Singapore": "Singapore",
                        "UK": "United Kingdom",
                        "Others": "Others"
                    };

                    var prop = new teq.EntityProperty();
                    prop.Label = "Highest Education Country";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.MarkCompulsary = false;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            choices: newOptions
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_StudyCountry;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_StudyCountry = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Highest Education Branch";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_HighestEducation;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_HighestEducation = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Parent/Guardian Information";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's Name";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_FatherGuardianName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FatherGuardianName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Identification Number";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_FatherGuardianIC;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FatherGuardianIC = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Occupation";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_FatherGuardianTypeOfOccupation;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FatherGuardianTypeOfOccupation = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Employer's Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_FatherGuardianEmployerName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FatherGuardianEmployerName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Monthly Income";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_FatherIncome;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_FatherIncome = parseFloat(val);
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's Name";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_MotherGuardianName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MotherGuardianName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Identification Number";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_MotherGuardianIC;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MotherGuardianIC = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Occupation";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_MotherGuardianTypeOfOccupation;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MotherGuardianTypeOfOccupation = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Employer's Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_MotherGuardianEmployerName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MotherGuardianEmployerName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Monthly Income";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_MotherIncome;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MotherIncome = parseFloat(val);
                    }
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Additional Information";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Bank Name";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_BankName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_BankName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Bank Account No.";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_BankAccountNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_BankAccountNumber = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Primary Emergency Contact Person";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactName1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactName1 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactNumber1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactNumber1 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Relationship";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactRelationship1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactRelationship1 = val;
                    }
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Secondary Emergency Contact Person";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactName2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactName2 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactNumber2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactNumber2 = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Relationship";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_EmergencyContactRelationship2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_EmergencyContactRelationship2 = val;
                    }
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }
    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 400;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            RegistrationListingAjaxGateway.NewImport(function (res) {
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
            RegistrationListingAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Registration List";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

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
