using UnityEngine;

public interface IDirectionMovable
{
    void SwapMove(Vector2 finishPosition);
    Vector2Int SwapDirection { get; set; }
}