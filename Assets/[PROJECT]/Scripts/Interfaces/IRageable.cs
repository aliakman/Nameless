namespace Interfaces
{
    public interface IRageable
    {
        float Rage { get; set; }
        void TakeRage(float _rage);
        void GiveRage();
    }
}