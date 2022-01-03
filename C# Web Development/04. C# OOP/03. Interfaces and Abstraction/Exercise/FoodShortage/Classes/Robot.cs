namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        //---------------------------Properties---------------------------
        public string Model { get; private set; }
        public string Id { get; private set; }

        //---------------------------Constructors---------------------------
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
