using Commonlayer.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        void AdminRegistration(Credential credential);
        Credential AdminLogin(Credential credential);
    }
}
