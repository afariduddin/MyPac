local.AlumniPageController = function (idPrefix) {
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

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing()

        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.AlumniView)) {
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
            Name: "Alumni Work History List",
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
            var state = $(txtSearchState).val();
            AlumniAjaxGateway.GetWorkHistoryListing(fullname, gender, email, IC, state, order.Columns, order.Directions, pg, function (res) {
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
            htr.append("<td >Mobile</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Start Date</td>");
            htr.append("<td >Resign Date</td>");
            htr.append("<td >Job Title</td>");
            htr.append("<td >Company</td>");
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
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_State + "</td>"));
                tr.append(("<td align=center>" + dr.Application_PhonePrefix + "-" + dr.Application_PhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_MobilePhonePrefix + "-" + dr.Application_MobilePhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.WorkHistory_StartDate) + "</td>"));
                var ResignDate;
                if (teq.Common.FormatDate(dr.WorkHistory_ResignDate) == "1-Jan-1900")
                    ResignDate = "";
                else 
                    ResignDate = teq.Common.FormatDate(dr.WorkHistory_ResignDate)
                tr.append(("<td align=center>" + ResignDate + "</td>"));
                tr.append(("<td align=center>" + dr.WorkHistory_JobTitle + "</td>"));
                tr.append(("<td align=center>" + dr.WorkHistory_CompanyName + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.WorkHistory_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);
                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Alumni Work History Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                AlumniAjaxGateway.NewWorkHistory(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                AlumniAjaxGateway.GetWorkHistory(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {

                            if (!local.ValidatePermission(FlagCodes.PermissionType.AlumniEdit)){  
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }

                            ctrl.Populate(res.value);
                        }
                    }
                    else ctrl.Close();
                });
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            AlumniAjaxGateway.SaveWorkHistory(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            //var title = self.Title + " - " + edit;
            //return title;
            var title = "Create Assessment Session";
            if (entity.AssessmentSession_ID != GuidEmpty) title = "Editing \"" + entity.WorkHistory_JobTitle + "\"";
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
            grp.Name = "Application Detail";
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
                    prop.Label = "IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_IdentificationNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
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
                        return entity.Application_DOB;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Application_DOB = val;
                    }
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
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
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
                        return entity.Application_PhonePrefix + "-" + entity.Application_PhoneNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
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
                        return entity.Application_MobilePhonePrefix + "-" + entity.Application_MobilePhoneNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
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
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Job Title";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_JobTitle;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_JobTitle = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Company";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_CompanyName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_CompanyName = val;
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
                        return entity.WorkHistory_Description;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_Description = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Start Date";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_StartDate;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_StartDate = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Reisgn Date";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        if (teq.Common.FormatDate(entity.WorkHistory_ResignDate) == "1-Jan-1900") {
                            return "";
                        }
                        else return entity.WorkHistory_ResignDate;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == null) {
                            entity.WorkHistory_ResignDate = "1900-01-01 00:00:00.000";
                        }
                        else entity.WorkHistory_ResignDate = val;
                    }
                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.Initialize();
    }
}