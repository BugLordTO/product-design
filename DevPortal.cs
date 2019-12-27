[Route("api/[controller]")]
public class DevController
{
    [HttpGet]
    DevAccount GetDevAccount();
    [HttpPost]
    DevAccount RegisterDevAccount(DevAccountRequest request);
    [HttpPut]
    DevAccount UpdateDevAccount(DevAccountRequest request);
    [HttpDelete]
    void CloseDevAccount();
}

[Route("api/[controller]")]
public class ServiceController
{
    [HttpGet]
    ServiceInfo[] GetService();
    [HttpGet("{id}")]
    ServiceInfo GetService(string id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>Production.SubscribeHookUrl</item>
    /// <item>Sandbox.SubscribeHookUrl</item>
    /// <item>AutoVerify</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost]
    ServiceRegistryInfo RegisterService(ServiceRequest request);
    [HttpPut("{id}")]
    ServiceRegistryInfo UpdateService(string id, ServiceRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ServiceVersionId</returns>
    [HttpPut("{id}/sandbox")]
    ServiceRegistryInfo PublishServiceToSandbox(string id);
    [HttpPut("{id}/v/{serviceVersionId}/production")]
    ServiceRegistryInfo PublishServiceToProduction(string id, string serviceVersionId);
    [HttpDelete("{id}")]
    void CloseService();
    //service version management
}

[Route("api/{serviceid}/[controller]")]
public class FeatureController
{
    [HttpPost("appform")]
    void EnableApplicationForm(ApplicationFormRequest request);
    [HttpPost("reminder")]
    HookRegistry[] EnableReminder(ReminderRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>X Production.ExternalProductApiUrl ?? /product data hook for each product</item>
    /// <item>Production.ProductHookUrl</item>
    /// <item>Production.CartHookUrl</item>
    /// <item>Production.CartResolutionHookUrl</item>
    /// <item>Production.OrderHookUrl</item>
    /// <item>X Sandbox.ExternalProductApiUrl ?? / product data hook for each product</item>
    /// <item>Sandbox.ProductHookUrl</item>
    /// <item>Sandbox.CartHookUrl</item>
    /// <item>Sandbox.CartResolutionHookUrl</item>
    /// <item>Sandbox.OrderHookUrl</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost("cart")]
    HookRegistry[] EnableCart(CartRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>Production.ReceiveEslipHookUrl</item>
    /// <item>Production.UseEslipHookUrl</item>
    /// <item>Sandbox.ReceiveEslipHookUrl</item>
    /// <item>Sandbox.UseEslipHookUrl</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost("eslip")]
    HookRegistry[] EnableEslip(EslipRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>Production.MemberRegisterHookUrl</item>
    /// <item>Sandbox.MemberRegisterHookUrl</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost("membership")]
    HookRegistry[] EnableMembership(MembershipRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>ProductCollectionName</item>
    /// <item>IsAutorunProductId</item>
    /// <item>AutorunProductIdPrefix</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost("database")]
    HookRegistry[] EnableInternalDatabase(DatabaseRequest request);

    [HttpDelete("appform")]
    void DisableApplicationForm();
    [HttpDelete("reminder")]
    void DisableReminder();
    [HttpDelete("cart")]
    void DisableCart();
    [HttpDelete("eslip")]
    void DisableEslip();
    [HttpDelete("membership")]
    void DisableMembership();
    [HttpDelete("database")]
    void DisableInternalDatabase();
}

[Route("api/{serviceid}/[controller]")]
public class MContentController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mcontent">
    /// <list type="bullet">
    /// <item>Production.ContentUrl</item>
    /// <item>Sandbox.ContentUrl</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpGet]
    MContent[] GetMContent();
    [HttpGet("{id}")]
    MContent GetMContent(string id);
    [HttpPost("pages")]
    MContentRegistry RegisterMContent(MContentPage mcontent);
    [HttpPost("forms")]
    MContentRegistry RegisterMContent(MContentForm mcontent);
    [HttpPost("sforms")]
    MContentRegistry RegisterMContent(MContentSecuredForm mcontent);
    [HttpPost("options")]
    MContentRegistry RegisterMContent(MContentOptions mcontent);
    [HttpPut("{id}/pages")]
    MContentRegistry EditMContent(MContentPage mcontent);
    [HttpPut("{id}/forms")]
    MContentRegistry EditMContent(MContentForm mcontent);
    [HttpPut("{id}/sforms")]
    MContentRegistry EditMContent(MContentSecuredForm mcontent);
    [HttpPut("{id}/options")]
    MContentRegistry EditMContent(MContentOption mcontent);
    [HttpPut("{id}/binding")]
    MContentRegistry MContentOptionBinding(MContentOptionBinding binding);
    [HttpDelete("{id}")]
    MContentRegistry DeleteMContent(string id);
}

/// <summary>
/// API สำหรับให้ Dev จัดการ database schema ที่ mana เก็บให้
/// Apply RouteParameter to all API?
/// </summary>
[Route("api/{serviceid}/[controller]")]
public class DbSchemaController
{
    /// <summary>
    /// Get Database Detail => จำเป็นต้องมีมั้ย
    /// </summary>
    /// <returns>Database Detail</returns>
    DatabaseConfigurationDetail GetDatabaseSchema();
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
    DatabaseConfigurationDetail ConfigDatabaseSchema(DatabaseConfiguration configurations);
    /// <summary>
    /// Get single collection schema by name
    /// </summary>
    /// <param name="name">collection name</param>
    /// <returns>Collection Schema</returns>
    CollectionSchemaDetail GetCollectionSchema(string name);
    /// <summary>
    /// Get multiple collection schema
    /// </summary>
    /// <returns>list of collections schemas</returns>
    IEnumerable<CollectionSchemaDetail> GetCollectionSchemas();
    /// <summary>
    /// Create collection schema
    /// </summary>
    /// <param name="schema">
    /// Specify Collection Options
    /// - autorun id
    /// - autorun id prefix
    /// </param>
    /// <returns></returns>
    CollectionSchemaDetail CreateCollectionSchema(CollectionSchema schema);
    /// <summary>
    /// Update collection schema
    /// </summary>
    /// <param name="name">collection name</param>
    /// <param name="schema"></param>
    /// <returns></returns>
    CollectionSchemaDetail UpdateCollectionSchema(string name, CollectionSchema schema);
    /// <summary>
    /// Delete collection schema
    /// </summary>
    /// <param name="name">collection name</param>
    /// <returns></returns>
    void DropCollectionSchema(string name);
}
class DatabaseConfiguration
{
    public string ProductCollectionName { get; set; }
    public bool AutoGenerateProductId { get; set; }
    public bool ProductDataPrefixId { get; set; }
}
class DatabaseConfigurationDetail : DatabaseConfiguration
{
    public DateTime CreatedDate { get; set; }
    public int CollectionCount { get; set; }
}
class CollectionSchema
{
    public string Name { get; set; }
    public string DataPrefixId { get; set; }
    public bool AutoGenerateId { get; set; }
    public IEnumerable<string> Fields { get; set; }
}
class CollectionSchemaDetail : CollectionSchema
{
    public DateTime CreatedDate { get; set; }
}
//=============================> DB
class DatabaseSchema
{
    public string _id { get; set; }
    public string ServiceId { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<CollectionSchema> CollectionSchemas { get; set; }
    
}
class CollectionSchema
{
    public string Name { get; set; }
    public string DataPrefixId { get; set; }
    public bool AutoGenerateId { get; set; }
    public bool IsProductCollection { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<string> Fields { get; set; }
}
//DB <=============================

[Route("api/{serviceid}/[controller]")]
public class SubscriptionController
{
    /// <summary>
    /// Get multiple subscription detail
    /// </summary>
    /// <param name="serviceid"></param>
    /// <returns>list of documents detail</returns>
    [HttpGet]
    Subscription[] GetSubscriptions(string serviceid);
    /// <summary>
    /// Get subscription detail
    /// </summary>
    /// <param name="serviceid"></param>
    /// <param name="id"></param>
    /// <returns>list of documents detail</returns>
    [HttpGet("{id}")]
    Subscription GetSubscription(string serviceid, string id);
    //approve subscription manualy
}
