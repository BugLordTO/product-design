using System.Linq;
using System.Collections.Generic;

/// <summary>
/// API สำหรับให้ Dev จัดการ product ที่ mana เก็บให้
/// Apply RouteParameter to all API?
/// </summary>
interface ProductManageAPI
{
    /// <summary>
    /// Generate id
    /// </summary>
    /// <param name="prefix">กำหนด prefix ของ id</param>
    /// <param name="options">???</param>
    /// <returns>generated id</returns>
    string GenerateId(string prefix, GenerateIdOptions options = null);

    /// <summary>
    /// Create Database
    /// </summary>
    /// <param name="databaseName"></param>
    /// <param name="configurations">
    /// Specify database options
    /// - Product collection name
    /// - autorun id for Product collection 
    /// - autorun id prefix for Product collection
    /// </param>
    /// <returns></returns>
    DatabaseDetail CreateDatabase(string databaseName, DatabaseConfigurations configurations);
    /// <summary>
    /// Get Database Detail
    /// </summary>
    /// <returns>Database Detail</returns>
    DatabaseDetail GetDatabaseDetail();
    /// <summary>
    /// Config Database
    /// </summary>
    /// <param name="configurations">
    /// Specify database options
    /// - Product database name
    /// </param>
    /// <returns>Database Detail</returns>
    DatabaseDetail ConfigDatabase(DatabaseConfigurations configurations);

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
    /// </summary>
    /// <param name="collectionName">collection Name</param>
    /// <param name="configurations">
    /// Specify Collection Options
    /// - autorun id
    /// - autorun id prefix
    /// </param>
    /// <returns></returns>
    Response CreateCollection(string collectionName, CollectionConfigurations configurations);
    /// <summary>
    /// Config additional collection
    /// </summary>
    /// <param name="collectionId">collection Id</param>
    /// <param name="configurations">
    /// Specify Collection Options
    /// - autorun id
    /// - autorun id prefix
    /// </param>
    /// <returns></returns>
    Response ConfigCollection(string collectionId, CollectionConfigurations configurations);
    /// <summary>
    /// Delete additional collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <returns></returns>
    Response DeleteCollection(string collectionId);

    /// <summary>
    /// Get single document detail by id
    /// </summary>
    /// <param name="id">document id</param>
    /// <param name="querySyntax">???</param>
    /// <returns>document detail</returns>
    Document GetDocument(string collectionId, string id, string querySyntax);
    /// <summary>
    /// Get multiple documents detail
    /// </summary>
    /// <param name="querySyntax">???</param>
    /// <returns>list of documents detail</returns>
    IEnumerable<Document> GetDocuments(string collectionId, string querySyntax);
    /// <summary>
    /// Create document to specify collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="document">Creating document</param>
    /// <returns></returns>
    Response CreateDocument(string collectionId, Document document);
    /// <summary>
    /// Edit document to specify collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="document">Editing document</param>
    /// <returns></returns>
    Response EditDocument(string collectionId, string id, Document document);
    /// <summary>
    /// Delete document from specify collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="id">The document id</param>
    /// <returns></returns>
    Response DeleteDocument(string collectionId, string id);
}

class GenerateIdOptions { }
class DatabaseConfigurations { }
class DatabaseDetail { }
class CollectionDetail { }
class CollectionConfigurations { }
class Document { }
class CreateDocumentOptions { }

/// <summary>
/// API สำหรับลงทะเบียน product ให้ mana app เปิดได้
/// </summary>
interface ThirdAPI
{
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
    IEnumerable<ManaLinkRegistry> RegisterProductBatch(string prefix, IEnumerable<string> refid);
    /// <summary>
    /// Register ProductOptions
    /// </summary>
    ProductOptionsRegistry RegisterProductOptions(string serviceId, string mcontentId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    void RegisterProductApi(ProductApiRequest request);
}

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
}

class Product { }
class ProductOptions { }
class MContent { }

class RouteParameter { }
class Response { }
