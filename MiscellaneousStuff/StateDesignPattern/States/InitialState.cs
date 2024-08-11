using static UsefulStuff.ValidationUtils;

namespace StateDesignPattern.States
{
    internal class InitialState : IState
    {
        public IState DoLike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            ++stateComponent.Likes;
            stateComponent.ChangeState(new LikedState());

            return this;
        }

        public IState DoDislike(StateComponent stateComponent)
        {
            stateComponent.ThrowWhenNull();

            ++stateComponent.Dislikes;
            stateComponent.ChangeState(new DislikedState());

            return this;
        }
    }
}
