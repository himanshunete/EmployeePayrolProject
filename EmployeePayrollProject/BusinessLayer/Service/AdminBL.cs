using BusinessLayer.Interface;
using Commonlayer.Models.RequestModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AdminBL:IAdminBL
    {
        IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public void AdminRegistration(Credential credential)
        {
            try
            {
                this.adminRL.AdminRegistration(credential);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Credential AdminLogin(Credential credential)
        {
            try
            {
                return this.adminRL.AdminLogin(credential);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
