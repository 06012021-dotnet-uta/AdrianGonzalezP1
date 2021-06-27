using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// This Class is responsible for checking against another class. User for dbContext _.Compare() Method
    /// </summary>
    public class AccountComparer : IEqualityComparer<AccountModel>
    {
        public bool Equals(AccountModel x, AccountModel y)
        {
            //If both object refernces are equal then return true
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            //If one of the object refernce is null then return false
            if (x is null || y is null)
            {
                return false;
            }
            return x.Username.ToLower().Trim() == y.Username.ToLower().Trim() && x.Password == y.Password;
        }
        public int GetHashCode(AccountModel obj)
        {
            //If obj is null then return 0
            if (obj is null)
            {
                return 0;
            }
            int IDHashCode = obj.Username.GetHashCode();
            int TotalMarksHashCode = obj.Password.GetHashCode();
            return IDHashCode ^ TotalMarksHashCode;
        }
    }
}
