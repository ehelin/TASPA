var vocabularyList;
var vocabularyListIndex;
var vocabularyJson;

function InitializeVocabulary() {
    vocabularyList = [];
    vocabularyListIndex = 0;

    var vocabularySubPanelContent = document.getElementById("vocabularySubPanel");
    vocabularySubPanelContent.classList.remove('collasped');
    vocabularySubPanelContent.classList.add('expanded');
}

function SelectVocabularyList() {
    var selectedVocabularyList = document.getElementById("vocabularyListSelectList");
    var selectedValue = selectedVocabularyList.value;

    ServerCalls.GetVocabularyList(selectedValue);
}

function LoadNextVocabulary() {
    vocabularyListIndex++;
    var nextVocabularyName = vocabularyList[vocabularyListIndex];
    if (nextVocabularyName === undefined || nextVocabularyName === null) {
        var messageContent = document.getElementById("message");
        messageContent.innerHTML = '';
        messageContent.append('There are no more vocabulary in this list');
    }
    else {
        ServerCalls.SetVocabularyJson(nextVocabularyName);
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

function VocabularyListNext(vocabularyName, vocabularyJson) {
    ClearVocabularyPanel();

    var vocabularyNameContent = document.getElementById("vocabularyName");
    var vocabularyValueContent = document.getElementById("vocabularyValue");

    vocabularyValueContent.classList.remove('expanded');
    vocabularyValueContent.classList.add('collasped');

    var displaySpanish = LanguageToDisplayIsSpanish();
    if (displaySpanish === true) {
        vocabularyNameContent.append(vocabularyJson.Name);
        vocabularyValueContent.append(vocabularyJson.EnglishMeaning);
    }
    else {
        vocabularyNameContent.append(vocabularyJson.EnglishMeaning);
        vocabularyValueContent.append(vocabularyJson.Name);
    }
}

function VocabularyListShow() {
    var vocabularyValueContent = document.getElementById("vocabularyValue");
    vocabularyValueContent.classList.remove('collasped');
    vocabularyValueContent.classList.add('expanded');
}

function ClearVocabularyPanel() {
    var vocabularyNameContent = document.getElementById("vocabularyName");
    var vocabularyValueContent = document.getElementById("vocabularyValue");
    var messageContent = document.getElementById("message");
    vocabularyNameContent.innerHTML = '';
    vocabularyValueContent.innerHTML = '';
    messageContent.innerHTML = '';
}