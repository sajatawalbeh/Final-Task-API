using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Repository
{
    public interface IMass_CategoryRepository
    {
        public List<Mass_category> GetallCategory();

        public bool CreateCategory(Mass_category Category);

        public bool DeleteCategory(int? id);

        public bool UpdateCategory(Mass_category Category);
    }
}
