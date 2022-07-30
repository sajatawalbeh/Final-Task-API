using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Service
{
    public interface IMass_BlockService
    {
        public List<Mass_block> Getallblock();

        public bool Createblock(Mass_block block);

        public bool Deleteblock(int? id);

        public bool Updateblock(Mass_block block);
    }
}
