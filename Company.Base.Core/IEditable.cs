using System;

namespace Company.Base.Core
{
    public interface IEditable
    {
        long Id { get; }
        bool IsDirty { get; }

        StateEnum State { get; }

        void SetState(StateEnum stateEnum);
    }
}
