using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace SiemensHP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration :  DbMigrationsConfiguration<EfModel.SiemensHP> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(EfModel.SiemensHP context)
        {
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreateTimeColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreateTimeColumn(columnModel);
                SetGuidIdColumn(columnModel);
            }
        }

        private static void SetCreateTimeColumn(PropertyModel column)
        {
            if (column.Name == "CreateTime")
            {
                column.DefaultValueSql = "GETDATE()";
            }
        }
        private static void SetGuidIdColumn(PropertyModel column)
        {
            if (column.Name == "Id")
            {
                column.DefaultValueSql = "newsequentialid()";
            }
        }
    }
}
