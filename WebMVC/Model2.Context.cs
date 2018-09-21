﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SiemensBomTestFinalEntities : DbContext
    {
        public SiemensBomTestFinalEntities()
            : base("name=SiemensBomTestFinalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Directory> T_Directory { get; set; }
        public virtual DbSet<T_MailTask> T_MailTask { get; set; }
        public virtual DbSet<T_MaterielSAP> T_MaterielSAP { get; set; }
        public virtual DbSet<VersionData> VersionDatas { get; set; }
        public virtual DbSet<T_ApprovalRecord> T_ApprovalRecord { get; set; }
        public virtual DbSet<T_CntrNo> T_CntrNo { get; set; }
        public virtual DbSet<T_CntrNoTypical> T_CntrNoTypical { get; set; }
        public virtual DbSet<T_CntrNoTypicalLog> T_CntrNoTypicalLog { get; set; }
        public virtual DbSet<T_DirectoryClass> T_DirectoryClass { get; set; }
        public virtual DbSet<T_DirectoryGroup> T_DirectoryGroup { get; set; }
        public virtual DbSet<T_DirectoryTemplate> T_DirectoryTemplate { get; set; }
        public virtual DbSet<T_File> T_File { get; set; }
        public virtual DbSet<T_MasterInfo> T_MasterInfo { get; set; }
        public virtual DbSet<T_MaterielChildren> T_MaterielChildren { get; set; }
        public virtual DbSet<T_MaterielDesign> T_MaterielDesign { get; set; }
        public virtual DbSet<T_Menu> T_Menu { get; set; }
        public virtual DbSet<T_Product> T_Product { get; set; }
        public virtual DbSet<T_ProductContract> T_ProductContract { get; set; }
        public virtual DbSet<T_ProductContractHeader> T_ProductContractHeader { get; set; }
        public virtual DbSet<T_ProductData> T_ProductData { get; set; }
        public virtual DbSet<T_ProductDataLog> T_ProductDataLog { get; set; }
        public virtual DbSet<T_ProductDataLogTemp> T_ProductDataLogTemp { get; set; }
        public virtual DbSet<T_ProductDataPlan> T_ProductDataPlan { get; set; }
        public virtual DbSet<T_ProductDataTemp> T_ProductDataTemp { get; set; }
        public virtual DbSet<T_ProductSeries> T_ProductSeries { get; set; }
        public virtual DbSet<T_ProjectContract> T_ProjectContract { get; set; }
        public virtual DbSet<T_ProjectContractHeader> T_ProjectContractHeader { get; set; }
        public virtual DbSet<T_Role> T_Role { get; set; }
        public virtual DbSet<T_RoleMenu> T_RoleMenu { get; set; }
        public virtual DbSet<T_Semifinished> T_Semifinished { get; set; }
        public virtual DbSet<T_SemifinishedData> T_SemifinishedData { get; set; }
        public virtual DbSet<T_Series> T_Series { get; set; }
        public virtual DbSet<T_System> T_System { get; set; }
        public virtual DbSet<T_SystemInfo> T_SystemInfo { get; set; }
        public virtual DbSet<T_Typical> T_Typical { get; set; }
        public virtual DbSet<T_TypicalData> T_TypicalData { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }
        public virtual DbSet<T_UserDirectoryTemplate> T_UserDirectoryTemplate { get; set; }
        public virtual DbSet<T_UserRole> T_UserRole { get; set; }
        public virtual DbSet<T_VMaterielDesign> T_VMaterielDesign { get; set; }
        public virtual DbSet<V_ProjectContract_MateielDesign> V_ProjectContract_MateielDesign { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<V_Version_VersionData> V_Version_VersionData { get; set; }
        public virtual DbSet<T_VersionData> T_VersionData { get; set; }
        public virtual DbSet<T_Version> T_Version { get; set; }
        public virtual DbSet<V_ProductContractMateielDesign> V_ProductContractMateielDesign { get; set; }
        public virtual DbSet<ProductConnactVMaterelDesign> ProductConnactVMaterelDesigns { get; set; }
    
        [DbFunction("SiemensBomTestFinalEntities", "f_split")]
        public virtual IQueryable<f_split_Result> f_split(string c, string split)
        {
            var cParameter = c != null ?
                new ObjectParameter("c", c) :
                new ObjectParameter("c", typeof(string));
    
            var splitParameter = split != null ?
                new ObjectParameter("split", split) :
                new ObjectParameter("split", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<f_split_Result>("[SiemensBomTestFinalEntities].[f_split](@c, @split)", cParameter, splitParameter);
        }
    
        public virtual ObjectResult<BulkUpdateMaterial_Result> BulkUpdateMaterial(Nullable<int> totalCount, string execsql, string execNumSql)
        {
            var totalCountParameter = totalCount.HasValue ?
                new ObjectParameter("totalCount", totalCount) :
                new ObjectParameter("totalCount", typeof(int));
    
            var execsqlParameter = execsql != null ?
                new ObjectParameter("execsql", execsql) :
                new ObjectParameter("execsql", typeof(string));
    
            var execNumSqlParameter = execNumSql != null ?
                new ObjectParameter("execNumSql", execNumSql) :
                new ObjectParameter("execNumSql", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BulkUpdateMaterial_Result>("BulkUpdateMaterial", totalCountParameter, execsqlParameter, execNumSqlParameter);
        }
    
        public virtual int GetAllProductForAllMaterielBomItem(Nullable<int> contractId, Nullable<int> productId, Nullable<int> seriesId)
        {
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("ContractId", contractId) :
                new ObjectParameter("ContractId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var seriesIdParameter = seriesId.HasValue ?
                new ObjectParameter("SeriesId", seriesId) :
                new ObjectParameter("SeriesId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetAllProductForAllMaterielBomItem", contractIdParameter, productIdParameter, seriesIdParameter);
        }
    
        public virtual int GetAllProductRoot(Nullable<int> materielId, string version)
        {
            var materielIdParameter = materielId.HasValue ?
                new ObjectParameter("MaterielId", materielId) :
                new ObjectParameter("MaterielId", typeof(int));
    
            var versionParameter = version != null ?
                new ObjectParameter("Version", version) :
                new ObjectParameter("Version", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetAllProductRoot", materielIdParameter, versionParameter);
        }
    
        public virtual int GetAllSubRoot(Nullable<int> materielId, string version, Nullable<int> productId)
        {
            var materielIdParameter = materielId.HasValue ?
                new ObjectParameter("MaterielId", materielId) :
                new ObjectParameter("MaterielId", typeof(int));
    
            var versionParameter = version != null ?
                new ObjectParameter("Version", version) :
                new ObjectParameter("Version", typeof(string));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetAllSubRoot", materielIdParameter, versionParameter, productIdParameter);
        }
    
        public virtual int GetBaseSemifinishedForAllMaterielBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetBaseSemifinishedForAllMaterielBomItem", idParameter);
        }
    
        public virtual int GetBaseSemifinishedForSAPBomHeader(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetBaseSemifinishedForSAPBomHeader", idParameter);
        }
    
        public virtual int GetBaseSemifinishedForSAPBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetBaseSemifinishedForSAPBomItem", idParameter);
        }
    
        public virtual ObjectResult<GetMaterielDesignList_Result> GetMaterielDesignList(ObjectParameter total)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMaterielDesignList_Result>("GetMaterielDesignList", total);
        }
    
        public virtual int GetProductForAllMaterielBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetProductForAllMaterielBomItem", idParameter);
        }
    
        public virtual int GetProductForSAPBomHeader(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetProductForSAPBomHeader", idParameter);
        }
    
        public virtual int GetProductForSAPBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetProductForSAPBomItem", idParameter);
        }
    
        public virtual int GetReportList(Nullable<int> materielId)
        {
            var materielIdParameter = materielId.HasValue ?
                new ObjectParameter("MaterielId", materielId) :
                new ObjectParameter("MaterielId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetReportList", materielIdParameter);
        }
    
        public virtual int GetSeniorSemifinishedForAllMaterielBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSeniorSemifinishedForAllMaterielBomItem", idParameter);
        }
    
        public virtual int GetSeniorSemifinishedForSAPBomHeader(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSeniorSemifinishedForSAPBomHeader", idParameter);
        }
    
        public virtual int GetSeniorSemifinishedForSAPBomItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSeniorSemifinishedForSAPBomItem", idParameter);
        }
    
        public virtual int SaveAllProducts(Nullable<int> materielId, string version, string user)
        {
            var materielIdParameter = materielId.HasValue ?
                new ObjectParameter("MaterielId", materielId) :
                new ObjectParameter("MaterielId", typeof(int));
    
            var versionParameter = version != null ?
                new ObjectParameter("Version", version) :
                new ObjectParameter("Version", typeof(string));
    
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveAllProducts", materielIdParameter, versionParameter, userParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetReportMaterials(string columns, string materialNumber, string materialTypes, string descriptionCn, string descriptionEn, string manufacture, string certificate, Nullable<decimal> lowTemperature, Nullable<decimal> highTemperature, string flameClass, string type)
        {
            var columnsParameter = columns != null ?
                new ObjectParameter("columns", columns) :
                new ObjectParameter("columns", typeof(string));
    
            var materialNumberParameter = materialNumber != null ?
                new ObjectParameter("materialNumber", materialNumber) :
                new ObjectParameter("materialNumber", typeof(string));
    
            var materialTypesParameter = materialTypes != null ?
                new ObjectParameter("materialTypes", materialTypes) :
                new ObjectParameter("materialTypes", typeof(string));
    
            var descriptionCnParameter = descriptionCn != null ?
                new ObjectParameter("descriptionCn", descriptionCn) :
                new ObjectParameter("descriptionCn", typeof(string));
    
            var descriptionEnParameter = descriptionEn != null ?
                new ObjectParameter("descriptionEn", descriptionEn) :
                new ObjectParameter("descriptionEn", typeof(string));
    
            var manufactureParameter = manufacture != null ?
                new ObjectParameter("manufacture", manufacture) :
                new ObjectParameter("manufacture", typeof(string));
    
            var certificateParameter = certificate != null ?
                new ObjectParameter("certificate", certificate) :
                new ObjectParameter("certificate", typeof(string));
    
            var lowTemperatureParameter = lowTemperature.HasValue ?
                new ObjectParameter("lowTemperature", lowTemperature) :
                new ObjectParameter("lowTemperature", typeof(decimal));
    
            var highTemperatureParameter = highTemperature.HasValue ?
                new ObjectParameter("highTemperature", highTemperature) :
                new ObjectParameter("highTemperature", typeof(decimal));
    
            var flameClassParameter = flameClass != null ?
                new ObjectParameter("flameClass", flameClass) :
                new ObjectParameter("flameClass", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetReportMaterials", columnsParameter, materialNumberParameter, materialTypesParameter, descriptionCnParameter, descriptionEnParameter, manufactureParameter, certificateParameter, lowTemperatureParameter, highTemperatureParameter, flameClassParameter, typeParameter);
        }
    
        public virtual ObjectResult<sp_GetTableColumns_Result> sp_GetTableColumns(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetTableColumns_Result>("sp_GetTableColumns", tableNameParameter);
        }
    }
}
