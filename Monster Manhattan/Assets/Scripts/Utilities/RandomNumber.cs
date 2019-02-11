using System;
using System.Security.Cryptography;
using UnityEngine;

//A singleton for generating random numbers
public class RandomNumber : MonoBehaviour
{
    public static RandomNumber instance;
    private RNGCryptoServiceProvider rngCryptoServiceProvider;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        rngCryptoServiceProvider = new RNGCryptoServiceProvider();
    }

    public int GenerateExclusive(int min, int max)
    {
        //Applying the modulus operator to the random number so that it's within the specified min and max range, returned as an integer
        return (int)((GenerateUInt32() % (max - min)) + min);
    }

    public int GenerateInclusive(int min, int max)
    {
        return (int)((GenerateUInt32() % (max - min + 1)) + min);
    }

    private UInt32 GenerateUInt32()
    {
        byte[] byteArray = new byte[4];
        //Using RNGCryptoServiceProvider to fill the byte array with random numbers
        rngCryptoServiceProvider.GetBytes(byteArray);
        return BitConverter.ToUInt32(byteArray, 0);
    }
}