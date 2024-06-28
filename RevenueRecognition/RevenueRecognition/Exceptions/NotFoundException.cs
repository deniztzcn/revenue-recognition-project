namespace RevenueRecognition.Exceptions;

public abstract class NotFoundException(string message): Exception(message);
public class IndividualClientNotFound(int id): NotFoundException($"Individual client with id {id} is not found!");
public class CompanyClientNotFound(int id): NotFoundException($"Company client with id {id} is not found!");
public class SoftwareLicenseNotFound(int id): NotFoundException($"Software license with id {id} is not found!");
public class ClientNotFound(int id): NotFoundException($"Client with id {id} is not found!");
public class ContractNotFound(int id): NotFoundException($"Contract with id {id} is not found!");
public class UserNotFound(string username) : NotFoundException($"User with username {username} not found.");