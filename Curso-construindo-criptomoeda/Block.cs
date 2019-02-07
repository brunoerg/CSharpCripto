using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Curso
{
    public class Block
    {
        public int index { get; set; }
        public string hash { get; set; }
        public string previousHash { get; set; }
        public int timestamp { get; set; }
        public string data { get; set; }
        public int difficulty { get; set; }
        public int nonce { get; set; }

        public Block(int index, string hash, string previousHash, int timestamp, string data, int difficulty, int nonce)
        {
            this.index = index;
            this.hash = hash;
            this.previousHash = previousHash;
            this.timestamp = timestamp;
            this.data = data;
            this.difficulty = difficulty;
            this.nonce = nonce;
        }

        public static string calculateHash(int index, string previousHash, int timestamp, string data, int difficulty, int nonce)
        {
            string concat = (index.ToString()) + previousHash + (timestamp.ToString()) + data + (difficulty.ToString()) + (nonce.ToString());
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(concat));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
