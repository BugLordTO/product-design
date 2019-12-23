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

public class ServiceController
{
    [HttpGet]
    DevAccount GetService();
    [HttpGet("{id}")]
    DevAccount GetService(string id);
    [HttpPost]
    ServiceRegistryInfo RegisterService(ServiceRequest request);
    [HttpPut]
    ServiceRegistryInfo UpdateService(ServiceRequest request);
    [HttpPost]
    ServiceRegistryInfo PublishService(ServiceRequest request);
    [HttpDelete]
    void CloseService();
}

public class FeatureController
{
    [HttpPost]
    HookRegistry EnableFeatureApplicationForm(ApplicationFormRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>ProductHookUrl_prod</item>
    /// <item>CartHookUrl_prod</item>
    /// <item>CartResolutionHookUrl_prod</item>
    /// <item>OrderHookUrl_prod</item>
    /// <item>ProductHookUrl_sand</item>
    /// <item>CartHookUrl_sand</item>
    /// <item>CartResolutionHookUrl_sand</item>
    /// <item>OrderHookUrl_sand</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost]
    HookRegistry EnableFeatureCart(CartRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>ReceiveEslipHookUrl_prod</item>
    /// <item>UseEslipHookUrl_prod</item>
    /// <item>ReceiveEslipHookUrl_sand</item>
    /// <item>UseEslipHookUrl_sand</item>
    /// <item>UseEslipContentUrl_sand</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost]
    HookRegistry EnableFeatureEslip(EslipRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request">
    /// <list type="bullet">
    /// <item>MemberRegisterHookUrl_prod</item>
    /// <item>MemberRegisterHookUrl_sand</item>
    /// </list>
    /// </param>
    /// <returns></returns>
    [HttpPost]
    HookRegistry EnableFeatureMembership(MembershipRequest request);
}

public class MContentController
{
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
public class DbSchemaController
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
    Response DeployToSandboxEnvironment(DatabaseConfigurations configurations);
    Response DeployToProductionEnvironment(DatabaseConfigurations configurations);

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
    Response DropCollection(string collectionId);
    IEnumerable<CollectionMappings> GetCollectionMappings();
    Response SetupCollectionMappings(IEnumerable<CollectionMappings> mappings);
}
