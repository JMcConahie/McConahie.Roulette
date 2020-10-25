using System;
using System.Security.Cryptography;

namespace McConahie.Roulette
{
    public class RandomNumberGenerator
    {
        public int GetRandomNumber(int maxNumberExclusive)
        {
            var provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);

            int randomInteger = (int)BitConverter.ToUInt32(byteArray, 0);

            return Math.Abs(randomInteger % maxNumberExclusive);
        }
    }
}
