using System;
using Services.Input.EventsProvider;
using Zenject;

namespace Services.Input
{
    public class InputService : IInputService
    {
        private Action<InputPointer> _onPointerDown;
        private Action<InputPointer> _onPointerMove;
        private Action<InputPointer> _onPointerUp;

        [Inject]
        public InputService(IInputEventsProvider eventsProvider)
        {
            eventsProvider.SetPointerDownEventHandler(HandlePointerDownEvent);
            eventsProvider.SetPointerMoveEventHandler(HandlePointerMoveEvent);
            eventsProvider.SetPointerUpEventHandler(HandlePointerUpEvent);
        }

        public void AddPointerDownListener(Action<InputPointer> listener) => _onPointerDown += listener;

        public void RemovePointerDownListener(Action<InputPointer> listener) => _onPointerDown -= listener;

        public void AddPointerMoveListener(Action<InputPointer> listener) => _onPointerMove += listener;

        public void RemovePointerMoveListener(Action<InputPointer> listener) => _onPointerMove += listener;

        public void AddPointerUpListener(Action<InputPointer> listener) => _onPointerUp += listener; 

        public void RemovePointerUpListener(Action<InputPointer> listener) => _onPointerUp += listener;
        
        private void HandlePointerDownEvent(InputPointer pointer) => _onPointerDown?.Invoke(pointer);
        private void HandlePointerMoveEvent(InputPointer pointer) => _onPointerMove?.Invoke(pointer);
        private void HandlePointerUpEvent(InputPointer pointer) => _onPointerUp?.Invoke(pointer);
    }
}