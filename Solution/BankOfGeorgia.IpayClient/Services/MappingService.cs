using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public interface IMappingService
    {
        IpayOrderRequest CreateIpayOrderRequest(OrderRequest orderRequest);
    }

    public class MappingService : IMappingService
    {
        public IpayOrderRequest CreateIpayOrderRequest(OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            return new IpayOrderRequest()
            {
                CaptureMethod = orderRequest.CaptureMethod,
                Intent = orderRequest.Intent,
                Locale = orderRequest.Locale,
                RedirectUrl = orderRequest.RedirectUrl,
                ShopOrderId = orderRequest.ShopOrderId,
                ShowShopOrderIdOnExtract = orderRequest.ShowShopOrderIdOnExtract,
                Items = orderRequest.Items
                    .Select(item => CreateIpayOrderItem(item)),
                PurchaseUnits = CreateIpayOrderRequestPurchaseUnits(orderRequest.Items, orderRequest.Currency)
            };
        }

        private IpayOrderItem CreateIpayOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            return new IpayOrderItem()
            {
                Amount = StringDecimalConversionHelper.ConvertDecimalToString(orderItem.Price),
                Description = orderItem.Description,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }

        private IEnumerable<IpayOrderRequestPurchaseUnit> CreateIpayOrderRequestPurchaseUnits(IEnumerable<OrderItem> orderItems, string currency)
        {
            if (orderItems == null)
            {
                throw new ArgumentNullException(nameof(orderItems));
            }

            if (!orderItems.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(orderItems), $"{nameof(orderItems)} is empty");

            }

            decimal sum = orderItems.Sum(i => i.Quantity * i.Price);

            var purchaseUnit = new IpayOrderRequestPurchaseUnit();
            purchaseUnit.Amount = new OrderRequestPurchaseUnitAmount();
            purchaseUnit.Amount.Value = StringDecimalConversionHelper.ConvertDecimalToString(sum);
            purchaseUnit.Amount.Currency = currency;

            return new IpayOrderRequestPurchaseUnit[] { purchaseUnit };
        }
    }
}
