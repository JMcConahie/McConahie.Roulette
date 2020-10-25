namespace McConahie.Roulette.Models
{
    public class Classification
    {
        public string Name { get; set; }
        public int PayoutMultiplier { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Classification o = (Classification)obj;

                return (o.Name == Name) && (o.PayoutMultiplier == PayoutMultiplier);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
