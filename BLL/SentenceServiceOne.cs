using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shared.Interfaces;
using Shared.Dto.Sentence;

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
		public int MAX_COUNTER = 10000;
		public int PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE = 10;

		private readonly List<string> sentencesAlreadyUsed;		//Track created sentences so no duplicates during one session

		//sentence components
		private readonly List<string> subjects;
		private readonly List<SentenceVerb> verbs;
		private readonly List<string> articles;
		private readonly List<string> nouns;
		public readonly List<string> pronouns; 

		private readonly Random randomSubject;
		private readonly Random randomVerb;
		private readonly Random randomArticle;
		private readonly Random randomNoun;
		private readonly Random randomPronoun;

		public SentenceServiceOne()
		{
			this.randomSubject = new Random();
			this.randomVerb = new Random();
			this.randomArticle = new Random();
			this.randomNoun = new Random();
			this.randomPronoun = new Random();

			this.sentencesAlreadyUsed = new List<string>();

			this.subjects = new List<string>() { "I", "You", "He", "She", "We", "They", "It" };
			this.verbs = InitializeVerbs();
			this.articles = new List<string> { "a", "this", "that", "the" };
			this.pronouns = new List<string> { "this", "that", "him", "her", "them", "it" }; 
			this.nouns = InitializeNouns();
		}

		public List<string> GetPronouns() { return this.pronouns; }
		public int GetMaxCounter() { return this.MAX_COUNTER; }
		public int GetPronounPreviousSentenceCheckBatchSize() { return this.PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE; }

		public string GenerateSentence()
		{
			var sentence = "";
			var ctr = 0;

			while (ctr < MAX_COUNTER)
			{
				sentence = CreateSentence();

				if (!sentencesAlreadyUsed.Any(x => x == sentence)) { break; }

				ctr++;
			}

			sentencesAlreadyUsed.Add(sentence);

			return sentence;
		}

		// Ideas
		// 1) composite subjects
		// 2) composite verbs
		// 3) composite nouns
		private string CreateSentence()
		{
			var subject = this.subjects[randomSubject.Next(0, this.subjects.Count())];
			var verb = this.verbs[randomVerb.Next(0, this.verbs.Count())];
			var article = "";
			var noun = this.nouns[randomNoun.Next(0, this.nouns.Count())];
			var pronoun = "";

			//=====================================================
			//manipulations
			// TODO - add code to randomize the manipulations
			// TODO - move each manipulation to a separate method
			var manipulationApplied = false;
			ManipulationGetPronoun(verb, out manipulationApplied, out pronoun);
			
			if (!manipulationApplied && subject == "It" && verb.type == VerbType.Have) 
			{ 
				verb.name = verb.name.Replace("have", "has");
				manipulationApplied = true;
			} 
			
			if (!manipulationApplied && verb.type == VerbType.Have || verb.type == VerbType.Past) 
			{ 
				article = this.articles[randomArticle.Next(0, this.articles.Count())];
				manipulationApplied = true;
			}
			
			if (!manipulationApplied && verb.type == VerbType.Present && (subject == "It" || subject == "He" || subject == "She")) 
			{ 
				verb.name = verb.name + "s"; 
			}
			
			if (!manipulationApplied && verb.type == VerbType.Have && (subject == "It" || subject == "He" || subject == "She")) 
			{ 
				verb.name = verb.name.Replace("have", "has");
				manipulationApplied = true;
			}

			var sentence = ConstructSentence(article, pronoun, subject, verb, noun);

			return sentence;
		}

		private string ConstructSentence(string article, string pronoun, string subject, SentenceVerb verb, string noun)
		{
			//create sentence
			var sentence = "";
			if (!string.IsNullOrEmpty(article))
			{
				sentence = string.Format("{0} {1} {2} {3}", subject, verb.name.ToLower(), article.ToLower(), noun.ToLower());
			}
			else if (!string.IsNullOrEmpty(pronoun))
			{
				sentence = string.Format("{0} {1} {2}", subject, verb.name.ToLower(), pronoun.ToLower());
			}
			else
			{
				sentence = string.Format("{0} {1} {2}", subject, verb.name.ToLower(), noun.ToLower());
			}

			return sentence;
		}

		#region Manipulation Methods

		//random pronouns (applied only every PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE intervals)
		private void ManipulationGetPronoun(SentenceVerb verb, out bool manipulationApplied, out string pronoun)
		{
			manipulationApplied = false;
			pronoun = string.Empty;

			if (verb.pronouns)
			{
				if (this.sentencesAlreadyUsed != null && this.sentencesAlreadyUsed.Count() > PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE)
				{
					var pronounUsedInLastFiveSentences = false;
					var lastFiveSentences = this.sentencesAlreadyUsed.TakeLast(PRONOUN_PREVIOUS_SENTENCE_CHECK_BATCH_SIZE);
					foreach (var lastSentence in lastFiveSentences)
					{
						var sentenceAsArray = lastSentence.Split(" ");
						var sentenceLastWord = sentenceAsArray[sentenceAsArray.Length - 1];
						if (this.pronouns.Any(x => x == sentenceLastWord))
						{
							pronounUsedInLastFiveSentences = true;
							break;
						}
					}

					if (!pronounUsedInLastFiveSentences)
					{
						pronoun = this.pronouns[randomPronoun.Next(0, this.pronouns.Count())];
						manipulationApplied = true;
					}
				}
			}
		}

		#endregion

		#region Initialization Methods

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

		private List<SentenceVerb> InitializeVerbs()
		{
			var list = new List<SentenceVerb>();

			//present
			list.Add(new SentenceVerb() { name = "have", type = VerbType.Present, pronouns = true});	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "do", type = VerbType.Present, pronouns = true });      // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "say", type = VerbType.Present });// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "go", type = VerbType.Present });		// there/here/different locations
			list.Add(new SentenceVerb() { name = "get", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "make", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "know", type = VerbType.Present });// this/that about him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "think", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "take", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "see", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "come", type = VerbType.Present });	// nothing
			list.Add(new SentenceVerb() { name = "want", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "look", type = VerbType.Present });	// there/here/different locations
			list.Add(new SentenceVerb() { name = "use", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "find", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "give", type = VerbType.Present });    // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "tell", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "work", type = VerbType.Present });	// there/here/different places
			list.Add(new SentenceVerb() { name = "call", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "try", type = VerbType.Present, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "ask", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "need", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "feel", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "become", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "leave", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "put", type = VerbType.Present, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "mean", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "keep", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "let", type = VerbType.Present, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "begin", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "seem", type = VerbType.Present });	// happy/content/sad/mad<adjective>
			list.Add(new SentenceVerb() { name = "help", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "talk", type = VerbType.Present, pronouns = true });    // to him/her/them/it about a/the <noun>
			list.Add(new SentenceVerb() { name = "turn", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "start", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "show", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "hear", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "play", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "run", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "move", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "like", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "live", type = VerbType.Present });    // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "believe", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "hold", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "bring", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "happen", type = VerbType.Present });	// here/there/different locations
			list.Add(new SentenceVerb() { name = "write", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "provide", type = VerbType.Present, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "sit", type = VerbType.Present });		// here/there/different places
			list.Add(new SentenceVerb() { name = "stand", type = VerbType.Present });	// here/there/different locations
			list.Add(new SentenceVerb() { name = "lose", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "pay", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "meet", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "include", type = VerbType.Present, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "continue", type = VerbType.Present });// this/that/there
			list.Add(new SentenceVerb() { name = "set", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "learn", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "change", type = VerbType.Present, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "lead", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "understand", type = VerbType.Present, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "watch", type = VerbType.Present, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "follow", type = VerbType.Present, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "create", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "speak", type = VerbType.Present, pronouns = true });   // this/that to him/her/them/it about a/the <noun>
			list.Add(new SentenceVerb() { name = "read", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "allow", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "add", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "spend", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "grow", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "open", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "walk", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "win", type = VerbType.Present, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "offer", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "remember", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "love", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "consider", type = VerbType.Present, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "appear", type = VerbType.Present });	// nothing
			list.Add(new SentenceVerb() { name = "buy", type = VerbType.Present });     // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "wait", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "serve", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "send", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "expect", type = VerbType.Present, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "build", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "stay", type = VerbType.Present });	// there/here/different locations
			list.Add(new SentenceVerb() { name = "fall", type = VerbType.Present });	// there/here/different locations
			list.Add(new SentenceVerb() { name = "cut", type = VerbType.Present, pronouns = true });     // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "reach", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "remain", type = VerbType.Present, pronouns = true });	// here/there/different locations
			list.Add(new SentenceVerb() { name = "suggest", type = VerbType.Present, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "raise", type = VerbType.Present, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "pass", type = VerbType.Present, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "sell", type = VerbType.Present });    // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "require", type = VerbType.Present, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "report", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "decide", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "pull", type = VerbType.Present, pronouns = true });	// this/that/him/her/them/it a/the <noun>

			//past
			list.Add(new SentenceVerb() { name = "had", type = VerbType.Past });			// a <noun...drink>
			list.Add(new SentenceVerb() { name = "did", type = VerbType.Past });			// that/this (no noun)
			list.Add(new SentenceVerb() { name = "said", type = VerbType.Past });			// that/this/no/yes (no noun)
			list.Add(new SentenceVerb() { name = "went", type = VerbType.Past });			// away, down (adjective) (no noun)
			list.Add(new SentenceVerb() { name = "got", type = VerbType.Past });			// that/this
			list.Add(new SentenceVerb() { name = "made", type = VerbType.Past });			// that/this
			list.Add(new SentenceVerb() { name = "knew", type = VerbType.Past });			// that/this
			list.Add(new SentenceVerb() { name = "thought", type = VerbType.Past });		// that/this
			list.Add(new SentenceVerb() { name = "saw", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "came", type = VerbType.Past });			// down/home/from <noun>
			list.Add(new SentenceVerb() { name = "wanted", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "looked", type = VerbType.Past });			// down/home/from <noun>
			list.Add(new SentenceVerb() { name = "used", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "found", type = VerbType.Past });			// this/that/ the/a <noun>
			list.Add(new SentenceVerb() { name = "gave", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "worked", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "called", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "tried", type = VerbType.Past, pronouns = true });			// this/that a/the <noun>
			list.Add(new SentenceVerb() { name = "asked", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "needed", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "felt", type = VerbType.Past });			// this/that
			list.Add(new SentenceVerb() { name = "became", type = VerbType.Past });			// this/that a/the <noun>
			list.Add(new SentenceVerb() { name = "left", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun>	
			list.Add(new SentenceVerb() { name = "put", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun> away/down/behind
			list.Add(new SentenceVerb() { name = "meant", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun>
			list.Add(new SentenceVerb() { name = "kept", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun> 
			list.Add(new SentenceVerb() { name = "let", type = VerbType.Past, pronouns = true });			// this/that/him/her/them go/run/walk/fish<appropriate verb>
			list.Add(new SentenceVerb() { name = "began", type = VerbType.Past });			// this/that a/the <noun>	
			list.Add(new SentenceVerb() { name = "seemed", type = VerbType.Past });			// funny/big/small<adjective>
			list.Add(new SentenceVerb() { name = "helped", type = VerbType.Past });			// them/it
			list.Add(new SentenceVerb() { name = "talked", type = VerbType.Past });			// to him/her/them
			list.Add(new SentenceVerb() { name = "turned", type = VerbType.Past });			// around/back/left/right<adjective>
			list.Add(new SentenceVerb() { name = "started", type = VerbType.Past });		// this/that a/the <noun>
			list.Add(new SentenceVerb() { name = "showed", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun> 
			list.Add(new SentenceVerb() { name = "heard", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "played", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun> 
			list.Add(new SentenceVerb() { name = "ran", type = VerbType.Past, pronouns = true });			// this/that/him/her/them to the <noun> 
			list.Add(new SentenceVerb() { name = "moved", type = VerbType.Past, pronouns = true });			// this/that/him/her/them to the <noun> 
			list.Add(new SentenceVerb() { name = "liked", type = VerbType.Past, pronouns = true });			// this/that/him/her/them
			list.Add(new SentenceVerb() { name = "lived", type = VerbType.Past });			// there/here
			list.Add(new SentenceVerb() { name = "believed", type = VerbType.Past, pronouns = true });		// this/that/him/her/them	
			list.Add(new SentenceVerb() { name = "held", type = VerbType.Past, pronouns = true });			// this/that/him/her/them here/there/different places
			list.Add(new SentenceVerb() { name = "brought", type = VerbType.Past, pronouns = true });		// this/that/him/her/them a/the <noun>
			list.Add(new SentenceVerb() { name = "happened", type = VerbType.Past });		// to him/her/them
			list.Add(new SentenceVerb() { name = "wrote", type = VerbType.Past, pronouns = true });			// this/that/it
			list.Add(new SentenceVerb() { name = "provided", type = VerbType.Past, pronouns = true });		// this/that/it a <noun>	
			list.Add(new SentenceVerb() { name = "sat", type = VerbType.Past });			// down/there/different places
			list.Add(new SentenceVerb() { name = "lost", type = VerbType.Past, pronouns = true });			// this/that/him/her/them a/the <noun>
			list.Add(new SentenceVerb() { name = "paid", type = VerbType.Past, pronouns = true });			// this/that/him/her/them 
			list.Add(new SentenceVerb() { name = "met", type = VerbType.Past });			// him/her/them
			list.Add(new SentenceVerb() { name = "included", type = VerbType.Past, pronouns = true });		// this/that/him/her/them a <noun>
			list.Add(new SentenceVerb() { name = "continued", type = VerbType.Past });		// down/there/different places
			list.Add(new SentenceVerb() { name = "set", type = VerbType.Past });			// a/the <noun>
			list.Add(new SentenceVerb() { name = "learned", type = VerbType.Past, pronouns = true });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "changed", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "led", type = VerbType.Past });			// him/her/them a/the <noun>
			list.Add(new SentenceVerb() { name = "understood", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it
			list.Add(new SentenceVerb() { name = "watched", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it
			list.Add(new SentenceVerb() { name = "followed", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "created", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "spoke", type = VerbType.Past });			// this/that/ to him/her/them/it
			list.Add(new SentenceVerb() { name = "read", type = VerbType.Past, pronouns = true });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "allowed", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it
			list.Add(new SentenceVerb() { name = "added", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "spent", type = VerbType.Past });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "grew", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "opened", type = VerbType.Past });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "walked", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "won", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "offered", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "remembered", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "loved", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "considered", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "appeared", type = VerbType.Past });		// nothing
			list.Add(new SentenceVerb() { name = "bought", type = VerbType.Past });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "waited", type = VerbType.Past, pronouns = true });			// for this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "served", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "died", type = VerbType.Past });			// nothing
			list.Add(new SentenceVerb() { name = "sent", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "expected", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "built", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "stayed", type = VerbType.Past });			// there/here/different places
			list.Add(new SentenceVerb() { name = "fell", type = VerbType.Past });			// there/here/in different places
			list.Add(new SentenceVerb() { name = "cut", type = VerbType.Past });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "reached", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "remained", type = VerbType.Past });		// here/there/in different places
			list.Add(new SentenceVerb() { name = "suggested", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "raised", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "passed", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "sold", type = VerbType.Past, pronouns = true });			// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "required", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "reported", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "decided", type = VerbType.Past, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "pulled", type = VerbType.Past, pronouns = true });			// this/that/him/her/them/it a/the <noun>

			//have x
			list.Add(new SentenceVerb() { name = "have had", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have done", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have said", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have gone", type = VerbType.Have });		// there/here/different locations
			list.Add(new SentenceVerb() { name = "have gotten", type = VerbType.Have });	// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have made", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have known", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have thought", type = VerbType.Have });	// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have seen", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have come", type = VerbType.Have });		// there/here/different locations  
			list.Add(new SentenceVerb() { name = "have wanted", type = VerbType.Have });    // this/that/it a/the <noun>	
			list.Add(new SentenceVerb() { name = "have looked", type = VerbType.Have });	// there/here/different locations 
			list.Add(new SentenceVerb() { name = "have used", type = VerbType.Have });		// this/that/it a/the <noun>	
			list.Add(new SentenceVerb() { name = "have found", type = VerbType.Have });		// this/that/it a/the <noun>	
			list.Add(new SentenceVerb() { name = "have given", type = VerbType.Have });		// this/that/it a/the <noun>	
			list.Add(new SentenceVerb() { name = "have worked", type = VerbType.Have });	// there/here/different locations 
			list.Add(new SentenceVerb() { name = "have called", type = VerbType.Have, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have tried", type = VerbType.Have });		// this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have asked", type = VerbType.Have, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have needed", type = VerbType.Have, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have felt", type = VerbType.Have, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have become", type = VerbType.Have, pronouns = true });	// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have left", type = VerbType.Have, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have put", type = VerbType.Have, pronouns = true });		// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have meant", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have kept", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have let", type = VerbType.Have, pronouns = true });       // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have begun", type = VerbType.Have });     // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have seemed", type = VerbType.Have });	// sad/happy/content<adjective>
			list.Add(new SentenceVerb() { name = "have helped", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have talked", type = VerbType.Have });    // to this/that/him/her/them/it
			list.Add(new SentenceVerb() { name = "have turned", type = VerbType.Have });    // to this/that/him/her/them/it
			list.Add(new SentenceVerb() { name = "have started", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have showed", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have heard", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have played", type = VerbType.Have });    // this/that with him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have run", type = VerbType.Have });       // this/that with him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have moved", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have liked", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have lived", type = VerbType.Have });     // this/that as him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have believed", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have held", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have brought", type = VerbType.Have });   // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have happened", type = VerbType.Have });	// nothing
			list.Add(new SentenceVerb() { name = "have written", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have provided", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have sat", type = VerbType.Have });		// there/here/different locations
			list.Add(new SentenceVerb() { name = "have lost", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have paid", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have met", type = VerbType.Have });       // him/her/them/it
			list.Add(new SentenceVerb() { name = "have included", type = VerbType.Have });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have continued", type = VerbType.Have }); // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have set", type = VerbType.Have, pronouns = true });       // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have learned", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have changed", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have led", type = VerbType.Have, pronouns = true });       // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have understood", type = VerbType.Have, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have watched", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have followed", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have created", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have spoken", type = VerbType.Have });    // this/that to him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have read", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have allowed", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have added", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have spent", type = VerbType.Have });     // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have grown", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have opened", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have walked", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have won", type = VerbType.Have });       // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have offered", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have remembered", type = VerbType.Have, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have loved", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have considered", type = VerbType.Have, pronouns = true });// this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have appeared", type = VerbType.Have });	// nothing
			list.Add(new SentenceVerb() { name = "have bought", type = VerbType.Have });    // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have brought", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have waited", type = VerbType.Have });    // for this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have served", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have sent", type = VerbType.Have, pronouns = true });      // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have expected", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have built", type = VerbType.Have, pronouns = true });     // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have stayed", type = VerbType.Have });	// there/here/different locations
			list.Add(new SentenceVerb() { name = "have fallen", type = VerbType.Have });	// down/there/here/different locations
			list.Add(new SentenceVerb() { name = "have cut", type = VerbType.Have });       // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have reached", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have remained", type = VerbType.Have });	//here/there/different locations
			list.Add(new SentenceVerb() { name = "have suggested", type = VerbType.Have, pronouns = true }); // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have raised", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have passed", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have sold", type = VerbType.Have });      // this/that/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have required", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have reported", type = VerbType.Have, pronouns = true });  // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have decided", type = VerbType.Have, pronouns = true });   // this/that/him/her/them/it a/the <noun>
			list.Add(new SentenceVerb() { name = "have pulled", type = VerbType.Have, pronouns = true });    // this/that/him/her/them/it a/the <noun>

			return list;
		}

		#endregion
	}
}