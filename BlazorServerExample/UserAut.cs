using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerExample
{
    public static class UserAut
    {
        public static int? Id { get; set; }
        public static string? Name { get; set; }
        public static string? Role { get; set; }

        public static string? Email { get; set; }
        public static int userCode = 123;
        public static int? GroupId { get; set; }
    }
}
