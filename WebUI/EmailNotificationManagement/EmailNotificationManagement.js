local.EmailNotificationManagementPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    //var btnImport = "#" + idPrefix + "_btnImport";
    //var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    //var btnExport = "#" + idPrefix + "_btnDownloadExcel";
    
    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var txtSearchRecipient = "#" + idPrefix + "_txtSearchRecipient";
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";
    var txtSearchSubject = "#" + idPrefix + "_txtSearchSubject";
    var dtpSearchCreatedFrom = "#" + idPrefix + "_dtpSearchCreatedFrom";
    var dtpSearchCreatedTo = "#" + idPrefix + "_dtpSearchCreatedTo";
    
    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing();

        $(dtpSearchCreatedFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(dtpSearchCreatedFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(dtpSearchCreatedTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(dtpSearchCreatedTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));
       
        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.EmailNotificationStatusType
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.EmailNotificationManagement)) {
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
            Name: "Email Notification Management",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        //$(btnExport).button({
        //    icons: { primary: "ui-icon-arrowthickstop-1-s" }
        //}).attr('disabled', true);
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

            var emailRecipient = $(txtSearchRecipient).val();
            var emailStatus = $(selSearchStatus).val();
            var emailSubject = $(txtSearchSubject).val();
            var dtCreatedfrom = $(dtpSearchCreatedFrom).val() == "" ? null : $(dtpSearchCreatedFrom).val();
            var dtCreatedto = $(dtpSearchCreatedTo).val() == "" ? null : $(dtpSearchCreatedTo).val();

            if (dtCreatedfrom == null || dtCreatedto == null) {
                teq.Context.Alert("<b>Created Date Range</b> cannot be blank.");
                return false;
            }

            EmailNotificationManagementAjaxGateway.GetEmailNotificationListing(dtCreatedfrom, dtCreatedto, emailRecipient, emailStatus, emailSubject, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Recipient</td>");
            htr.append("<td >Subject</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >Sent Retry Count</td>");
            htr.append("<td >Created Date</td>");
            
            //htr.append("<td >View</td>");
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
                tr.append(("<td align=center>" + dr.EmailNotification_Recipient + "</td>"));
                tr.append(("<td align=center>" + dr.EmailNotification_Subject + "</td>"));
                tr.append(("<td align=center>" + FlagNames.EmailNotificationStatusType[dr.EmailNotification_Status] + "</td>"));
                tr.append(("<td align=center>" + dr.EmailNotification_RetryCount + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.EmailNotification_CreatedDate) + "</td>"));
                //tr.append(buileEditTd(dr));
                tr.append(buileActionTd(dr));
                tbody.append(tr);
            }

            //function buileEditTd(dr) {
            //    var actionTd = $("<td align=center/>");

            //    var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
            //    editLnk.click(function (event) {
            //        buildSurfaceDataDialog(dr.EmailNotification_ID);
            //        event.stopPropagation();
            //    });
            //    actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

            //    var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
            //    delLnk.click(function (event) {
            //        event.stopPropagation();
            //        self.DeleteRecord(dr.EmailNotification_ID, dr.EmailNotification_Recipient);
            //    });
            //    actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

            //    return actionTd;
            //}

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Reset Retry Count</a>");
                editLnk.click(function (event) {
                    buildResetRetryCountDataDialog(dr.EmailNotification_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "refresh"), editLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    //var Title = "Email Notification Detail Detail";
    //self.Title = Title;

    //function buildSurfaceDataDialog(id) {
    //    var ctrl = new teq.EntityPropertiesDialogController();
    //    ctrl.DialogWidth = 400;

    //    if (id == null) {
    //        ctrl.LoadDelegate = function () {
    //            EmailNotificationManagementAjaxGateway.NewEmailNotification(function (res) {
    //                if (res.error == null) ctrl.Populate(res.value);
    //                else ctrl.Close();
    //            });
    //        }
    //    }
    //    else {
    //        ctrl.LoadDelegate = function () {
    //            EmailNotificationManagementAjaxGateway.GetEmailNotification(id, function (res) {
    //                if (res.error == null) {
    //                    if (res.value == null) {
    //                        teq.Context.Alert("Selected record no longer exists.");
    //                        ctrl.Close();
    //                    }
    //                    else {
    //                        ctrl.Populate(res.value);
    //                    }
    //                }
    //                else ctrl.Close();
    //            });
    //        }
    //    }
    //    ctrl.SaveDelegate = function (entity, callback) {
    //        EmailNotificationManagementAjaxGateway.SaveEmailNotification(entity, function (res) {
    //            callback(res);
    //            if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
    //        });
    //    };
    //    ctrl.GetTitleDelegate = function (entity) {
    //        var title = "Create Email Notification";
    //        if (entity.EmailNotification_ID != GuidEmpty) title = "Editing \"" + entity.EmailNotification_Recipient + "\"";
    //        return title;
    //    };

    //    function Enums_GetLabel(key) {
    //        if (key == null) return '';
    //        else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
    //        else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
    //        else return '';
    //    }

    //    {
    //        var inputWidth = "200px";
    //        var inputWidthShort = "50px";
    //        var inputWidthTruncate = "150px";

    //        var grp = new teq.EntityPropertiesGroup();
    //        grp.Name = "Email Notification Detail";
    //        ctrl.Groups.push(grp);
    //        ctrl.DialogWidth = 500;
    //        {
    //            var sec = new teq.EntityPropertiesFormSection();
    //            sec.Name = "";

    //            grp.Sections.push(sec);

    //            {
    //                var prop = new teq.EntityProperty();
    //                prop.Label = "Recipient";
    //                prop.MarkCompulsary = true;
    //                prop.Input = new teq.EntityTextboxInput();
    //                prop.Input.BuildElementDelegate = function (element) {
    //                    element.width(inputWidth);
    //                };
    //                prop.GetValueDelegate = function (entity) {
    //                    return entity.EmailNotification_Recipient;
    //                }
    //                prop.SetValueDelegate = function (entity, val) {
    //                    entity.EmailNotification_Recipient = val;
    //                }
    //                sec.Properties.push(prop);
    //            }
    //            {
    //                var prop = new teq.EntityProperty();
    //                prop.Label = "Status";
    //                prop.Input = new teq.EntityDropdownSelectInput();
    //                prop.Input.BuildElementDelegate = function (element) {
    //                    element.attr("readonly", "readonly");
    //                    element.dropdownSelect({
    //                        //nullValue: -1,
    //                        //nullLabel: "- Please Select -",
    //                        choices: Enums.EmailNotificationStatusType,
    //                    });
    //                }
    //                prop.AssociatedErrors = [];
    //                prop.GetValueDelegate = function (entity) {
    //                    return entity.EmailNotification_Status;
    //                }
    //                prop.SetValueDelegate = function (entity, val) {
    //                    //entity.EmailNotification_Status = val;
    //                }
    //                sec.Properties.push(prop);
    //            }
    //            {
    //                var prop = new teq.EntityProperty();
    //                prop.Label = "Sent Retry Count";
    //                //prop.MarkCompulsary = true;
    //                prop.Input = new teq.EntityTextboxInput();
    //                prop.Input.BuildElementDelegate = function (element) {
    //                    element.attr("readonly", "readonly");
    //                    element.width(inputWidth);
    //                };
    //                prop.GetValueDelegate = function (entity) {
    //                    return entity.EmailNotification_RetryCount;
    //                }
    //                prop.SetValueDelegate = function (entity, val) {
    //                    //entity.EmailNotification_RetryCount = val;
    //                }
    //                sec.Properties.push(prop);
    //            }
    //            {
    //                var prop = new teq.EntityProperty();
    //                prop.Label = "Email Content";
    //                prop.Input = new teq.EntityCustomInput();
    //                prop.Input.BuildElementDelegate = function (element) {
    //                    element.width("200px");
    //                    element.css("border", "solid 1px #AAAAAA");
    //                    element.css("padding", "3px");
    //                    //element.html("<b>rich</b> <i>text</i> <u>enabled</u> content. Click to edit.");
    //                    teq.Common.BuildInlineCKEditor(element, local.GetTextOnlyCKConfig());
    //                }
    //                prop.Input.CollectContentDelegate = function (element) {
    //                    return element.html();
    //                }
    //                prop.Input.PopulateContentDelegate = function (val, element) {
    //                    element.html(val);
    //                }
    //                prop.AssociatedErrors = [];
    //                prop.GetValueDelegate = function (entity) {
    //                    return entity.EmailNotification_EmailContent;
    //                }
    //                prop.SetValueDelegate = function (entity, val) {
    //                    entity.EmailNotification_EmailContent = val;
    //                }
    //                prop.ValidationDelegate = null;
    //                sec.Properties.push(prop);
    //            }
    //            {
    //                var prop = new teq.EntityProperty();
    //                prop.Label = "Status Message";

    //                //prop.MarkCompulsary = true;
    //                prop.Input = new teq.EntityTextareaInput();
    //                prop.Input.BuildElementDelegate = function (element) {
    //                    element.attr("readonly", "readonly");
    //                    element.width(inputWidth);
    //                };
    //                prop.GetValueDelegate = function (entity) {
    //                    return entity.EmailNotification_StatusMessage;
    //                }
    //                prop.SetValueDelegate = function (entity, val) {
    //                    //entity.EmailNotification_StatusMessage = val;
    //                }
    //                sec.Properties.push(prop);
    //            }
    //        } 
    //    }
    //    ctrl.Initialize();
    //}

    //this.DeleteRecord = function (id, recipient) {
    //        var msg = "Delete email notification to :<br><br>\"" + recipient + "\"<br><br>Are you sure?";
    //        teq.Context.Confirm(msg, function () {
    //            EmailNotificationManagementAjaxGateway.DeleteEmailNotication(id, function (res) {
    //                if (res.error == null) {
    //                    if (res.value.Code == teq.Context.SuccessErrorCode) {
    //                        self.ListControlller.RefreshList();
    //                        teq.Context.ToastTape("The email notification is deleted successfully.");
    //                    }
    //                    else teq.Context.Alert(res.value.Name);
    //                }
    //            });
    //        });
    //}

    function buildResetRetryCountDataDialog(ID) {
        var msg = "This will reset the \"Sent Retry Count\" to 0. Proceed?";
        teq.Context.Confirm(msg, function () {

            EmailNotificationManagementAjaxGateway.ResetRetryCount(ID, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("The retry count had been reset successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
    }
}
