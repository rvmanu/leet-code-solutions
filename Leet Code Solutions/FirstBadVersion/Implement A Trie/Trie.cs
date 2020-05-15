using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Implement_A_Trie
{
    public class Trie
    {
        private class TrieNode
        {
            public char Value { get; set; }
            public TrieNode[] Children { get; set; }
            public bool isEnd { get; set; }

            public TrieNode(char Value)
            {
                this.Value = Value;
                this.Children = new TrieNode[26];
            }
        }

        TrieNode trie;
        /** Initialize your data structure here. */
        public Trie()
        {
            trie = new TrieNode('#');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var node = trie;
            foreach (var c in word)
            {
                if (node.Children[c - 'a'] == null)
                {
                    node.Children[c - 'a'] = new TrieNode(c);
                }

                node = node.Children[c - 'a'];
            }

            node.isEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = trie;
            foreach (var c in word)
            {
                node = node.Children[c - 'a'];
                if (node == null)
                    return false;
            }

            return node.isEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = trie;
            foreach (var c in prefix)
            {
                node = node.Children[c - 'a'];
                if (node == null)
                    return false;
            }

            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
