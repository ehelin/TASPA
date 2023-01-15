using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shared.Interfaces;

namespace BLL
{
	/// <summary>
	/// A rudimentary sentence generator to be used in conjunction with the Chat Service implementation.
	/// 
	/// Implementation One.
	/// 
	/// </summary>
	public class SentenceServiceOne : ISentenceService
	{
		private int MAX_COUNTER = 10000;

		private readonly List<string> sentencesAlreadyUsed;		//Track created sentences so no duplicates during one session

		//sentence components
		private readonly List<string> subjects;
		private readonly List<Verb> verbs;
		private readonly List<string> articles;
		private readonly List<string> nouns;

		private readonly Random randomSubject;
		private readonly Random randomVerb;
		private readonly Random randomArticle;
		private readonly Random randomNoun;

		public SentenceServiceOne()
		{
			this.randomSubject = new Random();
			this.randomVerb = new Random();
			this.randomArticle = new Random();
			this.randomNoun = new Random();

			this.sentencesAlreadyUsed = new List<string>();

			this.subjects = new List<string>() { "I", "You", "He", "She", "We", "They", "It" };
			this.verbs = InitializeVerbs();
			this.articles = new List<string> { "a", "this", "that", "the" };
			this.nouns = InitializeNouns();
		}

		private string CreateSentence()
		{
			var subject = this.subjects[randomSubject.Next(0, this.subjects.Count())];
			var verb = this.verbs[randomVerb.Next(0, this.verbs.Count())];
			var article = "";
			var noun = this.nouns[randomNoun.Next(0, this.nouns.Count())];

			//manipulations
			if (subject == "It" && verb.type == VerbType.Have) { verb.name = verb.name.Replace("have", "has"); } 
			if (verb.type == VerbType.Have || verb.type == VerbType.Past) { article = this.articles[randomArticle.Next(0, this.articles.Count())]; }
			if (verb.type == VerbType.Present && (subject == "It" || subject == "He" || subject == "She")) { verb.name = verb.name + "s"; }
			if (verb.type == VerbType.Have && (subject == "It" || subject == "He" || subject == "She")) { verb.name = verb.name.Replace("have", "has"); }
;
			//create sentence
			var sentence = "";
			if (!string.IsNullOrEmpty(article))
			{
				sentence = string.Format("{0} {1} {2} {3}", subject, verb.name.ToLower(), article.ToLower(), noun.ToLower());
			}
			else
			{
				sentence = string.Format("{0} {1} {2}", subject, verb.name.ToLower(), noun.ToLower());
			}

			return sentence;
		}

		public string GenerateSentence()
		{
			var sentence = "";
			var ctr = 0;

			while(ctr < MAX_COUNTER)
			{
				sentence = CreateSentence();

				if (!sentencesAlreadyUsed.Any(x => x == sentence)) { break; }

				ctr++;
			}

			sentencesAlreadyUsed.Add(sentence);

			return sentence;
		}

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

