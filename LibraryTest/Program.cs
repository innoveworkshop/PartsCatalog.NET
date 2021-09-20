using System;
using System.Collections.Generic;
using System.Text;
using PartsCatalog.Utilities;
using PartsCatalog.Models;

namespace LibraryTest {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("PartsCatalog Library Test");
			Console.WriteLine();

			// Test URLBuilder.
			Console.WriteLine("URLBuilder");
			URLBuilder url = new URLBuilder("http://blueberry.farm.lan:8080/PartsCatalog",
				"/test");
			url.Parameters.Add("id", 123);
			url.Parameters.Add("testing", "Some Other Thing");
			Console.WriteLine(url.ToString());
			Console.WriteLine();

			// Test SubCategory.
			Console.WriteLine("Sub-Category");
			SubCategory subCategory = new SubCategory(1);
			Console.WriteLine("ID: {0}", subCategory.ID);
			Console.WriteLine("Name: {0}", subCategory.Name);
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}
