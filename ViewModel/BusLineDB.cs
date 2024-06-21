using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BusLineDB:BaseDB
    {
        static private BusLineList list = null;
        public BusLineList SelectAll()
        {
            command.CommandText = "SELECT * FROM BusLineTbl";
            list = new BusLineList(Select());
            return list;
        }
        public static BusLine SelectById(int id)
        {
            BusLineDB db = new BusLineDB();
            foreach (BusLine c in db.SelectAll()) { if (c.Id == id) return c; }
            return null;
        }
        public override BaseEntity CreateModel(BaseEntity entity)
        {
            BusLine busLine = null;
            if (entity != null)
            {
                busLine = entity as BusLine;
                busLine.Id = (int)reader["ID"];
                busLine.Line1 = (int)reader["Line"];
                busLine.Destination1 = reader["Destaination"].ToString();
                busLine.Hour1 = reader["Hour"].ToString();
                busLine.Price1 = (int)reader["Price"];
                busLine.CompanyID = (int)reader["CompanyID"];
            }
            return busLine;
        }
        public override BaseEntity newEntity()
        {
            return new BusLine();
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            BusLine busLine = entity as BusLine;
            string sqlStr = string.Format("INSERT INTO BusLineTbl(Line, Destaination, Hour, Price, CompanyID)" +
                "VALUES({0},'{1}','{2}',{3}, {4})", busLine.Line1, busLine.Destination1, busLine.Hour1, busLine.Price1, busLine.CompanyID);
            return sqlStr;
        }
        
        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            BusLine busLine = entity as BusLine;
            StringBuilder sql_builder = new StringBuilder();
            sql_builder.AppendFormat("DELETE FROM BusLineTbl WHERE BusLineID={0}", busLine.Id);
            return sql_builder.ToString();
        }
    }
}
