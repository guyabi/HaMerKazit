using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CompanyDB:BaseDB
    {
        static private CompanyList list = null;
        public CompanyList SelectAll()
        {
            command.CommandText = "SELECT * FROM CompanyTbl";
            list = new CompanyList(Select());
            return list;
        }
        public static Company SelectById(int id)
        {
            CompanyDB db = new CompanyDB();
            foreach (Company c in db.SelectAll()) { if (c.Id == id) return c; }
            return null;
        }
        public override BaseEntity CreateModel(BaseEntity entity)
        {
            Company company = null;
            if (entity != null)
            {
                company = entity as Company;
                company.Id = (int)reader["ID"];
                company.Name = reader["Name"].ToString();
            }
            return company;
        }
        public override BaseEntity newEntity()
        {
            return new Company();
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Company company = entity as Company;
            string sqlStr = string.Format("INSERT INTO CompanyTbl(Name)" +
                "VALUES('{0}')", company.Name);
            return sqlStr;
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Company company = entity as Company;
            StringBuilder sql_builder = new StringBuilder();
            sql_builder.AppendFormat("DELETE FROM CompanyTbl WHERE CompanyID={0}", company.Id);
            return sql_builder.ToString();
        }
    }
}
