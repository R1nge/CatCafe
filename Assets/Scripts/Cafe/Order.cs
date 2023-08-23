using UnityEngine;

namespace Cafe
{
    [CreateAssetMenu(fileName = "Order", menuName = "Order")]
    public class Order : ScriptableObject
    {
        [SerializeField] private string dishName;
        public string DishName => dishName;
    }
}