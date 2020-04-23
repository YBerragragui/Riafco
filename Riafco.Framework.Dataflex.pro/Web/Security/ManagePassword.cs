using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Riafco.Framework.Dataflex.pro.Web.Security
{
    /// <summary>
    /// the ManagePassword class.
    /// </summary>
    public static class ManagePassword
    {
        /// <summary>
        /// Crype password
        /// </summary>
        /// <param name="password">the password to crypte</param>
        /// <returns></returns>
        public static string HashPasword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            //get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach (byte pass in result)
            {
                strBuilder.Append(pass.ToString("x2"));
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// Generate Password
        /// </summary>
        /// <param name="lenght"></param>
        /// <param name="nbrOfNonAlphabitic"></param>
        /// <returns></returns>
        public static string GeneratePassword(int lenght, int nbrOfNonAlphabitic = 0)
        {
            return Membership.GeneratePassword(lenght, nbrOfNonAlphabitic);
        }

        /// <summary>
        /// generate hashed password.
        /// </summary>
        /// <returns>the password hashed.</returns>
        public static string GenerateHashedPassword(int lenght, int nbrOfNonAlphabitic = 0)
        {
            string stringPassword = Membership.GeneratePassword(lenght, nbrOfNonAlphabitic);
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(stringPassword));

            //get hash result after compute it
            byte[] bytePassword = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach (byte pass in bytePassword)
            {
                strBuilder.Append(pass.ToString("x2"));
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// compare two password
        /// </summary>
        /// <param name="passwordOne">the first password</param>
        /// <param name="passwordTwo">the secend password</param>
        /// <returns>true if the the two password is the same</returns>
        public static bool ComparePassword(string passwordOne, string passwordTwo)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytePasswordOne = md5.ComputeHash(Encoding.ASCII.GetBytes(passwordOne));
            byte[] bytePasswordTwo = md5.ComputeHash(Encoding.ASCII.GetBytes(passwordOne));
            return bytePasswordOne.Equals(bytePasswordTwo);
        }
    }
}
