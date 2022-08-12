using System;
using Services.Input;
using UnityEngine;
using Zenject;

public class SquaresMovementManager : MonoBehaviour
{
    private InputService _inputService;
    private Camera _camera;
    
    [Inject]
    private void Constructor(InputService inputService)
    {
        _inputService = inputService;
    }


    private void Awake()
    {
        _camera = Camera.main;
        _inputService.AddPointerDownListener(HandleOnPointerDown);
    }

    private void OnDisable() => _inputService.RemovePointerDownListener(HandleOnPointerDown);

    private void HandleOnPointerDown(InputPointer inputPointer)
    {
        Ray ray = _camera.ScreenPointToRay(inputPointer.Position);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Single.MaxValue))
        {
            if (hitInfo.collider != null)
            {
                var movable = hitInfo.collider.gameObject.GetComponent<IDirectionMovable>();
                if (movable != null)
                {
                    var swap = movable.SwapDirection;
                    var swapDirection = new Vector2((_camera.aspect * _camera.orthographicSize * swap.x),
                         (_camera.orthographicSize * swap.y) );
                    movable.SwapMove(swapDirection);
                }
            }
        }
    }
}
