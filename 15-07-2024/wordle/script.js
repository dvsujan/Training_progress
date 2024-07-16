var row = 0;
var col = 0;
var validWords = [];
var guessWord = "";

function LoadText() {
  fetch("valid-wordle-words.txt")
    .then((res) => res.text())
    .then((text) => {
      validWords = text.split("\n");
      guessWord= validWords[Math.floor(Math.random() * validWords.length)];
    })
    .catch((e) => {
      console.error(e);
      alert("Error loading words");
      return;
    });

}

function initializeGrid() {
  const grid = document.getElementById("grid");
  for (let i = 0; i < 6; i++) {
    for (let j = 0; j < 5; j++) {
      const cell = document.createElement("div");
      cell.id = `cell-${i}-${j}`;
      cell.className = "cell";
      grid.appendChild(cell);
    }
  }
}

function getWord(row) {
  let word = "";
  for (let i = 0; i < 5; i++) {
    const cell = document.getElementById(`cell-${row}-${i}`);
    if (cell.textContent === "") {
      alert("Please fill all the cells in the row");
      return null;
    }
    word += cell.textContent;
  }
  if (!validWords.includes(word.toLowerCase())) {
    alert("Invalid word");
    return null;
  }
  return word;
}

function checkWord(word, row) {
  const result = [0, 0, 0, 0, 0];
  const wordArray = word.split("");
  const guessWordArray = guessWord.split("");
  for (let i = 0; i < 5; i++) {
    if (wordArray[i] === guessWordArray[i]) {
      result[i] = 2;
      wordArray[i] = null;
      guessWordArray[i] = null;
    }
  }
  for (let i = 0; i < 5; i++) {
    if (wordArray[i] === null) {
      continue;
    }
    const index = guessWordArray.indexOf(wordArray[i]);
    if (index !== -1) {
      result[i] = 1;
      guessWordArray[index] = null;
    }
  }
  return result;
}


function updateGrid(word, result, row) {
  for (let i = 0; i < 5; i++) {
    const cell = document.getElementById(`cell-${row}-${i}`);
    if (result[i] === 2) {
      cell.classList.add("correct");
    } else if (result[i] === 1) {
      cell.classList.add("present");
    } else {
      cell.classList.add("absent");
    }
  }
  if (word.toLowerCase() === guessWord) {
    alert("Congratulations! You won!");
    location.reload();
  }
  
}

document.addEventListener("keydown", function (event) {
  if (event.key === "Enter") {
    const word = getWord(row);
    if (word === null) {
      return;
    }
    const result = checkWord(word.toLowerCase(), row);
    updateGrid(word, result, row);
    row++;
    col = 0;
    if (row === 6) {
      alert("Game Over\nWord:"+guessWord);
      location.reload();
    }
    return;
  } else if (event.key === "Backspace") {
    col--;
    if (col < 0) {
      col = 0;
    }
    const cell = document.getElementById(`cell-${row}-${col}`);
    cell.textContent = "";
  }

  if (!col <= 5 || !col < 0) {
    var key = event.key;
    if (key.length === 1 && key.match(/[a-z]/i)) {
      const cell = document.getElementById(`cell-${row}-${col}`);
      cell.textContent = key.toUpperCase();
      col++;
    }
  }
});

LoadText();
initializeGrid();
