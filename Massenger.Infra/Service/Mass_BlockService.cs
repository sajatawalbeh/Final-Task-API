using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_BlockService : IMass_BlockService
    {
        private readonly IMass_BlockRepository repo;
        public Mass_BlockService(IMass_BlockRepository repo)
        {
            this.repo = repo;
        }
        public bool Createblock(Mass_block block)
        {
            return repo.Createblock(block);
        }

        public bool Deleteblock(int? id)
        {
            return repo.Deleteblock(id);
        }

        public List<Mass_block> Getallblock()
        {
            return repo.Getallblock();
        }

        public bool Updateblock(Mass_block block)
        {
            return repo.Updateblock(block);
        }
    }
}
