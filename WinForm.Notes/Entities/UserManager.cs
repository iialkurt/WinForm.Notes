using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Notes.Entities
{
    public class UserManager
    {




        public  bool Test(string Usr, String Pass)
        {

            Users user = new Users();

            if (user.Username == Usr && user.Password == Pass) { return true; }
            else { return false; }


        }
       



    }
    }

