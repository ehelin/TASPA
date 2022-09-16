var verbList;
var verbListIndex;

function Initialize() {
    verbList = [];
    verbListIndex = -1;
    ClearVerbPanel();
}

function SelectVerbList() {
    var selectedVerbList = document.getElementById("verbListSelectList");
    var selectedValue = selectedVerbList.value;

    ServerCalls.GetVerbList(selectedValue);
}

function VerbListNext() {
    ClearVerbPanel();

    verbListIndex++;

    var verbSubPanelContent = document.getElementById("verbSubPanelContent");
    verbSubPanelContent.append(verbList[verbListIndex]);
}

function VerbListShow() {
    alert('you click show - add api call that loads verb json files...and add json verb files');
}

function ClearVerbPanel() {
    var verbSubPanelContent = document.getElementById("verbSubPanelContent");
    verbSubPanelContent.innerHTML = '';
}