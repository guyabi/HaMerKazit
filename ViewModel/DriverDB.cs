using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DriverDB:PersonDB
    {
        public override BaseEntity newEntity()
        {
            return new Driver() as BaseEntity;
        }

        public override BaseEntity CreateModel(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            driver.BusLineID = (int)reader["BusLineID"];
            driver.CompanyID = (int)reader["CompanyID"];
            base.CreateModel(driver);
            return driver;
        }
        public DriverList SelectAll()
        {
            command.CommandText = "SELECT *,PersonTbl.PersonID as PersonID FROM (PersonTbl INNER JOIN DriverTbl ON PersonTbl.PersonID = DriverTbl.DriverID)";
            DriverList list = new DriverList(base.Select());
            return list;
        }

        public DriverList SelectByName(string firstName, string lastName)
        {
            command.CommandText = string.Format("SELECT *,PersonTbl.ID as ID FROM(PersonTbl " + "INNER JOIN DriverTbl ON PersonTbl.ID = PersonTbl.ID)"
            + "WHERE FirstName = '{0}' AND LastName = '{1}'", firstName, lastName);
            List<Driver> driverList = base.Select().Cast<Driver>().ToList();
            return new DriverList(driverList);
        }
        public Driver SelectById(int Id)
        {
            command.CommandText = "SELECT *,PersonTbl.ID as ID FROM(PersonTbl " +
                "INNER JOIN DriverTbl ON PersonTbl.ID = PersonTbl.ID) " +
                $"WHERE PersonTbl.ID={Id}";

            List<BaseEntity> driverList = base.Select();
            if (driverList.Count == 1)
            {
                return driverList[0] as Driver;
            }
            return null;
        }

         
        public override void Insert(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            if (driver != null)
            {
                insert.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                insert.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            if (driver != null)
            {
                update.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            if (driver != null)
            {
                delete.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
                delete.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
            }
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            string sqlString = $"INSERT INTO DriverTbl (DriverID)  VALUES({driver.Id})";
            return sqlString;
        }
        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Driver driver = entity as Driver;
            StringBuilder sql_builder = new StringBuilder();
            sql_builder.AppendFormat("DELETE FROM DriverTbl WHERE DriverID={0}", driver.Id);
            return sql_builder.ToString();
        }
    }
}
