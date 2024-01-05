namespace Farabeh.MyBuilding.Api.Core.Domain.Common.Dto
{
    public interface IDto
    {
        long Id { get; set; }
        string Title { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        bool Enable { get; set; }
        UserDto UserInfo { get; set; }
    }
}
