using AutoMapper;
using JqueryDataTables.LoopsIT;
using Microsoft.EntityFrameworkCore.Internal;
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
                if (!model.OrderLists.Any())
                    return new DbResponse<int>(false, "No item added");

                return _db.Order.PleaseOrder(model);
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

                if (model.CustomerId == 0)
                    return new DbResponse<int>(false, "Invalid User");

                return this.PleaseOrder(model);
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