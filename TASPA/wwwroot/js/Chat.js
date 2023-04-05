function SendChatMessage() {
    var chatConversationTextArea = document.getElementById("chatConversationTextArea");
    var chatMessageBox = document.getElementById("chatMessage");
    var chatMessage = chatMessageBox.value;
    
    ServerCalls.SendChatMessage(chatMessage, chatConversationTextArea, true);
}

function ClearChatSession() {
    var chatConversationTextArea = document.getElementById("chatConversationTextArea");
    var chatMessageBox = document.getElementById("chatMessage");

    chatMessageBox.value = '';
    chatConversationTextArea.value = '';

    ServerCalls.ClearChatSession();
}

function ClearChatAnalsysCssClasses() {
    var conversationRankingLabel = document.getElementById("conversationRanking");
    conversationRankingLabel.innerText = '';
    conversationRankingLabel.classList.remove('chatAnalysisColorPositive');
    conversationRankingLabel.classList.remove('chatAnalysisColorNegative');
    conversationRankingLabel.classList.remove('chatAnalysisColorNeutral');

    var messageRankingLabel = document.getElementById("messageRanking");
    messageRankingLabel.innerText = '';
    messageRankingLabel.classList.remove('chatAnalysisColorPositive');
    messageRankingLabel.classList.remove('chatAnalysisColorNegative');
    messageRankingLabel.classList.remove('chatAnalysisColorNeutral');
}

function SetAnalysisResults(controlId, result) {
    var rankingLabel = document.getElementById(controlId);
    rankingLabel.innerText = result;

    if (result === 'Positive') {
        rankingLabel.classList.add('chatAnalysisColorPositive');
    }
    else if (result === 'Negative') {
        rankingLabel.classList.add('chatAnalysisColorNegative');
    }
    else {
        rankingLabel.classList.add('chatAnalysisColorNeutral');
    }
}