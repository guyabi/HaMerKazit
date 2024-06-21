using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model;
using System.Data.OleDb;
using System.Data;


namespace ViewModel
{
    public abstract class PersonDB : BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity entity)
        {
            Person person = entity as Person;
            person.Id = (int)reader["PersonID"];
            person.FirstName = reader["FirstName"].ToString();
            person.LastName = reader["LastName"].ToString();
            person.Email = reader["Email"].ToString();
            person.City = CityDB.SelectById((int)reader["City"]);
            person.UserName = reader["UserName"].ToString();
            person.Password1 = reader["Password"].ToString();
            person.IsAdmin1 = (bool)reader["Admin"];
            return person;
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Person person = entity as Person;
            string sqlStr = string.Format("INSERT INTO PersonTbl(FirstName, LastName, Email, City, UserName, Password, Admin)" +
                "VALUES('{0}','{1}', '{2}',{3},'{4}','{5}', '{6}')", person.FirstName, person.LastName, person.Email, person.City.Id, person.UserName, person.Password1, person.IsAdmin1);
            return sqlStr;
        }
        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Person person = entity as Person;
            StringBuilder oledb_builder = new StringBuilder();
            oledb_builder.AppendFormat("DELETE FROM PersonTbl WHERE PersonID = {0}", person.Id);
            return oledb_builder.ToString();
        }
        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            Person person = entity as Person;
            string oldbStr = $"UPDATE PersonTbl SET FirstName = '{person.FirstName}'," + $"LastName='{person.LastName}', Email='{person.Email}', City={person.City.Id} , UserName='{person.UserName}, Password = {person.Password1}, Admin = {person.IsAdmin1}"+
            $"WHERE PersonID = {person.Id}";
            return oldbStr;
        }


    }
}
