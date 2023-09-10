var verbList;
var verbListIndex;
var verbJson;

var currentConjunction;      // current array of displayed verb's conjugations
var currentConjunctionIndex; // currently displayed conjugation

function InitializeVerbs() {
    verbList = [];
    verbListIndex = 0;

    currentConjunction = [];
    currentConjunctionIndex = 0

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

    //SetConjungations(verbJson);
}

function ShowConjugationPanel(tenseName) {
    var conjunctionPanel = document.getElementById("conjunctionPanel");
    var conjunctionPanelTitleContent = document.getElementById("conjunctionPanelTitle")

    conjunctionPanel.style.display = 'block';
    conjunctionPanelTitleContent.innerText = tenseName;

    SetConjungations(this.verbJson);
}

function HideConjugationPanel(event) {
    event.stopPropagation();

    var conjunctionPanel = document.getElementById("conjunctionPanel");
    conjunctionPanel.style.display = 'none';
    clearConjugationList();
}

function clearConjugationList() {
    var yo = document.getElementById("yo").innerText = '';
    var tu = document.getElementById("tu").innerText = '';
    var elellausted = document.getElementById("elellausted").innerText = '';
    var nosotros = document.getElementById("nosotros").innerText = '';
    var vosotros = document.getElementById("vosotros").innerText = '';
    var ellosellasustedes = document.getElementById("ellosellasustedes").innerText = '';
    document.getElementById("EndOfList").innerText = '';
}

function SetConjungations(verbJson) {
    var currentConjungationContent = document.getElementById("currentConjungation")

    if (verbJson != null && verbJson != 'undefined')
    {
        clearConjugationList();

        this.currentConjunctionIndex = 0;
        this.currentConjunction =
        [
            verbJson.Indicative.PresentTense.Yo,
            verbJson.Indicative.PresentTense.Tu,
            verbJson.Indicative.PresentTense.ElEllaUsted,
            verbJson.Indicative.PresentTense.Nosotros,
            verbJson.Indicative.PresentTense.Vosotros,
            verbJson.Indicative.PresentTense.EllosEllasUstedes
        ];

        var yo = document.getElementById("yo")
        yo.innerText = 'yo - ?';
    }
}

// TODO - add method to prevent showConjugation() from firing when conjungation box is closed
function showConjugation()
{
    if (this.currentConjunctionIndex == 0)
    {
        var yo = document.getElementById("yo")
        var tu = document.getElementById("tu")

        yo.innerText = 'yo - ' + currentConjunction[0];
        tu.innerText = 'tu - ?';

        currentConjunctionIndex++;
    }
    else if (this.currentConjunctionIndex == 1)
    {
        var tu = document.getElementById("tu")
        var elellausted = document.getElementById("elellausted")

        tu.innerText = 'tu - ' + currentConjunction[1];
        elellausted.innerText = 'el/ella/usted - ?';

        currentConjunctionIndex++;
    }
    else if (this.currentConjunctionIndex == 2)
    {
        var elellausted = document.getElementById("elellausted")
        var nosotros = document.getElementById("nosotros")

        elellausted.innerText = 'el/ella/usted - ' + currentConjunction[2];
        nosotros.innerText = 'nosotros - ?';

        currentConjunctionIndex++;
    }
    else if (this.currentConjunctionIndex == 3)
    {
        var nosotros = document.getElementById("nosotros")
        var vosotros = document.getElementById("vosotros")

        nosotros.innerText = 'nosotros - ' + currentConjunction[3];
        vosotros.innerText = 'vosotros - ?';

        currentConjunctionIndex++;
    }
    else if (this.currentConjunctionIndex == 4)
    {
        var vosotros = document.getElementById("vosotros")
        var ellosellasustedes = document.getElementById("ellosellasustedes")

        vosotros.innerText = 'vosotros - ' + currentConjunction[4];
        ellosellasustedes.innerText = 'ellos/ellas/ustedes - ?';

        currentConjunctionIndex++;
    }
    else if (this.currentConjunctionIndex == 5)
    {
        var ellosellasustedes = document.getElementById("ellosellasustedes")
        ellosellasustedes.innerText = 'ellos/ellas/ustedes - ' + currentConjunction[5];

        currentConjunctionIndex++;
    }
    else
    {
        var ellosellasustedes = document.getElementById("EndOfList")
        ellosellasustedes.innerText = 'No More Conjungations';
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
    clearConjugationList();
}