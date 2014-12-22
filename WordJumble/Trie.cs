using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordJumble
{
    public class Trie
    {
        private Node Root { get; set; }
        public Trie(string wordFile)
        {
            Root = new Node();
            BuildTrie(wordFile);
        }

        public List<string> GetWords(string text) {
            return TraverseTrie(text, Root).Distinct().OrderBy(w => w).ThenBy(w => w.Length).ToList();
        }

        private List<string> TraverseTrie(string text, Node root) {
            var words = new List<string>();
            for(var i = 0; i < text.Length; i++) {
                var curLetter = text[i].ToString();
                if (root.Edges.ContainsKey(curLetter)) {
                    if (root.Edges[curLetter].IsValid) {
                        words.Add(root.Edges[curLetter].Word);
                    }
                    words.AddRange(TraverseTrie(text.Remove(i, 1), root.Edges[curLetter]));
                }
            }
            return words;
        }

        private void BuildTrie(string wordFile) {
            System.IO.StreamReader file = new StreamReader(wordFile);
            string line;
            while((line = file.ReadLine()) != null) {
                Node curNode = Root;
                line = line.ToLower().Replace("[a-z]+", "");
                for (var i = 0; i < line.Length; i++) {
                    var curLetter = line[i].ToString();
                    if (!curNode.Edges.ContainsKey(curLetter)) {
                        var newNode = new Node();
                        newNode.Word = line.Substring(0, i+1);
                        curNode.Edges.Add(curLetter, newNode);
                    }
                    curNode = curNode.Edges[curLetter];
                }
                curNode.IsValid = true;
            }
            file.Close();
        }
    }
}
