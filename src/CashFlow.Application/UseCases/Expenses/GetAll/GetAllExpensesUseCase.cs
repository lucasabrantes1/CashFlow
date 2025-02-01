﻿using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponsesExpensesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponsesExpensesJson
        {
             Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}
