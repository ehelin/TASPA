function LoadVocabularyLists() {
    var vocabularyFolder = 'bodyparts';
    var listName = 'TheBody'; // TODO - make dynamic (default)
    //ServerCalls.SetVocabularyLists();
    VocabularyPanelSetVocabularyList(vocabularyFolder, listName);
}

function SelectVocabularyList() {
    var selectedVocabularyList = document.getElementById("vocabularyListSelectList");
    var selectedValue = selectedVocabularyList.value;

    ServerCalls.SetVocabularyList(selectedValue);
}

function VocabularyPanelSetVocabularyList(vocabularyFolder, listName) {
    ServerCalls.SetVocabularyList(vocabularyFolder, listName);
}