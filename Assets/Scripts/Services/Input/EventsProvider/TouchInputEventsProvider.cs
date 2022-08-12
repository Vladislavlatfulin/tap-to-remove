using UnityEngine;
using Zenject;
using UnityInput = UnityEngine.Input;

namespace Services.Input.EventsProvider
{
    public class TouchInputEventsProvider : BaseInputEventsProvider, ILateTickable
    {
        public void LateTick()
        {
            if (UnityInput.touchCount == 0)
                return;

            for (int i = 0; i < UnityInput.touchCount; i++)
            {
                Touch touch = UnityInput.GetTouch(i);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        HandlePointerDown(touch.position, touch.fingerId);
                        break;
                    
                    case TouchPhase.Stationary:
                    case TouchPhase.Moved:
                        HandlePointerMove(touch.position, touch.deltaPosition, touch.fingerId);
                        break;
                    
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        HandlePointerUp(touch.position, touch.fingerId);
                        break;
                }
            }
        }
    }
}