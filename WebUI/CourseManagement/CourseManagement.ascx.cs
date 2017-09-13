using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class CourseManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CourseManagementAjaxGateway));
        AjaxLib.RegisterController("CourseManagement", ClientID);
    }
}
public class CourseManagementAjaxGateway : AjaxGatewayBase
{
    public CourseManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<CourseTable> GetCourseList(string name, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<CourseTable> lis = da.Course.Search(name, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public CourseDialogData NewCourse()
    {
        CourseDialogData ret = new CourseDialogData();

        CourseRow dr = new CourseTable().NewCourseRow();
        ret.Entity = new CourseMinimalizedEntity(dr);

        ret.TSP = GetTSP();
        ret.SelectedTSP = new List<string>();
        return ret;
    }
    [AjaxMethod]
    public CourseDialogData GetCourse(Guid id)
    {
        DA da = new DA();
        CourseRow dr = da.Course.GetByCourse_ID(id);
        if (dr == null) return null;
        else
        {
            CourseDialogData ret = new CourseDialogData();


            ret.Entity = new CourseMinimalizedEntity(dr);

            ret.TSP = GetTSP();

            List<CourseTSPRow> drs = da.CourseTSP.GetByCourse(id);
            ret.SelectedTSP = new List<string>();
            foreach (CourseTSPRow cdr in drs)
            {
                ret.SelectedTSP.Add(cdr.TSP_ID.ToString());
            }
            ret.EntitySubject = GetSubject(id);

            return ret;
        }
    }

    [AjaxMethod]
    public Dictionary<string, string> GetTSP()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<TSPRow> list = da.TSP.GetAll();
        foreach (TSPRow r in list)
        {
            lis.Add(r.TSP_ID.ToString(), r.TSP_CampusName);
        }

        return lis;
    }

    [AjaxMethod]
    public List<CourseSubjectMinimalizedEntity> GetSubject(Guid CourseID)
    {
        List<CourseSubjectMinimalizedEntity> lis = new List<CourseSubjectMinimalizedEntity>();
        DA da = new DA();
        CourseSubjectTable dt = da.CourseSubject.GetAll(CourseID);

        foreach (CourseSubjectRow dr in dt.Rows)
        {
            CourseSubjectMinimalizedEntity l = new CourseSubjectMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }
    
    [AjaxMethod]
    public ErrorCodes[] SaveCourse(CourseDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyCode(ett.Entity.Course_Code));
        AddError(errs, VerifyName(ett.Entity.Course_Name));
        if (ett.Entity.Course_ID == Guid.Empty)
        {
            AddError(errs, VerifyDuplicateCode(ett.Entity.Course_Code));
        }
            
        
        ActionLog log = WebLib.CreateLog((ett.Entity.Course_ID == Guid.Empty ? "Create" : "Modify") + " Course.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            CourseRow dr;
            if (ett.Entity.Course_ID == Guid.Empty)
            {
                dr = new CourseTable().NewCourseRow();
                ett.Entity.Course_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Course_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Course_ID = Guid.NewGuid();
                dr.Course_CreatedDate = DateTime.Now;

            }
            else
            {
                dr = da.Course.GetByCourse_ID(ett.Entity.Course_ID);
                ett.Entity.Course_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Course_UpdatedDate = DateTime.Now;
            }

            da.CourseTSP.DeleteByCourse(ett.Entity.Course_ID);
            CourseTSPTable dtCourseTSP = new CourseTSPTable();

            List<string> selectedTSPs = ett.SelectedTSP;
            foreach (string selectedTSP in selectedTSPs)
            {
                CourseTSPRow drCourseTSP = dtCourseTSP.NewCourseTSPRow();
                drCourseTSP.CourseTSP_ID = Guid.NewGuid();
                drCourseTSP.Course_ID = ett.Entity.Course_ID;
                drCourseTSP.TSP_ID = Guid.Parse(selectedTSP);

                //dtCourseTSP.Rows.Add(drCourseTSP);
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.Entity.CopyTo(dr);
                da.Course.Update(dr,log);
                da.CourseTSP.Update(dtCourseTSP,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
    [AjaxMethod]
    public ErrorCodes VerifyCode(string code)
    {
        if (String.IsNullOrEmpty(code)) return ErrorCodes.Course_Code;
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }
    [AjaxMethod]
    public ErrorCodes VerifyName(string name)
    {
        if (String.IsNullOrEmpty(name)) return ErrorCodes.Course_Name;
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }
    [AjaxMethod]
    public ErrorCodes VerifyDuplicateCode(string code)
    {
        DA da = new DA();
        
        if (da.Course.GetBy_CourseCode(code) != null) return ErrorCodes.Course_CodeDuplicate;
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }
    [AjaxMethod]
    public ErrorCodes DeleteCourse(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        ActionLog log = WebLib.CreateLog("Delete Course.");
        CourseRow dr = da.Course.GetByCourse_ID(id);
        if (dr != null)
        {
            dr.Course_IsDeleted = true;
            da.Course.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }


    [AjaxMethod]
    public CourseSubjectMinimalizedEntity NewCourseSubject(Guid CourseID)
    { 
        CourseSubjectRow dr = new CourseSubjectTable().NewCourseSubjectRow();
        dr.Course_ID = CourseID;
        CourseSubjectMinimalizedEntity CourseSubjectMinimalizedEntity = new CourseSubjectMinimalizedEntity(dr);
        
        return CourseSubjectMinimalizedEntity;
    }
    [AjaxMethod]
    public CourseSubjectMinimalizedEntity GetCourseSubject(Guid id)
    {
        DA da = new DA();
        CourseSubjectRow dr = da.CourseSubject.GetByCourseSubject_ID(id);
        if (dr == null) return null;
        else
        {
            CourseSubjectMinimalizedEntity Entity = new CourseSubjectMinimalizedEntity(dr);
            
            return Entity;
        }
    }
    [AjaxMethod]
    public ErrorCodes VerifySubjectCode(string code)
    {
        if (String.IsNullOrEmpty(code))
        {
            return ErrorCodes.Course_Code;
        }
        else
        {
            DA da = new DA();
            CourseSubjectRow drCourseSubject = da.CourseSubject.GetBy_Code(code);
            if (drCourseSubject != null)
            {
                return ErrorCodes.CourseSubject_Code;
            }

        }
        return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteCourseSubject(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        ActionLog log = WebLib.CreateLog("Delete Course Subject.");
        CourseSubjectRow dr = da.CourseSubject.GetByCourseSubject_ID(id);
        if (dr != null)
        {
            dr.Delete();
            da.CourseSubject.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveCourseSubject(CourseSubjectMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog((ett.CourseSubject_ID == Guid.Empty ? "Create" : "Modify") + " Sourse Subject.");
        DA da = new DA();
        if ((ett.CourseSubject_ID == Guid.Empty))
        {
            CourseSubjectRow drCourseSubject = da.CourseSubject.GetBy_Code(ett.Course_ID,ett.CourseSubject_Code);
            if (drCourseSubject != null)
            {
                errs.Add(ErrorCodes.CourseSubject_Code);
            }
        }


        if (errs.Count == 0)
        {
            CourseSubjectRow dr;
            if (ett.CourseSubject_ID == Guid.Empty)
            {
                dr = new CourseSubjectTable().NewCourseSubjectRow();
                ett.CourseSubject_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.CourseSubject_CreatedDate = DateTime.Now;
                ett.CourseSubject_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.CourseSubject.GetByCourseSubject_ID(ett.CourseSubject_ID);
            }
            ett.CourseSubject_UpdatedBy = WebLib.LoggedInUser.UserName;
            ett.CourseSubject_UpdatedDate = DateTime.Now;


            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.CourseSubject.Update(dr,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public List<Teq.ValuePair> GetAllCourses()
    {
        DA da = new DA();
        List<Teq.ValuePair> vps = new List<Teq.ValuePair>();
        CourseTable tbl = da.Course.GetAll();
        foreach(CourseRow r in tbl.Rows)
        {
            Teq.ValuePair vp = new Teq.ValuePair(r.Course_Name, r.Course_ID);
            vps.Add(vp);
        }
        return vps;
    }
}

public class CourseDialogData
{
    public CourseMinimalizedEntity Entity;
    public Dictionary<string, string> TSP;
    public List<string> SelectedTSP;
    public List<CourseSubjectMinimalizedEntity> EntitySubject;
}