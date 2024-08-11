namespace StateDesignPattern
{
    internal sealed class StateComponent
    {
        private IState _state = default;

        internal StateComponent(IState state) => _state = state;

        internal StateComponent(in int likes,
                                in int dislikes,
                                IState state) : this(state) => (Likes, Dislikes) = (likes, dislikes);

        internal int Likes { get; set; }
        internal int Dislikes { get; set; }

        internal StateComponent ChangeState(IState state)
        {
            _state = state;
            return this;
        }

        internal StateComponent DoLike()
        {
            _state.DoLike(this);
            return this;
        }
        internal StateComponent DoDislike()
        {
            _state.DoDislike(this);
            return this;
        }
    }
}
