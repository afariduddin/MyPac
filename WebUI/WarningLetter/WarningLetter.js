local.WarningLetterPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnNew = "#" + idPrefix + "_btnNew";
    var btnShowTemplateAttribute = "#" + idPrefix + "_btnShowTemplateAttribute";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var txtSearchWarningLetterName = "#" + idPrefix + "_txtSearchWarningLetterName";

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
        if (!local.ValidatePermission(FlagCodes.PermissionType.WarningLetterTemplateSetting)) {
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
            Name: "Warning Letter Template Setting",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        $(btnShowTemplateAttribute).button({
            icons: { primary: "ui-button-icon-secondary ui-icon ui-icon-newwin" }
        });

        $(btnShowTemplateAttribute).click(function (event) {
            //teq.Context.Alert("Viewing Template Attributes.");
            buildTemplateAttributeDialog();
            //event.stopPropagation();
        });
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

            var name = $(txtSearchWarningLetterName).val();

            WarningLetterAjaxGateway.GetWarningLetterList(name, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No.</td>");
            htr.append("<td >Template Name</td>");
            htr.append("<td >Created Date</td>");
            htr.append("<td >Created By</td>");
            htr.append("<td >Updated Date</td>");
            htr.append("<td >Updated By</td>");
            htr.append("<td  width='200px'>View</td>");
            //htr.append("<td>Action</td>");

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
                tr.append(("<td align=center>" + dr.WarningLetter_Name + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.WarningLetter_CreatedDate) + "</td>"));
                tr.append(("<td align=center>" + dr.WarningLetter_CreatedBy + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.WarningLetter_UpdatedDate) + "</td>"));
                tr.append(("<td align=center>" + dr.WarningLetter_UpdatedBy + "</td>"));
                tr.append(buileEditTd(dr));
                //tr.append(buileActionTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.WarningLetter_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteWarningLetter(dr.WarningLetter_ID, dr.WarningLetter_Name);
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

    var Title = 'Email Template Setting';
    self.Title = Title;

    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450

        if (id == null) {
            ctrl.LoadDelegate = function () {
                WarningLetterAjaxGateway.NewWarningLetter(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                WarningLetterAjaxGateway.GetWarningLetter(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected warning letter template no longer exists.");
                            ctrl.Close();
                        }
                        else ctrl.Populate(res.value);
                    }
                    else ctrl.Close();
                });
            }
        }
        ctrl.SaveDelegate = function (entity, callback) {
            WarningLetterAjaxGateway.SaveWarningLetter(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create New Warning Letter Template";
            if (entity.WarningLetter_ID != GuidEmpty) title = "Editing \"" + entity.WarningLetter_Name + "\"";
            return title;
        };

        {
            var inputWidth = "200px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Warning Letter Template Detail ";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Template Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WarningLetter_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WarningLetter_Name = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Template Subject";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WarningLetter_Subject;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WarningLetter_Subject = val;
                    }
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Template Content";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.css("border", "solid 1px #AAAAAA");
                        element.css("padding", "3px");
                        element.html("<b>rich</b> <i>text</i> <u>enabled</u> content. Click to edit.");
                        teq.Common.BuildInlineCKEditor(element, local.GetTextOnlyCKConfig());
                    }
                    prop.Input.CollectContentDelegate = function (element) {
                        return element.html();
                    }
                    prop.Input.PopulateContentDelegate = function (val, element) {
                        element.html(val);
                    }
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        return entity.WarningLetter_Body;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WarningLetter_Body = val;
                    }
                    prop.ValidationDelegate = null;
                    //sec.Grids[1][0].Property = prop;
                    //sec.Grids[1][0].ColSpan = 5;
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }

    var tblBodyTemplateAttribute = $("<tbody>");
    function buildTemplateAttributeDialog() {
        var prop = $("<div title='Template Attributes'>");

        var divListTemplateAttribute = $("<div>");
        var divWrapTemplateAttribute = $("<div class='Wrap' style='width:99%;'>");
        var tblListTemplateAttribute = $("<table class='List'>");
        var tblHeaderTemplateAttribute = $("<thead>");
        var tblPagerTemplateAttribute = $("<table class='Pager'>");

        tblListTemplateAttribute.append(tblHeaderTemplateAttribute);
        tblListTemplateAttribute.append(tblBodyTemplateAttribute);
        divWrapTemplateAttribute.append(tblListTemplateAttribute);
        divWrapTemplateAttribute.append(tblPagerTemplateAttribute);
        divListTemplateAttribute.append(divWrapTemplateAttribute);

        prop.append(divListTemplateAttribute);

        var ctd = $("<div style='width:100%', text-align='center'; ></div>");
        ctd.append("<span><b>Note 1</b>: Only the following pre-defined attributes can be detected by the system.</span><br>");
        ctd.append("<span><b>Note 2</b>: Please include curly brackets {} to represent specified attribute. Eg: {attribute}.</span>");
        ctd.append("<br><br>");
        ctd.append("<table style='width:100%', text-align='center';><tr><td><b>Template Attribute</b></td><td><b>Descriptions</b></td></tr>"
            + "<tr><td>{FullName}</td><td>This field will be replaced with actual recipient name.</td></tr>"
            + "<tr><td>{Sponsor}</td><td>This field is for the recipient sponsor.</td></tr>"
            + "<tr><td>{Course}</td><td>This field is for the recipient current taken course.</td></tr>"
            + "<tr><td>{TSP}</td><td>This field will be replaced with course TSP.</td></tr>"
            + "</table>"
            //+ add in more attributes.
            );
        ctd.append("<br><br>");
        ctd.append("<span><b>Note 3</b>: If you wish to add in more attributes, please contact admin.</span>");

        tblHeaderTemplateAttribute.empty();
        tblHeaderTemplateAttribute.append(ctd);

        prop.dialog();
        prop.dialog("option", "width", 500);
        prop.dialog("option", "height", 400);
        prop.dialog('open');
    }

    this.DeleteWarningLetter = function (id, name) {
        var msg = "Delete Template:<br><br>\"" + name + "\"<br><br>Deleted template cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {

            WarningLetterAjaxGateway.DeleteWarningLetter(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Warning letter template deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }
}