public interface IState
{
    void FixedTick();
    void Tick();
    void LateTick();
    void OnEnter();
    void OnExit();
}
