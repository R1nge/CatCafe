namespace Cafe
{
    public class OrderManager
    {
        private Order _currentOrder;

        public bool HasOrder() => _currentOrder;

        public void SetOrder(Order order)
        {
            _currentOrder = order;
        }
    }
}