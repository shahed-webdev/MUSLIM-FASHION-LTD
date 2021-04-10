﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.LoopsIT;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Linq;
using Order = MuslimFashion.Data.Order;

namespace MuslimFashion.Repository
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public DbResponse<int> PleaseOrder(OrderAddModel model)
        {
            var order = _mapper.Map<Order>(model);
            order.OrderNo = this.GetNewOrderNo();
            Db.Order.Add(order);
            Db.SaveChanges();
            var orderId = order.OrderId;

            return new DbResponse<int>(true, $"{order.OrderNo} Order Please Successfully", orderId);
        }

        public int GetNewOrderNo()
        {
            return !Db.Order.Any() ? 10001 : Db.Order.Max(o => o.OrderNo) + 1;
        }

        public DataResult<OrderListViewModel> Records(DataRequest request)
        {
            return Db.Order
                .ProjectTo<OrderListViewModel>(_mapper.ConfigurationProvider)
                .ToDataResult(request);
        }

        public DataResult<OrderListViewModel> CustomerWiseRecords(DataRequest request, int customerId)
        {
            return Db.Order
                .Where(o => o.CustomerId == customerId)
                .ProjectTo<OrderListViewModel>(_mapper.ConfigurationProvider)
                .ToDataResult(request);
        }

        public OrderReceiptViewModel OrderReceipt(int orderId)
        {
            return Db.Order
                .Where(o => o.OrderId == orderId)
                .ProjectTo<OrderReceiptViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public DbResponse Delete(int orderId)
        {
            var order = Db.Order.Find(orderId);
            Db.Order.Remove(order);
            Db.SaveChanges();

            return new DbResponse(true, "Order Rejected Successfully");
        }

        public DbResponse Confirmed(int orderId, decimal discount)
        {
            var order = Db.Order.Find(orderId);
            order.Discount = discount;
            order.OrderStatus = OrderStatus.Confirmed;
            Db.Order.Update(order);
            Db.SaveChanges();

            return new DbResponse(true, "Order Confirmed Successfully");
        }

        public DbResponse Delivered(int orderId)
        {
            var order = Db.Order.Find(orderId);
            order.OrderStatus = OrderStatus.Delivered;
            Db.Order.Update(order);
            Db.SaveChanges();

            return new DbResponse(true, "Order Delivered Successfully");
        }

        public bool IsNull(int id)
        {
            return !Db.Order.Any(r => r.OrderId == id);
        }
    }
}