public class Cylinder : Product
{
    public GameEvent Event;
    private void OnEnable()
    {
        Event.Raise();
    }
}