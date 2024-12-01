using CashFlow.Communication.Enum;

namespace CashFlow.Communication.Requests;
public class RequestRegisterexpenseJson
{
    public string Title { get; set; }  = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
    public decimal Amount {  get; set; }

    public PaymentType paymentType { get; set; }

}
