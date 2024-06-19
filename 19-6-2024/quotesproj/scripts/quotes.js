const pagefromParams = new URLSearchParams(window.location.search).get("page");
let currentPage = pagefromParams ? parseInt(pagefromParams) : 1;
const quotesPerPage = 5;
const authorfromParams = new URLSearchParams(window.location.search).get("author");
var quthorName = authorfromParams ? authorfromParams : "";
var allQuotes = [];

const getAllQuotes = async () => {
    const response = await fetch(`https://dummyjson.com/quotes`);
    const data = await response.json();
    allQuotes = data.quotes;
}

document.getElementById("search-button").addEventListener("click", () => {
    quthorName = document.getElementById("quote-search-author").value;
    const quotes = allQuotes.filter(quote => quote.author.toLowerCase().includes(quthorName.toLowerCase()));
    displayQuotes(quotes);
});

const getQuotes = async (page) => {
  const response = await fetch(
    `https://dummyjson.com/quotes?skip=${
      page * quotesPerPage
    }&limit=${quotesPerPage}`
  );
  console.log(page);
  const data = await response.json();
  return data.quotes;
};

const displayQuotes = (quotes) => {
    const params = new URLSearchParams(window.location.search);
    if (params.has("sort") && params.has("page")) {
        const sortValue = params.get("sort");
        const pageValue = params.get("page");
        const startIndex = (pageValue - 1) * quotesPerPage;
        const endIndex = startIndex + quotesPerPage;
        quotes = quotes.slice(startIndex, endIndex);
    }
  const quotesContainer = document.getElementById("quotes-container");
  quotesContainer.innerHTML = "";
  console.log(quotes);
  quotes.forEach((quote) => {
    quotesContainer.innerHTML += `
    <div class="quote">
      <h3>"${quote.quote}"</h3>
      <p> - ${quote.author}</p>
      </div>
      `;
  });
  document.getElementById("current-page").innerText = currentPage;
};

document.getElementById("prev-page").addEventListener("click", () => {
  if (currentPage > 1) {
    currentPage--;
    window.history.pushState({}, "", `?page=${currentPage}`);
    window.location.reload();
  }
});

document.getElementById("next-page").addEventListener("click", () => {
  currentPage++;
  window.history.pushState({}, "", `?page=${currentPage}`);
  window.location.reload();
});

document.getElementById("sort-quotes-alpha").addEventListener("change", function() {
  const selectedOption = this.value;
    if(selectedOption === "asc") {
        var ascendingquotes = allQuotes.sort((a, b) => a.author.localeCompare(b.author));
        displayQuotes(ascendingquotes);

    } else if(selectedOption === "desc") {
        var descendingquotes = allQuotes.sort((a, b) => b.author.localeCompare(a.author));
        displayQuotes(descendingquotes);
    }
});



getAllQuotes();
getQuotes(currentPage).then(displayQuotes);
