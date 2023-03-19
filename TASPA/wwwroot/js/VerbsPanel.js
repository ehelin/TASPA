function LoadVerbLists(searchTerm, searchVerbList) {
    ServerCalls.SetVerbLists(searchTerm, searchVerbList);
}

function SelectVerbList() {
    var selectedVerbList = document.getElementById("verbListSelectList");
    var selectedValue = selectedVerbList.value;

    ServerCalls.SetVerbList(selectedValue);
}

function SetLastVerbListUsed(lastVerbListUsed) {
    var lastVerbListUsedLabel = document.getElementById('lastVerbListUsed');
    lastVerbListUsedLabel.innerHTML = lastVerbListUsed;
}