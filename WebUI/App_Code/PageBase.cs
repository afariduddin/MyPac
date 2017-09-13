using System;
using System.Web.UI;

public class PageBase : Page
{
    public MasterBase MasterBase
    {
        get
        {
            if (this.Master is MasterBase) return (MasterBase)this.Master;
            else throw new NotImplementedException();
        }
    }
    public PageBase()
    {
    }
}