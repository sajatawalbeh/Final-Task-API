using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{
    public class Mass_CategoryRepository : IMass_CategoryRepository
    {
        private readonly IDbContext dbContext;

        public Mass_CategoryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateCategory(Mass_category Category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@category_Name", Category.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);
        
            var result = dbContext.Connection.ExecuteAsync("category_package_api.insertcategory", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCategory(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@category_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("category_package_api.deletecategory", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_category> GetallCategory()
        {
            IEnumerable<Mass_category> result = dbContext.Connection.Query<Mass_category>("category_package_api.getallcategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCategory(Mass_category Category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@category_id", Category.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@category_Name", Category.categoryName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("category_package_api.updatecategory", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
