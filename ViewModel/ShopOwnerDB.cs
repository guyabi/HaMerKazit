using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ShopOwnerDB:PersonDB
    {
        public override BaseEntity newEntity()
        {
            return new ShopOwner() as BaseEntity;
        }

        public override BaseEntity CreateModel(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            base.CreateModel(shopOwner);
            return shopOwner;
        }
        public ShopOwnerList SelectAll()
        {
            command.CommandText = "SELECT *,PersonTbl.PersonID as PersonID FROM (PersonTbl INNER JOIN ShopOwnerTbl ON PersonTbl.PersonID = ShopOwnerTbl.ShopOwnerID)";
            ShopOwnerList list = new ShopOwnerList(base.Select());
            return list;
        }

        public ShopOwnerList SelectByName(string firstName, string lastName)
        {
            command.CommandText = string.Format("SELECT *,PersonTbl.ID as ID FROM(PersonTbl " + "INNER JOIN ShopOwnerTbl ON PersonTbl.ID = PersonTbl.ID)"
            + "WHERE FirstName = '{0}' AND LastName = '{1}'", firstName, lastName);
            List<ShopOwner> shopOwnerList = base.Select().Cast<ShopOwner>().ToList();
            return new ShopOwnerList(shopOwnerList);
        }
        public ShopOwner SelectById(int Id)
        {
            command.CommandText = "SELECT *,PersonTbl.ID as ID FROM(PersonTbl " +
                "INNER JOIN ShopOwnerTbl ON PersonTbl.ID = PersonTbl.ID) " +
                $"WHERE PersonTbl.ID={Id}";

            List<BaseEntity> shopOwnerList = base.Select();
            if (shopOwnerList.Count == 1)
            {
                return shopOwnerList[0] as ShopOwner;
            }
            return null;
        }


        public override void Insert(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            if (shopOwner != null)
            {
                insert.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                insert.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            if (shopOwner != null)
            {
                update.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            if (shopOwner != null)
            {
                delete.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
                delete.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
            }
        }
        protected override string CreateInsertSQL(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            string sqlString = $"INSERT INTO ShopOwnerTbl (ShopOwnerID)  VALUES({shopOwner.Id})";
            return sqlString;
        }
        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            ShopOwner shopOwner = entity as ShopOwner;
            StringBuilder sql_builder = new StringBuilder();
            sql_builder.AppendFormat("DELETE FROM ShopOwnerTbl WHERE ShopOwnerID={0}", shopOwner.Id);
            return sql_builder.ToString();
        }
    }
}
