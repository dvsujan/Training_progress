const words = [
  "DWELL",
  "DWELLED",
  "DWELLING",
  "DWINDLE",
  "DWINDLED",
  "DWINDLING",
  "LEWD",
  "NEWEL",
  "WEDDED",
  "WEDDING",
  "WEDGE",
  "WEDGED",
  "WEDGIE",
  "WEDGING",
  "WEED",
  "WEEDED",
  "WEEDING",
  "WEENIE",
  "WELD",
  "WELDED",
  "WELDING",
  "WELL",
  "WELLED",
  "WELLING",
  "WEND",
  "WENDED",
  "WENDING",
  "WIDE",
  "WIDEN",
  "WIDENED",
  "WIDENING",
  "WIELD",
  "WIELDED",
  "WIELDING",
  "WIENIE",
  "WIGGED",
  "WIGGING",
  "WIGGLE",
  "WIGGLED",
  "WIGGLING",
  "WILD",
  "WILDLING",
  "WILE",
  "WILL",
  "WILLED",
  "WILLING",
  "WIND",
  "WINDED",
  "WINDING",
  "WINE",
  "WINED",
  "WING",
  "WINGDING",
  "WINGED",
  "WINGING",
  "WINING",
  "WINNING",
];
var found = [];

const letters = ["N", "L", "G", "E", "I", "D"];
const MandatoryLetter = "W";
var score = 0;

var alphas = Array.from(letters);
alphas.push(MandatoryLetter);

const isPangram = (string) => {
  string = string.toLowerCase();
  return alphas.every((x) => string.includes(x.toLowerCase()));
};

function setMiddleOfHex(hexid, letter) {
  const element = document.getElementById(hexid);
  element.querySelector(".middle").innerHTML = "<p>" + letter + "</p>";
}

function LoadAllHex() {
  const element = document.getElementById("hex-mand");
  element.querySelector(".yellow-middle").innerHTML =
    "<p>" + MandatoryLetter + "</p>";
  for (var i = 0; i < letters.length; i++) {
    setMiddleOfHex("hex-" + (i + 1), letters[i]);
  }
}

function AddToTable(string){ 
    const table = document.getElementById('words') ; 
    const row = document.createElement("tr"); 
    const cell = document.createElement("td"); 
    cell.textContent = string ; 
    row.appendChild(cell); 
    table.append(row); 
}

function checkWord() {
  const inputval = document.getElementById("txt-inp").value;
  var res = 0;
  if (inputval == "") {
    window.alert("input must be valid string");
    return;
  }
  if (words.includes(inputval.toUpperCase())) {
    if (found.includes(inputval.toUpperCase())) {
      window.alert("word already found");
      return;
    }
    document.getElementById("words-cnt").innerHTML = "You have found "+ (found.length+1) +" words"; 
    found.push(inputval.toUpperCase());
    AddToTable(inputval.toUpperCase()); 
    const wordSize = inputval.length;
    const isPan = isPangram(inputval);
    if (isPan) {
      res += 7;
      res += wordSize;
    } else {
      res += wordSize - 3;
    }
    score += res;
    document.getElementById("score").innerHTML = "Score "+ score ; 
  } else {
    window.alert("Not in Words List");
    return;
  }
}
LoadAllHex();
