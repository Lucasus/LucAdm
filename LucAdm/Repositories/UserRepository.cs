namespace LucAdm
{
    public class UserRepository : Repository<User, PersistenceContext>
    {
        public UserRepository(PersistenceContext context) : base(context)
        {
        }
    }
}