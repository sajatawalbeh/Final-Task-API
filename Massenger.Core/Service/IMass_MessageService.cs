using Massenger.Core.Data;
using Massenger.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Massenger.Core.Service
{
    public interface IMass_MessageService
    {
        public List<Mass_messages> Getallmessage();

        public bool Createmessage(Mass_messages message);

        public bool Deletemessage(int? id);

        public bool Updatemessage(Mass_messages message);
        public int Message_Count();
       
        public List<Dtomessage> Search(SearchMessageDTO D);
        public List<string> GetTotalMessForEachUser(int id);
        public List<MassgeFilter> filtermessage(Mass_messages mess);
        public List<MassgeFilter> filtermessage2(char c);
        public List<string> Backup(int id);

    }
}
