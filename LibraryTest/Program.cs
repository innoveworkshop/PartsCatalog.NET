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

			// Test Property.
			Console.WriteLine("Property:");
			Property property = new Property(10);
			// TODO: Test creation and update.
			Console.WriteLine("ID: {0}", property.ID);
			Console.WriteLine("Name: {0}", property.Name);
			Console.WriteLine("Value: {0}", property.Value);
			Console.WriteLine("Component: {0}", property.Parent);
			Console.WriteLine();

			// Test Component.
			Console.WriteLine("Component:");
			Component component = new Component(2);
			// TODO: Test creation and update.
			Console.WriteLine("ID: {0}", component.ID);
			Console.WriteLine("Name: {0}", component.Name);
			Console.WriteLine("Quantity: {0}", component.Quantity);
			Console.WriteLine("Description: {0}", component.Description);
			Console.WriteLine("Category: {0}", component.Category);
			Console.WriteLine("Sub-Category: {0}", component.SubCategory);
			Console.WriteLine("Package: {0}", component.Package);
			foreach (Property prop in component.Properties) {
				Console.WriteLine("    - " + prop);
			}
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}
