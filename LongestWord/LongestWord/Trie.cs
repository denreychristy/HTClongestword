class Trie
{
	private Node root;

	public Trie() {
		root = new Node('\0');
	}

	public void insert(String word)
	{
		Node curr = root;
		for (int i = 0; i < word.Length; i++)
		{
			char c = word[i];
			if (curr.children[c - 'a'] == null)
			{
				curr.children[c - 'a'] = new Node(c);
			}
			curr = curr.children[c - 'a'];
		}
		curr.isWord = true;
	}

	public Boolean search(String word)
	{
		Node node = getNode(word);
		return node != null && node.isWord;
	}

	public Boolean startsWith(String prefix)
	{
		return getNode(prefix) != null;
	}

	private Node getNode(String word)
	{
		Node curr = root;
		for (int i = 0; i < word.Length; i++)
		{
			char c = word[i];
			if (curr.children[c - 'a'] == null)
			{
				return null;
			}
			curr = curr.children[c - 'a'];
		}
		return curr;
	}

	class Node {
		public char c;
		public Boolean isWord;
		public Node[] children;

		public Node(char c)
		{
			this.c = c;
			isWord = false;
			children = new Node[26];
		}
	}
}