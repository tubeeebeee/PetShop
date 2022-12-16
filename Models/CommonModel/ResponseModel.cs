namespace PetShop.Models.CommonModel
{
    public class ResponseModel
    {
        public bool IsError { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
