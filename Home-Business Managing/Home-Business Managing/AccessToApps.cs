using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    public class AccessToApps : IInOut, IForgot // Multiple Inheritance
    {
        public void ForgotPassword()
        {

        }

        public void ForgotUsername()
        {
            
        }

        public bool Login(string username, string password)
        {
            if(username == Owner.Username && Owner.Password == password)
            {
                return true;
            }
            else
                return false;
        }

        public void Logout()
        {

        }

        
    }
}
