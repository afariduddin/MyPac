
local.CandidateChangeProfilePageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSave = "#" + idPrefix + "_btnSave";
    var divProperty = "#" + idPrefix + "_divProperty";

    var SettingType;

    var selLevel1 = $("<select style=\"width:200px; padding: 5px 10px;\" />");
    var selField1 = $("<select style=\"width:326px; padding: 5px 10px;\" />");

    var selLevel2 = $("<select style=\"width:200px; padding: 5px 10px;\" />");
    var selField2 = $("<select style=\"width:326px; padding: 5px 10px;\" />");

    var selLevel3 = $("<select style=\"width:200px; padding: 5px 10px;\" />");
    var selField3 = $("<select style=\"width:326px; padding: 5px 10px;\" />");

    var selLevel4 = $("<select style=\"width:200px; padding: 5px 10px;\" />");
    var selField4 = $("<select style=\"width:326px; padding: 5px 10px;\" />");

    var selLevel5 = $("<select style=\"width:200px; padding: 5px 10px;\" />");
    var selField5 = $("<select style=\"width:326px; padding: 5px 10px;\" />");

    var txtEthnicity = $("<input style=\"width:300px; padding:5px 10px 5px 10px;\" />");

    var selCountry = $("<select style=\"width:324px; padding:5px 10px 5px 10px;\" />");
    var txtBranch = $("<input style=\"width:300px; padding:5px 10px 5px 10px;\" />");

    this.Initialize = Initialize;
    function Initialize() {
        $(txtEthnicity).attr("list", "dtEthnicity");


        var newOptions = {
            "Australia": "Australia",
            "Malaysia": "Malaysia",
            "New Zealand": "New Zealand",
            "Singapore": "Singapore",
            "UK": "United Kingdom",
            "Others": "Others"
        };
        selCountry.dropdownSelect({
            choices: newOptions
        });


        $(selCountry).change(function () {
            $(txtBranch).attr("list", "dt" + $(selCountry).val() + "University");
        });

        $(btnSave).button();
        $(btnSave).click(function (event) {
            event.preventDefault();
            ctrl.Save();
        });

        BuildPageContent();
    }

    this.Activated = Activated;
    function Activated() {
        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_CandidateDashboard1
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

    this.Shown = function () {
    }
    
    function BuildPageContent() {
        var inputWidth = "400px";
        ctrl = new teq.EntityPropertiesFormController();
        ctrl.SaveDelegate = function (entity, callback) {
            CandidateChangeProfileAjaxGateway.SaveCandidate(entity, function (res) {
                callback(res);
            });
        };
        ctrl.SaveSuccessDelegate = function () {
            teq.Context.ToastTape("Record saved successfully.");
        }

        var jqQualification = null;
        var jqSector = null;
        var jqPosition = null;
        var jqCountry = null;
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Personal Information";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                sec.Description = "";
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "User ID";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform propertyseperator");
                        element.attr("maxlength", "30");
                        element.attr("readonly", "");
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_UserID;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_UserID = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.MarkCompulsary = true;
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }
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
                    prop.Label = "IC Number (without dash)";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                        element.attr("maxlength", "30");
                    }
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
                    prop.Label = "Date of Birth";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform standardformgap");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                    }
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Candidate_DOB;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_DOB = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Nationality";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
                        element.radioButtonList({
                            choices: Enums.NationalityType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
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
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
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
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
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
                        if (entity.Entity.Candidate_IsBumiputra)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == FlagCodes.YesNoType.Yes)
                            entity.Entity.Candidate_IsBumiputra = true;
                        else
                            entity.Entity.Candidate_IsBumiputra = false;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Ethnicity";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform standardformgap");
                        element.append(txtEthnicity);
                    }
                    prop.GetValueDelegate = function (entity) {
                        txtEthnicity.val(entity.Entity.Candidate_OtherEthnicity);

                        return [entity.Entity.Candidate_OtherEthnicity];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_OtherEthnicity = txtEthnicity.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Currently Employed";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
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
                        if (entity.Entity.Candidate_CurrentlyEmployed)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == FlagCodes.YesNoType.Yes)
                            entity.Entity.Candidate_CurrentlyEmployed = true;
                        else
                            entity.Entity.Candidate_CurrentlyEmployed = false;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Sector";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
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
                        element.addClass("standardform");
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: ""
                        });
                        jqPosition = element;
                    };
                    prop.GetValueDelegate = function (entity) {
                        //alert(entity.Entity.Candidate_Position);
                        return entity.Entity.Candidate_Position;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_Position = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Contact Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                sec.Description = "";
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address Line 1";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }

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
                    prop.Label = "Address Line 2";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }
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
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }
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
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }
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
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }
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
                        element.addClass("standardform propertyseperator");
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
                    var txtPhonePrefix = $("<input type='text' style=\"width:50px; padding:5px 10px 5px 10px;\" />");
                    var txtPhone = $("<input type='text' style=\"width:215px; padding:5px 10px 5px 10px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Phone Number";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPhonePrefix, "&nbsp;-&nbsp;", txtPhone);
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
                    var txtPrefix = $("<input type='text' style=\"width:50px; padding:5px 10px 5px 10px;\" />");
                    var txtMobile = $("<input type='text' style=\"width:215px; padding:5px 10px 5px 10px;\" />");

                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Phone Number";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(txtPrefix, "&nbsp;-&nbsp;", txtMobile);
                    }

                    prop.GetValueDelegate = function (entity) {
                        txtPrefix.val(entity.Entity.Candidate_MobilePhonePrefix);
                        txtMobile.val(entity.Entity.Candidate_MobilePhoneNumber);
                        return [entity.Entity.Candidate_MobilePhonePrefix, entity.Entity.Candidate_MobilePhoneNumber];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_MobilePhonePrefix = txtPrefix.val();
                        entity.Entity.Candidate_MobilePhoneNumber = txtMobile.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                    }

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
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";
                sec.Description = "";
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Preferred Qualification";
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
                        element.checkboxList({
                            columns: 1,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                        jqQualification = element;
                    }
                    prop.AssociatedErrors = [];
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
                        element.addClass("standardformgap");
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
                    prop.Label = "Which Country You Attain Your Highest Education";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform");
                        element.append(selCountry);
                    }
                    prop.GetValueDelegate = function (entity) {
                        selCountry.val(entity.Entity.Candidate_StudyCountry);

                        $(txtBranch).attr("list", "dt" + $(selCountry).val() + "University");

                        return [entity.Entity.Candidate_StudyCountry];
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_StudyCountry = selCountry.val();
                    }
                    prop.AssociatedErrors = [];
                    prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "University / Institution / School - Branch";
                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardform standardformgap");
                        element.append(txtBranch);
                    }
                    prop.GetValueDelegate = function (entity) {
                        txtBranch.val(entity.Entity.Candidate_HighestEducation);

                        return entity.Entity.Candidate_HighestEducation;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Candidate_HighestEducation = txtBranch.val();
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Pursuing Highest Level of Education";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("standardformgap");
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
                        if (entity.Entity.Candidate_CurrentlyPursuingHighestLevel)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == FlagCodes.YesNoType.Yes)
                            entity.Entity.Candidate_CurrentlyPursuingHighestLevel = true;
                        else
                            entity.Entity.Candidate_CurrentlyPursuingHighestLevel = false;
                    }
                    sec.Properties.push(prop);
                }
            }
            {

                var grp = new teq.EntityPropertiesGroup();
                grp.Name = "Parent/Guardian Information";
                ctrl.Groups.push(grp);
                {
                    var sec = new teq.EntityPropertiesFormSection();
                    sec.Name = "";
                    grp.Sections.push(sec);
                    {  
                        {
                            var prop = new teq.EntityProperty();
                            prop.Label = "Father's Name";
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                                element.attr("placeholder", "601012081234");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform propertyseperator");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
                            prop.GetValueDelegate = function (entity) {
                                //  return entity.Entity.Field1;
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                                element.attr("placeholder", "651230081234");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
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
                            prop.Input = new teq.EntityTextboxInput();
                            prop.Input.BuildElementDelegate = function (element) {
                                element.addClass("standardform");
                            }
                            prop.GetValueDelegate = function (entity) {
                                return entity.Entity.Candidate_MotherIncome;
                            }
                            prop.SetValueDelegate = function (entity, val) {
                                entity.Entity.Candidate_MotherIncome = parseFloat(val);
                            }
                            sec.Properties.push(prop);
                        }
                    }
                }
            }
            {
                var grp = new teq.EntityPropertiesGroup();
                grp.Name = "Additional Information";
                ctrl.Groups.push(grp);
                {
                    var sec = new teq.EntityPropertiesFormSection();
                    sec.Name = "";
                    grp.Sections.push(sec);

                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Bank Name";
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
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
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform propertyseperator");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
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
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
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
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
                            return entity.Entity.Candidate_EmergencyContactNumber1;
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Entity.Candidate_EmergencyContactNumber1 = val;
                        }
                        sec.Properties.push(prop);
                    }
                    //{
                    //    var prop = new teq.EntityProperty();
                    //    prop.Label = "Contact Number";
                    //    prop.Input = new teq.EntityTextboxInput();
                    //    prop.Input.BuildElementDelegate = function (element) {
                    //        element.width(inputWidth);
                    //        //element.attr("maxlength", "30");
                    //    }
                    //    prop.GetValueDelegate = function (entity) {
                    //        //  return entity.Entity.Field1;
                    //        return entity.Entity.Candidate_EmergencyContactNumber1Alternative;
                    //    }
                    //    prop.SetValueDelegate = function (entity, val) {
                    //        entity.Entity.Candidate_EmergencyContactNumber1Alternative = val;
                    //    }
                    //    sec.Properties.push(prop);
                    //}
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Relationship";
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
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
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
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
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            return entity.Entity.Candidate_EmergencyContactNumber2;
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Entity.Candidate_EmergencyContactNumber2 = val;
                        }
                        sec.Properties.push(prop);
                    }
                    //{
                    //    var prop = new teq.EntityProperty();
                    //    prop.Label = "Emergency Contact Number 2 (alternate)";
                    //    prop.Input = new teq.EntityTextboxInput();
                    //    prop.Input.BuildElementDelegate = function (element) {
                    //        element.width(inputWidth);
                    //    }
                    //    prop.GetValueDelegate = function (entity) {
                    //        return entity.Entity.Candidate_EmergencyContactNumber2Alternative;
                    //    }
                    //    prop.SetValueDelegate = function (entity, val) {
                    //        entity.Entity.Candidate_EmergencyContactNumber2Alternative = val;
                    //    }
                    //    sec.Properties.push(prop);
                    //}
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Relationship";
                        prop.Input = new teq.EntityTextboxInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("standardform");
                        }
                        prop.GetValueDelegate = function (entity) {
                            //  return entity.Entity.Field1;
                            return entity.Entity.Candidate_EmergencyContactRelationship2;
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Entity.Candidate_EmergencyContactRelationship2 = val;
                        }
                        sec.Properties.push(prop);
                    }
                }
            }
        }
        ctrl.BuildLayout($(divProperty));

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {

                    CandidateChangeProfileAjaxGateway.GetGlobalSetting(FlagCodes.GlobalSettingType.EducationLevel, function (resLevel) {
                        selLevel1.dropdownSelect({
                            nullValue: "",
                            nullLabel: "- Select Level -",
                            choices: teq.Common.DictionaryToArray(resLevel.value)
                        });

                        selLevel2.dropdownSelect({
                            nullValue: "",
                            nullLabel: "- Select Level -",
                            choices: teq.Common.DictionaryToArray(resLevel.value)
                        });

                        selLevel3.dropdownSelect({
                            nullValue: "",
                            nullLabel: "- Select Level -",
                            choices: teq.Common.DictionaryToArray(resLevel.value)
                        });

                        selLevel4.dropdownSelect({
                            nullValue: "",
                            nullLabel: "- Select Level -",
                            choices: teq.Common.DictionaryToArray(resLevel.value)
                        });

                        selLevel5.dropdownSelect({
                            nullValue: "",
                            nullLabel: "- Select Level -",
                            choices: teq.Common.DictionaryToArray(resLevel.value)
                        });


                        CandidateChangeProfileAjaxGateway.GetGlobalSetting(FlagCodes.GlobalSettingType.FieldOfStudy, function (resField) {
                            selField1.dropdownSelect({
                                nullValue: "",
                                nullLabel: "- Select Field of Study -",
                                choices: teq.Common.DictionaryToArray(resField.value)
                            });

                            selField2.dropdownSelect({
                                nullValue: "",
                                nullLabel: "- Select Field of Study -",
                                choices: teq.Common.DictionaryToArray(resField.value)
                            });

                            selField3.dropdownSelect({
                                nullValue: "",
                                nullLabel: "- Select Field of Study -",
                                choices: teq.Common.DictionaryToArray(resField.value)
                            });

                            selField4.dropdownSelect({
                                nullValue: "",
                                nullLabel: "- Select Field of Study -",
                                choices: teq.Common.DictionaryToArray(resField.value)
                            });

                            selField5.dropdownSelect({
                                nullValue: "",
                                nullLabel: "- Select Field of Study -",
                                choices: teq.Common.DictionaryToArray(resField.value)
                            });
                            jqQualification.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value.Course));
                            jqSector.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Sector));
                            jqPosition.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Position));
                            jqCountry.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value.Country));
                            ctrl.Populate(res.value);

                        });
                    });

                  



            
                }
            }
            else ctrl.Close();
        }

        CandidateChangeProfileAjaxGateway.GetCandidate(populateDel);
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "My Profile";
    self.Title = Title;
    //#endregion


}