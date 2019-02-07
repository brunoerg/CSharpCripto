using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso
{
    public class Blockchain
    {
        private List<Block> chain = new List<Block>();
        public const int DIFFICULTY_ADJUSTMENT = 10;
        public const int BLOCK_INTERVAL = 10;

        public Blockchain(Block genesisBlock)
        {
            chain.Add(genesisBlock);
        }

        public Block getLatestBlock()
        {
            return chain[-1];
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public void generateNextBlock(String data)
        {
            var previousBlock = this.getLatestBlock();
            int nextIndex = previousBlock.index + 1;
            String nextTimestamp = GetTimestamp(DateTime.Now);
            String nextPreviousHash = previousBlock.hash;
            Block newBlock = this.findBlock();
        }

        public Block findBlock(int index, string previousHash, int timestamp, string data, int difficulty)
        {
            int nonce = 0;
            while(true)
            {
                string hash = Block.calculateHash(index, previousHash, timestamp, data, difficulty, nonce);
                if (hashMatchesDifficulty(hash, difficulty))
                {
                    Block block = new Block(index, hash, previousHash, timestamp, data, difficulty, nonce);
                    return block;
                }
                nonce++;
            }
        }
        
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public Boolean hashMatchesDifficulty(string hash, int difficulty)
        {
            String hashBinary = StringToBinary(hash);
            String requiredPrefix = new string('0', difficulty);
            return hashBinary.StartsWith(requiredPrefix);
        }

        public int getDifficulty()
        {
            Block latestBlock = getLatestBlock();
            if (latestBlock.index % DIFFICULTY_ADJUSTMENT == 0 && latestBlock.index != 0)
            {
                return getAdjustedDifficulty();
            } else
            {
                return latestBlock.difficulty
            }
        }

        public int getAdjustedDifficulty()
        {
            Block latestBlock = getLatestBlock();
            Block prevAdjustmentBlock = this.chain[chain.Count - DIFFICULTY_ADJUSTMENT];
            int timeExpected = BLOCK_INTERVAL * DIFFICULTY_ADJUSTMENT;
            int timeTaken = Convert.ToInt32(latestBlock.timestamp) - Convert.ToInt32(prevAdjustmentBlock.timestamp);
            if (timeTaken < timeExpected * 2)
            {
                return prevAdjustmentBlock.difficulty + 1;
            } else if (timeTaken > timeExpected * 2)
            {
                return prevAdjustmentBlock.difficulty - 1;
            } else
            {
                return prevAdjustmentBlock.difficulty;
            }
        }
    }
}
