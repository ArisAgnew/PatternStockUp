using UsefulStuff;

namespace StateDesignPattern.States
{
    internal class DislikedState : IState
    {
        public IState DoDislike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            --stateComponent.Dislikes;
            ++stateComponent.Likes;
            stateComponent.ChangeState(new LikedState());

            return this;
        }

        public IState DoLike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            ++stateComponent.Dislikes;
            stateComponent.ChangeState(new InitialState());

            return this;
        }
    }
}
