using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUniteOfWork _uniteOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository repository, 
        IUniteOfWork uniteOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _uniteOfWork = uniteOfWork;
        _mapper = mapper;

    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterexpenseJson request)
    {
        
        Validate(request);
        
        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _uniteOfWork.Commit(); 

        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }


    private void Validate(RequestRegisterexpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
