using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToStringExtension(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportPaymentTypeText.CASH,
            PaymentType.CreditCard => ResourceReportPaymentTypeText.CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportPaymentTypeText.DEBIT_CARD,
            PaymentType.EletronicTransfer => ResourceReportPaymentTypeText.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
