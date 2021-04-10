using AutoMapper;
using JqueryDataTables.LoopsIT;
using MuslimFashion.Data;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;

namespace MuslimFashion.BusinessLogic
{
    public class OrderCore : Core, IOrderCore
    {
        public OrderCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<int> PleaseOrder(OrderAddModel model)
        {
            try
            {
                model.OrderDate = DateTime.Now.BdTime().Date;
                return model.OrderLists.Count < 1 ? new DbResponse<int>(false, "No item added") : _db.Order.PleaseOrder(model);
            }
            catch (Exception e)
            {
                return new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<int> PleaseOrder(OrderAddModel model, string customerUserName)
        {
            try
            {
                model.CustomerId = _db.Registration.CustomerIdByUserName(customerUserName);

                return model.CustomerId == 0 ? new DbResponse<int>(false, "Invalid User") : this.PleaseOrder(model);
            }
            catch (Exception e)
            {
                return new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DataResult<OrderListViewModel> Records(DataRequest request)
        {

            return _db.Order.Records(request);
        }

        public DataResult<OrderListViewModel> CustomerWiseRecords(DataRequest request, string customerUserName)
        {
            var customerId = _db.Registration.CustomerIdByUserName(customerUserName);
            return _db.Order.CustomerWiseRecords(request, customerId);
        }

        public DataResult<OrderListViewModel> StatusWiseRecords(DataRequest request, OrderStatus status)
        {
            return _db.Order.StatusWiseRecords(request, status);
        }

        public DbResponse<OrderReceiptViewModel> OrderReceipt(int orderId)
        {
            try
            {
                if (_db.Order.IsNull(orderId))
                    return new DbResponse<OrderReceiptViewModel>(false, "No Data Found");

                var data = _db.Order.OrderReceipt(orderId);
                return new DbResponse<OrderReceiptViewModel>(true, $"Order No: {data.OrderNo} Found", data);
            }
            catch (Exception e)
            {
                return new DbResponse<OrderReceiptViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Delete(int orderId)
        {
            try
            {
                if (_db.Order.IsNull(orderId))
                    return new DbResponse(false, "No Data Found");


                return _db.Order.Delete(orderId);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Confirmed(int orderId, decimal discount)
        {
            try
            {
                if (_db.Order.IsNull(orderId))
                    return new DbResponse(false, "No Data Found");


                return _db.Order.Confirmed(orderId, discount);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Delivered(int orderId)
        {
            try
            {
                if (_db.Order.IsNull(orderId))
                    return new DbResponse(false, "No Data Found");


                return _db.Order.Delivered(orderId);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }
    }
}