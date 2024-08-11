namespace StateDesignPattern
{
    internal interface IState
    {
        IState DoLike(StateComponent stateComponent);
        IState DoDislike(StateComponent stateComponent);
    }
}
