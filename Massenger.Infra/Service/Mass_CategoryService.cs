using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
   
    public class Mass_CategoryService : IMass_CategoryService
    {
        private readonly IMass_CategoryRepository repo;
        public Mass_CategoryService(IMass_CategoryRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateCategory(Mass_category Category)
        {
            return repo.CreateCategory(Category);
        }

        public bool DeleteCategory(int? id)
        {
            return repo.DeleteCategory(id);
        }

        public List<Mass_category> GetallCategory()
        {
            return repo.GetallCategory();
        }

        public bool UpdateCategory(Mass_category Category)
        {
            return repo.UpdateCategory(Category);
        }
    }
}
