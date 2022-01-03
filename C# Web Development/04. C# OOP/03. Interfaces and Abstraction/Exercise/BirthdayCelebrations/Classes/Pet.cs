namespace BorderControl
{
    public class Pet : IBirthable
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public string Birthdate { get; private set; }

        //---------------------------Constructors---------------------------
        public Pet(string model, string birthdate)
        {
            this.Model = model;
            this.Birthdate = birthdate;
        }
    }
}
