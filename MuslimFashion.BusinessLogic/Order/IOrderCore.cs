using JqueryDataTables.LoopsIT;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;

namespace MuslimFashion.BusinessLogic
{
    public interface IOrderCore
    {
        DbResponse<int> PleaseOrder(OrderAddModel model);
        DbResponse<int> PleaseOrder(OrderAddModel model, string customerUserName);
        DataResult<OrderListViewModel> Records(DataRequest request);
        DataResult<OrderListViewModel> CustomerWiseRecords(DataRequest request, string customerUserName);
        DataResult<OrderListViewModel> StatusWiseRecords(DataRequest request, OrderStatus status);
        DbResponse<OrderReceiptViewModel> OrderReceipt(int orderId);
        DbResponse Delete(int orderId);
        DbResponse Confirmed(int orderId, decimal discount);
        DbResponse Delivered(int orderId);
    }
}