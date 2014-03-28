using System;

namespace Services.Identity
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public override string ToString()
        {
            return UserId.ToString();
        }

        public static UserInfo FromString(string s)
        {
            return new UserInfo { UserId = Guid.Parse(s) };
        }
    }
}
