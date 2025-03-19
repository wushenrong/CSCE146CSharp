namespace Labs.Lab08;

public class OrderScheduler {
  private readonly MinHeap<Order> _orders;
  private Order? _currentOrder;
  private int _currentMinute;
  private int _totalOrders;
  private int _totalWaitingTime;

  public OrderScheduler() {
    _orders = new();
    _currentOrder = null;
    _currentMinute = 0;
    _totalOrders = 0;
    _totalWaitingTime = 0;
  }

  public Order? GetCurrentOrder() => _currentOrder;

  public void AddOrder(Order data) {
    _totalOrders++;

    if (_currentOrder is null) {
      _currentOrder = data;
      return;
    }

    _orders.Add(data);
  }

  public void AdvanceOneMinute() {
    _currentMinute++;
    if (_currentOrder is not null) {
      _currentOrder.CookForOneMinute();

      if (_currentOrder.IsDone()) {
        _totalWaitingTime += _currentMinute - _currentOrder.ArrivalTime;
        _currentOrder = _orders.Remove();
      }
    }
  }

  public bool IsDone() => _currentOrder is null;

  public double GetAverageWaitingTime() {
    return (double)_totalWaitingTime / _totalOrders;
  }
}
