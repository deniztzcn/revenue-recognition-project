using RevenueRecognition.Exceptions;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class ContractService: IContractService
{
    private readonly IContractRepository _contractRepository;
    private readonly ISoftwareLicenseRepository _softwareLicenseRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IPaymentRepository _paymentRepository;

    public ContractService(IPaymentRepository paymentRepository,IDiscountRepository discountRepository,IClientRepository clientRepository,IContractRepository contractRepository,ISoftwareLicenseRepository softwareLicenseRepository)
    {
        _contractRepository = contractRepository;
        _softwareLicenseRepository = softwareLicenseRepository;
        _clientRepository = clientRepository;
        _discountRepository = discountRepository;
        _paymentRepository = paymentRepository;

    }

    public async Task<int> CreateContract(CreateContractDto createContractDto)
    {
        if (createContractDto.PaymentDuration < 3 || createContractDto.PaymentDuration > 30)
        {
            throw new InvalidPaymentRangeException();
        }

        if (createContractDto.ContractDuration < 1 || createContractDto.ContractDuration > 3)
        {
            throw new InvalidContractDurationException();
        }

        var extraSupportYear = createContractDto.AdditionalSupport ?? 0;
        
        if (extraSupportYear < 0 || extraSupportYear > 2)
        {
            throw new InvalidExtraSupportDurationException();
        }
        
        var contract = await _contractRepository.GetContractByClientIdAndSoftwareLicenseId(createContractDto.ClientId,
            createContractDto.SoftwareLicenseId) ?? throw new ContractAlreadyExistsException(createContractDto.ClientId,createContractDto.SoftwareLicenseId);

        Client? client = await _clientRepository.GetCompanyClientByIdAsync(createContractDto.ClientId);
        if (client is null)
        {
            client = await _clientRepository.GetIndividualClientByIdAsync(createContractDto.ClientId) 
                     ?? throw new ClientNotFound(createContractDto.ClientId);
        }

        var softwareLicense =
            await _softwareLicenseRepository.GetSoftwareLicenseByIdAsync(createContractDto.SoftwareLicenseId) 
            ?? throw new SoftwareLicenseNotFound(createContractDto.SoftwareLicenseId);

        var isOldClient = await _contractRepository.HasAnyContract(createContractDto.ClientId);

        var discounts = await _discountRepository.GetValidDiscounts();
        var discount = discounts.MaxBy(d => d.DiscountValue);
        var highestDiscount = discount?.DiscountValue ?? 0;
        var totalPrice = 1000F * extraSupportYear +
                         createContractDto.ContractDuration * softwareLicense.Price;
        float discountedPrice;
        if (isOldClient)
        {
            discountedPrice = totalPrice - totalPrice * highestDiscount;
        }
        else
        {
            discountedPrice = totalPrice - totalPrice * (highestDiscount + 0.5F);
        }

        var contractToAdd = new Contract
        {
            ClientId = createContractDto.ClientId,
            SoftwareId = createContractDto.SoftwareLicenseId,
            PaymentStartDate = DateTime.Now,
            PaymentEndDate = DateTime.Now.AddDays(createContractDto.PaymentDuration),
            ContractStartDate = DateTime.Now,
            ContractEndDate = DateTime.Now.AddYears(createContractDto.ContractDuration),
            AdditionalSupportEndDate = DateTime.Now.AddYears(extraSupportYear),
            IsSigned = false,
            Price = discountedPrice
        };
        
        if (discount != null)
        {
            contractToAdd.DiscountId = discount.DiscountId;
        }
        else
        {
            contractToAdd.DiscountId = null;
        }
        return await _contractRepository.AddContractAsync(contractToAdd);
    }

    public async Task<int> AddPaymentContract(int contractId, PaymentContractDto requestDto)
    {
        var contract = await _contractRepository.GetContractByIdAsync(contractId) ?? throw new ContractNotFound(contractId);
        var payments = await _paymentRepository.GetPaymentsByContractId(contractId);
        var totalPayments = payments.Sum(p => p.Amount);
        
        if (contract.PaymentEndDate > DateTime.Now)
        {
            throw new PaymentDatePassedException(contract.PaymentEndDate);
        }

        if (contract.IsSigned)
        {
            throw new PaymentIsDoneAlreadyException(contractId);
        }

        if (totalPayments + requestDto.Amount > contract.Price)
        {
            var difference = totalPayments + requestDto.Amount - contract.Price;
            throw new PaymentExceedsTheContractPriceException(difference);
        }
        var payment = new Payment
        {
            ContractId = contractId,
            Amount = requestDto.Amount,
            PaymentDate = DateTime.Now,
            IsFinalPayment = false
        };
        
        if (contract.Price == totalPayments + requestDto.Amount)
        {
            await _contractRepository.SignContract(contract);
            payment.IsFinalPayment = true;
        }
        return await _paymentRepository.AddPaymentAsync(payment);
    }
}