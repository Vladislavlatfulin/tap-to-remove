using System;

namespace Services.Input.EventsProvider
{
    public interface IInputEventsProvider
    {
        public void SetPointerDownEventHandler(Action<InputPointer> handler);
        public void SetPointerMoveEventHandler(Action<InputPointer> handler);
        public void SetPointerUpEventHandler(Action<InputPointer> handler);
    }
}