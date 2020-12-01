namespace Footballista.Game.Domain.Clubs.Teams
{
    public class Manager
    {
        public int Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }

        public Manager(string firstname, string lastname) : this(1000, firstname, lastname)
        {
        }
        public Manager(int id, string firstname, string lastname)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
    };
}
