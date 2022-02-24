namespace StateDesignPattern
{
    internal sealed class StateComponent : IState
    {
        private (ILike like, IDislike dislike) _state = default;

        internal StateComponent((ILike, IDislike) state) => _state = state;

        internal StateComponent(in int likes, in int dislikes, (ILike, IDislike) state) : this(state) =>
            (Likes, Dislikes) = (likes, dislikes);

        internal int Likes { get; set; }
        internal int Dislikes { get; set; }

        internal StateComponent ChangeState((ILike, IDislike) state)
        {
            _state = state;
            return this;
        }

        internal IState DoLike() => _state.like.DoLike(this);
        internal IState DoDislike() => _state.dislike.DoDislike(this);
    }
}
