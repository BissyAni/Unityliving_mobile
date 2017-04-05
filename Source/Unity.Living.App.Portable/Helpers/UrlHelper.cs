namespace Unity.Living.App.Portable.Helpers
{
    public static class UrlHelper
    {
        public static string BaseUrl = "http://mobile.unityliving.com/";
        public static string HouseDues = "dues-house-view/?house={0}";
        public static string DuesReceiptList = "dues-receipt-list/?house={0}";
        public static string PayAdvanceOnlinePayment = "pay-advance-online-payment/?house=";
        public static string DuesOnlineSettle = "dues-online-settle-save/?house=";
        public static string PaiditemCreate = "paiditem/create/";
        public static string ChargeItemView = "charge-item-view/?house_id={0}&charge_item_id={1}";
        public static string DuesReceiptView = "dues-receipt-view/?id={0}";
        public static string DuesSettle = "dues-settle/?house=";
        public static string PayuPayment = "https://secure.payu.in/_payment";
        public static string ServiceRequestCreate = "servicerequest-create/";
        public static string ServiceRequest = "servicerequest/";
        public static string LatestServiceRequest = "servicerequest-latest/";
        public static string ServiceRequestView = "servicerequest-view/?service=";
        public static string HouseAccountStatement = "house-account-statement/?house={0}";
        public static string HouseDuesAccountStatement = "house-dues-account-statement/?house={0}";
        public static string HouseAdvanceAccountStatement = "house-advance-account-statement/?house={0}";
        public static string Overview = "overview/";
        public static string HouseView = "house-view/?house={0}";
        public static string EditHouse = "house-details-edit/?house={0}";
        public static string EditOwner = "house-owner-edit/?house={0}";
        public static string EditTenant = "house-tenant-edit/?house={0}";
        public static string UserDetails = "user-details/?id=";
        public static string ChangePassword = "change-password/";
        public static string AutoComplete = "sites-autocomplete/";
    }
}
