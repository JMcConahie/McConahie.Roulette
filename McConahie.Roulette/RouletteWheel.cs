namespace McConahie.Roulette
{
    public class RouletteWheel
    {
        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
        private NumberStore _numberStore = new NumberStore();

        public int Spin()
        {
            int outcome = _randomNumberGenerator.GetRandomNumber(38);
            _numberStore.AddResult(outcome);

            return outcome;
        }
    }
}
