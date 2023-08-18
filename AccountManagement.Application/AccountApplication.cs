using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application;

public class AccountApplication : IAccountApplication
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IFileUploader _fileUploader;
    private readonly IRoleRepository _roleRepository;
    private readonly IAuthHelper _authHelper;

    public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
        IFileUploader fileUploader, IRoleRepository roleRepository, IAuthHelper authHelper)
    {
        _accountRepository = accountRepository;
        _passwordHasher = passwordHasher;
        _fileUploader = fileUploader;
        _roleRepository = roleRepository;
        _authHelper = authHelper;
    }

    public OperationResult ChangePassword(ChangePassword command)
    {
        var operation = new OperationResult();
        var account = _accountRepository.Get(command.Id);
        if (account == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (command.Password != command.RePassword)
            return operation.Failed(ApplicationMessages.PasswordsNotMatch);

        var password = _passwordHasher.Hash(command.Password);
        account.ChangePassword(password);
        _accountRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Edit(EditAccount command)
    {
        var operation = new OperationResult();
        var account = _accountRepository.Get(command.Id);
        if (account == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (_accountRepository.Exist(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var fileNameUniqe = CreateFileName().ToString();
        var path = "profilePhotos";
        var picturePath = _fileUploader.Upload(command.ProfilePhoto, path, fileNameUniqe,2);
        account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, picturePath);
        _accountRepository.SaveChanges();
        return operation.Succedded();
    }

    public AccountViewModel GetAccountBy(long id)
    {
        throw new NotImplementedException();
    }

    public List<AccountViewModel> GetAccounts()
    {
        throw new NotImplementedException();
    }

    public EditAccount GetDetails(long id)
    {
        return _accountRepository.GetDetails(id);
    }

    public void Logout()
    {
        _authHelper.SignOut();
    }

    public OperationResult Create(CreateAccount command)
    {
        var operation = new OperationResult();

        if (_accountRepository.Exist(x => x.Username == command.Username || x.Mobile == command.Mobile))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var password = _passwordHasher.Hash(command.Password);

        var path = "ProfilePics";
        var fileNameUniqe = CreateFileName().ToString();

        var picturePath = _fileUploader.Upload(command.ProfilePhoto, path, fileNameUniqe,2);
        var account = new Account(command.Fullname, command.Username, password, command.Mobile, command.RoleId,
            picturePath);
        _accountRepository.Create(account);
        _accountRepository.SaveChanges();
        return operation.Succedded();
    }

    public string CreateFileName()
    {

        Guid g = Guid.NewGuid();
        string GuidString = Convert.ToBase64String(g.ToByteArray());
        GuidString = GuidString.Replace("=", "");
        GuidString = GuidString.Replace("+", "");
        GuidString = GuidString.Replace("/", "");
        GuidString = GuidString.Replace(@"\", "");
        return GuidString;
    }

    public List<AccountViewModel> Search(AccountSearchModel searchModel)
    {
        return _accountRepository.Search(searchModel);
    }


    public OperationResult Login(Login command)
    {
        var operation = new OperationResult();
        var account = _accountRepository.GetBy(command.Username);
        if (account == null)
            return operation.Failed(ApplicationMessages.WrongUserPass);

        var result = _passwordHasher.Check(account.Password, command.Password);
        if (!result.Verified)
            return operation.Failed(ApplicationMessages.WrongUserPass);

        //var permissions = _roleRepository.Get(account.RoleId)
        //    .Permissions
        //    .Select(x => x.Code)
        //    .ToList();

        var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname
            , account.Username, account.Mobile);
        //, permissions
        _authHelper.Signin(authViewModel);
        return operation.Succedded();
    }
}
