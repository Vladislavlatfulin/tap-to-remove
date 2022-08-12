using UnityEngine;

namespace Services.Input
{
    public readonly struct InputPointer
    {
        public int Id { get; }
        public Vector3 Position { get; }
        public Vector3 Delta { get; }

        public InputPointer(Vector3 position, Vector3 delta = default, int id = default)
        {
            Position = position;
            Delta = delta;
            Id = id;
        }
    }
}