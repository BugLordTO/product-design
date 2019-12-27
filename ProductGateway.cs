[Route("api/{subscriptionid}/[controller]")]
public class ProductController
{
    [HttpGet]
    Product[] Gets();
    [HttpGet("{id}")]
    Product Get(string id);
}
class Product
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string NameExtension { get; set; }
    public string Logo { get; set; }
    public string RefId { get; set; }
    public string Details { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<string> Tags { get; set; }
    // extra data field ...
}
//db ไม่มี/ไม่ได้อยู่ตรงนี้
[Route("api/{subscriptionid}/[controller]/{collection}")]
public class DatabaseController
{
    [HttpGet]
    Document[] Gets(string subscriptionid, string collection);
    [HttpGet("{id}")]
    Document Get(string subscriptionid, string collection, string id);
}
class Document
{
    public string _id { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public DateTime CreatedDate { get; set; }
    // extra data field ...
}
