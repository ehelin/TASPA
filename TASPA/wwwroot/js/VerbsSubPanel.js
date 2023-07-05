var verbList;
var verbListIndex;
var verbJson;

function InitializeVerbs() {
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

function LoadNextVerb() {
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

function LanguageToDisplayIsSpanish() {
    var cbLanguage = document.getElementById("cbLanguage");
    if (cbLanguage !== undefined && cbLanguage !== null && cbLanguage.checked === true) {
        return true;
    }
    else {
        return false;
    }
}

function VerbListNext(verbName, verbJson) {
    ClearVerbPanel();

    var verbNameContent = document.getElementById("verbName");
    var verbValueContent = document.getElementById("verbValue");

    verbValueContent.classList.remove('expanded');
    verbValueContent.classList.add('collasped');

    var displaySpanish = LanguageToDisplayIsSpanish();
    if (displaySpanish === true) {
        verbNameContent.append(verbName);
        verbValueContent.append(verbJson.EnglishMeaning);
    }
    else {
        verbNameContent.append(verbJson.EnglishMeaning);
        verbValueContent.append(verbName);
    }

    SetConjungations(verbJson);
}

function SetConjungations(verbJson) {
    var conjunctionLabelContent = document.getElementById("conjunctionLabel")
    var currentConjungationContent = document.getElementById("currentConjungation")

    if (verbJson != null && verbJson != 'undefined') {
        conjunctionLabelContent.innerText = 'Present Tense'
        currentConjungationContent.innerText =verbJson.Indicative.PresentTense.Yo + ', '
            + verbJson.Indicative.PresentTense.Tu + ', '
            + verbJson.Indicative.PresentTense.ElEllaUsted + ', '
            + verbJson.Indicative.PresentTense.Nosotros + ', '
            + verbJson.Indicative.PresentTense.Vosotros + ', '
            + verbJson.Indicative.PresentTense.EllosEllasUstedes;
    }
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