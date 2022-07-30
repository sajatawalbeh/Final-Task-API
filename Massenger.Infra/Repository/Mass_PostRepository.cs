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
    public class Mass_PostRepository : IMass_PostRepository
    {
        private readonly IDbContext dbContext;

        public Mass_PostRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Createpost(Mass_Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@content_", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@image_Name", post.imageName, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("@likes_", post.likes, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userid", post.user_id, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("Post_package_api.insertPost", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Deletepost(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Post_package_api.deletePost", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_Post> Getallpost()
        {
            IEnumerable<Mass_Post> result = dbContext.Connection.Query<Mass_Post>("Post_package_api.getallPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updatepost(Mass_Post post)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Post_id", post.id, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@content_", post.content, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@image_Name", post.imageName, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("@likes_", post.likes, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userid", post.user_id, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Post_package_api.updatePost", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<string> GetlikesEachPost(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LikesDTO> result = dbContext.Connection.Query<LikesDTO>("GetLikenum.likesNum", parameter, commandType: CommandType.StoredProcedure);
            List<LikesDTO> R = result.ToList();
            List<string> finalResult = new List<string>();



            finalResult.Add("Post id: " + R[1].id + " ***** Post Content: " + R[1].content + " ***** likes Number: " + R.Count);


            return finalResult;
        }
    }
}
