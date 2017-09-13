local.TSPManagementPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnNew = "#" + idPrefix + "_btnNew";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var txtSearchCampusName = "#" + idPrefix + "_txtSearchCampusName";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing()
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.TrainingServiceProviderManagement)) {
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
            Name: "Training Service Provider Management",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }
    function BuildSurfaceListing() {
        self.ListControlller = new teq.EntityListController();

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

        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var name = $(txtSearchCampusName).val();
            TSPManagementAjaxGateway.GetTSPList(name, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Campus Name</td>");
            htr.append("<td >State</td>");
            htr.append("<td >Contact Person</td>");
            htr.append("<td >Contact Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Created By</td>");
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
                tr.append(("<td align=center>" + dr.TSP_CampusName + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_State + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_ContactPerson + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_ContactNumber + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_Email + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_CreatedBy + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.TSP_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.TSP_ID, dr.TSP_CampusName);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Training Service Provider Management";
    self.Title = Title;

    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;

        var jqMonth = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {

                    TSPManagementAjaxGateway.getMonth(function (entMonth) {
                        jqMonth.checkboxList("option", "choices", teq.Common.DictionaryToArray(entMonth.value));
                    });

                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }

        if (id == null) {
            ctrl.LoadDelegate = function () {
                TSPManagementAjaxGateway.NewTSP(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                TSPManagementAjaxGateway.GetTSP(id, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            TSPManagementAjaxGateway.SaveTSP(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Training Service Provider";
            if (entity.TSP_ID != GuidEmpty) title = "Editing \"" + entity.TSP_CampusName + "\"";
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
            grp.Name = "Campus Detail ";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Campus Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_CampusName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_CampusName = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);

                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Address1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Address1 = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();

                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Address2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Address2 = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Postcode";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Postcode;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Postcode = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "City";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_City;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_City = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "State";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();

                   // prop.Input.BuildElementDelegate = null;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.attr('list', 'dtState');
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_State;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_State = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Country";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Country;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Country = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Person";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_ContactPerson;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_ContactPerson = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Email = val;
                    }
                    prop.ValidationDelegate = null;
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
                        return entity.TSP_ContactNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_ContactNumber = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Course Type";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: Enums.CourseType
                        });
                    };
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_CourseType;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_CourseType = val;
                    }
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Available Intake";
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.checkboxList({
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });

                        jqMonth = element;
                    }

                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedMonth;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CheckedMonths = val;
                    }

                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();

                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };

                    prop.GetValueDelegate = function (entity) {
                        return entity.TSP_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.TSP_Remark = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
            }

        }
        ctrl.Initialize();
    }

    this.DeleteRecord = function (id, name) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {

            TSPManagementAjaxGateway.DeleteTSP(id, function (res) {
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