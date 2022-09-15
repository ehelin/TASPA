function SelectVerbList() {
    var selectedVerbList = document.getElementById("verbListSelectList");
    var selectedValue = selectedVerbList.value;

    var results = ServerCalls.GetVerbList(selectedValue);
}