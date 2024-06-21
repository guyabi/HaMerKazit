﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ViewModel
{
    public delegate string CreateSql(BaseEntity entity);
    public class ChangeEntity
    {
        private BaseEntity entity;
        private CreateSql createSql;

        public ChangeEntity(CreateSql createSql, BaseEntity entity)
        {
            this.createSql = createSql;
            this.entity = entity;
        }

        public BaseEntity Entity { get => entity; set => entity = value; }
        public CreateSql CreateSQL { get => createSql; set => createSql = value; }

    }
}
