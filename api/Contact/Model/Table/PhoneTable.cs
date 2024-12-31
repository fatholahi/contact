namespace Contact.Model.Table
{
    public class PhoneTable
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public byte PhoneTypeId { get; set; }
        public string Number { get; set; }
    }
}
