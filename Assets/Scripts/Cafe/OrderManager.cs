using System;

namespace Cafe
{
    public class OrderManager
    {
        public event Action OnOrderCompleted;
        private Order _currentOrder;

        public bool HasOrder() => _currentOrder;

        public void SetOrder(Order order)
        {
            _currentOrder = order;
        }

        public void CompleteOrder()
        {
            _currentOrder = null;
            OnOrderCompleted?.Invoke();
        }
    }
}