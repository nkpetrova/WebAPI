namespace WebAPI.Domain
{
    public class TurFirma
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Address { get;  set; }
        public int Commission { get;  set; }

        public TurFirma(int id, string name, string address, int commission)
        {
            Id = id;
            Name = name;
            Address = address;
            Commission = commission;
        }
    }
}