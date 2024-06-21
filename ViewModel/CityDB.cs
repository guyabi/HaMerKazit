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
    public class CityDB : BaseDB
    {
        static private CityList list = null;
        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM CityTbl";
            list = new CityList(Select());
            return list;

        }
        public static City SelectById(int id)
        {
            CityDB db = new CityDB();
            foreach (City c in db.SelectAll()) { if (c.Id == id) return c; }
            return null;
        }
        public override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = null;
            if (entity != null)
            {
                city = entity as City;
                city.Id = (int)reader["CityID"];
                city.CityName = reader["CityName"].ToString();
            }
            return city;
        }
        public override BaseEntity newEntity()
        {
            return new City();
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
