[Route("api/{subscriptionid}/[controller]")]
public class ApplicationFormController
{
    [HttpGet]
    ApplicationForm[] GetApplicationForm();
    [HttpGet("{id}")]
    ApplicationForm GetApplicationForm(string serviceid, string subscriptionid, string id);
    [HttpPost]
    ApplicationFormRegistry RegisterApplicationForm(string serviceid, string subscriptionid, ApplicationForm applicationForm);
    [HttpPut("{id}")]
    ApplicationFormRegistry EditApplicationForm(string serviceid, string subscriptionid, ApplicationForm applicationForm);
    [HttpDelete("{id}")]
    ApplicationFormRegistry DeleteApplicationForm(string serviceid, string subscriptionid, string id);
}

[Route("api/{subscriptionid}/[controller]")]
public class EslipController
{
    [HttpGet("/api/{serviceid}/eslips/stubs")]
    EslipStub[] GetEslipStubInService(string serviceid);
    [HttpGet("/api/{serviceid}/eslips/stubs/expired")]
    EslipStub[] GetExpiredEslipStubInService(string serviceid);
    [HttpGet("/api/{serviceid}/eslips/stubs/all")]
    EslipStub[] GetAllEslipStubInService(string serviceid);
    [HttpGet("/api/{serviceid}/eslips/stubs/tags/{tags}")]
    EslipStub[] GetEslipStubInServiceByTags(string serviceid, string tags);

    [HttpGet("stubs")]
    EslipStub[] GetEslipStub(string serviceid, string subscriptionid);

    //quota
    //distribution
    //tail
}

[Route("api/{subscriptionid}/[controller]")]
public class MembershipController
{
    //members
    //broadcast
    //send point
    //send eslip
}

[Route("api/{subscriptionid}/[controller]")]
public class ReminderController
{

}

[Route("api/service/{serviceId}/merchant/{merchantId}/[controller]")]
public class CartController
{
    /// <summary>
    /// 
    /// </summary>
    [HttpPost()]
    Cart RegisterCart();
    /// <summary>
    /// 
    /// </summary>
    [HttpPost("options")]
    Cart RegisterCartOptions();
    /// <summary>
    /// Get default cart 
    /// </summary>
    [HttpGet("base")]
    Cart CartBase(string serviceId, string merchantId);
    /// <summary>
    /// Create default cart 
    /// </summary>
    [HttpPost("base")]
    Cart CartBase(string serviceId, string merchantId, Cart baseCart);
    /// <summary>
    /// Send bill to user after checkout
    /// </summary>
    [HttpPost("bill")]
    void SendBill(string serviceId, string merchantId, string cartId, Bill bill);
}

[Route("api/service/{serviceId}/merchant/{merchantId}/[controller]")]
public class ManaProductController
{
    /// <summary>
    /// Get all product registry
    /// </summary>
    [HttpGet()]
    IEnumerable<ProductRegistry> GetAllManaProducts(string serviceId,string merchantId);
    /// <summary>
    /// Get a product 
    /// </summary>
    [HttpGet("{refid}")]
    IEnumerable<ProductRegistry> GetManaProduct(string serviceId,string merchantId, string refid);
    /// <summary>
    /// Register product
    /// </summary>
    [HttpPost("{refid}/mcontent/{mcintentId}")]
    ManaLinkRegistry RegisterManaProduct(string serviceId,string merchantId, string refid, string mcontentId);
    /// <summary>
    /// Register multiple products
    /// </summary>
    [HttpPost("mcontent/{mcintentId}")]
    IEnumerable<ManaLinkRegistry> RegisterManaProductBatch(string serviceId,string merchantId, IEnumerable<string> refids, string mcontentId);
    // remove/disable/suspend ManaProduct qr/endpoint

    /// <summary>
    /// Updatw product
    /// </summary>
    [HttpPut("{refid}/mcontent/{mcintentId}")]
    ManaLinkRegistry UpdateManaProduct(string serviceId,string merchantId, string refid, string mcontentId);
    /// <summary>
    /// Updatw product
    /// </summary>
    [HttpDelete("{refid}")]
    ManaLinkRegistry RemoveManaProduct(string serviceId,string merchantId, string refid);


    //***** /// <summary>
    //***** /// Register ProductOptions
    //***** /// </summary>
    //***** ProductOptionsRegistry RegisterProductOptions(string serviceId, string mcontentId);
    //***** /// <summary>
    //***** /// ???
    //***** /// </summary>
    //***** /// <param name="request"></param>
    //***** void RegisterProductApi(ProductApiRequest request);
}

[Route("api/service/{serviceId}/merchant/{merchantId}/[controller]")]
public class ProductController
{
    [HttpGet]
    Product[] GetProducts();
    [HttpGet("{id}")]
    Product GetProduct(string serviceId,string merchantId, string id);
    [HttpPost]
    ProductRegistry RegisterProduct(string serviceId,string merchantId, Product product);
    [HttpPut]
    ProductRegistry EditProduct(string serviceId,string merchantId, Product product);
    [HttpDelete("{id}")]
    ProductRegistry DeleteProduct(string serviceId,string merchantId, string id);
    //[HttpPost("{id}")]
    //ProductRegistry RegisterProductOption(string subscriptionid, ProductOption productOption);
}

[Route("api/subscription/{subscriptionid}/[controller]")]
public class DatabaseController
{
    /// <summary>
    /// Generate id
    /// </summary>
    /// <param name="prefix">กำหนด prefix ของ id</param>
    /// <param name="options">???</param>
    /// <returns>generated id</returns>
    [HttpPost("{prefix}")]
    string GenerateId(string subscriptionid, string prefix, GenerateIdOptions options = null);

    /// <summary>
    /// Get single document detail by id
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="querySyntax">???</param>
    /// <returns>document detail</returns>
    [HttpGet("collection/{name}/document/{id}/qry/{querySyntax}")]
    Document GetDocument(string subscriptionid, string name, string id, string querySyntax);
    /// <summary>
    /// Get multiple documents detail
    /// </summary>
    /// <param name="querySyntax">???</param>
    /// <returns>list of documents detail</returns>
    [HttpGet("collection/{name}/qry/{querySyntax}")]
    IEnumerable<Document> GetDocuments(string subscriptionid, string name, string querySyntax);
    /// <summary>
    /// Create document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="document">Creating document</param>
    /// <returns></returns>
    [HttpPost("collection/{name}")]
    Response CreateDocument(string subscriptionid, string name, Document document);
    /// <summary>
    /// Edit document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="document">Editing document</param>
    /// <returns></returns>
    [HttpPut("collection/{name}/document/{id}")]
    Response EditDocument(string subscriptionid, string name, string id, Document document);
    /// <summary>
    /// Delete document from specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">The document id</param>
    /// <returns></returns>
    [HttpDelete("collection/{name}/document/{id}")]
    Response DeleteDocument(string subscriptionid, string name, string id);
    //backup whole db
}
