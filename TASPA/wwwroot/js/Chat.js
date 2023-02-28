function SendChatMessage() {
    var chatConversationTextArea = document.getElementById("chatConversationTextArea");
    var chatMessageBox = document.getElementById("chatMessage");
    var chatMessage = chatMessageBox.value;
    
    ServerCalls.SendChatMessage(chatMessage, chatConversationTextArea);
}

function ClearChatSession() {
    var chatConversationTextArea = document.getElementById("chatConversationTextArea");
    var chatMessageBox = document.getElementById("chatMessage");

    chatMessageBox.value = '';
    chatConversationTextArea.value = '';

    ServerCalls.ClearChatSession();
}