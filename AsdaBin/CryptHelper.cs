﻿using System.IO;
using System.Linq;

namespace AsdaBin
{
  class CryptHelper
  {
    public enum Version
    {
      asda2EnglishPrivate,
      asda2ArabicPrivate,
      Los_Asda2ArabicOfficial,
      asdaGlobal
    }

    static byte[][] keys = {
      new byte[]{ 0xE8, 0x40, 0xB8, 0xB7, 0x9A, 0x2F, 0x35, 0x63, 0x61, 0xB2, 0xD8, 0xFE, 0xEA, 0x1E, 0xAA, 0x24, 0x65, 0x2E, 0x6D, 0xA1, 0xBE, 0xEB, 0xC5, 0x91, 0x27, 0xE4, 0x7F, 0xE0, 0xF5, 0xD0, 0xF7, 0x58, 0x80, 0x66, 0x25, 0x3E, 0xFA, 0x9B, 0x55, 0x69, 0x3C, 0xC6, 0xDB, 0x75, 0x9F, 0xE1, 0x38, 0x1B, 0x88, 0x9C, 0xE5, 0xAB, 0xF6, 0x4B, 0x3D, 0xD6, 0x79, 0x98, 0x96, 0x62, 0xB3, 0x05, 0xEF, 0x5F, 0x78, 0x1A, 0x5C, 0x77, 0x71, 0xE6, 0x3F, 0x76, 0xF8, 0x6B, 0xA6, 0x28, 0xE9, 0x8F, 0xAC, 0xC1, 0x12, 0xA0, 0x54, 0x81, 0xDE, 0x5A, 0x1F, 0xDD, 0x7B, 0xF1, 0x21, 0x00, 0x0C, 0xBC, 0x90, 0x68, 0xE7, 0x34, 0xF0, 0xDF, 0x09, 0x67, 0x8D, 0x10, 0xCB, 0xC4, 0x32, 0x45, 0xD1, 0x2A, 0x95, 0x8E, 0x7D, 0x0E, 0x39, 0x03, 0x97, 0xCD, 0xFD, 0x7C, 0xCE, 0xA3, 0x7A, 0xB6, 0x02, 0x72, 0xF9, 0xAE, 0x20, 0x30, 0x48, 0xD3, 0x31, 0xEE, 0x60, 0x16, 0x87, 0x11, 0x84, 0x08, 0xDA, 0x43, 0x42, 0x64, 0xD2, 0x74, 0xCC, 0x4C, 0xE2, 0x6C, 0xB5, 0x93, 0x94, 0x86, 0xBF, 0x1C, 0xD5, 0x51, 0xF3, 0x2C, 0x52, 0x0B, 0xA2, 0xE3, 0x01, 0xC7, 0xBA, 0x3B, 0x8A, 0x57, 0x5E, 0xFB, 0x85, 0x06, 0xFC, 0x4F, 0xCA, 0x4E, 0xA9, 0x6F, 0xBB, 0x17, 0xA7, 0x53, 0x59, 0x2D, 0x18, 0x50, 0x82, 0xD7, 0xF4, 0x46, 0x13, 0x22, 0x4D, 0xD4, 0x8C, 0x5D, 0xAD, 0x70, 0x0F, 0xB9, 0xA4, 0xDC, 0x56, 0x26, 0xA8, 0x1D, 0xCF, 0x07, 0x23, 0x15, 0x6A, 0xED, 0x7E, 0x4A, 0x36, 0xAF, 0x29, 0x49, 0x9E, 0x44, 0x99, 0x0A, 0x73, 0x04, 0x83, 0x8B, 0xC0, 0xB1, 0x6E, 0x14, 0x47, 0x33, 0xC3, 0x41, 0xEC, 0xD9, 0xB0, 0xC2, 0xC8, 0xBD, 0x92, 0xF2, 0x37, 0x9D, 0x2B, 0xB4, 0xFF, 0x0D, 0x19, 0xC9, 0xA5, 0x3A, 0x5B, 0x89 },
      new byte[]{ 0xD0, 0x78, 0x80, 0x8F, 0xA2, 0x17, 0x0D, 0x5B, 0x59, 0x8A, 0xE0, 0xC6, 0xD2, 0x26, 0x92, 0x1C, 0x5D, 0x16, 0x55, 0x99, 0x86, 0xD3, 0xFD, 0xA9, 0x1F, 0xDC, 0x47, 0xD8, 0xCD, 0xE8, 0xCF, 0x60, 0xB8, 0x5E, 0x1D, 0x06, 0xC2, 0xA3, 0x6D, 0x51, 0x04, 0xFE, 0xE3, 0x4D, 0xA7, 0xD9, 0x00, 0x23, 0xB0, 0xA4, 0xDD, 0x93, 0xCE, 0x73, 0x05, 0xEE, 0x41, 0xA0, 0xAE, 0x5A, 0x8B, 0x3D, 0xD7, 0x67, 0x40, 0x22, 0x64, 0x4F, 0x49, 0xDE, 0x07, 0x4E, 0xC0, 0x53, 0x9E, 0x10, 0xD1, 0xB7, 0x94, 0xF9, 0x2A, 0x98, 0x6C, 0xB9, 0xE6, 0x62, 0x27, 0xE5, 0x43, 0xC9, 0x19, 0x38, 0x34, 0x84, 0xA8, 0x50, 0xDF, 0x0C, 0xC8, 0xE7, 0x31, 0x5F, 0xB5, 0x28, 0xF3, 0xFC, 0x0A, 0x7D, 0xE9, 0x12, 0xAD, 0xB6, 0x45, 0x36, 0x01, 0x3B, 0xAF, 0xF5, 0xC5, 0x44, 0xF6, 0x9B, 0x42, 0x8E, 0x3A, 0x4A, 0xC1, 0x96, 0x18, 0x08, 0x70, 0xEB, 0x09, 0xD6, 0x58, 0x2E, 0xBF, 0x29, 0xBC, 0x30, 0xE2, 0x7B, 0x7A, 0x5C, 0xEA, 0x4C, 0xF4, 0x74, 0xDA, 0x54, 0x8D, 0xAB, 0xAC, 0xBE, 0x87, 0x24, 0xED, 0x69, 0xCB, 0x14, 0x6A, 0x33, 0x9A, 0xDB, 0x39, 0xFF, 0x82, 0x03, 0xB2, 0x6F, 0x66, 0xC3, 0xBD, 0x3E, 0xC4, 0x77, 0xF2, 0x76, 0x91, 0x57, 0x83, 0x2F, 0x9F, 0x6B, 0x61, 0x15, 0x20, 0x68, 0xBA, 0xEF, 0xCC, 0x7E, 0x2B, 0x1A, 0x75, 0xEC, 0xB4, 0x65, 0x95, 0x48, 0x37, 0x81, 0x9C, 0xE4, 0x6E, 0x1E, 0x90, 0x25, 0xF7, 0x3F, 0x1B, 0x2D, 0x52, 0xD5, 0x46, 0x72, 0x0E, 0x97, 0x11, 0x71, 0xA6, 0x7C, 0xA1, 0x32, 0x4B, 0x3C, 0xBB, 0xB3, 0xF8, 0x89, 0x56, 0x2C, 0x7F, 0x0B, 0xFB, 0x79, 0xD4, 0xE1, 0x88, 0xFA, 0xF0, 0x85, 0xAA, 0xCA, 0x0F, 0xA5, 0x13, 0x8C, 0xC7, 0x35, 0x21, 0xF1, 0x9D, 0x02, 0x63, 0xB1 },
      new byte[]{ 0x3E, 0xC6, 0xC4, 0xFC, 0xA9, 0x31, 0xE7, 0xE5, 0x5E, 0x34, 0x5A, 0xE2, 0x1D, 0xB8, 0xBA, 0xEF, 0x5D, 0x40, 0xA8, 0xE4, 0x6D, 0x27, 0xA1, 0x17, 0xF9, 0x62, 0xEC, 0xC5, 0x56, 0x66, 0x06, 0xDE, 0xA3, 0xE0, 0x1C, 0xAE, 0x4B, 0x85, 0x48, 0xFA, 0xFC, 0x25, 0x15, 0x25, 0x67, 0xF3, 0x0E, 0x9D, 0x63, 0x1A, 0x33, 0x7E, 0xCD, 0x2D, 0xFF, 0x50, 0x10, 0x1E, 0x64, 0x48, 0x83, 0xE4, 0xFE, 0xD9, 0xDA, 0x9C, 0x28, 0xC9, 0x60, 0xF1, 0x7E, 0xF0, 0x20, 0xED, 0xB8, 0x3F, 0x98, 0x78, 0x9F, 0xA2, 0x7B, 0xA8, 0x4A, 0x7C, 0xDC, 0x07, 0xFD, 0x5B, 0xA7, 0x77, 0xAC, 0x73, 0x91, 0xE9, 0xDF, 0xD5, 0x9E, 0xAB, 0xCC, 0x6F, 0xE1, 0x59, 0x4D, 0x96, 0xB4, 0x42, 0x77, 0x0B, 0xAC, 0xC3, 0xFB, 0x08, 0xBF, 0x88, 0x3E, 0x02, 0xA0, 0x5A, 0x49, 0x9B, 0xA5, 0x81, 0x8C, 0x00, 0xF4, 0x30, 0xA6, 0x28, 0xCE, 0xB6, 0x58, 0x10, 0x68, 0x55, 0x01, 0x90, 0x02, 0x97, 0x5E, 0xED, 0xC5, 0x8E, 0x54, 0xE2, 0x4A, 0xF2, 0x6C, 0xB0, 0xEA, 0xCA, 0x12, 0xD5, 0x39, 0x00, 0x3C, 0xA7, 0x3A, 0x86, 0x61, 0xEF, 0x76, 0xB2, 0xCB, 0x2E, 0x41, 0x65, 0x0C, 0xBD, 0xD8, 0xD1, 0x66, 0x0E, 0x80, 0x7D, 0x40, 0xC9, 0x2F, 0xC8, 0x0C, 0xA4, 0x17, 0x9A, 0xD4, 0xAA, 0x24, 0x8D, 0x85, 0x8D, 0x51, 0xD6, 0x95, 0xC0, 0xCB, 0xA4, 0xDB, 0x20, 0xDB, 0x52, 0x89, 0xF6, 0x22, 0x3F, 0x60, 0x75, 0x5F, 0xC7, 0x4F, 0x44, 0x14, 0x3B, 0xF0, 0x98, 0x6B, 0x93, 0xB0, 0xCC, 0xAF, 0x29, 0xC3, 0xB4, 0xC2, 0xCF, 0xF5, 0x8C, 0x05, 0x82, 0x88, 0x90, 0x37, 0x01, 0xC1, 0x92, 0x45, 0xB5, 0x87, 0xD4, 0x09, 0xAE, 0x94, 0x47, 0xD2, 0x26, 0xBE, 0x16, 0x1B, 0x74, 0x79, 0x32, 0x9F, 0x8B, 0x22, 0xD0, 0xBC, 0x4F, 0x6E, 0x0F },
      new byte[]{ 0x62, 0x9A, 0x98, 0xA0, 0xF5, 0x6D, 0xBB, 0xB9, 0x02, 0x68, 0x06, 0xBE, 0x41, 0xE4, 0xE6, 0xB3, 0x01, 0x1C, 0xF4, 0xB8, 0x31, 0x7B, 0xFD, 0x4B, 0xA5, 0x3E, 0xB0, 0x99, 0x0A, 0x3A, 0x5A, 0x82, 0xFF, 0xBC, 0x40, 0xF2, 0x17, 0xD9, 0x14, 0xA6, 0xA0, 0x79, 0x49, 0x79, 0x3B, 0xAF, 0x52, 0xC1, 0x3F, 0x46, 0x6F, 0x22, 0x91, 0x71, 0xA3, 0x0C, 0x4C, 0x42, 0x38, 0x14, 0xDF, 0xB8, 0xA2, 0x85, 0x86, 0xC0, 0x74, 0x95, 0x3C, 0xAD, 0x22, 0xAC, 0x7C, 0xB1, 0xE4, 0x63, 0xC4, 0x24, 0xC3, 0xFE, 0x27, 0xF4, 0x16, 0x20, 0x80, 0x5B, 0xA1, 0x07, 0xFB, 0x2B, 0xF0, 0x2F, 0xCD, 0xB5, 0x83, 0x89, 0xC2, 0xF7, 0x90, 0x33, 0xBD, 0x05, 0x11, 0xCA, 0xE8, 0x1E, 0x2B, 0x57, 0xF0, 0x9F, 0xA7, 0x54, 0xE3, 0xD4, 0x62, 0x5E, 0xFC, 0x06, 0x15, 0xC7, 0xF9, 0xDD, 0xD0, 0x5C, 0xA8, 0x6C, 0xFA, 0x74, 0x92, 0xEA, 0x04, 0x4C, 0x34, 0x09, 0x5D, 0xCC, 0x5E, 0xCB, 0x02, 0xB1, 0x99, 0xD2, 0x08, 0xBE, 0x16, 0xAE, 0x30, 0xEC, 0xB6, 0x96, 0x4E, 0x89, 0x65, 0x5C, 0x60, 0xFB, 0x66, 0xDA, 0x3D, 0xB3, 0x2A, 0xEE, 0x97, 0x72, 0x1D, 0x39, 0x50, 0xE1, 0x84, 0x8D, 0x3A, 0x52, 0xDC, 0x21, 0x1C, 0x95, 0x73, 0x94, 0x50, 0xF8, 0x4B, 0xC6, 0x88, 0xF6, 0x78, 0xD1, 0xD9, 0xD1, 0x0D, 0x8A, 0xC9, 0x9C, 0x97, 0xF8, 0x87, 0x7C, 0x87, 0x0E, 0xD5, 0xAA, 0x7E, 0x63, 0x3C, 0x29, 0x03, 0x9B, 0x13, 0x18, 0x48, 0x67, 0xAC, 0xC4, 0x37, 0xCF, 0xEC, 0x90, 0xF3, 0x75, 0x9F, 0xE8, 0x9E, 0x93, 0xA9, 0xD0, 0x59, 0xDE, 0xD4, 0xCC, 0x6B, 0x5D, 0x9D, 0xCE, 0x19, 0xE9, 0xDB, 0x88, 0x55, 0xF2, 0xC8, 0x1B, 0x8E, 0x7A, 0xE2, 0x4A, 0x47, 0x28, 0x25, 0x6E, 0xC3, 0xD7, 0x7E, 0x8C, 0xE0, 0x13, 0x32, 0x53 }
    };

