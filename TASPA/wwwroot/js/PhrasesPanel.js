function LoadPhraseLists() {
    ServerCalls.SetPhraseLists();
}

function SelectPhraseList() {
    var selectedPhraseList = document.getElementById("phraseListSelectList");
    var selectedValue = selectedPhraseList.value;

    ServerCalls.SetPhraseList(selectedValue);
}