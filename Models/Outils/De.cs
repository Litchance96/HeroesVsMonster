namespace Models.Outils
{
    public class De
    {
       
        public int Max = 5;

        public int Lancer()
        {
            Random random = new Random();
            int result = Random.Shared.Next(Max) + 1;
            return result;
        }
    }
}
