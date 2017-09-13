using System;
using System.Web.UI;

public class MasterBase : MasterPage
{
    public PageBase PageBase
    {
        get
        {
            if (this.Page is PageBase) return (PageBase)this.Page;
            else throw new NotImplementedException();
        }
    }
    public MasterBase()
    {
    }
}