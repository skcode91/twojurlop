using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.DataAccess.Seeds
{
    public class GenderSeed
    {
        public static List<Gender> Seed()
        {
            List<Gender> items = new List<Gender>();

            foreach (object item in Enum.GetValues(typeof(Common.Enums.Gender)))
            {
                items.Add(new Gender
                {
                    Id = (int)item,
                    Name = item.ToString()!
                });
            }
            return items;
        }
    }
}
