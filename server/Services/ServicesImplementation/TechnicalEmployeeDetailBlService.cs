namespace Services.ServicesImplementation
{
    public class TechnicalEmployeeDetailBlService
    {
        private readonly IMapper _mapper;
        public TechnicalEmployeeDetailBlService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
//public class UserController : Controller
//{
//    private readonly IMapper _mapper;
//    public UserController(IMapper mapper)
//    {
//        _mapper = mapper;
//    }
//    public IActionResult Index()
//    {
//        // Populate the user details from DB
//        var user = GetUserDetails();
//        UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
//        return View(userViewModel);
//    }
//}
