function SelectVerbList() {
    var selectedVerbList = document.getElementById("verbListSelectList");
    var selectedValue = selectedVerbList.value;

    ServerCalls.SetVerbList(selectedValue);
}