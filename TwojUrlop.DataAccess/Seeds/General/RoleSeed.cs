using TwojUrlop.Common.Models.Entities;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.DataAccess.Seeds;
public class RoleSeed
{
    public static List<Role> Seed()
    {
        List<Role> items = new List<Role>();

        foreach (object item in Enum.GetValues(typeof(Enums.Role)))
        {
            items.Add(new Role
            {
                Id = (int)item,
                Name = item.ToString(),
                NormalizedName = item.ToString()!.ToUpperInvariant()!,
                ConcurrencyStamp = "8060baf5-f2ca-40db-9f4d-c1a4667af17f",
            });
        }
        return items;
    }
}
