local.CandidateChangePasswordPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSave = "#" + idPrefix + "_btnSave";
    var divProperty = "#" + idPrefix + "_divProperty";
    var txtCurrentPassword = "#" + idPrefix + "_txtCurrentPassword";
    var txtNewPassword = "#" + idPrefix + "_txtNewPassword";
    var txtConfirmPassword = "#" + idPrefix + "_txtConfirmPassword";


    this.Initialize = Initialize;
    function Initialize() {
        $(btnSave).button();
        //$(btnSave).click(function (event) {
        //    event.preventDefault();
        //    ctrl.Save();
        //});
        // BuildPageContent()
        $(btnSave).click(function (event) {
            //var CurrentPassword = $('#txtCurrentPassword');
            //var NewPassword = $('#txtNewPassword');
            //var ConfirmPassword = $('#txtConfirmPassword');

           CandidateChangePasswordAjaxGateway.SavePassword($(txtCurrentPassword).val(), $(txtNewPassword).val(), $(txtConfirmPassword).val(), function (res) {
            //CandidateChangePasswordAjaxGateway.SavePassword($(txtCurrentPassword).val(), function (res) {
            if (res.value.length == 0) {
                    teq.Context.ToastTape("Password updated successfully.");
                }
                else {
                    var errMessage = "";
                    for (var x = 0; x < res.value.length; x++) {
                        if (x > 0)
                            errMessage += "<br>";
                        errMessage += res.value[x].Name;
                    }
                    teq.Context.Alert(errMessage, null, function () {
                    });
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {
        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Change Password",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }


    this.Shown = function () {
    }

    function BuildPageContent() {

        var inputWidth = "400px";
        ctrl = new teq.EntityPropertiesFormController();

        ctrl.SaveDelegate = function (entity, callback) {
            GlobalSettingManagementAjaxGateway.SaveGlobalSetting(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.SaveSuccessDelegate = function () {
            teq.Context.ToastTape("Record saved successfully.");
        }
        //#region Group: Advance
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Change Password";
            ctrl.Groups.push(grp);
            //#region Section: Another Section
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                sec.Description = "";
                grp.Sections.push(sec);
                //#region Field: Current Password
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Current Password";
                    prop.Input = new teq.EntityTextboxPasswordInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width(inputWidth);
                        element.attr("password", "");
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: New Password
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "New Password";
                    prop.Input = new teq.EntityTextboxPasswordInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width(inputWidth);
                        element.attr("maxlength", "30");
                        element.attr("password", "");
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Confirm Password
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Confirm Password";
                    prop.Input = new teq.EntityTextboxPasswordInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width(inputWidth);
                        element.attr("password", "");
                    }
                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.BuildLayout($(divProperty));
        ctrl.Populate(null);
    }
}
