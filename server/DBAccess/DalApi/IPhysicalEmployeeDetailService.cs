namespace DBAccess.DalApi
{
    public interface IPhysicalEmployeeDetailService:ICrud<PhysicalEmployeeDetail>
    {
        Task<PhysicalEmployeeDetail?> GetAsyncByEmployee(int id);

    }
}
