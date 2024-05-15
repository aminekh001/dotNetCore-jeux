namespace jeuxVedio.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set;}
        
        //manytoOne
        public List<Weapon> Weapons { get; set;}

        public List<Team> Teams { get; set;}
    }
}
