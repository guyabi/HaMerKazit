using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PassengerDB : PersonDB
    {
        public override BaseEntity newEntity()
        {
            return new Passenger() as BaseEntity;
        }

        public override BaseEntity CreateModel(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            base.CreateModel(passenger);
            return passenger;
        }
        public PassengerList SelectAll()
        {
            command.CommandText = "SELECT *,PersonTbl.PersonID as PersonID FROM (PersonTbl INNER JOIN PassengerTbl ON PersonTbl.PersonID = PassengerTbl.PassengerID)";
            PassengerList list = new PassengerList(base.Select());
            return list;
        }
       
        public PassengerList SelectByName(string firstName, string lastName)
        {
            command.CommandText = string.Format("SELECT *,PersonTbl.ID as ID FROM(PersonTbl " + "INNER JOIN PassengerTbl ON PersonTbl.ID = PersonTbl.ID)"
            + "WHERE FirstName = '{0}' AND LastName = '{1}'", firstName, lastName);
            List<Passenger> passengerList = base.Select().Cast<Passenger>().ToList();
            return new PassengerList(passengerList);
        }
        public Passenger SelectById(int Id)
        {
            command.CommandText = "SELECT *,PersonTbl.ID as ID FROM(PersonTbl " +
                "INNER JOIN PassengerTbl ON PersonTbl.ID = PersonTbl.ID) " +
                $"WHERE PersonTbl.ID={Id}";

            List<BaseEntity> passengerList = base.Select();
            if (passengerList.Count == 1)
            {
                return passengerList[0] as Passenger;
            }
            return null;
        }


        public override void Insert(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            if (passenger != null)
            {
                insert.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                insert.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            if (passenger != null)
            {
                update.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            if (passenger != null)
            {
                delete.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
                delete.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
            }
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            string sqlString = $"INSERT INTO PassengerTbl (PassengerID)  VALUES({passenger.Id})";
            return sqlString;
        }
        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Passenger passenger = entity as Passenger;
            StringBuilder sql_builder = new StringBuilder();
            sql_builder.AppendFormat("DELETE FROM PassengerTbl WHERE PassengerID={0}", passenger.Id);
            return sql_builder.ToString();
        }
    }
}
