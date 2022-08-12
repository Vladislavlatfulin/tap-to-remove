using System;
using UnityEngine;

namespace Services.Input.EventsProvider
{
    public abstract class BaseInputEventsProvider : IInputEventsProvider
    {
        private Action<InputPointer> _pointerDownEventHandler;
        private Action<InputPointer> _pointerMoveEventHandler;
        private Action<InputPointer> _pointerUpEventHandler;

        public void SetPointerDownEventHandler(Action<InputPointer> handler) => _pointerDownEventHandler = handler;
        public void SetPointerMoveEventHandler(Action<InputPointer> handler) => _pointerMoveEventHandler = handler;
        public void SetPointerUpEventHandler(Action<InputPointer> handler) => _pointerUpEventHandler = handler;
        
        protected void HandlePointerDown(Vector3 position, int id)
        {
            InputPointer pointer = new InputPointer(position, id: id);
            _pointerDownEventHandler?.Invoke(pointer);
        }

        protected void HandlePointerMove(Vector3 position, Vector3 delta, int id)
        {
            InputPointer pointer = new InputPointer(position, delta, id);
            _pointerMoveEventHandler?.Invoke(pointer);
        }
        
        protected void HandlePointerUp(Vector3 position, int id)
        {
            InputPointer pointer = new InputPointer(position, id: id);
            _pointerUpEventHandler?.Invoke(pointer);
        }
    }
}