const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  if (document.body.classList.contains('darkTheme')) {
    document.body.classList.replace('darkTheme', 'lightTheme');
    document.getElementById("userLogo").src = "img/userIconLT.svg";
    document.getElementById("searchIcon").src = "img/searchIconLT.svg";
    document.getElementById("filterIcon").src = "img/filterIconLT.svg";
  } else {
    document.body.classList.replace('lightTheme', 'darkTheme');
    document.getElementById("userLogo").src = "img/userIconDT.svg";
    document.getElementById("searchIcon").src = "img/searchIconDT.svg";
    document.getElementById("filterIcon").src = "img/filterIconDT.svg";
  }
});