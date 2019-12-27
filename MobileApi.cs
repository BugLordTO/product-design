public class MerchantController
{
    [HttpGet]
    Merchant[] Gets();
    [HttpGet("{id}")]
    Merchant Get(string id);
    [HttpPost]
    Merchant Create(Merchant merchant);
    [HttpPut("{id}")]
    Merchant Update(Merchant merchant);
    // financial
    // topup / withdraw
    // employee
    // co-owner
}

[Route("api/{merchantId}/[controller]")]
public class SubscriptionController
{
    [HttpGet]
    Subscription[] GetSubscriptions();
    [HttpGet("{id}")]
    Subscription GetSubscription(string id);
    /// <summary>
    /// Subscribe Service -> hook prefix or subscriptionid??? to SubscriptionHookUrl 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ClientResponse</returns>
    [HttpPost("{id}")]
    ClientResponse SubscribeService(string id);
}
