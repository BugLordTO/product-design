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

[Route("api/{subscriptionid}/[controller]")]
public class CartController
{
    [HttpPost("cart")]
    Cart RegisterCart();
    [HttpPost("cart/options")]
    Cart RegisterCartOptions();
    /// <summary>
    /// Get default cart 
    /// </summary>
    [HttpGet("cart/base")]
    CartRegistry CartBase(string serviceId, string merchantId);
    /// <summary>
    /// Create default cart 
    /// </summary>
    [HttpPost("cart/base")]
    CartRegistry CartBase(string serviceId, string merchantId, Cart baseCart);
    /// <summary>
    /// Send bill to user after checkout
    /// </summary>
    [HttpPost("cart/bill")]
    void SendBill(string serviceId, string merchantId, string cartId, Bill bill);

}

[Route("api/{subscriptionid}/[controller]")]
public class ManaProductController
{
    /// <summary>
    /// Get all product registry
    /// </summary>
    IEnumerable<ProductRegistry> GetAllManaProducts(string prefix);
    /// <summary>
    /// Register product
    /// </summary>
    ManaLinkRegistry RegisterManaProduct(string prefix, string refid);
    /// <summary>
    /// Register multiple products
    /// </summary>
    IEnumerable<ManaLinkRegistry> RegisterManaProductBatch(string prefix, IEnumerable<string> refids);
    // remove/disable/suspend ManaProduct qr/endpoint

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

[Route("api/{subscriptionid}/[controller]")]
public class ProductController
{
    [HttpGet]
    Product[] GetProducts();
    [HttpGet("{id}")]
    Product GetProduct(string subscriptionid, string id);
    [HttpPost]
    ProductRegistry RegisterProduct(string subscriptionid, Product product);
    [HttpPut("{id}")]
    ProductRegistry EditProduct(string subscriptionid, Product product);
    [HttpDelete("{id}")]
    ProductRegistry DeleteProduct(string subscriptionid, string id);
    //[HttpPost("{id}")]
    //ProductRegistry RegisterProductOption(string subscriptionid, ProductOption productOption);
}

[Route("api/{subscriptionid}/[controller]")]
public class DatabaseController
{
    /// <summary>
    /// Generate id
    /// </summary>
    /// <param name="prefix">กำหนด prefix ของ id</param>
    /// <param name="options">???</param>
    /// <returns>generated id</returns>
    [HttpPost("{prefix}")]
    string GenerateId(string serviceid, string subscriptionid, string prefix, GenerateIdOptions options = null);

    /// <summary>
    /// Get single document detail by id
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="querySyntax">???</param>
    /// <returns>document detail</returns>
    [HttpGet("{collectionName}/{id}")]
    Document GetDocument(string serviceid, string subscriptionid, string collectionName, string id, string querySyntax);
    /// <summary>
    /// Get multiple documents detail
    /// </summary>
    /// <param name="querySyntax">???</param>
    /// <returns>list of documents detail</returns>
    [HttpGet("{collectionName}")]
    IEnumerable<Document> GetDocuments(string serviceid, string subscriptionid, string collectionName, string querySyntax);
    /// <summary>
    /// Create document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="document">Creating document</param>
    /// <returns></returns>
    [HttpPost("{collectionName}")]
    Response CreateDocument(string serviceid, string subscriptionid, string collectionName, Document document);
    /// <summary>
    /// Edit document to specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">document id</param>
    /// <param name="document">Editing document</param>
    /// <returns></returns>
    [HttpPut("{collectionName}/{id}")]
    Response EditDocument(string serviceid, string subscriptionid, string collectionName, string id, Document document);
    /// <summary>
    /// Delete document from specify collection
    /// </summary>
    /// <param name="collectionName">collection id</param>
    /// <param name="id">The document id</param>
    /// <returns></returns>
    [HttpDelete("{collectionName}/{id}")]
    Response DeleteDocument(string serviceid, string subscriptionid, string collectionName, string id);
    //backup whole db
}
