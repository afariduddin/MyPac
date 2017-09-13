
local.ChangePasswordPageController = function (idPrefix) {

    var self = this;
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSave = "#" + idPrefix + "_btnSave";
    var txtCurrentPassword = "#" + idPrefix + "_txtCurrentPassword";
    var txtNewPassword = "#" + idPrefix + "_txtNewPassword";
    var txtConfirmPassword = "#" + idPrefix + "_txtConfirmPassword";

    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        $(btnSave).button();

        $(btnSave).click(function (event) {
            var CurrentPassword = $('#txtCurrentPassword');
            var NewPassword = $('#txtNewPassword');
            var ConfirmPassword = $('#txtConfirmPassword');

            ChangePasswordAjaxGateway.SavePassword($(txtCurrentPassword).val(), $(txtNewPassword).val(), $(txtConfirmPassword).val(), function (res) {
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

        BuildPageContent()
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

        //var inputWidth = "400px";
        //ctrl = new teq.EntityPropertiesFormController();

        //ctrl.SaveDelegate = function (entity, callback) {
        //    ChangePasswordAjaxGateway.SavePassword(entity, function (res) {
        //        callback(res);
        //        if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
        //    });
        //};
        //ctrl.SaveSuccessDelegate = function () {
        //    teq.Context.ToastTape("Record saved successfully.");
        //}


        ////#region Group: Advance
        //{
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Change Password";
        //    ctrl.Groups.push(grp);
        //    //#region Section: Another Section
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        sec.Name = "";
        //        sec.Description = "";
        //        grp.Sections.push(sec);
        //        //#region Field: Full Name
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Current Password";
        //            prop.Input = new teq.EntityTextboxPasswordInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.width(inputWidth);
        //                element.attr("password", "");
        //            }
        //            prop.GetValueDelegate = function (entity) {
        //                //return entity.CurrentPassword;
        //            }
        //            prop.SetValueDelegate = function (entity, val) {
        //                entity.CurrentPassword = val;
        //            }
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: User ID
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "New Password";
        //            prop.Input = new teq.EntityTextboxPasswordInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.width(inputWidth);
        //                element.attr("maxlength", "30");
        //                element.attr("password", "");
        //            }
        //            prop.GetValueDelegate = function (entity) {
        //                //return entity.NewPassword;
        //            }
        //            prop.SetValueDelegate = function (entity, val) {
        //                entity.NewPassword = val;
        //            }
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: User ID
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Confirm Password";
        //            prop.Input = new teq.EntityTextboxPasswordInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.width(inputWidth);
        //                element.attr("password", "");
        //            }
        //            prop.GetValueDelegate = function (entity) {
        //                //return entity.ConfirmPassword;
        //            }
        //            prop.SetValueDelegate = function (entity, val) {
        //                entity.ConfirmPassword = val;
        //            }
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //    }
        //}

        //ctrl.BuildLayout($(divProperty));
        //ctrl.Populate(null);

    }
}