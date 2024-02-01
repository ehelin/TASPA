# from transformers import AutoTokenizer, AutoModelForCausalLM

# tokenizer = AutoTokenizer.from_pretrained("meta-llama/Llama-2-70b-chat-hf")
# model = AutoModelForCausalLM.from_pretrained("meta-llama/Llama-2-70b-chat-hf")

#==================================================================================================

# # prompt = "Hey, are you conscious? Can you talk to me?"
# # inputs = tokenizer(prompt, return_tensors="pt")

# # # Generate
# # generate_ids = model.generate(inputs.input_ids, max_length=30)
# # tokenizer.batch_decode(generate_ids, skip_special_tokens=True, clean_up_tokenization_spaces=False)[0]

# =============================================================================================

# from transformers import pipeline

# pipe = pipeline("text-generation", model="meta-llama/Llama-2-70b-chat-hf")

#===============================================================================================
import json

# Load the LLaMA model
with open('llama_2_70b_chat_hf.json', 'r') as f:
    model = json.load(f)

# Define a function to generate responses
def generate_response(input_text):
    input_ids = tokenizer.encode(input_text, return_tensors='pt')
    outputs = model(input_ids)
    response = tokenizer.decode(outputs[0], skip_special_tokens=True)
    return response

# Prompt the user to enter text
print('Enter some text:')
user_text = input()

# Generate a response
response = generate_

