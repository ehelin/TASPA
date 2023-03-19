function LoadVocabularyLists(searchTerm, searchVocabularyFolder) {
    var vocabularyFolder = 'bodyparts'; // default
    //var listName = 'bodyparts';           // default

    if (searchVocabularyFolder != null && searchVocabularyFolder != undefined && searchVocabularyFolder.length > 0)
    {
        vocabularyFolder = searchVocabularyFolder;
    }
    //if (searchTerm != null && searchTerm != undefined && searchTerm.length > 0)
    //{
    //    listName = searchTerm;
    //}

    VocabularyPanelSetVocabularyList(vocabularyFolder, searchTerm);
}

function SelectVocabularyList() {
    var selectedVocabularyList = document.getElementById("vocabularyListSelectList");
    var selectedValue = selectedVocabularyList.value;

    ServerCalls.SetVocabularyList(selectedValue);
}

function VocabularyPanelSetVocabularyList(vocabularyFolder, searchTerm) {
    ServerCalls.SetVocabularyList(vocabularyFolder, searchTerm);
}

function SetLastVocabularyListUsed(lastVocabularyListUsed) {
    var lastVerbListUsedLabel = document.getElementById('lastVocabularyListUsed');
    lastVerbListUsedLabel.innerHTML = lastVocabularyListUsed;
}