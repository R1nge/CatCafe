using UnityEngine;
using UnityEngine.EventSystems;

namespace Cafe.Devices
{
    public class Fish : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        [SerializeField] private Fish[] firstParts, secondParts;
        [SerializeField] private Vector2 startCoordinates, endCoordinates;
        [SerializeField] private bool final;
        private Vector2 _enterPosition, _exitPosition;
        private int _part;

        private void SetPart(int part) => _part = part;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _enterPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (final)
            {
                Debug.LogError("This piece if final", this);
                return;
            }

            _exitPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            Debug.DrawLine(_enterPosition, _exitPosition, Color.black, Mathf.Infinity);
            _enterPosition = transform.InverseTransformPoint(_enterPosition);
            _exitPosition = transform.InverseTransformPoint(_exitPosition);

            var enterDeltaX = Mathf.Abs(Mathf.Abs(_enterPosition.x) - Mathf.Abs(startCoordinates.x));
            var enterDeltaY = Mathf.Abs(Mathf.Abs(_enterPosition.y) - Mathf.Abs(startCoordinates.y));
            var endDeltaX = Mathf.Abs(Mathf.Abs(_exitPosition.x) - Mathf.Abs(endCoordinates.x));
            var endDeltaY = Mathf.Abs(Mathf.Abs(_exitPosition.y) - Mathf.Abs(endCoordinates.y));
            print($"Enter: {_enterPosition}, Exit: {_exitPosition}");
            print(
                $"EnterDeltaX: {enterDeltaX}, EnterDeltaY: {enterDeltaY}, EndDeltaX: {endDeltaX}, EndDeltaY: {endDeltaY}");
            var maxDistance = .1f;
            if (enterDeltaX <= maxDistance && enterDeltaY <= maxDistance && endDeltaX <= maxDistance &&
                endDeltaY <= maxDistance)
            {
                if (_part == 0)
                {
                    for (int i = 0; i < firstParts.Length; i++)
                    {
                        var part = Instantiate(firstParts[i], transform.position + new Vector3(.1f, 0, 0), Quaternion.identity);
                        var partIndex = _part;
                        partIndex++;
                        part.SetPart(partIndex);
                    }
                }

                _part++;
                Destroy(gameObject);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (final)
            {
                transform.position =
                    Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));
            }
        }
    }
}