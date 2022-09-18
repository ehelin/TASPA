var verbList;
var verbListIndex;
var verbJson;

function Initialize() {
    verbList = [];
    verbListIndex = 0;

    var verbSubPanelContent = document.getElementById("verbSubPanel");
    verbSubPanelContent.classList.remove('collasped');
    verbSubPanelContent.classList.add('expanded');
}

function SelectVerbList() {
    var selectedVerbList = document.getElementById("verbListSelectList");
    var selectedValue = selectedVerbList.value;

    ServerCalls.GetVerbList(selectedValue);
}

function LoadNext() {
    verbListIndex++;
    var nextVerbName = verbList[verbListIndex];
    if (nextVerbName === undefined || nextVerbName === null) {
        var messageContent = document.getElementById("message");
        messageContent.innerHTML = '';
        messageContent.append('There are no more verbs in this list');
    }
    else {
        ServerCalls.SetVerbJson(nextVerbName);
    }
}

function VerbListNext(verbName, verbJson) {
    ClearVerbPanel();

    var verbNameContent = document.getElementById("verbName");
    verbNameContent.append(verbName);

    var verbValueContent = document.getElementById("verbValue");
    verbValueContent.classList.remove('expanded');
    verbValueContent.classList.add('collasped');
    verbValueContent.append(verbJson.EnglishMeaning);
}

function VerbListShow() {
    var verbValueContent = document.getElementById("verbValue");
    verbValueContent.classList.remove('collasped');
    verbValueContent.classList.add('expanded');
}

function ClearVerbPanel() {
    var verbNameContent = document.getElementById("verbName");
    var verbValueContent = document.getElementById("verbValue");
    var messageContent = document.getElementById("message");
    verbNameContent.innerHTML = '';
    verbValueContent.innerHTML = '';
    messageContent.innerHTML = '';
}