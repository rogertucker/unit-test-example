namespace DBLayer.Models{
    public class PhoneNumber : BaseModel
    {
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
    }
}