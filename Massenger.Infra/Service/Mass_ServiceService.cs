using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_ServiceService : IMass_ServiceService
    {

        private readonly IMass_ServiceRepository repo;
        public Mass_ServiceService(IMass_ServiceRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateService(Mass_Service Service)
        {
            return repo.CreateService(Service);
        }

        public bool DeleteService(int? id)
        {
            return repo.DeleteService(id);
        }

        public List<Mass_Service> GetallService()
        {
            return repo.GetallService();
        }

        public bool UpdateService(Mass_Service Service)
        {
            return repo.UpdateService(Service);
        }
        public string Payment(VisaDTO visa)
        {
            return repo.Payment(visa);
        }
    }
}
