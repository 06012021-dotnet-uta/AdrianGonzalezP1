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
            if (x.Username.ToLower().Trim() == y.Username.ToLower().Trim() &&
                x.Password == y.Password) 
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(AccountModel obj)
        {
            return obj.GetHashCode();
        }
    }
}
