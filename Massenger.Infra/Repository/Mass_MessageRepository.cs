using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Massenger.Infra.Repository
{
    public class Mass_MessageRepository : IMass_MessageRepository
    {
        private readonly IDbContext dbContext;

        public Mass_MessageRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Createmessage(Mass_messages message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@message_", message.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@createdAt", message.created_at, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@conversationID", message.conversation_id, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@senderID", message.sender_id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("message_package_api.insertmessage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Deletemessage(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@messages_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("message_package_api.deletemessage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_messages> Getallmessage()
        {
            IEnumerable<Mass_messages> result = dbContext.Connection.Query<Mass_messages>("message_package_api.getallmessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updatemessage(Mass_messages message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@messages_id", message.messagesid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@message_", message.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@createdAt", message.created_at, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@conversationID", message.conversation_id, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@senderID", message.sender_id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("message_package_api.updatemessage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }


        public int Message_Count()
        {
            var count = Getallmessage();
            return count.Count();
        }

        public List<Dtomessage> Search(SearchMessageDTO D)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Datein", D.Datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@Dateout", D.Dateout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Dtomessage> result = dbContext.Connection.Query<Dtomessage>("SearchDateMessage.Search", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();


        }

        public List<string> GetTotalMessForEachUser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id_user", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<MessageUser> result = dbContext.Connection.Query<MessageUser>("GetNametotalmessage.Nametotalmes", parameter, commandType: CommandType.StoredProcedure);
            List<MessageUser> R = result.ToList();
            List<string> finalResult = new List<string>();



            finalResult.Add("User Name: " + R[1].FName+" **** User Message Number :" + R.Count);


            return finalResult;
        }

        public List<MassgeFilter> filtermessage(Mass_messages mess)
        {
            IEnumerable<MassgeFilter> result = dbContext.Connection.Query<MassgeFilter>("FilterMessage.Filter", commandType: CommandType.StoredProcedure);
            List<MassgeFilter> mes = result.ToList();
            List<MassgeFilter> mesNew = new List<MassgeFilter>();
            List<string> finalResult = new List<string>();
            for (int i = 0; i < mes.Count; i++)
            {
                if (mes[i].Message == mess.message)
                {
                    mesNew.Add(mes[i]);
                    break;
                }
            }
            return mesNew;
        }

        public List<MassgeFilter> filtermessage2(char c)
        {
            IEnumerable<MassgeFilter> result = dbContext.Connection.Query<MassgeFilter>("FilterMessage.Filter", commandType: CommandType.StoredProcedure);
            List<MassgeFilter> mes = result.ToList();
            List<MassgeFilter> mesNew = new List<MassgeFilter>();
            List<string> finalResult = new List<string>();
            for (int i = 0; i < mes.Count; i++)
            {
                for (int k = 0; k < mes[i].Message.Length; k++)
                {
                    if (mes[i].Message[k] == c)
                    {
                        mesNew.Add(mes[i]);
                        break;
                    }
                }
            }
            return mesNew;
        }

        public List<string> Backup(int id )
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id_user", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<BackupDTOcs> result = dbContext.Connection.Query<BackupDTOcs>("Backup.BackupMessage", parameter, commandType: CommandType.StoredProcedure);
            List<BackupDTOcs> R = result.ToList();
            List<string> finalResult = new List<string>();
            //var fileName = "Backup.txt";
            //var mimeType = "application/....";
            string file = @"C:\Users\DELL\Desktop\Backup.txt";
          for(int i =0;i<R.Count;i++)
            {
              finalResult.Add("Message Content: " + R[i].message + " **** Message Date :" + R[i].Date);

            }
            using (var write = new StreamWriter(file))
            {
                for (int i = 0; i <R.Count; i++)
                {
                    write.WriteLine("Message Content: " + R[i].message + " **** Message Date :" + R[i].Date);

                }
                write.Close();
            }
            //var contentType = "text/plain";
            //using (var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World")))
            //    return new FileStreamResult(stream, contentType);
            return finalResult;


        }
    }
}
