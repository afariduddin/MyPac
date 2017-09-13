
local.GlobalSettingPageController = function (idPrefix) {

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
        $(divProperty).empty();
        BuildPageContent();
       // alert('Initialize');
    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.GlobalSetting)) {
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
            Name: "Global Setting",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
       // alert('Activated');
    }
    //#endregion

    this.Shown = function () {
       // alert('Shown');
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }
    
    this.PopulateData = PopulateData;

    function PopulateData() {
       // alert('hi');
        $(divProperty).empty();
        BuildPageContent();
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
            grp.Name = "System Global Setting";
            ctrl.Groups.push(grp);
            //#region Section: Another Section
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "Please use ; as separator";
                sec.Description = "";
                grp.Sections.push(sec);
                //#region Field: Full Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Reasons for Deferment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.ReasonsForDeferment;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.ReasonsForDeferment = val;
                    }
                    //sec.Grids[6][0].Property = prop;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Field of Study";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.FieldOfStudy;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.FieldOfStudy = val;
                    }
                    //sec.Grids[6][0].Property = prop;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Education Level";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    //sec.Grids[6][0].Property = prop;
                    prop.GetValueDelegate = function (entity) {
                        return entity.EducationLevel;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.EducationLevel = val;
                    }
                    sec.Properties.push(prop);
                }
                //{
                //    var prop = new teq.EntityProperty();
                //    prop.Label = "Preferred Location";

                //    //prop.MarkCompulsary = true;
                //    prop.Input = new teq.EntityTextareaInput();
                //    prop.Input.BuildElementDelegate = function (element) {
                //        element.width("400px");
                //        element.height("80px");
                //    };
                //    //sec.Grids[6][0].Property = prop;
                //    prop.GetValueDelegate = function (entity) {
                //        return entity.PreferredLocation;
                //    }
                //    prop.SetValueDelegate = function (entity, val) {
                //        entity.PreferredLocation = val;
                //    }
                //    sec.Properties.push(prop);
                //}
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Sector";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    //sec.Grids[6][0].Property = prop;
                    prop.GetValueDelegate = function (entity) {
                        return entity.Sector;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Sector = val;
                    }
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Position";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    //sec.Grids[6][0].Property = prop;
                    prop.GetValueDelegate = function (entity) {
                        return entity.Position;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Position = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Level Start";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.width("400px");
                        element.height("80px");
                    };
                    //sec.Grids[6][0].Property = prop;
                    prop.GetValueDelegate = function (entity) {
                        return entity.PQLevelStart;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.PQLevelStart = val;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

            }
            //#endregion
        }
        //#endregion

        ctrl.BuildLayout($(divProperty));
        //teq.Common.SetDefaultButton($(divProperty), $(btnSave));
        //ctrl.Populate();
        // ctrl.Initialize();

        //ctrl.LoadDelegate = function () {
        //    alert('loading...');
        //    GlobalSettingManagementAjaxGateway.GetGlobalSetting(populateDel);
        //}
        var populateDel = function (res) {
          //  alert('loading...');
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    //ctrl.Close();
                }
                else {
                    //   alert('loading...');
                    //alert(res.value);
                    ctrl.Populate(res.value);
                }
            }
            else; //ctrl.Close();
        }

        GlobalSettingManagementAjaxGateway.GetGlobalSetting(populateDel);

     
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "Global Setting";
    self.Title = Title;
    //#endregion


}