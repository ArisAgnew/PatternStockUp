using UsefulStuff;

namespace StateDesignPattern.States
{
    internal class LikedState : IState
    {
        public IState DoDislike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            --stateComponent.Likes;
            stateComponent.ChangeState(new InitialState());

            return this;
        }

        public IState DoLike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            --stateComponent.Likes;
            ++stateComponent.Dislikes;
            stateComponent.ChangeState(new DislikedState());

            return this;
        }
    }
}
