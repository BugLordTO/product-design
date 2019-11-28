using System.Linq;
using System.Collections.Generic;

/// <summary>
/// จัดการข้อมูลที่ mana เก็บให้
/// Apply RouteParameter to all API?
/// </summary>
interface DatabaseManagementAPI
{
    /// <summary>
    /// Generate id
    /// </summary>
    /// <param name="prefix">กำหนด prefix ของ id</param>
    /// <param name="options">???</param>
    /// <returns>generated id</returns>
    string GenerateId(string prefix, GenerateIdOptions options = null);

    /// <summary>
    /// Get single document detail by id
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="querySyntax">???</param>
    /// <returns>document detail</returns>
    Document GetDocument(string collectionName, string id, string querySyntax);
    /// <summary>
    /// Get multiple documents detail
    /// </summary>
    /// <param name="querySyntax">???</param>
    /// <returns>list of documents detail</returns>
    IEnumerable<Document> GetDocuments(string collectionName, string querySyntax);
    /// <summary>
    /// Create document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="document">Creating document</param>
    /// <returns></returns>
    Response CreateDocument(string collectionName, Document document);
    /// <summary>
    /// Edit document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="document">Editing document</param>
    /// <returns></returns>
    Response EditDocument(string collectionName, string id, Document document);
    /// <summary>
    /// Delete document from specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">The document id</param>
    /// <returns></returns>
    Response DeleteDocument(string collectionName, string id);
}

class GenerateIdOptions { }
class Document { }

/// <summary>
/// API สำหรับให้ Dev จัดการ database schema ที่ mana เก็บให้
/// Apply RouteParameter to all API?
/// </summary>
interface DatabaseSchemaManagementAPI
{
    //TODO: GetDatabaseDetail, ConfigDatabase จำเป็นต้องมีมั้ย
    /// <summary>
    /// Get Database Detail
    /// </summary>
    /// <returns>Database Detail</returns>
    DatabaseDetail GetCurrentDatabaseSchema();
    /// <summary>
    /// Config Database
    /// </summary>
    /// <param name="configurations">
    /// Specify database options
    /// - Product collection name
    /// - autorun id for Product collection 
    /// - autorun id prefix for Product collection
    /// - bla..
    /// </param>
    /// <returns>Database Detail</returns>
    DatabaseDetail ConfigCurrentDatabaseSchema(DatabaseConfigurations configurations);
    Response ApplyToSandboxEnvironment(DatabaseConfigurations configurations);
    Response ApplyToProductionEnvironment(DatabaseConfigurations configurations);

    /// <summary>
    /// Get single collection detail by id
    /// </summary>
    /// <param name="collectionId">collection Id</param>
    /// <param name="id">collection id</param>
    /// <returns>Collection Detail</returns>
    CollectionDetail GetCollectionDetail(string collectionId);
    /// <summary>
    /// Get multiple collections detail
    /// </summary>
    /// <returns>list of collections detail</returns>
    IEnumerable<CollectionDetail> GetCollectionDetails();
    /// <summary>
    /// Create additional collection 
    /// - 
    /// </summary>
    /// <param name="collectionName">collection Name</param>
    /// <param name="schemas">
    /// Specify Collection Options
    /// - autorun id
    /// - autorun id prefix
    /// </param>
    /// <returns></returns>
    Response CreateCollection(string collectionName, CollectionSchemas schemas);
    /// <summary>
    /// Config additional collection
    /// </summary>
    /// <param name="collectionId">collection Id</param>
    /// <param name="schemas">
    /// Specify Collection Options
    /// - autorun id
    /// - autorun id prefix
    /// </param>
    /// <returns></returns>
    Response ConfigCollection(string collectionId, CollectionSchemas schemas);
    /// <summary>
    /// Delete additional collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <returns></returns>
    Response DeleteCollection(string collectionId);
    IEnumerable<CollectionMappings> GetCollectionMappings();
    Response SetupCollectionMappings(IEnumerable<CollectionMappings> mappings);
}

class DatabaseDetail { }
class DatabaseConfigurations { }
class CollectionDetail { }
class CollectionSchemas { }
class CollectionMappings { }

/// <summary>
/// API สำหรับลงทะเบียน product ให้ mana app เปิดได้
/// </summary>
interface ThirdAPI
{
    //register dev
    //register add product hook
    //register cart hook
    //register order hook
    //register payment hook
    /// <summary>
    /// Get all product registry
    /// </summary>
    IEnumerable<ProductRegistry> GetAllProductRegistries(string prefix);
    /// <summary>
    /// Register product
    /// </summary>
    ManaLinkRegistry RegisterProduct(string prefix, string refid);
    /// <summary>
    /// Register multiple products
    /// </summary>
    IEnumerable<ManaLinkRegistry> RegisterProductBatch(string prefix, IEnumerable<string> refids);
    /// <summary>
    /// Register ProductOptions
    /// </summary>
    ProductOptionsRegistry RegisterProductOptions(string serviceId, string mcontentId);
    /// <summary>
    /// Create Database
    /// </summary>
    /// <param name="databaseName"></param>
    /// <param name="configurations">
    /// Specify database options
    /// - Product collection name
    /// - autorun id for Product collection 
    /// - autorun id prefix for Product collection
    /// - bla..
    /// </param>
    /// <returns></returns>
    DatabaseDetail CreateDatabase(string databaseName, DatabaseConfigurations configurations);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    void RegisterProductApi(ProductApiRequest request);
}

//TODO:
//db for each merchant ? => use merchant id
//create db when merchant subscribe?
//- db api seperate => schema (setup) / access data (use)
//sql ddl ?
//update schema => old data => version

class ProductRegistry { }
class ManaLinkRegistry { }
class ProductOptionsRegistry { }
class ProductApiRequest { }

/// <summary>
/// API ที่ mobile ดึงข้อมูล product ไปแสดง
/// </summary>
interface ManaMobileAPI
{
    /// <summary>
    /// May be include options
    /// </summary>
    /// <param name="id">product id</param>
    /// <returns></returns>
    Product GetProduct(string id);
    /// <summary>
    /// Get Product MContent
    /// </summary>
    /// <param name="id">product id</param>
    /// <returns></returns>
    MContent GetProductMContent(string id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">product id</param>
    /// <returns></returns>
    ProductOptions GetProductOptions(string id);
    //merchant subscribe service
}

class Product { }
class ProductOptions { }
class MContent { }

class RouteParameter { }
class Response { }