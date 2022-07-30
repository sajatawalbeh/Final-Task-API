using Dapper;
using MailKit.Net.Smtp;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{
    public class Mass_UsersRepository : IMass_UsersRepository
    {
        private readonly IDbContext dbContext;

        public Mass_UsersRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     

        public bool Createuser(Mass_users user)
        {
            string file = @"C:\Users\DELL\Desktop\emp.txt";
            //StreamReader read = new StreamReader(file);
            List<string> Usernames = new List<string>();
            using(var read = new StreamReader(file))
            {
                while(read.Peek() >= 0 )
                {
                    Usernames.Add(read.ReadLine());
                }
            }
            //Random R = new Random();
            int Random = new Random().Next(0, Usernames.Count());
            var parameter = new DynamicParameters(); 
            parameter.Add("@phone_", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@firstName", Usernames[Random], dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@isblocked",0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@countryid", user.country_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Email_", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("users_package_api.createinsertuser", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }


      
        public bool Deleteuser(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("users_package_api.deleteuser", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_users> Getalluser()
        {
            IEnumerable<Mass_users> result = dbContext.Connection.Query<Mass_users>("users_package_api.getalluser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updateuser(Mass_users user)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@user_id", user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@phone_", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@firstName", user.first_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@isblocked", user.is_blocked, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@countryid", user.country_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Email_", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("users_package_api.updateuser", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }


        public List<Mass_users> InsertUserList(Mass_users[] user)
        {
            for (int i = 0; i < user.Length; i++)
            {
                Createuser(user[i]);
            }

            return user.ToList();
        }

        public string Block(BlockDTO block)
        {
            IEnumerable<Mass_users> result = dbContext.Connection.Query<Mass_users>("users_package_api.getalluser", commandType: CommandType.StoredProcedure);
            List<Mass_users> userlist = result.ToList();
            string username= "";
            string userEmail = "";
            for (int i =0; i<userlist.Count;i++)
            {
                if (userlist[i].id == block.userid)
                {
                    username = userlist[i].first_Name;
                     userEmail = userlist[i].Email;
                }

            }
            IEnumerable<Mass_contacts> contct = dbContext.Connection.Query<Mass_contacts>("contact_package_api.getallcontact", commandType: CommandType.StoredProcedure);
            List<Mass_contacts> contactlist = contct.ToList();
            string contactrname = "";
           
            for (int i = 0; i < contactlist.Count; i++)
            {
                if (contactlist[i].id == block.id_contact)
                {
                    contactrname = contactlist[i].first_Name;
                   
                }

            }

            var parameter = new DynamicParameters();
            parameter.Add("@id_user", block.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@id_conversation", block.Convid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@cont_id", block.id_contact, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result1 = dbContext.Connection.ExecuteAsync("BlockUser.Block", parameter, commandType: CommandType.StoredProcedure);

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "sajatawalbeh99@gmail.com");
            MailboxAddress to = new MailboxAddress("user", userEmail);

            builder.HtmlBody = "<h1>" + contactrname+ " " + "block" +" "+ username+"</h1>";

            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "Block Notification";
            using (var item = new SmtpClient())
            {
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("sajatawalbeh99@gmail.com", "aopolsyfzzvizglm");
                item.Send(message);
                item.Disconnect(true);

            }

            return "true";


        }

    }
}
