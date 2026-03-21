using Codeflix.Models;

namespace Codeflix.DataStructures
{
    public class BSTNode
    {
        public MediaItem Data { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public BSTNode(MediaItem data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}