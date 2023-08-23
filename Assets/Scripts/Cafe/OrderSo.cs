using System;
using UnityEngine;

namespace Cafe
{
    [CreateAssetMenu(fileName = "Order", menuName = "Order")]
    public class OrderSo : ScriptableObject
    {
        [SerializeField] private string dishName;
        public string DishName => dishName;
    }

    [Serializable]
    public class Order
    {
        public Order(string dishName)
        {
            _dishName = dishName;
        }

        private string _dishName;
        private bool _riceWashed;
        private bool _fishFried;
        private bool _fishCut;
        private bool _sushiRolled;
        private bool _bentoCompleted;

        public bool RiceWashed => _riceWashed;
        public bool FishFried => _fishFried;
        public bool FishCut => _fishCut;
        public bool SushiRolled => _sushiRolled;
        public bool BentoCompleted => _bentoCompleted;

        public void WashRice() => _riceWashed = true;
        public void FryFish() => _fishFried = true;
        public void CutFish() => _fishCut = true;
        public void RollSushi() => _sushiRolled = true;
        public void CompleteBento() => _bentoCompleted = true;
    }
}