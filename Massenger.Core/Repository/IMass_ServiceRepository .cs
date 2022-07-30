using Massenger.Core.Data;
using Massenger.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Repository
{
    public interface IMass_ServiceRepository
    {
        public List<Mass_Service> GetallService();

        public bool CreateService(Mass_Service Service);

        public bool DeleteService(int? id);

        public bool UpdateService(Mass_Service Service);
        public string Payment(VisaDTO visa);
    }
}
