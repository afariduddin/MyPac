
local.ChangeProfilePageController = function (idPrefix) {

    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSave = "#" + idPrefix + "_btnSave";
    var divProperty = "#" + idPrefix + "_divProperty";
    //var btnNew = "#" + idPrefix + "_btnNew";

    var SettingType;

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {
        $(btnSave).button();
        $(btnSave).click(function (event) {
            event.preventDefault();
            ctrl.Save();
        });
        BuildPageContent()
    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "My Profile",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }
    //#endregion

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }

    function BuildPageContent() {

        var inputWidth = "250px";
        ctrl = new teq.EntityPropertiesFormController();

        ctrl.SaveDelegate = function (entity, callback) {
            ChangeProfileAjaxGateway.SaveUserAccount(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.SaveSuccessDelegate = function () {
            teq.Context.ToastTape("Profile updated successfully.");
        }

        //#region Group: Advance
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "My Profile";
            ctrl.Groups.push(grp);
            //#region Section: Another Section
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                sec.Description = "";
                grp.Sections.push(sec);
                //#region Field: Full Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_FullName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_FullName = val;
                    }
                    sec.Properties.push(prop);
                }

                //#region Field: User ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "User ID";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.attr("maxlength", "30");
                        element.attr("readonly", "");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_UserID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_UserID = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Email
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_Email;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_Email = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Contact Number
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserAccount_Contact;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserAccount_Contact = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: User Group
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "User Group";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.attr("readonly", "");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.UserGroup_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UserGroup_Name = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion
            }
            //#endregion
        }
        //#endregion

        ctrl.BuildLayout($(divProperty));

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }

        ChangeProfileAjaxGateway.GetUserAccount(populateDel);
    }
    //#endregion
}