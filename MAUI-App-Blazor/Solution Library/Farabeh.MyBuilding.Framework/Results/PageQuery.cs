namespace Farabeh.MyBuilding.Framework.Results;

public class PageQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int SkipCount { get; }
    public bool NeedTotalCount { get; set; } = true;
    //public string SortBy { get; set; }
    //public bool SortAscending { get; set; }
}
