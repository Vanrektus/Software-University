namespace FakeAxeAndDummy.Contracts
{
    public interface IWeapon
    {
        //---------------------------Properties---------------------------
        int AttackPoints { get; }
        int DurabilityPoints { get; }

        //---------------------------Methods---------------------------
        void Attack(ITarget target);
    }
}
