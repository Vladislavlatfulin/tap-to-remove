using System;

namespace Services.Input
{
    public interface IInputService
    {
        void AddPointerDownListener(Action<InputPointer> listener);
        void RemovePointerDownListener(Action<InputPointer> listener);

        void AddPointerMoveListener(Action<InputPointer> listener);
        void RemovePointerMoveListener(Action<InputPointer> listener);
        
        void AddPointerUpListener(Action<InputPointer> listener);
        void RemovePointerUpListener(Action<InputPointer> listener);
    }
}