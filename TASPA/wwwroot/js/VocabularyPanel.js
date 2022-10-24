function LoadVocabularyLists() {
    ServerCalls.SetVocabularyLists();
}

function SelectVocabularyList() {
    var selectedVocabularyList = document.getElementById("vocabularyListSelectList");
    var selectedValue = selectedVocabularyList.value;

    ServerCalls.SetVocabularyList(selectedValue);
}