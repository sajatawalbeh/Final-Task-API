using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{
    public class Mass_ServiceRepository : IMass_ServiceRepository
    {
        private readonly IDbContext dbContext;

        public Mass_ServiceRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateService(Mass_Service Service)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@service_Name", Service.serviceName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@category_id", Service.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("Service_package_api.insertService", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteService(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@service_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Service_package_api.deleteService", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_Service> GetallService()
        {

            IEnumerable<Mass_Service> result = dbContext.Connection.Query<Mass_Service>("Service_package_api.getallService", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateService(Mass_Service Service)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@service_id", Service.id, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@service_Name", Service.serviceName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@category_id", Service.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Service_package_api.updateService", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string Payment(VisaDTO visa)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Amount", visa.Amount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@card_number", visa.cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
          
            IEnumerable<VisaDTO> result = dbContext.Connection.Query<VisaDTO>("Payment_package_api.paymentService", parameter,commandType: CommandType.StoredProcedure);
            List<VisaDTO> mes = result.ToList();
            for (int i = 0; i < mes.Count; i++)
            {
                if (mes[i].Amount >= visa.Amount)
                {
                    int NewAmount;
                    NewAmount = mes[i].Amount - visa.Amount;
                }
                else return "sorry your balance not enough!!";
            }

            return "Operation completed successfully!";
        }




    }
}
