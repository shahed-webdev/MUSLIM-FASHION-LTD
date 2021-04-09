﻿using JqueryDataTables.LoopsIT;
using MuslimFashion.ViewModel;

namespace MuslimFashion.Repository
{
    public interface IOrderRepository
    {
        DbResponse<int> PleaseOrder(OrderAddModel model);
        int GetNewOrderNo();
        DataResult<OrderListViewModel> Records(DataRequest request);
        OrderReceiptViewModel OrderReceipt(int orderId);
        DbResponse Delete(int orderId);
        DbResponse Confirmed(int orderId, decimal discount);
        DbResponse Delivered(int orderId);
        bool IsNull(int id);

    }
}