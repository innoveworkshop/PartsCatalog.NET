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
			URL url = new URL("http://blueberry.farm.lan:8080/PartsCatalog",
				"/test");
			url.Parameters.Add("id", 123);
			url.Parameters.Add("testing", "Some Other Thing");
			Console.WriteLine(url.ToString());
			Console.WriteLine();

			// Test Category.
			Console.WriteLine("Category:");
			Category category = new Category(1);
			Console.WriteLine("ID: " + category.ID);
			Console.WriteLine("Name: " + category.Name);
			Console.WriteLine("Sub-Categories:");
			foreach (SubCategory subCat in category.SubCategories) {
				Console.WriteLine("    - " + subCat.Name);
			}
			Console.WriteLine();

			// Test SubCategory.
			Console.WriteLine("Sub-Category:");
			SubCategory subCategory = new SubCategory(1);
			Console.WriteLine("ID: {0}", subCategory.ID);
			Console.WriteLine("Name: {0}", subCategory.Name);
			Console.WriteLine("Parent: {0}", subCategory.Parent.Name);
			Console.WriteLine();

			// Test Package.
			Console.WriteLine("Package:");
			Package package = new Package(1);
			Console.WriteLine("ID: {0}", package.ID);
			Console.WriteLine("Name: {0}", package.Name);
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}
