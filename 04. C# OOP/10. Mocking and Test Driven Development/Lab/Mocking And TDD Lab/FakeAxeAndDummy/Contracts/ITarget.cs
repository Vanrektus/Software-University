namespace FakeAxeAndDummy.Contracts
{
    public interface ITarget
    {
        //---------------------------Properties---------------------------
        int Health { get; }

        //---------------------------Methods---------------------------
        void TakeAttack(int attackPoints);

        int GiveExperience();

        bool IsDead();
    }
}
