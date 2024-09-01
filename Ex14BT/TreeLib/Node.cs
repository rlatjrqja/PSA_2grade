namespace TreeLib
{
    public class Node
    {
        public char Value {  get; private set; }
        public Node? LeftLink { get; private set; }
        public Node? RightLink { get; private set; }

        public Node(char data)
        {
            Value = data;
            LeftLink = null;
            RightLink = null;
        }

        public void UpdateLeftLink(Node node) { LeftLink = node; }
        public void UpdateRightLink(Node node) {  RightLink = node; }
        public void RemoveLeftLink() { LeftLink = null;}
        public void RemoveRightLink() { RightLink = null;}
    }
}