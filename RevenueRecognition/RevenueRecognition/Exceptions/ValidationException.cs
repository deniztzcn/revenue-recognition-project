namespace RevenueRecognition.Exceptions;

public abstract class ValidationException(string message) : Exception(message);
public class PeselExistsException(string pesel): ValidationException($"PESEL {pesel} already exists!");
public class KrsExistsException(string krs) : ValidationException($"KRS {krs} already exists!");
public class PaymentDatePassedException(DateTime dateTime): ValidationException($"Payment date {dateTime} is passed!");
public class PaymentExceedsTheContractPriceException(float difference): ValidationException($"Payment exceeds the contract price by {difference}");
public class ContractAlreadyExistsException(int clientId, int softwareLicenseId): ValidationException($"A contract already exists for " +
    $"client ID {clientId} with software license ID {softwareLicenseId}.");
public class InvalidContractDurationException(): ValidationException("Contract duration must be between 1, 2 or 3!");
public class InvalidExtraSupportDurationException(): ValidationException("Extra support duration must be between 1 or 2 years!");
public class InvalidPaymentRangeException(): ValidationException("Payment range must be between 3 and 30!");
public class PaymentIsDoneAlreadyException(int id): ValidationException($"Payment for contract id {id} is done already!");
public class UsernameAlreadyExistsException(string username) : ValidationException($"Username {username} already exists.");
public class InvalidPassword() : ValidationException("Invalid password!");
