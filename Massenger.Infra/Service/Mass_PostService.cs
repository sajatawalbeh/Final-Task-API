using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_PostService : IMass_PostService
    {
        private readonly IMass_PostRepository repo;
        public Mass_PostService(IMass_PostRepository repo)
        {
            this.repo = repo;
        }
        public bool Createpost(Mass_Post post)
        {
            return repo.Createpost(post);
        }

        public bool Deletepost(int? id)
        {
            return repo.Deletepost(id);
        }

        public List<Mass_Post> Getallpost()
        {
            return repo.Getallpost();
        }

        public bool Updatepost(Mass_Post post)
        {
            return repo.Updatepost(post);
        }
        public List<string> GetlikesEachPost(int id)
        {
            return repo.GetlikesEachPost(id);
        }
    }
}
