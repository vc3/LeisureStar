using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LeisureStar.Models
{
	public class Encryption
	{
		public static string Encrypt(string clearText)
		{
			byte[] arrbyte = new byte[clearText.Length];
			SHA256 hash = new SHA256CryptoServiceProvider();
			arrbyte = hash.ComputeHash(Encoding.UTF8.GetBytes(clearText));
			return Convert.ToBase64String(arrbyte);
		}
	}
}