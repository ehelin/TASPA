using System;
using System.Collections.Generic;
using BLL;
using Shared.Interfaces;
using Xunit;

namespace IntegrationTests
{
	[CollectionDefinition("ChatServiceOneTests", DisableParallelization = true)]
	public class SentenceServiceOneTests
	{
		private readonly ISentenceService sentenceService;

		public SentenceServiceOneTests()
		{
			ISentenceService sentenceService = new SentenceServiceOne();
			this.sentenceService = new SentenceServiceOne();
		}

		[Fact]
		public void GenerateSentence()
		{
			var ctr = 1;
			var sentence = "";
			while (ctr < 10000)
			{
				sentence = sentenceService.GenerateSentence();

				System.Diagnostics.Debug.WriteLine(sentence + " --- " + ctr.ToString());

				//System.Threading.Thread.Sleep(10000);

				ctr++;
			}

			// TODO - find something valid to test
			//Assert.True(!string.IsNullOrEmpty(sentence));
		}

		//===================================================
		private List<string> InitializeNouns()
		{
			var list = new List<string>();

			list.Add("Actor");
			list.Add("Advertisement");
			list.Add("Afternoon");
			list.Add("Airport");
			list.Add("Ambulance");
			list.Add("Animal");
			list.Add("Answer");
			list.Add("Apple");
			list.Add("Army");
			list.Add("Australia");
			list.Add("Balloon");
			list.Add("Banana");
			list.Add("Battery");
			list.Add("Beach");
			list.Add("Beard");
			list.Add("Bed");
			list.Add("Belgium");
			list.Add("Boy");
			list.Add("Branch");
			list.Add("Breakfast");
			list.Add("Brother");
			list.Add("Camera");
			list.Add("Candle");
			list.Add("Car");
			list.Add("Caravan");
			list.Add("Carpet");
			list.Add("Cartoon");
			list.Add("China");
			list.Add("Church");
			list.Add("Crayon");
			list.Add("Crowd");
			list.Add("Daughter");
			list.Add("Death");
			list.Add("Denmark");
			list.Add("Diamond");
			list.Add("Dinner");
			list.Add("Disease");
			list.Add("Doctor");
			list.Add("Dog");
			list.Add("Dream");
			list.Add("Dress");
			list.Add("Easter");
			list.Add("Egg");
			list.Add("Eggplant");
			list.Add("Egypt");
			list.Add("Elephant");
			list.Add("Energy");
			list.Add("Engine");
			list.Add("England");
			list.Add("Evening");
			list.Add("Eye");
			list.Add("Family");
			list.Add("Finland");
			list.Add("Fish");
			list.Add("Flag");
			list.Add("Flower");
			list.Add("Football");
			list.Add("Forest");
			list.Add("Fountain");
			list.Add("France");
			list.Add("Furniture");
			list.Add("Garage");
			list.Add("Gold");
			list.Add("Grass");
			list.Add("Greece");
			list.Add("Guitar");
			list.Add("Hair");
			list.Add("Hamburger");
			list.Add("Helicopter");
			list.Add("Helmet");
			list.Add("Holiday");
			list.Add("Honey");
			list.Add("Horse");
			list.Add("Hospital");
			list.Add("House");
			list.Add("Hydrogen");
			list.Add("Ice");
			list.Add("Insect");
			list.Add("Insurance");
			list.Add("Iron");
			list.Add("Island");
			list.Add("Jackal");
			list.Add("Jelly");
			list.Add("Jewellery");
			list.Add("Jordan");
			list.Add("Juice");
			list.Add("Kangaroo");
			list.Add("King");
			list.Add("Kitchen");
			list.Add("Kite");
			list.Add("Knife");
			list.Add("Lamp");
			list.Add("Lawyer");
			list.Add("Leather");
			list.Add("Library");
			list.Add("Lighter");
			list.Add("Lion");
			list.Add("Lizard");
			list.Add("Lock");
			list.Add("London");
			list.Add("Lunch");
			list.Add("Machine");
			list.Add("Magazine");
			list.Add("Magician");
			list.Add("Manchester");
			list.Add("Market");
			list.Add("Match");
			list.Add("Microphone");
			list.Add("Monkey");
			list.Add("Morning");
			list.Add("Motorcycle");
			list.Add("Nail");
			list.Add("Napkin");
			list.Add("Needle");
			list.Add("Nest");
			list.Add("Nigeria");
			list.Add("Night");
			list.Add("Notebook");
			list.Add("Ocean");
			list.Add("Oil");
			list.Add("Orange");
			list.Add("Oxygen");
			list.Add("Oyster");
			list.Add("Ghost");
			list.Add("Painting");
			list.Add("Parrot");
			list.Add("Pencil");
			list.Add("Piano");
			list.Add("Pillow");
			list.Add("Pizza");
			list.Add("Planet");
			list.Add("Plastic");
			list.Add("Portugal");
			list.Add("Potato");
			list.Add("Queen");
			list.Add("Quill");
			list.Add("Rain");
			list.Add("Rainbow");
			list.Add("Raincoat");
			list.Add("Refrigerator");
			list.Add("Restaurant");
			list.Add("River");
			list.Add("Rocket");
			list.Add("Room");
			list.Add("Rose");
			list.Add("Russia");
			list.Add("Sandwich");
			list.Add("School");
			list.Add("Scooter");
			list.Add("Shampoo");
			list.Add("Shoe");
			list.Add("Soccer");
			list.Add("Spoon");
			list.Add("Stone");
			list.Add("Sugar");
			list.Add("Sweden");
			list.Add("Teacher");
			list.Add("Telephone");
			list.Add("Television");
			list.Add("Tent");
			list.Add("Thailand");
			list.Add("Tomato");
			list.Add("Toothbrush");
			list.Add("Traffic");
			list.Add("Train");
			list.Add("Truck");
			list.Add("Uganda");
			list.Add("Umbrella");
			list.Add("Van");
			list.Add("Vase");
			list.Add("Vegetable");
			list.Add("Vulture");
			list.Add("Wall");
			list.Add("Whale");
			list.Add("Window");
			list.Add("Wire");
			list.Add("Xylophone");
			list.Add("Yacht");
			list.Add("Yak");
			list.Add("Zebra");
			list.Add("Zoo");
			list.Add("Garden");
			list.Add("Gas");
			list.Add("Girl");
			list.Add("Glass");

			return list;
		}
	}
}