local.FinalisedCandidatePageController = function (idPrefix) {

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
    var btnSendLO = "#" + idPrefix + "_btnSendLO";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";
    var tbody;

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchFinalisedApplicationStatus = "#" + idPrefix + "_selSearchFinalisedApplicationStatus";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        $(btnSendLO).button();

        $(btnSendLO).click(function (event) {
            arrItem = [];

            tbody.find('tr').each(function () {
                var row = $(this);
                var chkBox = row.find('input[type="checkbox"]');
                if (typeof chkBox[0] != 'undefined' && chkBox[0].checked) {
                    arrItem.push(chkBox[0].id);
                }
            });
            buildLODataDialog(arrItem);
        });

        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.GenderType
        });

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.ContractType
        });

        $(selSearchFinalisedApplicationStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.FinalisedApplicationStatusType
        });

        BuildSurfaceListing()

        if (!local.ValidatePermission(FlagCodes.PermissionType.FinalizedCandidateEdit)) {
            $(btnSendLO).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }
    }
    this.Activated = Activated;
    function Activated() {

        FinalisedCandidateAjaxGateway.ValidatePermission(FlagCodes.PermissionType.FinalizedCandidateView, function (res) {
            if (res.value != "0") {
                teq.Context.Alert("You do not have sufficient permission to the page you are trying to access.<br />Please contact your system administrator for further information.");
                teq.Context.ShowPage(local.aspxContent_Dashboard1);
            }
        });

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Finalized Candidate List",
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
            var contractType = $(selSearchContractType).val();
            var FinalisedApplicationStatus = $(selSearchFinalisedApplicationStatus).val();
            FinalisedCandidateAjaxGateway.GetFinalisedCandidateList(fullname, gender, email, IC, state, contractType, FinalisedApplicationStatus, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >IC Number</td>");
            htr.append("<td >State</td>");
            htr.append("<td >Mobile Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Reg. Date</td>");
            htr.append("<td >Sponsor</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");
            varCheckBox = $("<input type='checkbox' />");
            varTD = $("<td ></td>");

            varTD.append(varCheckBox);

            htr.append(varTD);

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
        tbody = $(tbdList);
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
                tr.append(("<td align=center>" + dr.Application_MobilePhonePrefix + " - " + dr.Application_MobilePhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.Application_CreatedDate) + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Code + "</td>"));
                tr.append(("<td align=center>" + FlagNames.FinalisedApplicationStatusType[dr.Application_FinalisedStatus] + "</td>"));
                tr.append(buileEditTd(dr));
                if (!local.ValidatePermission(FlagCodes.PermissionType.FinalizedCandidateEdit)) {
                    tr.append("<td></td>");
                }
                else {

                    if (FlagCodes.FinalisedApplicationStatusType.Confirmed == dr.Application_FinalisedStatus) {
                        tr.append("<td></td>");
                    }
                    else
                    {
                        tr.append("<td align=center><input type='checkbox' id='" + dr.Application_ID + "' /></td>");
                    }
                   
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
    var Title = "Finalised Candidate Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    if (!local.ValidatePermission(FlagCodes.PermissionType.FinalizedCandidateEdit) || res.value.Application_FinalisedStatus == FlagCodes.FinalisedApplicationStatusType.Confirmed) {
                        $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true)
                                                            .addClass("ui-state-disabled");
                    }
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }
        if (id == null) {
            ctrl.LoadDelegate = function () {
                FinalisedCandidateAjaxGateway.NewFinalisedCandidate(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                FinalisedCandidateAjaxGateway.GetFinalisedCandidate(id, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            FinalisedCandidateAjaxGateway.SaveFinalisedCandidate(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                }
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Application";
            if (entity.Application_ID != GuidEmpty) title = "Editing \"" + entity.Application_FullName + "\"";
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
            grp.Name = "Personal Data";
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
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "D.O.B";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return teq.Common.FormatDate(entity.Application_DOB);
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
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
                    }
                    prop.SetValueDelegate = function (entity, val) {
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
                    prop.Label = "Status";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: -1,
                            choices: Enums.FinalisedApplicationStatusType
                        });
                       // jqStatus = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_FinalisedStatus;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Application_FinalisedStatus = val;
                    }
                    sec.Properties.push(prop);
                }
            }
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Contact Data";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Address1;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Address2;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Postcode";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Postcode;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "City";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_City;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "State";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_State;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Country";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Country;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var txtPhonePrefix = $("<input type='text' style=\"width:40px; padding: 3px 6px; margin-bottom:3px;\" />");
                    var txtPhone = $("<input type='text' style=\"width:191px; padding: 3px 6px; margin-bottom:3px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPhonePrefix, "&nbsp;", txtPhone);
                    }
                    prop.GetValueDelegate = function (entity) {
                        txtPhonePrefix.val(entity.Application_PhonePrefix);
                        txtPhone.val(entity.Application_PhoneNumber);
                        return entity.Application_PhonePrefix, entity.Application_PhoneNumber;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var txtPrefix = $("<input type='text' style=\"width:40px; padding: 3px 6px; margin-bottom:3px;\" />");
                    var txtMobile = $("<input type='text' style=\"width:191px; padding: 3px 6px; margin-bottom:3px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Number";
                    // prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPrefix, "&nbsp;", txtMobile);
                    };
                    prop.GetValueDelegate = function (entity) {
                        txtPrefix.val(entity.Application_MobilePhonePrefix);
                        txtMobile.val(entity.Application_MobilePhoneNumber);
                        return entity.Application_MobilePhonePrefix, entity.Application_MobilePhoneNumber;
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
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                    }
                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.Initialize();
    }

    function buildLODataDialog(ApplicationIDs) {
        var msg = "Letter of Offer will be sent to all " + ApplicationIDs.length + " candidates. Proceed?";
        teq.Context.Confirm(msg, function () {

            FinalisedCandidateAjaxGateway.SendLO(ApplicationIDs, function (res) {
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

}