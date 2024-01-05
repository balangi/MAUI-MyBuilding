#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Common;

public class SqlDbContext : IdentityDbContext<UserDto,
    RoleDto, string, IdentityUserClaim<string>,
    UserRoleDto, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public SqlDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<BuildingDto> Buildings { get; set; } = null!;
    public virtual DbSet<RoleDto> Roles { get; set; } = null!;
    public virtual DbSet<SettingsDto> Settings { get; set; } = null!;
    public virtual DbSet<UserDto> Users { get; set; } = null!;
    public virtual DbSet<UserClaimDto> UserClaims { get; set; } = null!;
    public virtual DbSet<UserRoleDto> UserRoles { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

