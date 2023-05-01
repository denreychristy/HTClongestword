/*
* LongestWord
* Write a function to find the longest compound word in a list that is made up of other words in that same list.
* Solve with a custom built data structure, no 3rd party libraries.
*
* Example {mouse, state, road, cat, catch, building, catcher, chase, dog, when, dogcatcher, tunnel} = dogcatcher
*
* public String solve(String[] words};
*
* The ideal time complexity for a solution is O(n)
*/

internal class Program
{
	private static void Main(string[] args)
	{
		// Get user's word list
		Console.Write("Enter the word list here: ");
		String userInput = Console.ReadLine() + "";
		String userInputTrimmed = String.Concat(userInput.Where(c => !Char.IsWhiteSpace(c)));
		String[] words = userInputTrimmed.Split(',');

		String longestWord = solve(words);
		Console.WriteLine("The longest compound word in the list is: " + longestWord);
		Console.ReadLine();
	}

	public static String solve(String[] words)
	{
		// Sort words array by word length
		Array.Sort(words, (x, y) => y.Length.CompareTo(x.Length));

		// Create Trie Data Structure
		Trie wordTrie = new Trie();
		foreach (var word in words)
		{
			wordTrie.insert(word);
		}

		// Find longest compound word
		for (int i = 0; i < words.Length; i++)
		{
			int lengthOfWord = words[i].Length;
			for (int ii = 1; ii < lengthOfWord; ii++)
			{
				String substring1 = words[i].Substring(0, ii);
				String substring2 = words[i].Substring(ii);
				if (wordTrie.search(substring1) && wordTrie.search(substring2))
				{
					return words[i];
				}
			}
		}

		return "";
	}
}