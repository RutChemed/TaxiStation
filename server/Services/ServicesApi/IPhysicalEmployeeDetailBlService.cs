namespace Services.ServicesApi
{
    public interface IPhysicalEmployeeDetailBlService:IBlService<PhysicalEmployeeDetailDTO>
    {
        Task<PhysicalEmployeeDetailDTO?> GetAsyncByEmployee(int id);

    }
}
