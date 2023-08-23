using System;

namespace Cafe
{
    public class OrderManager
    {
        public event Action OnOrderCompleted;
        public event Action OnOrderSpoiled;
        private Order _order;

        public Order Order => _order;

        public bool HasOrder() => _order != null;

        public void SetOrder(OrderSo orderSo) => _order = new Order(orderSo.DishName);

        public void CompleteOrder()
        {
            _order = null;
            OnOrderCompleted?.Invoke();
        }

        public void SpoilOrder()
        {
            _order = null;
            OnOrderSpoiled?.Invoke();
        }
    }
}