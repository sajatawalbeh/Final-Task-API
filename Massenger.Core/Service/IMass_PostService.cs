using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Service
{
    public interface IMass_PostService
    {
        public List<Mass_Post> Getallpost();

        public bool Createpost(Mass_Post post);

        public bool Deletepost(int? id);

        public bool Updatepost(Mass_Post post);
        public List<string> GetlikesEachPost(int id);
    }
}
