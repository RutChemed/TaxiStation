namespace DBAccess.DalApi
{
    public interface ILoginRepository
    {
        Task<TechnicalEmployeeDetail?> GetUserByEmailAsync(string email);

    }
}
