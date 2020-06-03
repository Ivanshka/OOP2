namespace Laba_13
{
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Owner Owner { get; set; }

        public override string ToString() => ID.ToString();
    }
}