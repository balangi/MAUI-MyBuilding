#nullable disable

namespace Farabeh.MyBuilding.Framework.Results;

public class PagedData
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }

    public int PageCount
    {
        get
        {
            if (PageNumber == 0 || PageSize == 0 || TotalCount == 0)
                return 0;
            if (TotalCount % PageSize == 0)
            {
                return TotalCount / PageSize;
            }
            else
            {
                return (TotalCount / PageSize) + 1;
            }
        }
    }
}
public class PagedData<T> : PagedData
{
    public List<T> QueryResult { get; set; }
}
