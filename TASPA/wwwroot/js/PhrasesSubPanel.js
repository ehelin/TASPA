var phraseList;
var phraseListIndex;
var phraseJson;

function InitializePhrases() {
    phraseList = [];
    phraseListIndex = 0;

    var phraseSubPanelContent = document.getElementById("phraseSubPanel");
    phraseSubPanelContent.classList.remove('collasped');
    phraseSubPanelContent.classList.add('expanded');
}

function SelectPhraseList() {
    var selectedPhraseList = document.getElementById("phraseListSelectList");
    var selectedValue = selectedPhraseList.value;

    ServerCalls.GetPhraseList(selectedValue);
}

function LoadNextPhrase() {
    phraseListIndex++;
    var nextPhraseName = phraseList[phraseListIndex];
    if (nextPhraseName === undefined || nextPhraseName === null) {
        var messageContent = document.getElementById("message");
        messageContent.innerHTML = '';
        messageContent.append('There are no more phrases in this list');
    }
    else {
        ServerCalls.SetPhraseJson(nextPhraseName);
    }
}

function LanguageToDisplayIsSpanish() {
    var cbLanguage = document.getElementById("cbLanguage");
    if (cbLanguage !== undefined && cbLanguage !== null && cbLanguage.checked === true) {
        return true;
    }
    else {
        return false;
    }
}

function PhraseListNext(phraseName, phraseJson) {
    ClearPhrasePanel();

    var phraseNameContent = document.getElementById("phraseName");
    var phraseValueContent = document.getElementById("phraseValue");

    phraseValueContent.classList.remove('expanded');
    phraseValueContent.classList.add('collasped');

    var displaySpanish = LanguageToDisplayIsSpanish();
    if (displaySpanish === true) {
        phraseNameContent.append(phraseJson.Name);
        phraseValueContent.append(phraseJson.EnglishMeaning);
    }
    else {
        phraseNameContent.append(phraseJson.EnglishMeaning);
        phraseValueContent.append(phraseJson.Name);
    }
}

function PhraseListShow() {
    var phraseValueContent = document.getElementById("phraseValue");
    phraseValueContent.classList.remove('collasped');
    phraseValueContent.classList.add('expanded');
}

function ClearPhrasePanel() {
    var phraseNameContent = document.getElementById("phraseName");
    var phraseValueContent = document.getElementById("phraseValue");
    var messageContent = document.getElementById("message");
    phraseNameContent.innerHTML = '';
    phraseValueContent.innerHTML = '';
    messageContent.innerHTML = '';
}