		private List<Verb> InitializeVerbs()
		{
			var list = new List<Verb>();

			//present
			list.Add(new Verb() { name = "have", type = VerbType.Present });
			list.Add(new Verb() { name = "do", type = VerbType.Present });
			list.Add(new Verb() { name = "say", type = VerbType.Present });
			list.Add(new Verb() { name = "go", type = VerbType.Present });
			list.Add(new Verb() { name = "get", type = VerbType.Present });
			list.Add(new Verb() { name = "make", type = VerbType.Present });
			list.Add(new Verb() { name = "know", type = VerbType.Present });
			list.Add(new Verb() { name = "think", type = VerbType.Present });
			list.Add(new Verb() { name = "take", type = VerbType.Present });
			list.Add(new Verb() { name = "see", type = VerbType.Present });
			list.Add(new Verb() { name = "come", type = VerbType.Present });
			list.Add(new Verb() { name = "want", type = VerbType.Present });
			list.Add(new Verb() { name = "look", type = VerbType.Present });
			list.Add(new Verb() { name = "use", type = VerbType.Present });
			list.Add(new Verb() { name = "find", type = VerbType.Present });
			list.Add(new Verb() { name = "give", type = VerbType.Present });
			list.Add(new Verb() { name = "tell", type = VerbType.Present });
			list.Add(new Verb() { name = "work", type = VerbType.Present });
			list.Add(new Verb() { name = "call", type = VerbType.Present });
			list.Add(new Verb() { name = "try", type = VerbType.Present });
			list.Add(new Verb() { name = "ask", type = VerbType.Present });
			list.Add(new Verb() { name = "need", type = VerbType.Present });
			list.Add(new Verb() { name = "feel", type = VerbType.Present });
			list.Add(new Verb() { name = "become", type = VerbType.Present });
			list.Add(new Verb() { name = "leave", type = VerbType.Present });
			list.Add(new Verb() { name = "put", type = VerbType.Present });
			list.Add(new Verb() { name = "mean", type = VerbType.Present });
			list.Add(new Verb() { name = "keep", type = VerbType.Present });
			list.Add(new Verb() { name = "let", type = VerbType.Present });
			list.Add(new Verb() { name = "begin", type = VerbType.Present });
			list.Add(new Verb() { name = "seem", type = VerbType.Present });
			list.Add(new Verb() { name = "help", type = VerbType.Present });
			list.Add(new Verb() { name = "talk", type = VerbType.Present });
			list.Add(new Verb() { name = "turn", type = VerbType.Present });
			list.Add(new Verb() { name = "start", type = VerbType.Present });
			list.Add(new Verb() { name = "show", type = VerbType.Present });
			list.Add(new Verb() { name = "hear", type = VerbType.Present });
			list.Add(new Verb() { name = "play", type = VerbType.Present });
			list.Add(new Verb() { name = "run", type = VerbType.Present });
			list.Add(new Verb() { name = "move", type = VerbType.Present });
			list.Add(new Verb() { name = "like", type = VerbType.Present });
			list.Add(new Verb() { name = "live", type = VerbType.Present });
			list.Add(new Verb() { name = "believe", type = VerbType.Present });
			list.Add(new Verb() { name = "hold", type = VerbType.Present });
			list.Add(new Verb() { name = "bring", type = VerbType.Present });
			list.Add(new Verb() { name = "happen", type = VerbType.Present });
			list.Add(new Verb() { name = "write", type = VerbType.Present });
			list.Add(new Verb() { name = "provide", type = VerbType.Present });
			list.Add(new Verb() { name = "sit", type = VerbType.Present });
			list.Add(new Verb() { name = "stand", type = VerbType.Present });
			list.Add(new Verb() { name = "lose", type = VerbType.Present });
			list.Add(new Verb() { name = "pay", type = VerbType.Present });
			list.Add(new Verb() { name = "meet", type = VerbType.Present });
			list.Add(new Verb() { name = "include", type = VerbType.Present });
			list.Add(new Verb() { name = "continue", type = VerbType.Present });
			list.Add(new Verb() { name = "set", type = VerbType.Present });
			list.Add(new Verb() { name = "learn", type = VerbType.Present });
			list.Add(new Verb() { name = "change", type = VerbType.Present });
			list.Add(new Verb() { name = "lead", type = VerbType.Present });
			list.Add(new Verb() { name = "understand", type = VerbType.Present });
			list.Add(new Verb() { name = "watch", type = VerbType.Present });
			list.Add(new Verb() { name = "follow", type = VerbType.Present });
			list.Add(new Verb() { name = "sp", type = VerbType.Present });
			list.Add(new Verb() { name = "create", type = VerbType.Present });
			list.Add(new Verb() { name = "speak", type = VerbType.Present });
			list.Add(new Verb() { name = "read", type = VerbType.Present });
			list.Add(new Verb() { name = "allow", type = VerbType.Present });
			list.Add(new Verb() { name = "add", type = VerbType.Present });
			list.Add(new Verb() { name = "spend", type = VerbType.Present });
			list.Add(new Verb() { name = "grow", type = VerbType.Present });
			list.Add(new Verb() { name = "open", type = VerbType.Present });
			list.Add(new Verb() { name = "walk", type = VerbType.Present });
			list.Add(new Verb() { name = "win", type = VerbType.Present });
			list.Add(new Verb() { name = "offer", type = VerbType.Present });
			list.Add(new Verb() { name = "remember", type = VerbType.Present });
			list.Add(new Verb() { name = "love", type = VerbType.Present });
			list.Add(new Verb() { name = "consider", type = VerbType.Present });
			list.Add(new Verb() { name = "appear", type = VerbType.Present });
			list.Add(new Verb() { name = "buy", type = VerbType.Present });
			list.Add(new Verb() { name = "wait", type = VerbType.Present });
			list.Add(new Verb() { name = "serve", type = VerbType.Present });
			list.Add(new Verb() { name = "die", type = VerbType.Present });
			list.Add(new Verb() { name = "send", type = VerbType.Present });
			list.Add(new Verb() { name = "expect", type = VerbType.Present });
			list.Add(new Verb() { name = "build", type = VerbType.Present });
			list.Add(new Verb() { name = "stay", type = VerbType.Present });
			list.Add(new Verb() { name = "fall", type = VerbType.Present });
			list.Add(new Verb() { name = "cut", type = VerbType.Present });
			list.Add(new Verb() { name = "reach", type = VerbType.Present });
			list.Add(new Verb() { name = "kill", type = VerbType.Present });
			list.Add(new Verb() { name = "remain", type = VerbType.Present });
			list.Add(new Verb() { name = "suggest", type = VerbType.Present });
			list.Add(new Verb() { name = "raise", type = VerbType.Present });
			list.Add(new Verb() { name = "pass", type = VerbType.Present });
			list.Add(new Verb() { name = "sell", type = VerbType.Present });
			list.Add(new Verb() { name = "require", type = VerbType.Present });
			list.Add(new Verb() { name = "report", type = VerbType.Present });
			list.Add(new Verb() { name = "decide", type = VerbType.Present });
			list.Add(new Verb() { name = "pull", type = VerbType.Present });

			//past
			list.Add(new Verb() { name = "had", type = VerbType.Past });
			list.Add(new Verb() { name = "did", type = VerbType.Past });
			list.Add(new Verb() { name = "said", type = VerbType.Past });
			list.Add(new Verb() { name = "went", type = VerbType.Past });
			list.Add(new Verb() { name = "got", type = VerbType.Past });
			list.Add(new Verb() { name = "made", type = VerbType.Past });
			list.Add(new Verb() { name = "knew", type = VerbType.Past });
			list.Add(new Verb() { name = "thought", type = VerbType.Past });
			list.Add(new Verb() { name = "ok", type = VerbType.Past });
			list.Add(new Verb() { name = "saw", type = VerbType.Past });
			list.Add(new Verb() { name = "came", type = VerbType.Past });
			list.Add(new Verb() { name = "wanted", type = VerbType.Past });
			list.Add(new Verb() { name = "looked", type = VerbType.Past });
			list.Add(new Verb() { name = "used", type = VerbType.Past });
			list.Add(new Verb() { name = "found", type = VerbType.Past });
			list.Add(new Verb() { name = "gave", type = VerbType.Past });
			list.Add(new Verb() { name = "worked", type = VerbType.Past });
			list.Add(new Verb() { name = "called", type = VerbType.Past });
			list.Add(new Verb() { name = "tried", type = VerbType.Past });
			list.Add(new Verb() { name = "asked", type = VerbType.Past });
			list.Add(new Verb() { name = "needed", type = VerbType.Past });
			list.Add(new Verb() { name = "felt", type = VerbType.Past });
			list.Add(new Verb() { name = "became", type = VerbType.Past });
			list.Add(new Verb() { name = "left", type = VerbType.Past });
			list.Add(new Verb() { name = "put", type = VerbType.Past });
			list.Add(new Verb() { name = "meant", type = VerbType.Past });
			list.Add(new Verb() { name = "kept", type = VerbType.Past });
			list.Add(new Verb() { name = "let", type = VerbType.Past });
			list.Add(new Verb() { name = "began", type = VerbType.Past });
			list.Add(new Verb() { name = "seemed", type = VerbType.Past });
			list.Add(new Verb() { name = "helped", type = VerbType.Past });
			list.Add(new Verb() { name = "talked", type = VerbType.Past });
			list.Add(new Verb() { name = "turned", type = VerbType.Past });
			list.Add(new Verb() { name = "started", type = VerbType.Past });
			list.Add(new Verb() { name = "showed", type = VerbType.Past });
			list.Add(new Verb() { name = "heard", type = VerbType.Past });
			list.Add(new Verb() { name = "played", type = VerbType.Past });
			list.Add(new Verb() { name = "ran", type = VerbType.Past });
			list.Add(new Verb() { name = "moved", type = VerbType.Past });
			list.Add(new Verb() { name = "liked", type = VerbType.Past });
			list.Add(new Verb() { name = "lived", type = VerbType.Past });
			list.Add(new Verb() { name = "believed", type = VerbType.Past });
			list.Add(new Verb() { name = "held", type = VerbType.Past });
			list.Add(new Verb() { name = "brought", type = VerbType.Past });
			list.Add(new Verb() { name = "happened", type = VerbType.Past });
			list.Add(new Verb() { name = "wrote", type = VerbType.Past });
			list.Add(new Verb() { name = "provided", type = VerbType.Past });
			list.Add(new Verb() { name = "sat", type = VerbType.Past });
			list.Add(new Verb() { name = "sod", type = VerbType.Past });
			list.Add(new Verb() { name = "lost", type = VerbType.Past });
			list.Add(new Verb() { name = "paid", type = VerbType.Past });
			list.Add(new Verb() { name = "met", type = VerbType.Past });
			list.Add(new Verb() { name = "included", type = VerbType.Past });
			list.Add(new Verb() { name = "continued", type = VerbType.Past });
			list.Add(new Verb() { name = "set", type = VerbType.Past });
			list.Add(new Verb() { name = "learned", type = VerbType.Past });
			list.Add(new Verb() { name = "changed", type = VerbType.Past });
			list.Add(new Verb() { name = "led", type = VerbType.Past });
			list.Add(new Verb() { name = "understood", type = VerbType.Past });
			list.Add(new Verb() { name = "watched", type = VerbType.Past });
			list.Add(new Verb() { name = "followed", type = VerbType.Past });
			list.Add(new Verb() { name = "spped", type = VerbType.Past });
			list.Add(new Verb() { name = "created", type = VerbType.Past });
			list.Add(new Verb() { name = "spoke", type = VerbType.Past });
			list.Add(new Verb() { name = "read", type = VerbType.Past });
			list.Add(new Verb() { name = "allowed", type = VerbType.Past });
			list.Add(new Verb() { name = "added", type = VerbType.Past });
			list.Add(new Verb() { name = "spent", type = VerbType.Past });
			list.Add(new Verb() { name = "grew", type = VerbType.Past });
			list.Add(new Verb() { name = "opened", type = VerbType.Past });
			list.Add(new Verb() { name = "walked", type = VerbType.Past });
			list.Add(new Verb() { name = "won", type = VerbType.Past });
			list.Add(new Verb() { name = "offered", type = VerbType.Past });
			list.Add(new Verb() { name = "remembered", type = VerbType.Past });
			list.Add(new Verb() { name = "loved", type = VerbType.Past });
			list.Add(new Verb() { name = "considered", type = VerbType.Past });
			list.Add(new Verb() { name = "appeared", type = VerbType.Past });
			list.Add(new Verb() { name = "bought", type = VerbType.Past });
			list.Add(new Verb() { name = "waited", type = VerbType.Past });
			list.Add(new Verb() { name = "served", type = VerbType.Past });
			list.Add(new Verb() { name = "died", type = VerbType.Past });
			list.Add(new Verb() { name = "sent", type = VerbType.Past });
			list.Add(new Verb() { name = "expected", type = VerbType.Past });
			list.Add(new Verb() { name = "built", type = VerbType.Past });
			list.Add(new Verb() { name = "stayed", type = VerbType.Past });
			list.Add(new Verb() { name = "fell", type = VerbType.Past });
			list.Add(new Verb() { name = "cut", type = VerbType.Past });
			list.Add(new Verb() { name = "reached", type = VerbType.Past });
			list.Add(new Verb() { name = "killed", type = VerbType.Past });
			list.Add(new Verb() { name = "remained", type = VerbType.Past });
			list.Add(new Verb() { name = "suggested", type = VerbType.Past });
			list.Add(new Verb() { name = "raised", type = VerbType.Past });
			list.Add(new Verb() { name = "passed", type = VerbType.Past });
			list.Add(new Verb() { name = "sold", type = VerbType.Past });
			list.Add(new Verb() { name = "required", type = VerbType.Past });
			list.Add(new Verb() { name = "reported", type = VerbType.Past });
			list.Add(new Verb() { name = "decided", type = VerbType.Past });
			list.Add(new Verb() { name = "pulled", type = VerbType.Past });

			//have x
			list.Add(new Verb() { name = "have had", type = VerbType.Have });
			list.Add(new Verb() { name = "have done", type = VerbType.Have });
			list.Add(new Verb() { name = "have said", type = VerbType.Have });
			list.Add(new Verb() { name = "have went", type = VerbType.Have });
			list.Add(new Verb() { name = "have got", type = VerbType.Have });
			list.Add(new Verb() { name = "have made", type = VerbType.Have });
			list.Add(new Verb() { name = "have knew", type = VerbType.Have });
			list.Add(new Verb() { name = "have thought", type = VerbType.Have });
			list.Add(new Verb() { name = "have ok", type = VerbType.Have });
			list.Add(new Verb() { name = "have saw", type = VerbType.Have });
			list.Add(new Verb() { name = "have come", type = VerbType.Have });
			list.Add(new Verb() { name = "have wanted", type = VerbType.Have });
			list.Add(new Verb() { name = "have looked", type = VerbType.Have });
			list.Add(new Verb() { name = "have used", type = VerbType.Have });
			list.Add(new Verb() { name = "have found", type = VerbType.Have });
			list.Add(new Verb() { name = "have given", type = VerbType.Have });
			list.Add(new Verb() { name = "have worked", type = VerbType.Have });
			list.Add(new Verb() { name = "have called", type = VerbType.Have });
			list.Add(new Verb() { name = "have tried", type = VerbType.Have });
			list.Add(new Verb() { name = "have asked", type = VerbType.Have });
			list.Add(new Verb() { name = "have needed", type = VerbType.Have });
			list.Add(new Verb() { name = "have felt", type = VerbType.Have });
			list.Add(new Verb() { name = "have become", type = VerbType.Have });
			list.Add(new Verb() { name = "have left", type = VerbType.Have });
			list.Add(new Verb() { name = "have put", type = VerbType.Have });
			list.Add(new Verb() { name = "have meant", type = VerbType.Have });
			list.Add(new Verb() { name = "have kept", type = VerbType.Have });
			list.Add(new Verb() { name = "have let", type = VerbType.Have });
			list.Add(new Verb() { name = "have begun", type = VerbType.Have });
			list.Add(new Verb() { name = "have seemed", type = VerbType.Have });
			list.Add(new Verb() { name = "have helped", type = VerbType.Have });
			list.Add(new Verb() { name = "have talked", type = VerbType.Have });
			list.Add(new Verb() { name = "have turned", type = VerbType.Have });
			list.Add(new Verb() { name = "have started", type = VerbType.Have });
			list.Add(new Verb() { name = "have showed", type = VerbType.Have });
			list.Add(new Verb() { name = "have heard", type = VerbType.Have });
			list.Add(new Verb() { name = "have played", type = VerbType.Have });
			list.Add(new Verb() { name = "have run", type = VerbType.Have });
			list.Add(new Verb() { name = "have moved", type = VerbType.Have });
			list.Add(new Verb() { name = "have liked", type = VerbType.Have });
			list.Add(new Verb() { name = "have lived", type = VerbType.Have });
			list.Add(new Verb() { name = "have believed", type = VerbType.Have });
			list.Add(new Verb() { name = "have held", type = VerbType.Have });
			list.Add(new Verb() { name = "have brought", type = VerbType.Have });
			list.Add(new Verb() { name = "have happened", type = VerbType.Have });
			list.Add(new Verb() { name = "have written", type = VerbType.Have });
			list.Add(new Verb() { name = "have provided", type = VerbType.Have });
			list.Add(new Verb() { name = "have sat", type = VerbType.Have });
			list.Add(new Verb() { name = "have lost", type = VerbType.Have });
			list.Add(new Verb() { name = "have paid", type = VerbType.Have });
			list.Add(new Verb() { name = "have met", type = VerbType.Have });
			list.Add(new Verb() { name = "have included", type = VerbType.Have });
			list.Add(new Verb() { name = "have continued", type = VerbType.Have });
			list.Add(new Verb() { name = "have set", type = VerbType.Have });
			list.Add(new Verb() { name = "have learned", type = VerbType.Have });
			list.Add(new Verb() { name = "have changed", type = VerbType.Have });
			list.Add(new Verb() { name = "have led", type = VerbType.Have });
			list.Add(new Verb() { name = "have understood", type = VerbType.Have });
			list.Add(new Verb() { name = "have watched", type = VerbType.Have });
			list.Add(new Verb() { name = "have followed", type = VerbType.Have });
			list.Add(new Verb() { name = "have created", type = VerbType.Have });
			list.Add(new Verb() { name = "have spoken", type = VerbType.Have });
			list.Add(new Verb() { name = "have read", type = VerbType.Have });
			list.Add(new Verb() { name = "have allowed", type = VerbType.Have });
			list.Add(new Verb() { name = "have added", type = VerbType.Have });
			list.Add(new Verb() { name = "have spent", type = VerbType.Have });
			list.Add(new Verb() { name = "have grown", type = VerbType.Have });
			list.Add(new Verb() { name = "have opened", type = VerbType.Have });
			list.Add(new Verb() { name = "have walked", type = VerbType.Have });
			list.Add(new Verb() { name = "have won", type = VerbType.Have });
			list.Add(new Verb() { name = "have offered", type = VerbType.Have });
			list.Add(new Verb() { name = "have remembered", type = VerbType.Have });
			list.Add(new Verb() { name = "have loved", type = VerbType.Have });
			list.Add(new Verb() { name = "have considered", type = VerbType.Have });
			list.Add(new Verb() { name = "have appeared", type = VerbType.Have });
			list.Add(new Verb() { name = "have bought", type = VerbType.Have });
			list.Add(new Verb() { name = "have waited", type = VerbType.Have });
			list.Add(new Verb() { name = "have served", type = VerbType.Have });
			list.Add(new Verb() { name = "have died", type = VerbType.Have });
			list.Add(new Verb() { name = "have sent", type = VerbType.Have });
			list.Add(new Verb() { name = "have expected", type = VerbType.Have });
			list.Add(new Verb() { name = "have built", type = VerbType.Have });
			list.Add(new Verb() { name = "have stayed", type = VerbType.Have });
			list.Add(new Verb() { name = "have fallen", type = VerbType.Have });
			list.Add(new Verb() { name = "have cut", type = VerbType.Have });
			list.Add(new Verb() { name = "have reached", type = VerbType.Have });
			list.Add(new Verb() { name = "have killed", type = VerbType.Have });
			list.Add(new Verb() { name = "have remained", type = VerbType.Have });
			list.Add(new Verb() { name = "have suggested", type = VerbType.Have });
			list.Add(new Verb() { name = "have raised", type = VerbType.Have });
			list.Add(new Verb() { name = "have passed", type = VerbType.Have });
			list.Add(new Verb() { name = "have sold", type = VerbType.Have });
			list.Add(new Verb() { name = "have required", type = VerbType.Have });
			list.Add(new Verb() { name = "have reported", type = VerbType.Have });
			list.Add(new Verb() { name = "have decided", type = VerbType.Have });
			list.Add(new Verb() { name = "have pulled", type = VerbType.Have });

			return list;
		}
	}

	public enum VerbType
	{
		Present,
		Past,
		Have
	}

	public class Verb
	{
		public string name { get; set; }
		public VerbType type { get; set; }
	}
}