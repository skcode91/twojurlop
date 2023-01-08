using System;
using System.Collections.Generic;
using Entities = TwojUrlop.Common.Models.Entities;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.DomainModel.Common.Helpers;
public class UserHelper
{
    public static bool IsManagerOrAdmin(Entities.User user)
    {
        return user.RoleId == (int)Enums.Role.Manager || user.RoleId == (int)Enums.Role.Admin;
    }
}