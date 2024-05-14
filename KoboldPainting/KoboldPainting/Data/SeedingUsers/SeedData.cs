using System.Diagnostics.CodeAnalysis;
using Humanizer;
using KoboldPainting.Models;

namespace KoboldPainting.Data.SeedingUsers;

/// <summary>
/// Helper class to hold information we need for users in our project databases.
/// </summary>
[ExcludeFromCodeCoverage]
public class UserInfoData
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PaintRecipe { get; set; }
    public List<OwnedPaint> UserOwnedPaints { get; set; } = new List<OwnedPaint>();
    public List<WantedPaint> UserWantedPaints { get; set; } = new List<WantedPaint>();
    public List<RefillPaint> UserRefillPaints { get; set; } = new List<RefillPaint>();
}
[ExcludeFromCodeCoverage]
public class SeedData
{
    /// <summary>
    /// Data to be used to see the KoboldUsers and ASPNetUsers Tables
    /// </summary>
    public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
    {
        new UserInfoData { UserName = "TaliaK", Email = "knott@example.com",
                            FirstName = "Talia", LastName = "Knott", PaintRecipe = 0,
                            UserOwnedPaints = new List<OwnedPaint> { new OwnedPaint { PaintId = 1, KoboldUserId = 1 },
                                                                     new OwnedPaint { PaintId = 2, KoboldUserId = 1 },
                                                                     new OwnedPaint { PaintId = 3, KoboldUserId = 1 }},
                            UserWantedPaints = new List<WantedPaint> { new WantedPaint { PaintId = 4, KoboldUserId = 1 }},
                            UserRefillPaints = new List<RefillPaint> { new RefillPaint { PaintId = 1, KoboldUserId = 1 }}},
        new UserInfoData { UserName = "ZaydenC", Email = "clark@example.com",
                            FirstName = "Zayden", LastName = "Clark", PaintRecipe = 0,
                            UserOwnedPaints = new List<OwnedPaint> { new OwnedPaint { PaintId = 1, KoboldUserId = 2 }},
                            UserWantedPaints = new List<WantedPaint> { new WantedPaint { PaintId = 2, KoboldUserId = 2 }},
                            UserRefillPaints = new List<RefillPaint> { new RefillPaint { PaintId = 1, KoboldUserId = 2 }}},
        new UserInfoData { UserName = "DavilaH", Email = "hareem@example.com",
                            FirstName = "Hareem", LastName = "Davila", PaintRecipe = 0,
                            UserOwnedPaints = new List<OwnedPaint> { new OwnedPaint { PaintId = 1, KoboldUserId = 3 },
                                                                     new OwnedPaint { PaintId = 2, KoboldUserId = 3 }},
                            UserWantedPaints = new List<WantedPaint> { new WantedPaint { PaintId = 3, KoboldUserId = 3 }},
                            UserRefillPaints = new List<RefillPaint> { new RefillPaint { PaintId = 1, KoboldUserId = 3 }}},
        new UserInfoData { UserName = "KrzysztofP", Email = "krzysztof@example.com",
                            FirstName = "Krzysztof", LastName = "Ponce", PaintRecipe = 0,
                            UserOwnedPaints = new List<OwnedPaint> { new OwnedPaint { PaintId = 1, KoboldUserId = 3 },
                                                                     new OwnedPaint { PaintId = 2, KoboldUserId = 3 },
                                                                     new OwnedPaint { PaintId = 3, KoboldUserId = 3 }},
                            UserWantedPaints = new List<WantedPaint> { new WantedPaint { PaintId = 4, KoboldUserId = 3 }},
                            UserRefillPaints = new List<RefillPaint> { new RefillPaint { PaintId = 1, KoboldUserId = 3 }}},
    };
}