    static byte[][] headers = {
      new byte[] { 0xF9, 0x95, 0x09, 0x6F, 0xBB },
      new byte[] { 0xC1, 0xAD, 0x36, 0x54, 0x87 },
      new byte[] { 0xE0, 0x8C, 0x7C, 0x56, 0x37 },
      new byte[] { 0xBC, 0xD0, 0x27, 0x02, 0x6B }
    };

    private static byte[] Xor(byte[] bytes, byte[] key)
    {
      for (int i = 0; i < bytes.Length; i++)
      {
        bytes[i] = (byte)(key[(byte)i] ^ bytes[i]);
      }

      return bytes;
    }

    private static byte[] decryptBin(byte[] bytes, Version v)
    {
      return Xor(bytes.Skip(5).ToArray(), keys[(int)v]);
    }

    public static byte[] decryptBin(string fileName, Version v)
    {
      return decryptBin(File.ReadAllBytes(fileName), v);
    }

    private static byte[] encryptBin(byte[] bytes, Version v)
    {
      return headers[(int)v].Concat(Xor(bytes, keys[(int)v])).ToArray();
    }

    public static byte[] encryptBin(string fileName, Version v)
    {
      return encryptBin(File.ReadAllBytes(fileName), v);
    }

    private static byte[] convertBin(byte[] bytes, Version from, Version to)
    {
      if (from == to)
      {
        return bytes;
      }
      else
      {
        byte[] key = new byte[256];

        for (int i = 0; i < key.Length; i++)
        {
          key[i] = (byte)(keys[(int)from][i] ^ keys[(int)to][i]);
        }
        
        return headers[(int)to].Concat(Xor(bytes.Skip(5).ToArray(), key)).ToArray();
      }
    }

    public static byte[] convertBin(string fileName, Version from, Version to)
    {
      return convertBin(File.ReadAllBytes(fileName), from, to);
    }

    public static int detectVersion(byte[] binFile)
    {
      for (int i = 0; i < headers.Length; i++)
      {
        if (binFile.Take(5).SequenceEqual(headers[i]))
        {
          return i;
        }
      }

      return -1;
    }
  }
}