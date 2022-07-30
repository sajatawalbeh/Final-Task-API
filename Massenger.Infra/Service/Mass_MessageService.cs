using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Massenger.Infra.Service
{
    public class Mass_MessageService : IMass_MessageService
    {
        private readonly IMass_MessageRepository repo;
        public Mass_MessageService(IMass_MessageRepository repo)
        {
            this.repo = repo;
        }
        public bool Createmessage(Mass_messages message)
        {
            return repo.Createmessage(message);
        }

        public bool Deletemessage(int? id)
        {
            return repo.Deletemessage(id);
        }

        public List<Mass_messages> Getallmessage()
        {
            return repo.Getallmessage();
        }

        public bool Updatemessage(Mass_messages message)
        {
            return repo.Updatemessage(message);
        }
        public int Message_Count()
        {

            return repo.Message_Count();
        }
        public List<Dtomessage> Search(SearchMessageDTO D)
        {
            return repo.Search(D);
        }
      
        public List<string> GetTotalMessForEachUser(int id)
        {
            return repo.GetTotalMessForEachUser(id);
        }
        public List<MassgeFilter> filtermessage(Mass_messages mess)
        {
            return repo.filtermessage(mess);
        }
        public List<MassgeFilter> filtermessage2(char c)
        {
            return repo.filtermessage2(c);
        }
        public List<string> Backup(int id)
        {
            return repo.Backup(id);
        }
    }
}
