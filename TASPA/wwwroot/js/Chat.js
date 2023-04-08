function SendChatMessage() {
    let chatConversationTextArea = document.getElementById("chatConversationTextArea");
    let chatMessageBox = document.getElementById("chatMessage");
    let optionSentimentAnalysis = document.getElementById("optionSentimentAnalysis");
    let chatMessage = chatMessageBox.value;

    if (optionSentimentAnalysis.checked) {
        ServerCalls.SendChatMessage(chatMessage, chatConversationTextArea, true);
    } else {
        ServerCalls.SendChatMessage(chatMessage, chatConversationTextArea, false);
    }    
}

function SetDisplay() {
    let optionSentimentAnalysis = document.getElementById("optionSentimentAnalysis");
    let sentimentAnalsysDisplay = document.getElementById("sentimentAnalsysDisplay");

    if (optionSentimentAnalysis.checked) {
        sentimentAnalsysDisplay.classList.add('expanded');
        sentimentAnalsysDisplay.classList.remove('collasped');
    } else {
        sentimentAnalsysDisplay.classList.add('collasped');
        sentimentAnalsysDisplay.classList.remove('expanded');
    }  
}

function ToggleChatOptions()
{
    let chatOptionsDisplay = document.getElementById("chatOptions");
    let chatOptionsButton = document.getElementById("btnChatOptions");

    if (chatOptionsDisplay.className === 'collasped') {
        chatOptionsDisplay.classList.add('expanded');
        chatOptionsDisplay.classList.remove('collasped');

        chatOptionsButton.innerText = 'Hide Options';
    } else {
        chatOptionsDisplay.classList.add('collasped');
        chatOptionsDisplay.classList.remove('expanded');

        chatOptionsButton.innerText = 'Show Options';
    }
}

function ClearChatSession() {
    let chatConversationTextArea = document.getElementById("chatConversationTextArea");
    let chatMessageBox = document.getElementById("chatMessage");

    chatMessageBox.value = '';
    chatConversationTextArea.value = '';

    ServerCalls.ClearChatSession();
}

function ClearChatAnalsysCssClasses() {
    let conversationRankingLabel = document.getElementById("conversationRanking");
    conversationRankingLabel.innerText = '';
    conversationRankingLabel.classList.remove('chatAnalysisColorPositive');
    conversationRankingLabel.classList.remove('chatAnalysisColorNegative');
    conversationRankingLabel.classList.remove('chatAnalysisColorNeutral');

    let messageRankingLabel = document.getElementById("messageRanking");
    messageRankingLabel.innerText = '';
    messageRankingLabel.classList.remove('chatAnalysisColorPositive');
    messageRankingLabel.classList.remove('chatAnalysisColorNegative');
    messageRankingLabel.classList.remove('chatAnalysisColorNeutral');
}

function SetAnalysisResults(controlId, result) {
    let rankingLabel = document.getElementById(controlId);
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