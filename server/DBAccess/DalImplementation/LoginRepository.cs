using DBAccess.DalApi;
namespace DBAccess.DalImplementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TaxiStationContext _taxiStationContext;

        public LoginRepository(TaxiStationContext taxiStationContext)
        {
            _taxiStationContext = taxiStationContext;
        }

        public async Task<TechnicalEmployeeDetail?> GetUserByEmailAsync(string email)
        {
            return await _taxiStationContext.TechnicalEmployeeDetails.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
