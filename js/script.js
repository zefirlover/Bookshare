const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  if (document.body.classList.contains('darkTheme')) {
    document.body.classList.replace('darkTheme', 'lightTheme');
    document.getElementById("userLogo").src = "img/userIconLT.svg";
    document.getElementById("searchIcon").src = "img/searchIconLT.svg";
    document.getElementById("filterIcon").src = "img/filterIconLT.svg";
    document.getElementById("githubIcon").src = "img/githubIconLT.svg";
    // linkedinIcon1 == linkedinIcon2
    document.getElementById("linkedinIcon1").src = "img/linkedinIconLT.svg";
    document.getElementById("linkedinIcon2").src = "img/linkedinIconLT.svg";
  } else {
    document.body.classList.replace('lightTheme', 'darkTheme');
    document.getElementById("userLogo").src = "img/userIconDT.svg";
    document.getElementById("searchIcon").src = "img/searchIconDT.svg";
    document.getElementById("filterIcon").src = "img/filterIconDT.svg";
    document.getElementById("githubIcon").src = "img/githubIconDT.svg";
    document.getElementById("linkedinIcon1").src = "img/linkedinIconDT.svg";
    document.getElementById("linkedinIcon2").src = "img/linkedinIconDT.svg";
  }
});

function openFilterForm() {
  isDisplayBlock = document.getElementById("filterForm").style.display;

  if(isDisplayBlock=="block"){
    document.getElementById("filterForm").style.display = "none";
  } else {
    document.getElementById("filterForm").style.display = "block";
  }
}