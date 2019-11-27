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
    //#region Query GraphQL implementation
    ///// <summary>
    ///// Get single product detail by id
    ///// </summary>
    ///// <param name="id">product id</param>
    ///// <param name="querySyntax">???</param>
    ///// <returns>product detail</returns>
    //Product GetProduct(string id, string querySyntax);
    ///// <summary>
    ///// Get multiple products detail
    ///// </summary>
    ///// <param name="querySyntax">???</param>
    ///// <returns>list of products detail</returns>
    //IEnumerable<Product> GetProducts(string querySyntax);
    //#endregion Query GraphQL implementation
    ///// <summary>
    ///// Create product
    ///// </summary>
    ///// <param name="product">products detail to create</param>
    ///// <param name="options">XXX create option eg. auto use runnumber => use pre config</param>
    ///// <returns></returns>
    //Response CreateProduct(Product product, CreateDocumentOptions options = null);
    ///// <summary>
    ///// Edit product detail
    ///// </summary>
    ///// <param name="product">editing product detail</param>
    ///// <returns></returns>
    //Response EditProduct(Product product);
    ///// <summary>
    ///// Delete product
    ///// </summary>
    ///// <param name="id">product id to delete</param>
    ///// <returns></returns>
    //Response DeleteProduct(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="databaseName"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    DatabaseDetail InitDatabase(string databaseName, InitDatabaseOptions options);
    /// <summary>
    /// Get single document detail by id
    /// </summary>
    /// <param name="id">document id</param>
    /// <param name="querySyntax">???</param>
    /// <returns>document detail</returns>
    Product GetDocument(string collectionId, string id, string querySyntax);
    /// <summary>
    /// Get multiple documents detail
    /// </summary>
    /// <param name="querySyntax">???</param>
    /// <returns>list of documents detail</returns>
    IEnumerable<Product> GetDocument(string collectionId, string querySyntax);
    /// <summary>
    /// Init additional collection for collect data
    /// </summary>
    /// <param name="collectionName">collection name</param>
    /// <returns>created collection detail</returns>
    CollectionDetail InitCollection(string collectionName);
    /// <summary>
    /// Create additional document to specify collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="document">The document</param>
    /// <returns></returns>
    Response CreateDocument(string collectionId, Document document, CreateDocumentOptions options = null);
    /// <summary>
    /// Edit additional document to specify collection
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="document">The document</param>
    /// <returns></returns>
    Response EditDocument(string collectionId, Document document);
    /// <summary>
    /// Delete additional document
    /// </summary>
    /// <param name="collectionId">collection id</param>
    /// <param name="id">The document id</param>
    /// <returns></returns>
    Response DeleteDocument(string collectionId, string id);
}

//- create db => product collection name, auto run id
//- create collection => collection name, auto run id
//- register api

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
    /// Register ProductOptions
    /// </summary>
    ProductOptionsRegistry RegisterProductOptions(string serviceId, string mcontentId);

    DBRegistry CreateDB(string prefix,string productCollectionName);

    void RegisterProductApi(ProductApiRequest request);

}

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

class RouteParameter
{

}

class InitDatabaseOptions
{

}

class DatabaseDetail
{

}

class GenerateIdOptions
{

}

class Product
{

}

class MContent
{

}

class CreateDocumentOptions
{

}

class ProductRegistry
{

}

class ProductOptionsRegistry
{

}

class ProductOptions
{

}

class ManaLinkRegistry
{

}

class Response
{

}

class CollectionDetail
{

}

class Document
{

}