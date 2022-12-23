namespace DocutilAppLibrary.Models;

public class SubscriptionModel
{
    public string Id { get; set; }
    public string SubscriptionType { get; set; }
    public string PaymentInfo { get; set; }
    public BasicUserModel SubsribedUser { get; set; }

}

