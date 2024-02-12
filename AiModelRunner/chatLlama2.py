# Load model directly
from transformers import AutoTokenizer, AutoModelForCausalLM

tokenizer = AutoTokenizer.from_pretrained("meta-llama/Llama-2-7b-chat-hf")
model = AutoModelForCausalLM.from_pretrained("meta-llama/Llama-2-7b-chat-hf")

test = 1

for step in range(5):
	prompt = "Hey, are you conscious? Can you talk to me?" 

	inputs = tokenizer(prompt, return_tensors="pt") 

	# Generate
	generate_ids = model.generate(inputs.input_ids, max_length=30) 

	result = tokenizer.batch_decode(generate_ids, 
				 skip_special_tokens=True, 
				 clean_up_tokenization_spaces=False)[0]

	print("Llama2: {}".format(tokenizer.batch_decode(generate_ids, 
						  skip_special_tokens=True, 
						  clean_up_tokenization_spaces=False)[0]))