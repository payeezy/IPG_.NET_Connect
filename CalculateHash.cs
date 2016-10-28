using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

/// <summary>
/// Contains functions required to calculate Hash form string
/// </summary>
public static class CalculateHash
{
    private static String DEFAULT_ALGORITHM = "SHA1";

    private static String SHA256 = "SHA256";

    private static ReadOnlyCollection<String> SUPPORTED_ALGORITHMS = new ReadOnlyCollection<String>(new List<String> { DEFAULT_ALGORITHM, SHA256 });

    /// <summary>
    /// Calculates hash (hash algorithm SHA1 or SHA256) from string
    /// </summary>
    /// <param name="stringValue">string to create hash from</param>
    /// <returns>hashed value of sent string</returns>
    public static String calculateHashFromString(StringBuilder stringValue, String hashAlgorithmName)
    {
        if (!SUPPORTED_ALGORITHMS.Contains(hashAlgorithmName) && hashAlgorithmName.Length > 0)
        {
            throw new System.ArgumentOutOfRangeException("hashAlgorithmName", hashAlgorithmName, "Algorithm '" + hashAlgorithmName + "' not supported");
        }
        HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName.Length == 0 ? DEFAULT_ALGORITHM : hashAlgorithmName);

        StringBuilder sb = new StringBuilder();

        byte[] stringValueBytes = Encoding.ASCII.GetBytes(stringValue.ToString());

        int stringValueBytesLength = stringValueBytes.Length;

        for (int i = 0; i < stringValueBytesLength; i++)
        {
            sb.Append(forDigit((stringValueBytes[i] & 240) >> 4, 16));
            sb.Append(forDigit((stringValueBytes[i] & 15), 16));
        }

        stringValueBytes = Encoding.ASCII.GetBytes((new StringBuilder(sb.ToString()).ToString()));

        hashAlgorithm.TransformFinalBlock(stringValueBytes, 0, stringValueBytes.Length);
        byte[] hash = hashAlgorithm.Hash;
        int hashLength = hash.Length;

        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Determines the character representation for a specific number (digit)
    /// </summary>
    /// <param name="digit"></param>
    /// <param name="radix"></param>
    /// <returns></returns>
    private static char forDigit(int digit, int radix)
    {
        int MIN_RADIX = 2, MAX_RADIX = 36;
        if ((digit >= radix) || (digit < 0))
        {
            return '\0';
        }
        if ((radix < MIN_RADIX) || (radix > MAX_RADIX))
        {
            return '\0';
        }
        if (digit < 10)
        {
            return (char)('0' + digit);
        }
        return (char)('a' - 10 + digit);
    }
}