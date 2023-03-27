namespace Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public List<Cuisine>? Cuisines { get; set; }
    }
}
