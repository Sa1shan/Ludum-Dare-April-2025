namespace _Source.InteractiableObj
{
    public class CheckActive
    {
        public static CheckActive Instance { get; } = new CheckActive();
        public bool IsActiveHm = false;
        public bool isExit = false;
    }
}