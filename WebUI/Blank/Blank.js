/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.BlankPageController = function (idPrefix)
{
    //#region Initialize
    this.Initialize = Initialize;
    function Initialize()
    {

    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {

        local.AdvancedSearchMode = null;

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Blank1
        };


        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

    }
    //#endregion
}